using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Midi;
using Windows.UI.Notifications;

namespace AuralVoice;

/// <summary>
///  Contained in Piano and recieves input from the associated key.
/// </summary>
internal class Note : Piano
{
    private readonly String? _name;
    private readonly PictureBox _associatedKey;
    private readonly byte _midiIndex;
    private readonly bool _isBlack;
    private IMidiMessage? _midiMessage;
    private KeyStatus? _keyStatus;

    /// <summary>
    ///  Handles user input logic for overlapping calls.
    /// </summary>
    private bool _isPlayingNote = false;
    private ActionCaller? _prevCaller;

    internal Note(in String noteName, ref PictureBox keyRef)
    {
        _name = noteName;
        _associatedKey = keyRef;
        _midiIndex = GetMidiIndex();
        _isBlack = _name.Contains('b') ? true : false;
    }

    /// <summary>
    ///  Send a midi signal to start playing this note.
    /// </summary>
    internal void PlayNote()
    {
        if (!_isPlayingNote)
        {
            if (midiDevice != null)
            {
                _midiMessage = new MidiNoteOnMessage(defaultChannel, _midiIndex, maxVelocity);
                midiDevice.SendMessage(_midiMessage);
                _isPlayingNote = true;
                // TODO: remember to re-write this exception when the asynchronous function is fixed.
            } else { throw new NullReferenceException($"{this}.midiDevice = null. \n\n" +
                $"NOTE: It's highly likely that you just opened the application and tried to play a note. " +
                $"This is not your fault, just wait a couple of seconds for all keys to be initialized. " +
                $"If this is the case, click 'Continue' :)."); }
        }
    }

    /// <summary>
    ///  Send a midi signal to stop playing this note.
    /// </summary>
    internal void StopNote()
    {
        if (_isPlayingNote)
        {
            if (midiDevice != null)
            {
                _midiMessage = new MidiNoteOffMessage(defaultChannel, _midiIndex, maxVelocity);
                midiDevice.SendMessage(_midiMessage);
                _isPlayingNote = false;
            } else { throw new NullReferenceException($"{this}.midiDevice = null"); }
        }
    }

    /// <summary>
    ///  Handles output of key/note based on <paramref name="keyAction"/> and <paramref name="actionCaller"/>.
    /// </summary>
    internal void ActionInput(in KeyAction keyAction, in ActionCaller actionCaller = ActionCaller.MOUSE)
    {
        // If input was made via mouse.
        if (actionCaller == ActionCaller.MOUSE)
        {
            // Don't run if the note is already playing and if that call was made via keyboard.
            if (!(_isPlayingNote && _prevCaller == ActionCaller.KEYBOARD))
            {
                MouseInput(keyAction);
                _prevCaller = ActionCaller.MOUSE;
            }
        }

        // If input was made via keyboard.
        if (actionCaller == ActionCaller.KEYBOARD)
        {
            // Don't run if the note is already playing and if that call was made via mouse.
            if (!(_isPlayingNote && _prevCaller == ActionCaller.MOUSE))
            {
                KeyboardInput(keyAction);
                _prevCaller = ActionCaller.KEYBOARD;
            }
        }
    }

    /// <summary>
    ///  Performs audiovisual output of key/note, from mouse input. 
    /// </summary>
    private void MouseInput(in KeyAction keyAction)
    {
        switch (keyAction)
        {
            case KeyAction.ENTER:
                _keyStatus = KeyStatus.HOVER;
                break;
            case KeyAction.LEAVE:
                _keyStatus = KeyStatus.IDLE;
                break;
            case KeyAction.DOWN:
                _keyStatus = KeyStatus.PRESS;
                PlayNote();
                break;
            case KeyAction.UP:
                _keyStatus = KeyStatus.HOVER;
                StopNote();
                break;
            default:
                throw new ArgumentOutOfRangeException($"Enum KeyAction '{keyAction}' is not accounted for.");
        }

        UpdateKeyImage();
    }

    /// <summary>
    ///  Performs audiovisual output of key/note, from keyboard input. 
    /// </summary>
    private void KeyboardInput(in KeyAction keyAction)
    {
        switch (keyAction)
        {
            case KeyAction.DOWN:
                _keyStatus = KeyStatus.PRESS;
                PlayNote();
                break;
            case KeyAction.UP:
                _keyStatus = KeyStatus.IDLE;
                StopNote();
                break;
            default:
                throw new ArgumentOutOfRangeException($"Enum KeyAction '{keyAction}' is not accounted for.");
        }

        UpdateKeyImage();
    }

    /// <summary>
    ///  Updates the displayed image of the associated key based on its '_keyStatus'.
    /// </summary>
    private void UpdateKeyImage()
    {
        switch (_keyStatus)
        {
            case KeyStatus.IDLE:
                _associatedKey.Image = _isBlack ? _keyImages["idle_black"] : _keyImages["idle_white"];
                break;
            case KeyStatus.HOVER:
                _associatedKey.Image = _isBlack ? _keyImages["hover_black"] : _keyImages["hover_white"];
                break;
            case KeyStatus.PRESS:
                _associatedKey.Image = _isBlack ? _keyImages["press_black"] : _keyImages["press_white"];
                break;
            default:
                throw new ArgumentOutOfRangeException($"Enum KeyStatus '{_keyStatus}' is not accounted for.");
        }
    }

    /// <summary>
    ///  Calculates and returns a midi message note index based on 'Note._name'.
    /// </summary>
    private byte GetMidiIndex()
    {
        /// <Summary>
        /// Midi message note index:
        /// - Index range  (0 - 127)
        /// - Lowest note  (21 = A0)
        /// - Highest note (108 = C8)
        /// 
        ///  Return: 12 + (sum of each char in 'this._name'), where their values are the following:
        ///  '0' = 0     'C' = 0    
        ///  '1' = 12    'D' = 2    
        ///  '2' = 24    'E' = 4    
        ///  '3' = 36    'F' = 5    
        ///  '4' = 48    'G' = 7    
        ///  '5' = 60    'A' = 9
        ///  '6' = 72    'B' = 11   
        ///  '7' = 84    'b' = -1
        ///  '8' = 96
        ///  Example: _name = "Eb4" would be equal to (12 + 4 + (-1) + 48) = 63
        /// </Summary>

        if (_name != null)
        {
            byte calculatedIndex = 12;

            for (int i = 0; i < _name.Length; i++)
            {
                switch (_name[i])
                {
                    case 'C':
                        calculatedIndex += 0;
                        break;
                    case 'D':
                        calculatedIndex += 2;
                        break;
                    case 'E':
                        calculatedIndex += 4;
                        break;
                    case 'F':
                        calculatedIndex += 5;
                        break;
                    case 'G':
                        calculatedIndex += 7;
                        break;
                    case 'A':
                        calculatedIndex += 9;
                        break;
                    case 'B':
                        calculatedIndex += 11;
                        break;
                    case 'b':
                        calculatedIndex -= 1;
                        break;
                    case '0':
                        calculatedIndex += 0;
                        break;
                    case '1':
                        calculatedIndex += 12;
                        break;
                    case '2':
                        calculatedIndex += 24;
                        break;
                    case '3':
                        calculatedIndex += 36;
                        break;
                    case '4':
                        calculatedIndex += 48;
                        break;
                    case '5':
                        calculatedIndex += 60;
                        break;
                    case '6':
                        calculatedIndex += 72;
                        break;
                    case '7':
                        calculatedIndex += 84;
                        break;
                    case '8':
                        calculatedIndex += 96;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Char '{_name[i]}' is not accounted for.");
                }
            }

            return calculatedIndex;
        } 
        else
        {
            throw new NullReferenceException($"{this}._name = null");
        }
    }
}
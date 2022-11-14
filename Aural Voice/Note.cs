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

    internal Note(in String noteName, ref PictureBox keyRef)
    {
        _name = noteName;
        _associatedKey = keyRef;
        _midiIndex = GetMidiIndex();
        _isBlack = _associatedKey.Name.Contains('b') ? true : false;
    }

    internal void PlayNote()
    {
        _midiMessage = new MidiNoteOnMessage(defaultChannel, _midiIndex, maxVelocity);

        if (midiDevice != null)
        {
            midiDevice.SendMessage(_midiMessage);
        }
    }

    internal void StopNote()
    {
        _midiMessage = new MidiNoteOffMessage(defaultChannel, _midiIndex, maxVelocity);

        if (midiDevice != null)
        {
            midiDevice.SendMessage(_midiMessage);
        }
    }

    /// <summary>
    ///  Handles visual and audio output of a key/note based on <paramref name="keyAction"/>.
    /// </summary>
    internal void KeyInput(in KeyAction keyAction)
    {
        KeyStatus keyStatus;

        // Visual output
        switch (keyAction)
        {
            case KeyAction.ENTER:
                keyStatus = KeyStatus.HOVER;
                break;
            case KeyAction.LEAVE:
                keyStatus = KeyStatus.IDLE;
                break;
            case KeyAction.DOWN:
                keyStatus = KeyStatus.PRESS;
                break;
            case KeyAction.UP:
                keyStatus = KeyStatus.HOVER;
                break;
            default:
                // exception
                keyStatus=KeyStatus.IDLE;
                break;
        }

        SetKeyImage(keyStatus);

        // Audio output
        if (keyAction == KeyAction.DOWN) PlayNote();
        if (keyAction == KeyAction.UP) StopNote();
    }

    /// <summary>
    ///  Sets the displayed image of the associated key to its corresponding <paramref name="keyStatus"/>..
    /// </summary>
    private void SetKeyImage(in KeyStatus keyStatus)
    {
        switch (keyStatus)
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
                break;
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

        if (this._name != null)
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
                        // Exception: invalid note name! Char '_name[i]' is not accounted for.
                        break;
                }
            }

            return calculatedIndex;
        }

        // Exception: this_name == null
        return 0;
    }
}
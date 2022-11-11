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
    ///  Calculates and returns the correct 'note' value in midi message calls: 
    ///  MidiNoteOnMessage(byte channel, byte note, byte velocity);
    /// </summary>
    private byte GetMidiIndex()
    {
        // Maps each note name to its corresponding note index for midi input.
        // - Index range (0 - 127)
        // - lowest note (21 = A0)
        // - highest note (108 = C8)

        if (this._name != null)
        {
            switch (this._name)
            {
                case AppWindow.NoteName.A0:
                    return 21;
                case AppWindow.NoteName.Bb0:
                    return 22;
                // ...
                default:
                    // Unvalid Note._name
                    break;
            }
        }

        // Alternatively:
        // Read 'Note._name' and split the String into an array of chars.
        // So "A0" = ['A', '0'] and "Bb0" = ['B', 'b', '0'] and so on.
        // Then return: 12 + (sum of each char), where their values are the following:
        // '0' = 0     'C' = 0    
        // '1' = 12    'D' = 2    
        // '2' = 24    'E' = 4    
        // '3' = 36    'F' = 5    
        // '4' = 48    'G' = 7    
        // '5' = 60    'A' = 9
        // '6' = 72    'B' = 11   
        // '7' = 84    'b' = -1
        // '8' = 96
        // So "Eb4" would be equal to 12 + 4 + (-1) + 48 = 63

        // Exception: this_name == null
        return 0;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Midi;

namespace AuralVoice.Audio;

internal class Note : Piano
{
    private readonly PictureBox _associatedKey;
    private readonly bool _isBlack;

    internal Note(ref PictureBox associatedKey)
    {
        // Reference to the appropriate "key"
        _associatedKey = associatedKey;

        // Boolean to determine whether the note is black or white.
        _isBlack = _associatedKey.Name.Contains('b') ? true : false;
    }

    internal void PlayNote()
    {
        // Temp play note
        IMidiMessage onMessage = new MidiNoteOnMessage(1, 70, 80);
        midiSynth.SendMessage(onMessage);
    }

    internal void StopNote()
    {
        // Temp stop note
        IMidiMessage offMessage = new MidiNoteOffMessage(1, 70, 80);
        midiSynth.SendMessage(offMessage);
    }

    internal void MouseDown()
    {
        SetKeyImage(KeyStatus.PRESS);
        PlayNote();
    }

    internal void MouseUp()
    {
        SetKeyImage(KeyStatus.HOVER);
        StopNote();
    }

    internal void MouseEnter()
    {
        SetKeyImage(KeyStatus.HOVER);
    }

    internal void MouseLeave()
    {
        SetKeyImage(KeyStatus.IDLE);
    }

    // Sets the displayed image of the associated key to its corresponding KeyStatus.
    private void SetKeyImage(KeyStatus keyStatus)
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
}

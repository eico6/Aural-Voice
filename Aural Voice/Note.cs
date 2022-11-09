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
    private readonly PictureBox associatedKey;
    private readonly bool isBlack;
    private IMidiMessage? midiMessage;


    internal Note(ref PictureBox inAssociatedKey)
    {
        // Reference to the appropriate "key"
        associatedKey = inAssociatedKey;

        // Boolean to determine whether the note is black or white.
        isBlack = associatedKey.Name.Contains('b') ? true : false;
    }

    internal void PlayNote()
    {
        // Temp play note - check Piano.GetNoteIndex() for further plan
        midiMessage = new MidiNoteOnMessage(defaultChannel, 21, maxVelocity);
        midiDevice.SendMessage(midiMessage);
    }

    internal void StopNote()
    {
        // Temp stop note - check Piano.GetNoteIndex() for further plan
        midiMessage = new MidiNoteOffMessage(defaultChannel, 21, maxVelocity);
        midiDevice.SendMessage(midiMessage);

        // For debugging
        MessageBox.Show(associatedKey.Name);
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
                associatedKey.Image = isBlack ? _keyImages["idle_black"] : _keyImages["idle_white"];
                break;
            case KeyStatus.HOVER:
                associatedKey.Image = isBlack ? _keyImages["hover_black"] : _keyImages["hover_white"];
                break;
            case KeyStatus.PRESS:
                associatedKey.Image = isBlack ? _keyImages["press_black"] : _keyImages["press_white"];
                break;
            default:
                break;
        }
    }
}

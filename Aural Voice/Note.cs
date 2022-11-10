using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Midi;

namespace AuralVoice;

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

        if (midiDevice != null)
        {
            midiDevice.SendMessage(midiMessage);
        }
    }

    internal void StopNote()
    {
        // Temp stop note - check Piano.GetNoteIndex() for further plan
        midiMessage = new MidiNoteOffMessage(defaultChannel, 21, maxVelocity);

        if (midiDevice != null)
        {
            midiDevice.SendMessage(midiMessage);
        }

        // For debugging
        MessageBox.Show(associatedKey.Name);
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

/// <summary>
///  ... 
/// </summary>
internal static class NoteID
{
    internal static byte GetMidiIndex(String noteID)
    {
        return 0;
    }

    internal const String A0 = "A0";
    internal const String Bb0 = "Bb0";
    // ...
}
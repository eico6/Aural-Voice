using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace AuralVoice;

internal class Note
{
    private Stream _noteAudio;
    private readonly PictureBox _keyReference;

    internal Note(PictureBox keyReference)
    {
        _keyReference = keyReference;

        // temp audio for debugging
        _noteAudio = ProjectResources.my_song;
    }

    internal Stream noteAudio
    {
        get => _noteAudio;
        set => _noteAudio = value;
    }

    internal void Play()
    {
        // Play the appropriate note audio.
        SoundPlayer soundPlayer = new SoundPlayer(_noteAudio);
        soundPlayer.Play();
    }

    internal void MouseEnter()
    {
        // Change color of '_keyReference' to a light blue color.
    }

    internal void MouseLeave()
    {
        // Change color of '_keyReference' to its default color.
    }
}

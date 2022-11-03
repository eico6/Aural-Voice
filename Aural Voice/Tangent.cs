using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace AuralVoice;

internal class Tangent : PictureBox
{
    Tangent(PictureBox visualTangent)
    {
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
        // Play the appropriate note.
        SoundPlayer soundPlayer = new SoundPlayer(_noteAudio);
        soundPlayer.Play();
    }

    new internal void MouseEnter()
    {
        // Change color of 'this.PictureBox' to a light blue color.
    }

    new internal void MouseLeave()
    {
        // Change color of 'this.PictureBox' to its default color.
    }

    private Stream _noteAudio;
}

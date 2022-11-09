using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;
using Windows.UI.Core;

namespace AuralVoice.Audio;

internal class Piano
{
    /// <summary>
    ///  @ midiSynth - Reference to a MIDI device. Initialized with the "Microsoft GS Wavetable Synth";
    ///                a virtual MIDI synth bundled with Windows releases. Handles audio I/O.
    /// </summary>

    protected IMidiOutPort? midiSynth;
    internal Dictionary<String, Note>? notes;

    // References to each piano key image in 'ProjectResources.resx'.
    protected readonly Dictionary<String, Bitmap> _keyImages = new Dictionary<String, Bitmap>()
    {
        { "idle_white", ProjectResources.key_white_idle },
        { "idle_black", ProjectResources.key_black_idle },
        { "hover_white", ProjectResources.key_white_hover },
        { "hover_black", ProjectResources.key_black_hover },
        { "press_white", ProjectResources.key_white_press },
        { "press_black", ProjectResources.key_black_press }
    };

    internal Piano()
    {
        notes = new Dictionary<String, Note>();
        InitializeMidiSynth();
    }

    protected enum KeyStatus
    {
        IDLE = 0,
        HOVER = 1,
        PRESS = 2
    }

    private async void InitializeMidiSynth()
    {
        // midiSynth = "Microsoft GS Wavetable Synth"
        midiSynth = await MidiSynthesizer.CreateAsync();
    }
}

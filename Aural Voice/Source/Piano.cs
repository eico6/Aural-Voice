using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;
using Windows.UI.Core;

namespace AuralVoice;

/// <summary>
///  Virtual piano containing a collection of type Note. Handles midi input/output.
/// </summary>
internal class Piano
{
    /// <summary>
    ///  Reference to a MIDI device. Initialized with the "Microsoft GS Wavetable Synth";
    ///  a virtual MIDI synth bundled with Windows releases. Handles audio I/O.
    /// </summary>
    protected IMidiOutPort? midiDevice;

    /// <summary>
    ///  Collection containing the notes of the piano.
    ///  Hash key should be passed as a 'AppWindow.NoteName' string.
    /// </summary>
    private Dictionary<String, Note>? _notes;

    private const byte _defaultChannel = 0;
    private const byte _maxVelocity = 127;
    protected byte defaultChannel { get => _defaultChannel; }
    protected byte maxVelocity    { get => _maxVelocity; }

    /// <summary>
    ///  Holds references to each piano key image in 'ProjectResources.resx'.
    /// </summary>
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
        _notes = new Dictionary<String, Note>();
        AssignMidiDevice();
    }

    /// <summary>
    ///  Specifies the caller of a KeyAction to prevent overlapping inputs.
    /// </summary>
    internal enum ActionCaller : byte
    {
        MOUSE = 0,
        KEYBOARD = 1
    }

    /// <summary>
    ///  All user input related to the keys, either via mouse events, or the use of hotkeys.
    /// </summary>
    internal enum KeyAction : Byte
    {
        ENTER = 0,
        LEAVE = 1,
        DOWN = 2,
        UP = 3
    }

    /// <summary>
    ///  Determines which one of the three possible key images should be displayed. 
    /// </summary>
    protected enum KeyStatus : Byte
    {
        IDLE = 0,
        HOVER = 1,
        PRESS = 2
    }

    /// <summary>
    ///  Adds a single note to the piano.
    /// </summary>
    internal void AddNote(in String noteName, PictureBox keyRef)
    {
        if (_notes != null)
        {
            var newNote = new Note(noteName, ref keyRef);

            if (_notes.ContainsKey(noteName))
            {
                throw new ArgumentException($"Note '{noteName}' already exists.");
            }

            if (_notes.Count == 88)
            {
                throw new ArgumentException($"Tried to add note '{noteName}' to '{this}._notes' when full.");
            }

            _notes.Add(noteName, newNote);
        }
        else
        {
            throw new NullReferenceException($"{this}._notes = null");
        }
    }

    /// <summary>
    ///  Gets a single note from the piano.
    /// </summary>
    internal Note GetNote(in String noteName)
    {
        if (_notes != null)
        {
            return _notes[noteName];
        }

        throw new NullReferenceException($"{this}._notes = null");
    }

    private async void AssignMidiDevice()
    {
        // midiDevice = "Microsoft GS Wavetable Synth"
        midiDevice = await MidiSynthesizer.CreateAsync();

        // Sets the assigned synth to program 0 ("Acoustic Grand Piano")
        IMidiMessage programChange = new MidiProgramChangeMessage(defaultChannel, 0);
        midiDevice.SendMessage(programChange);
    }
}

﻿using System;
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
internal partial class Piano
{
    /// <summary>
    ///  Reference to a MIDI device. Initialized with the "Microsoft GS Wavetable Synth";
    ///  a virtual MIDI synth bundled with Windows releases. Handles audio I/O.
    /// </summary>
    private static IMidiOutPort? s_midiDevice;

    /// <summary>
    ///  Collection containing the notes of the piano.
    ///  Hash key should be passed as a 'AppWindow.NoteName' string.
    /// </summary>
    private Dictionary<String, Note>? _notes;

    private const byte _defaultChannel = 0;
    private const byte _maxVelocity = 127;
    internal static byte defaultChannel { get => _defaultChannel; }
    internal static byte maxVelocity    { get => _maxVelocity; }

    /// <summary>
    ///  Holds references to each piano key image in 'ProjectResources.resx'.
    /// </summary>
    private static readonly Dictionary<String, Bitmap> s_keyImages = new Dictionary<String, Bitmap>()
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
        AssignMidiDeviceAsync();
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

    /// <summary>
    ///  Initialize the midi device to default values.
    /// </summary>
    private async void AssignMidiDeviceAsync()
    {
        // midiDevice = "Microsoft GS Wavetable Synth"
        s_midiDevice = await MidiSynthesizer.CreateAsync();

        // Sets the assigned synth to program 0 ("Acoustic Grand Piano")
        IMidiMessage programChange = new MidiProgramChangeMessage(defaultChannel, 0);
        s_midiDevice.SendMessage(programChange);
    }
}

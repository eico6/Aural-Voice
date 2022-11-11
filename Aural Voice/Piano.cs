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
internal class Piano
{
    /// <summary>
    ///  Reference to a MIDI device. Initialized with the "Microsoft GS Wavetable Synth";
    ///  a virtual MIDI synth bundled with Windows releases. Handles audio I/O.
    /// </summary>
    protected IMidiOutPort? midiDevice;

    /// <summary>
    ///  Holds references to each piano key image in 'ProjectResources.resx'.
    /// </summary>
    private Dictionary<String, Note>? _notes;

    private const byte _defaultChannel = 0;
    private const byte _maxVelocity = 127;
    protected byte defaultChannel { get => _defaultChannel; }
    protected byte maxVelocity    { get => _maxVelocity; }

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
            _notes.Add(noteName, newNote);
        }

        // TODO: Check if note already exists.
        // TODO: Check if '_notes' count == 88

        //throw new NullReferenceException("Tried to add an element to '_notes' when '_notes' == null.");
    }

    internal Note GetNote(in String noteName)
    {
        if (_notes != null)
        {
            return _notes[noteName];
        }

        // TEMP CODE FOR COMPILATION
        PictureBox tempBox = new PictureBox();
        return new Note("temp", ref tempBox);
        //throw new NullReferenceException("Tried to get an element from '_notes' when '_notes' == null.");
    }

    // TODO: 'async' or 'await' makes it seem like the assigning happens ca. 1 sec after app starts (?)
    private async void AssignMidiDevice()
    {
        // midiDevice = "Microsoft GS Wavetable Synth"
        midiDevice = await MidiSynthesizer.CreateAsync();

        // Sets the assigned synth to program 0 ("Acoustic Grand Piano")
        IMidiMessage programChange = new MidiProgramChangeMessage(defaultChannel, 0);
        midiDevice.SendMessage(programChange);
    }
}

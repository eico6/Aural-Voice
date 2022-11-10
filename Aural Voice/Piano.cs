using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;
using Windows.UI.Core;

namespace AuralVoice;

internal class Piano
{
    /// <summary>
    ///  @midiDevice  - Reference to a MIDI device. Initialized with the "Microsoft GS Wavetable Synth";
    ///                 a virtual MIDI synth bundled with Windows releases. Handles audio I/O.
    ///  @_keyImages  - Holds references to each piano key image in 'ProjectResources.resx'.
    /// </summary>

    protected IMidiOutPort? midiDevice;
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
    internal void AddNote(String noteID, PictureBox keyRef)
    {
        if (_notes != null)
        {
            _notes.Add(noteID, new Note(ref keyRef));
        }

        // TODO: Check if note already exists.
        // TODO: Check if '_notes' count == 88

        //throw new NullReferenceException("Tried to add an element to '_notes' when '_notes' == null.");
    }

    internal Note GetNote(String noteID)
    {
        if (_notes != null)
        {
            return _notes[noteID];
        }

        // TEMP CODE FOR COMPILATION
        PictureBox tempBox = new PictureBox();
        return new Note(ref tempBox);
        //throw new NullReferenceException("Tried to get an element from '_notes' when '_notes' == null.");
    }

    // Move this to 'Note' class (?) 
    protected byte GetNoteIndex(String keyName)
    {
        // TODO
        // - Function is called from notes, where they pass "associatedKey.Name".
        // - This function is going to calculate 'NOTE' in midi message calls:
        //   MidiNoteOnMessage(byte channel, byte NOTE, byte velocity);
        // - Maps each key name to its note index.
        // - Index range (0 - 127)
        // - lowest note (21 = A0)
        // - highest note (108 = C8)

        // Reads 'keyName' and splits it into chars, excluding "key" string from each name.
        // So "keyA0" = ['A', '0'] and "keyBb0" = ['B', 'b', '0'] and so on.
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
        // So "keyEb4" would be equal to 12 + 4 + (-1) + 48 = 63

        return 0;
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

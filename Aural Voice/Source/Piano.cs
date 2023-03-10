using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;
using Windows.UI.Core;
using MaterialSkin.Controls;

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

    /// <summary>
    ///  Direct references to windows forms controls.
    /// </summary>
    public static MaterialSlider? volumeSliderRef;
    public static MaterialComboBox? programSelectorRef;

    private const byte _defaultChannel = 0;
    public static byte defaultChannel { get => _defaultChannel; }

    /// <summary>
    ///  Volume range = [0 - 127].
    ///  Volume Slider Control range = [0 - 100]
    ///  The volume setter "de-normalizes" the value.
    /// </summary>
    private static byte s_volume = 127; 
    public static byte volume   
    { 
        get => s_volume; 
        set => s_volume = Convert.ToByte(value * 1.27);
    }

    private static byte s_program = 0;
    public static byte program
    {
        get => s_program;
        set => s_program = value;
    }

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

    /// <summary>
    ///  Collection of "General MIDI 1" instrument indexes.
    /// </summary>
    private static readonly Dictionary<String, byte> s_programElement = new Dictionary<String, byte>()
    {
        { "Acoustic Grand Piano", 0 },
        { "Electric Piano", 4 },
        { "Vibraphone", 11 },
        { "Drawbar Organ", 16 },
        { "Pan Flute", 75 }
    };

    internal Piano(ref MaterialSlider volumeSlider, ref MaterialComboBox programSelector)
    {
        // Assign references to the windows forms controls.
        volumeSliderRef = volumeSlider;
        programSelectorRef = programSelector;

        // Instantiate '_notes' and initialize the midi device.
        _notes = new Dictionary<String, Note>();
        AssignMidiDeviceAsync();
    }

    /// <summary>
    ///  Sets new volume value, from 'int' to 'byte'.
    /// </summary>
    internal void updateVolume(int volumeIn)
    {
        if (volumeSliderRef != null)
        {
            volume = Convert.ToByte(volumeIn);
        } else
        {
            throw new NullReferenceException($"{this}.volumeSliderRef = null");
        }
    }

    /// <summary>
    ///  Sets new program value, from 'string' to 'byte'.
    /// </summary>
    internal void updateProgram()
    {
        if (programSelectorRef != null)
        {
            if (s_midiDevice != null)
            {
                byte newProgram = s_programElement[programSelectorRef.SelectedItem.ToString()];

                IMidiMessage programChange = new MidiProgramChangeMessage(defaultChannel, newProgram);
                s_midiDevice.SendMessage(programChange);
            }
            else
            {
                throw new NullReferenceException($"{this}.s_midiDevice = null");
            }
        } else
        {
            throw new NullReferenceException($"{this}.programSelectorRef = null");
        }
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
        // midiDevice = "Microsoft GS Wavetable Synth".
        s_midiDevice = await MidiSynthesizer.CreateAsync();

        // Sets the assigned synth to program 0 ("Acoustic Grand Piano").
        IMidiMessage programChange = new MidiProgramChangeMessage(defaultChannel, program);
        s_midiDevice.SendMessage(programChange);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;
using Windows.UI.Core;
using MaterialSkin.Controls;
using Windows.ApplicationModel.Preview.Notes;

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
    private static IMidiOutPort? midiDevice
    {
        get { return s_midiDevice; }
        set { s_midiDevice = value; }
    }

    /// <summary>
    ///  Collection containing the notes of the piano.
    ///  Hash key should be passed as a 'AppWindow.NoteName' string.
    /// </summary>
    private Dictionary<String, Note>? _notes;
    public Dictionary<String, Note>? notes
    {
        get { return _notes; }
        private set { _notes = value; }
    }

    /// <summary>
    ///  Determines whether the piano should recieve input or not.
    /// </summary>
    private static bool _isActive = true;
    private static bool isActive
    {
        get { return _isActive; }
        set { _isActive = value; }
    }

    /// <summary>
    ///  Holds reference to the Gamemaster.
    /// </summary>
    private static Gamemaster? _gamemasterRef;
    public static Gamemaster? gamemasterRef
    {
        get { return _gamemasterRef; }
        set { _gamemasterRef = value; }
    }

    /// <summary>
    ///  MIDI channel. 
    ///  Aural Voice only supports one channel.
    /// </summary>
    private const byte _defaultChannel = 0;
    public static byte defaultChannel 
    { 
        get { return _defaultChannel; }
    }

    /// <summary>
    ///  Piano program instrument index.
    /// </summary>
    private const byte _defaultProgram = 0;
    public static byte defaultProgram
    {
        get { return _defaultProgram; }
    }

    /// <summary>
    ///  Audio volume.
    ///  - Volume range = [0 - 127].
    ///  - Volume Slider Control range = [0 - 100]
    ///  - The volume setter "de-normalizes" the value.
    /// </summary>
    private static byte s_volume = 127; 
    public static byte volume   
    { 
        get => s_volume; 
        set => s_volume = Convert.ToByte(value * 1.27);
    }

    /// <summary>
    ///  References to winforms controls.
    /// </summary>
    private MaterialComboBox? programSelector;
    private MaterialTabControl? tabController;

    /// <summary>
    ///  Holds references to each piano key image in 'ProjectResources.resx'.
    /// </summary>
    private static readonly Dictionary<String, Bitmap> keyImages = new Dictionary<String, Bitmap>()
    {
        { "idle_white",     ProjectResources.key_white_idle },
        { "idle_black",     ProjectResources.key_black_idle },
        { "hover_white",    ProjectResources.key_white_hover },
        { "hover_black",    ProjectResources.key_black_hover },
        { "press_white",    ProjectResources.key_white_press },
        { "press_black",    ProjectResources.key_black_press },
        { "red_white",      ProjectResources.key_white_red },
        { "red_black",      ProjectResources.key_black_red },
        { "green_white",    ProjectResources.key_white_green },
        { "green_black",    ProjectResources.key_black_green },
        { "disabled_white", ProjectResources.key_white_disabled },
        { "disabled_black", ProjectResources.key_black_disabled }

    };

    /// <summary>
    ///  Collection of "General MIDI 1" instrument indexes.
    /// </summary>
    private static readonly Dictionary<String, byte> programElement = new Dictionary<String, byte>()
    {
        { "Acoustic Grand Piano", 0 },
        { "Electric Piano",       4 },
        { "Vibraphone",           11 },
        { "Drawbar Organ",        16 },
        { "Pan Flute",            75 }
    };

    internal Piano(ref MaterialComboBox programSelectorIn, ref MaterialTabControl tabControllerIn)
    {
        // Assign references to winforms controls.
        programSelector = programSelectorIn;
        tabController = tabControllerIn;

        // Instantiate notes and initialize the midi device.
        notes = new Dictionary<String, Note>();
        AssignMidiDeviceAsync();
    }

    /// <summary>
    ///  Update piano activation according to game state.
    /// </summary>
    public void UpdateIsPianoActive()
    {
        if (tabController == null) throw new NullReferenceException($"{this}.tabController = null");

        string newTab = tabController.SelectedTab.ToString();

        // if (the Piano tab is active && a question round is not over)
        if (newTab.Contains("Piano") && !gamemasterRef.roundOver)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    /// <summary>
    ///  Updates active program on the midi device.
    /// </summary>
    internal void UpdateProgram()
    {
        if (programSelector == null) throw new NullReferenceException($"{this}.programSelector = null");
        if (midiDevice == null)      throw new NullReferenceException($"{this}.midiDevice = null");

        // Get selected program and send it to the midi device.
        byte newProgram = Piano.programElement[programSelector.SelectedItem.ToString()];
        IMidiMessage programChange = new MidiProgramChangeMessage(defaultChannel, newProgram);
        midiDevice.SendMessage(programChange);
    }

    /// <summary>
    ///  Sets a new volume value equal to <paramref name="volumeIn"/>.
    /// </summary>
    internal void SetVolume(int volumeIn)
    {
        Piano.volume = Convert.ToByte(volumeIn);
    }

    /// <summary>
    ///  Adds a single note to the piano.
    /// </summary>
    internal void AddNote(in String noteName, PictureBox keyRef)
    {
        if (notes == null)               throw new NullReferenceException($"{this}.notes = null");
        if (notes.ContainsKey(noteName)) throw new ArgumentException($"Note '{noteName}' already exists.");
        if (notes.Count == 88)           throw new ArgumentException($"Tried to add note '{noteName}' to '{this}.notes' when full.");

        // Add the new note to the notes dictionary.
        var newNote = new Note(noteName, ref keyRef);
        notes.Add(noteName, newNote);
    }

    /// <summary>
    ///  Gets a single note from the piano.
    /// </summary>
    internal Note GetNote(in String noteName)
    {
        if (notes == null) throw new NullReferenceException($"{this}.notes = null");

        return notes[noteName];
    }

    /// <summary>
    ///  Initialize the midi device to default values.
    /// </summary>
    private async void AssignMidiDeviceAsync()
    {
        if (midiDevice == null) throw new NullReferenceException($"{this}.midiDevice = null");

        // midiDevice = "Microsoft GS Wavetable Synth".
        midiDevice = await MidiSynthesizer.CreateAsync();

        // Sets the assigned synth to the default program ("Acoustic Grand Piano").
        IMidiMessage programChange = new MidiProgramChangeMessage(Piano.defaultChannel, Piano.defaultProgram);
        midiDevice.SendMessage(programChange);
    }
}

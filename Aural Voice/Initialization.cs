using AuralVoice.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Midi;

namespace AuralVoice;

partial class AppWindow
{

    /// <summary>
    ///  There are two sets of "piano keys" (88 instances each).
    ///  This is due to the limitations of the Microsoft Windows Forms auto-generated code.
    ///  Notice the difference in naming when reffering between the two; "key(s)" and "note(s)".
    /// 
    ///      ImageBox keys - The actual visual representation of keys that the user interacts with.
    ///                      The keys are associated with the EventHandler. They consist of auto-
    ///                      generated code, which is why they are not stored in a collection.
    ///      Note notes    - This is where the functionality of each key is handled.
    ///                      Each note has a '_keyReference' to keep track of its associated key.
    ///                      The notes are stored within a hash table inside the 'Piano' class.
    /// </summary>

    private void InitializePiano()
    {
        piano = new Piano();

        AssignNotes();
    }

    private async void InitializeMidiSynth()
    {
        // "Microsoft GS Wavetable Synth"
        midiSynth = await MidiSynthesizer.CreateAsync();
    }

    // Assigns a unique reference between each "note" and each "key".
    private void AssignNotes()
    {
        // ...
    }
}

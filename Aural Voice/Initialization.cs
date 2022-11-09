using AuralVoice.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Preview.Notes;
using Windows.Devices.Midi;

namespace AuralVoice;

partial class AppWindow
{
    private void InitializePiano()
    {
        /// <summary>
        ///  - Adds 88 notes to the piano.
        ///  - Assigns a unique reference between each "note" and each "key".
        /// </summary> 
        
        piano = new Piano();
        
        if (piano.notes != null)
        {
            piano.notes.Add("A0",  new Note(ref keyA0));
            piano.notes.Add("Bb0", new Note(ref keyBb0));
            // ...
        }
    }
}

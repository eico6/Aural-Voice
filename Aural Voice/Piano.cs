using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuralVoice.Audio;

internal class Piano
{
    internal Dictionary<Note, string>? notes;

    internal Piano()
    {
        // There should be 88 notes
        notes = new Dictionary<Note, string>();
    }

    internal void PlayRandomNote()
    {
        // Lookup: Dictionary.ElementAt<TSource>(IEnumerable<TSource>, Index)
    }
}

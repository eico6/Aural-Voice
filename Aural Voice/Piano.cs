using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuralVoice;

internal class Piano
{
    internal Dictionary<Note, string>? notes;

    internal Piano()
    {
        notes = new Dictionary<Note, string>();
    }

    internal void PlayRandomNote()
    {
        // Lookup: Dictionary.ElementAt<TSource>(IEnumerable<TSource>, Index)
    }
}

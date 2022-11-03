using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuralVoice;

internal class Piano
{
    internal Piano()
    {
        tangents = new Dictionary<Tangent, string>();
    }

    internal Dictionary<Tangent, string>? tangents;

    internal void PlayRandomTangent()
    {
        // Lookup: Dictionary.ElementAt<TSource>(IEnumerable<TSource>, Index)
    }
}

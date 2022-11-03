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
        // TODO: replace List<T> with Dictionary<T> for readability
        tangents = new List<Tangent>();
        tangents.Capacity = 88;
    }

    internal List<Tangent>? tangents;

    internal void PlayRandomTangent()
    {
        // tangents[random].Play();
    }
}

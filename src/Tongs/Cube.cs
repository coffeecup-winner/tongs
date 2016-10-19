using System;
using System.Collections.Generic;
using Tongs.Storage;

namespace Tongs
{
    public static class Cube
    {
        public static NCube<T1, T2, TCell> Create<T1, T2, TCell>(IEnumerable<T1> source1, IEnumerable<T2> source2, Func<T1, T2, TCell> cellFunc)
        {
            return NCube<T1, T2, TCell>.Create(source1, source2, cellFunc);
        }
    }
}

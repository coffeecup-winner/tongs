using System;
using System.Collections.Generic;
using Tongs.Storage;

namespace Tongs
{
    public static class Cube
    {
        public static NCube<T1, T2, bool> Create<T1, T2>(IEnumerable<T1> source1, IEnumerable<T2> source2, Func<T1, T2, bool> cellFunc)
        {
            return NCube<T1, T2, bool>.Create(source1, source2, (i1, i2) => cellFunc(i1, i2) ? Option.Some(true) : Option.None<bool>());
        }

        public static NCube<T1, T2, TCell> Create<T1, T2, TCell>(IEnumerable<T1> source1, IEnumerable<T2> source2, Func<T1, T2, TCell> cellFunc)
        {
            return NCube<T1, T2, TCell>.Create(source1, source2, (i1, i2) => Option.Some(cellFunc(i1, i2)));
        }

        public static NCube<T1, T2, TCell> Create<T1, T2, TCell>(IEnumerable<T1> source1, IEnumerable<T2> source2, Func<T1, T2, Option<TCell>> cellFunc)
        {
            return NCube<T1, T2, TCell>.Create(source1, source2, cellFunc);
        }
    }
}

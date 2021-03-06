﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tongs.Storage
{
    public class NCube<T1, T2, TCell> : IDumpable
    {
        private readonly IEnumerable<T1> source1;
        private readonly IEnumerable<T2> source2;
        private readonly IReadOnlyDictionary<T1, IReadOnlyDictionary<T2, TCell>> data;

        internal NCube(IEnumerable<T1> source1, IEnumerable<T2> source2, IReadOnlyDictionary<T1, IReadOnlyDictionary<T2, TCell>> data)
        {
            this.source1 = source1;
            this.source2 = source2;
            this.data = data;
        }

        public static NCube<T1, T2, TCell> Create(IEnumerable<T1> source1, IEnumerable<T2> source2, Func<T1, T2, Option<TCell>> cellFunc)
        {
            var data = new Dictionary<T1, IReadOnlyDictionary<T2, TCell>>();
            foreach (var item1 in source1)
            {
                var level1 = new Dictionary<T2, TCell>();
                foreach (var item2 in source2)
                {
                    var cell = cellFunc(item1, item2);
                    if (cell.IsSome)
                    {
                        level1.Add(item2, cell.Value);
                    }
                }
                if (level1.Count > 0)
                {
                    data.Add(item1, level1);
                }
            }
            return new NCube<T1, T2, TCell>(source1, source2, data);
        }

        public NCube<T2, T1, TCell> Transpose()
        {
            return NCube<T2, T1, TCell>.Create(source2, source1, (i2, i1) => data.GetOrNone(i1).FlatMap(level1 => level1.GetOrNone(i2)));
        }

        public string GetDump()
        {
            var sb = new StringBuilder();
            foreach (var pair1 in data)
            {
                sb.AppendLine(pair1.Key.ToString());
                foreach (var pair2 in pair1.Value)
                {
                    sb.AppendLine("    " + pair2.Key);
                }
            }
            return sb.ToString();
        }
    }
}

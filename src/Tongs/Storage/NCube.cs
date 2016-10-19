using System;
using System.Collections.Generic;
using System.Text;

namespace Tongs.Storage
{
    public class NCube<T1, T2, TCell>
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

        public static NCube<T1, T2, TCell> Create(IEnumerable<T1> source1, IEnumerable<T2> source2, Func<T1, T2, TCell> cellFunc)
        {
            var data = new Dictionary<T1, IReadOnlyDictionary<T2, TCell>>();
            foreach (var item1 in source1)
            {
                var level1 = new Dictionary<T2, TCell>();
                foreach (var item2 in source2)
                {
                    level1[item2] = cellFunc(item1, item2);
                }
                data[item1] = level1;
            }
            return new NCube<T1, T2, TCell>(source1, source2, data);
        }

        public NCube<T2, T1, TCell> Transpose()
        {
            return NCube<T2, T1, TCell>.Create(source2, source1, (i2, i1) => data[i1][i2]);
        }

        public string GetDump(Func<TCell, bool> filter)
        {
            var sb = new StringBuilder();
            foreach (var item1 in source1)
            {
                bool printedItem = false;
                foreach (var item2 in source2)
                {
                    if (filter(data[item1][item2]))
                    {
                        if (!printedItem)
                        {
                            sb.AppendLine(item1.ToString());
                            printedItem = true;
                        }
                        sb.AppendLine("    " + item2);
                    }
                }
            }
            return sb.ToString();
        }

        public NCube<T1, T2, TCell> Dump(Func<TCell, bool> filter)
        {
            Console.Write(GetDump(filter));
            return this;
        }
    }
}

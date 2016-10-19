using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tongs.DataSource
{
    class StringDataSource : IEnumerable<string>
    {
        private readonly IReadOnlyCollection<string> strings;

        private StringDataSource(IEnumerable<string> strings)
        {
            this.strings = strings.ToArray();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return strings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static StringDataSource CreateFromFile(string filepath, bool ignoreEmptyLines = true)
        {
            return new StringDataSource(System.IO.File.ReadAllLines(filepath).Where(l => l != string.Empty));
        }
    }
}

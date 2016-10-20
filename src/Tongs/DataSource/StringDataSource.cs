using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tongs.ContentProviders;

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

        public static StringDataSource CreateFrom(string location, IContentProvider provider, bool ignoreEmptyLines = true)
        {
            return new StringDataSource(provider.GetContent(location)
                .Split(new[] { "\r", "\n" }, ignoreEmptyLines ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None));
        }
    }
}

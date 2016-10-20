using System.Collections.Generic;
using Tongs.ContentProviders;
using Tongs.DataSource;

namespace Tongs
{
    public static class Get
    {
        private static readonly ContentProviderResolver contentProviderResolver = new ContentProviderResolver();

        public static IEnumerable<File> Files(string directory, string pattern = FileDataSource.AnyFilePattern, bool recursively = true)
        {
            return FileDataSource.CreateFromDirectory(directory, pattern, recursively);
        }

        public static IEnumerable<string> Lines(string location, bool ignoreEmptyLines = true)
        {
            return StringDataSource.CreateFrom(location, contentProviderResolver.Resolve(location), ignoreEmptyLines);
        }
    }
}

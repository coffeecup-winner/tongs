using System.Collections.Generic;
using Tongs.DataSource;

namespace Tongs
{
    public static class Get
    {
        public static IEnumerable<File> Files(string directory, string pattern = FileDataSource.AnyFilePattern, bool recursively = true)
        {
            return FileDataSource.CreateFromDirectory(directory, pattern, recursively);
        }

        public static IEnumerable<string> Lines(string filepath, bool ignoreEmptyLines = true)
        {
            return StringDataSource.CreateFromFile(filepath);
        }
    }
}

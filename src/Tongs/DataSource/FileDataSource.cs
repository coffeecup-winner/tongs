using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tongs.DataSource
{
    public class FileDataSource : IEnumerable<File>
    {
        public const string AnyFilePattern = "*";

        private readonly IReadOnlyCollection<File> files;

        private FileDataSource(IEnumerable<File> files)
        {
            this.files = files.ToArray();
        }

        public IEnumerator<File> GetEnumerator()
        {
            return files.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static FileDataSource CreateFromDirectory(string directory, string pattern = AnyFilePattern, bool recursively = true)
        {
            return new FileDataSource(Directory.EnumerateFiles(Path.GetFullPath(directory), pattern, recursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                .Select(p => new File(p)));
        }
    }

    public class File
    {
        private readonly string path;

        internal File(string path)
        {
            this.path = path;
        }

        public override string ToString()
        {
            return path;
        }
    }
}

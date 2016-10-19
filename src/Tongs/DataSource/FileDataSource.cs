using System;
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
        private readonly Lazy<FileInfo> fileInfo;

        internal File(string path)
        {
            this.path = path;
            fileInfo = new Lazy<FileInfo>(() => new FileInfo(path));
        }

        public string Path => path;
        public string Name => System.IO.Path.GetFileName(Path);
        public string Extension => System.IO.Path.GetExtension(Path);
        public string DirectoryPath => System.IO.Path.GetDirectoryName(Path);
        public string DirectoryName => System.IO.Path.GetFileName(DirectoryPath);
        public bool Exists() => System.IO.File.Exists(Path);
        public long Size => fileInfo.Value.Length;
        public DateTime CreationTime => fileInfo.Value.CreationTime;
        public DateTime CreationTimeUtc => fileInfo.Value.CreationTimeUtc;
        public DateTime LastAccessTime => fileInfo.Value.LastAccessTime;
        public DateTime LastAccessTimeUtc => fileInfo.Value.LastAccessTimeUtc;
        public DateTime LastWriteTime => fileInfo.Value.LastWriteTime;
        public DateTime LastWriteTimeUtc => fileInfo.Value.LastWriteTimeUtc;
        public bool IsReadOnly => fileInfo.Value.Attributes.HasFlag(FileAttributes.ReadOnly);

        public bool Contains(string str)
        {
            // TODO: rewrite for better performance
            return System.IO.File.ReadAllText(path).Contains(str);
        }

        public override string ToString()
        {
            return path;
        }
    }
}

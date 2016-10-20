using System.IO;

namespace Tongs.ContentProviders
{
    class FileContentProvider : IContentProvider
    {
        public bool IsAcceptableLocation(string location)
        {
            return File.Exists(location);
        }

        public string GetContent(string location)
        {
            return File.ReadAllText(location);
        }
    }
}

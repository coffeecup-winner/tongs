namespace Tongs.ContentProviders
{
    interface IContentProvider
    {
        bool IsAcceptableLocation(string location);
        string GetContent(string location);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tongs.ContentProviders
{
    class ContentProviderResolver
    {
        private readonly IReadOnlyList<IContentProvider> providers;

        public ContentProviderResolver()
        {
            providers = new List<IContentProvider> {
                new FileContentProvider()
            };
        }

        public IContentProvider Resolve(string location)
        {
            var matching = providers.Where(p => p.IsAcceptableLocation(location)).ToArray();
            if (matching.Length == 0)
            {
                throw new InvalidOperationException($"No content provider for '{location}'");
            }
            if (matching.Length > 1)
            {
                throw new InvalidOperationException($"More than one content provider for '{location}'");
            }
            return matching[0];
        }
    }
}

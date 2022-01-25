﻿using Umbraco.Cms.Core.Composing;
using uSeoToolkit.Umbraco.Common.Core.Interfaces;
using uSeoToolkit.Umbraco.Common.Core.Models.ViewModels;

namespace uSeoToolkit.Umbraco.Sitemap.Core.Common.DisplayProviders
{
    [Weight(100)]
    public class SitemapDocumentTypeDisplayProvider : IDisplayProvider
    {
        public SeoSettingsDisplayViewModel Get(int contentTypeId)
        {
            return new SeoSettingsDisplayViewModel
            {
                Name = "Sitemap",
                View = "/App_Plugins/uSeoToolkitSitemap/Displays/DocumentType/sitemapSettings.html"
            };
        }
    }
}

﻿using uSeoToolkit.Umbraco.Sitemap.Core.Interfaces;
using uSeoToolkit.Umbraco.Sitemap.Core.Models.Business;

namespace uSeoToolkit.Umbraco.Sitemap.Core.Services.SitemapService
{
    public class SitemapService : ISitemapService
    {
        private readonly ISitemapPageTypeRepository _sitemapPageTypeRepository;

        public SitemapService(ISitemapPageTypeRepository sitemapPageTypeRepository)
        {
            _sitemapPageTypeRepository = sitemapPageTypeRepository;
        }

        public void SetPageTypeSettings(SitemapPageSettings pageSettings)
        {
            _sitemapPageTypeRepository.Set(pageSettings);
        }

        public SitemapPageSettings GetPageTypeSettings(int contentTypeId)
        {
            return _sitemapPageTypeRepository.Get(contentTypeId);
        }
    }
}

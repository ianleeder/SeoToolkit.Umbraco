﻿using System.Collections.Generic;
using System.Linq;
using uSeoToolkit.Umbraco.Common.Core.Models;

namespace uSeoToolkit.Umbraco.Common.Core.Collections
{
    public class ModuleCollection
    {
        private readonly List<SeoToolkitModule> _items;

        public ModuleCollection()
        {
            _items = new List<SeoToolkitModule>
            {
                new SeoToolkitModule{Title = "Meta Fields", Alias = "metaFields", Icon = "icon-thumbnail-list", Link = "https://github.com/patrickdemooij9/uSeoToolkit.Umbraco"},
                new SeoToolkitModule{Title = "Script Manager", Alias = "scriptManager", Icon = "icon-script", Link = "https://github.com/patrickdemooij9/uSeoToolkit.Umbraco"},
                new SeoToolkitModule{Title = "Sitemap", Alias = "sitemap", Icon = "icon-sitemap", Link = "https://github.com/patrickdemooij9/uSeoToolkit.Umbraco"},
                new SeoToolkitModule{Title = "Robots.txt", Alias = "robotsTxt", Icon = "icon-cloud", Link = "https://github.com/patrickdemooij9/uSeoToolkit.Umbraco"}
            };
        }

        public IEnumerable<SeoToolkitModule> GetAll() => _items;

        public void EnableModule(string alias)
        {
            var module = _items.FirstOrDefault(it => it.Alias == alias);
            if (module != null)
                module.Installed = true;
        }
    }
}
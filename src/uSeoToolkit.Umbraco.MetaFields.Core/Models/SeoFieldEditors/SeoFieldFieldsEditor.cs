﻿using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using uSeoToolkit.Umbraco.MetaFields.Core.Converters.EditorConverters;
using uSeoToolkit.Umbraco.MetaFields.Core.Interfaces.Converters;
using uSeoToolkit.Umbraco.MetaFields.Core.Interfaces.SeoField;

namespace uSeoToolkit.Umbraco.MetaFields.Core.Models.SeoFieldEditors
{
    public class SeoFieldFieldsEditor : ISeoFieldEditor
    {
        private readonly string[] _fieldTypes;
        public string View => "/App_Plugins/uSeoToolkitMetaFields/Interface/SeoFieldEditors/FieldsEditor/fieldsEditor.html";
        public Dictionary<string, object> Config => new Dictionary<string, object>
        {
            {"dataTypes", _fieldTypes}
        };

        public IEditorValueConverter ValueConverter { get; }

        public SeoFieldFieldsEditor(string[] fieldTypes)
        {
            _fieldTypes = fieldTypes;

            ValueConverter = new FieldValueConverter();
        }

        public string GetValue(IPublishedContent content, object value)
        {
            var aliases = value?.ToString()?.Split(',');
            if (aliases is null) return null;
            foreach (var alias in aliases)
            {
                var returnValue = content.Value(alias);
                if (returnValue is string stringValue && !string.IsNullOrWhiteSpace(stringValue))
                    return stringValue;
                if (returnValue is IPublishedContent publishedContent)
                    return publishedContent.Url(mode: UrlMode.Absolute);
                if (returnValue is IEnumerable<IPublishedContent> publishedContents)
                    return publishedContents.FirstOrDefault().Url(mode: UrlMode.Absolute);
            }

            return null;
        }
    }
}

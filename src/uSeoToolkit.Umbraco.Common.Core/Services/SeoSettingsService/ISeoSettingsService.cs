﻿namespace uSeoToolkit.Umbraco.Common.Core.Services.SeoSettingsService
{
    public interface ISeoSettingsService
    {
        bool IsEnabled(int contentTypeId);
        void ToggleSeoSettings(int contentTypeId, bool value);
    }
}

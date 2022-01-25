﻿using System;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using uSeoToolkit.Umbraco.Common.Core.Migrations;

namespace uSeoToolkit.Umbraco.Common.Core.Components
{
    public class SeoSettingsDatabaseComponent : IComponent
    {
        private readonly IMigrationPlanExecutor _planExecutor;
        private readonly IScopeProvider _scopeProvider;
        private readonly IKeyValueService _keyValueService;
        private readonly IRuntimeState _runtimeState;

        public SeoSettingsDatabaseComponent(IMigrationPlanExecutor planExecutor, IScopeProvider scopeProvider, IKeyValueService keyValueService, IRuntimeState runtimeState)
        {
            _planExecutor = planExecutor;
            _scopeProvider = scopeProvider;
            _keyValueService = keyValueService;
            _runtimeState = runtimeState;
        }

        public void Initialize()
        {
            if (_runtimeState.Level != RuntimeLevel.Run) return;

            var plan = new MigrationPlan("uSeoToolkit_Common_Migration");
            plan.From(string.Empty)
                .To<SeoSettingsInitialMigration>("state-1");

            var upgrader = new Upgrader(plan);
            upgrader.Execute(_planExecutor, _scopeProvider, _keyValueService);
        }

        public void Terminate()
        {
        }
    }
}

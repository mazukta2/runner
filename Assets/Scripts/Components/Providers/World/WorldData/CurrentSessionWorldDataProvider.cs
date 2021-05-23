using Assets.Scripts.Components.Providers.Common.Services;
using Assets.Scripts.Data.World;
using Assets.Scripts.Models.Services.Sessions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Providers.World
{
    // get current world from session
    public class CurrentSessionWorldDataProvider : WorldDataProvider
    {
        private ServiceSystemKeeper _serviceProvider = new ServiceSystemKeeper();

        public override WorldData Get() => _serviceProvider
            .GetServices().Get<SessionService>().WorldData;

    }
}
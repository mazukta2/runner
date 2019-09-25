using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class WorldSelector : ListSelector<WorldData, World>
    {
        [SerializeField] private WorldsSettingsData _WorldsSettings;

        protected override ListDataElement[] GetList()
        {
            return _WorldsSettings.Worlds.Select(x =>
                new ListDataElement
                {
                    Data = x,
                    Prefab = x.MenuPrefab,
                }
            ).ToArray();
        }
    }
}


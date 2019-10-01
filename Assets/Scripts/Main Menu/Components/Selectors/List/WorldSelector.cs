using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class WorldSelector : ListSelector<WorldData, MenuWorld>
    {
        [SerializeField] private SessionProvider _Session;
        [SerializeField] private WorldsSettingsData _WorldsSettings;

        public override WorldData CurrentElementData
        {
            get => _Session.Instance.World;
            protected set => _Session.Instance.World = value;
        }

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


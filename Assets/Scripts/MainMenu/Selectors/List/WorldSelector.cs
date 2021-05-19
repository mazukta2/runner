using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.MainMenu.Selectors;
using Game;
using Assets.Scripts.MainMenu.Providers;

namespace Assets.Scripts.MainMenu.Selectors.List
{
    public abstract class WorldSelector : MainMenuListSelector<WorldData, MenuWorld>
    {
        //[SerializeField] private MainMenuPreSessionProvider _session;
        //[SerializeField] private WorldsSettingsData _worldsSettings;

        //public override WorldData CurrentElement
        //{
        //    get => _session.Instance.World;
        //    protected set => _session.Instance.World = value;
        //}

        //protected override ListDataElement[] GetList()
        //{
        //    return _WorldsSettings.Worlds.Select(x =>
        //        new ListDataElement
        //        {
        //            Data = x,
        //            Prefab = x.MenuPrefab,
        //        }
        //    ).ToArray();
        //}
    }
}


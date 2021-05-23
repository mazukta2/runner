using UnityEngine;
using Assets.Scripts.Components.Providers.Sessions;
using Assets.Scripts.Components.Providers.World;

namespace Assets.Scripts.Components.Ui.MainMenu.Selectors
{
    // Selecting world in main menu
    [RequireComponent(typeof(MainMenuListSelector))]
    public class WorldSelector : MonoBehaviour
    {
        [SerializeField] private PreSessionProvider.Field _preSessionProvider;
        [SerializeField] private WorldDataListProvider.Field _worldsListProviders;

        private MainMenuListSelector _selector;

        protected void Awake()
        {
            _selector = GetComponent<MainMenuListSelector>();
            _selector.Init(0, _worldsListProviders.Get().Length, UpdatePreSession, GetModel);
        }

        private void UpdatePreSession()
        {
            _preSessionProvider.Get().SetWorld(_worldsListProviders.Get()[_selector.Index]);
        }

        private GameObject GetModel(int index)
        {
            return _worldsListProviders.Get()[index].MainMenuView;
        }
    }
}


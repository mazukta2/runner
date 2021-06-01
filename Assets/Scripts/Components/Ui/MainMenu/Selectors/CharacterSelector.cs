using UnityEngine;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Components.Providers.Sessions;

namespace Assets.Scripts.Components.Ui.MainMenu.Selectors
{
    // Selecting character in main menu
    [RequireComponent(typeof(MainMenuListSelector))]
    public class CharacterSelector : MonoBehaviour
    {
        [SerializeField] private PreSessionProvider.Field _preSessionProvider;
        [SerializeField] private CharacterDataListProvider.Field _charactersProvider;
        [SerializeField] private PreSessionProvider.Field2 _preSessionProvider2;

        private MainMenuListSelector _selector;

        protected void Awake()
        {
            _selector = GetComponent<MainMenuListSelector>();
            _selector.Init(0, _charactersProvider.Get().Length, UpdatePreSession, GetViewPrefab);
        }

        private void UpdatePreSession()
        {
            _preSessionProvider.Get().SetCharacter(_charactersProvider
                .Get()[_selector.Index]);
        }

        private GameObject GetViewPrefab(int index)
        {
            return _charactersProvider.Get()[index].MainMenuView;
        }

    }
}


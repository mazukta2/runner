using UnityEngine;
using System.Collections;

namespace Game
{
    public class Session : MonoBehaviour
    {
        public CharacterData Character { get => _Character; set => _Character = value; }
        public WorldData World { get => _World; set => _World = value; }

        [SerializeField] private SessionProvidersListData _Providers;
        [SerializeField] private CharacterData _Character;
        [SerializeField] private WorldData _World;

        private void Awake()
        {
            foreach (var provider in _Providers.Instance.List)
                provider.Instance = this;
            _Providers.Instance.OnRegister += Instance_OnRegister; 
        }

        private void OnDestroy()
        {
            _Providers.Instance.OnRegister -= Instance_OnRegister;
        }

        private void Instance_OnRegister(object sender, System.EventArgs e)
        {
            var provider = (SessionProvider)sender;
            provider.Instance = this;
        }
    }
}


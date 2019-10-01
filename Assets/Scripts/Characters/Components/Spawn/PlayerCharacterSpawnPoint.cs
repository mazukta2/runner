using UnityEngine;
using System.Collections;

namespace Game
{
    public class PlayerCharacterSpawnPoint : MonoBehaviour
    {
        [SerializeField] private SceneInit _Init;
        [SerializeField] private SessionProvider _SessionProvider;
        [SerializeField] private CharacterControllerProvider _CharacterProvider;

        protected void Awake()
        {
            if (_Init.IsFullyLoaded)
                Init();
            else
                _Init.OnLoaded += _Init_OnLoaded;
        }

        protected void OnDestroy()
        {
            _Init.OnLoaded -= _Init_OnLoaded;
        }

        private void _Init_OnLoaded(object sender, System.EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            _CharacterProvider.Controller =
                _SessionProvider.Instance
                .Character.CreateController(gameObject,
                _SessionProvider.Instance.World);
        }
    }
}

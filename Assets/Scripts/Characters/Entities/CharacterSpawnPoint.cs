using UnityEngine;
using System.Collections;

namespace Game
{
    public class CharacterSpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameData _Game;
        [SerializeField] private CharacterCamera _Camera;

        public void Start()
        {
            var controllerGo = new GameObject("Character Controller", typeof(CharacterMover));
            controllerGo.transform.SetParent(transform);
            var viewGo = Instantiate(_Game.Instance.Session.StartCharacter.ViewPrefab.gameObject, controllerGo.transform);
            var view = viewGo.GetComponent<CharacterView>();
            view.Init(_Game.Instance.Session.StartCharacter);
            controllerGo.GetComponent<CharacterMover>().View = view;

            _Camera.Character = viewGo;
        }
    }
}

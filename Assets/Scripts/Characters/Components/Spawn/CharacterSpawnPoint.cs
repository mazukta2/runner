using UnityEngine;
using System.Collections;

namespace Game
{
    public class CharacterSpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameData _Game;
        [SerializeField] private CharacterCamera _Camera;
        [SerializeField] private PlayerCharacterController _ControllerPrefab;

        public void Start()
        {
            var controllerGo = Instantiate(_ControllerPrefab, transform);
            controllerGo.transform.SetParent(transform);

            var viewGo = Instantiate(_Game.Instance.Character.Prefab.gameObject, controllerGo.transform);
            var character = viewGo.GetComponent<Character>();
            character.Data = _Game.Instance.Character;

            controllerGo.GetComponent<PlayerCharacterController>().Character = character;

            _Camera.Target = viewGo;
        }
    }
}

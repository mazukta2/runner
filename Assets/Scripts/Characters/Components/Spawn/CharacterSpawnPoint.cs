using UnityEngine;
using System.Collections;

namespace Game
{
    public class CharacterSpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameData _Game;
        [SerializeField] private CharacterCamera _Camera;
        [SerializeField] private PlayerCharacterController _ControllerPrefab;
        [SerializeField] private FailDetector _FailDetector;
        [SerializeField] private CharacterSpeed _SpeedDetector;
        [SerializeField] private CharacterJumpButton _JumpButton;

        public void Start()
        {
            var controllerGo = Instantiate(_ControllerPrefab, transform);
            controllerGo.transform.SetParent(transform);

            var viewGo = Instantiate(_Game.Instance.Character.Prefab.gameObject, controllerGo.transform);
            var character = viewGo.GetComponent<Character>();
            character.Data = _Game.Instance.Character;
            viewGo.GetComponent<PhysicObject>().Settings = _Game.Instance.World.Physics;

            controllerGo.GetComponent<PlayerCharacterController>().Character = character;
            
            _Camera.Target = viewGo;

            if (_FailDetector)
                _FailDetector.Character = character;

            if (_SpeedDetector)
                _SpeedDetector.Character = viewGo.GetComponent<PhysicObject>();

            _JumpButton.Character = controllerGo.GetComponent<PlayerCharacterMover>();
        }
    }
}

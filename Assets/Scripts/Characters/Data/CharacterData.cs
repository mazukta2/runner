using UnityEngine;

namespace Game
{
    // Describe combination of logic, settings and visual representations for
    // a character. 
    [CreateAssetMenu(menuName = "Game/Characters/Character")]
    public class CharacterData : ScriptableObject
    {
        public CharacterModel Model => _Model;

        [SerializeField] GameCharacterController _Controller;
        [SerializeField] CharacterModel _Model;

        // public MovementRuleData MovementRule => _Movement;
        //[SerializeField] MovementRuleData _Movement;

        public GameCharacterController CreateController(GameObject parent, WorldData world)
        {
            var model = CreateModel(parent, world.Physics);
            var controller = CreateController(parent, model);
            return controller;
        }

        public CharacterModel CreateModel(GameObject parent, PhysicSettingsData physics)
        {
            var modelGo = Instantiate(_Model.gameObject, parent.transform);
            var model = modelGo.GetComponent<CharacterModel>();
            model.Physics.Settings = physics;
            return model;
        }

        private GameCharacterController CreateController(GameObject parent, CharacterModel model)
        {
            var controllerGo = Instantiate(_Controller.gameObject, parent.transform);
            var controller = controllerGo.GetComponent<GameCharacterController>();
            controller.Model = model;

            return controller;
        }
    }

}

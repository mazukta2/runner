using Assets.Scripts.Components.Characters;
using Assets.Scripts.Data.Physics;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Services
{
    public class CharacterControlsService : IService
    {
        private Character _mainCharacter;
        private UpdaterService _updater;
        private bool _jumpRequested;

        public CharacterControlsService(Character mainCharacter, UpdaterService updater)
        {
            _mainCharacter = mainCharacter;
            _updater = updater;

            _updater.AddUpdater(Update);
        }

        protected void Update()
        {
            _mainCharacter.Data.Movement.Move(_mainCharacter, _jumpRequested);
            _jumpRequested = false;
        }

        public void Jump()
        {
            _jumpRequested = true;
        }
    }
}

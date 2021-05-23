using Game;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    public abstract class WorldProvider : MonoBehaviour
    {
        public abstract WorldData Get();
    }
}
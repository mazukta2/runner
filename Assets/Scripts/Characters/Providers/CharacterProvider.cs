using Assets.Scripts.Characters.Services;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    public abstract class CharacterProvider : MonoBehaviour
    {
        public abstract Character Get();
    }
}
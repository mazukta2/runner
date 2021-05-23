using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    public abstract class CharacterDataListProvider : MonoBehaviour
    {
        public abstract CharacterData[] Get();
    }
}
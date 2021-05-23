using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Components.World.Spawners
{
    // basic element of endless line
    public abstract class EndlessLineElement : MonoBehaviour
    {
        public abstract void Replaced();
    }
}
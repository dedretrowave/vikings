using System;
using UnityEngine;

namespace Core.Building.View
{
    public class BuildingView : MonoBehaviour, ICharacterTarget
    {
        public event Action TryBuild;

        public Transform GeTransform() => transform;

        public void TryInteract()
        {
            TryBuild?.Invoke();
        }

        public void ShowProgression()
        {
            Debug.Log("BUILDING!!!!");
        }
    }
}
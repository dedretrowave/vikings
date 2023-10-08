using System;
using Core.Character.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Building.View
{
    public class BuildingView : MonoBehaviour, ICharacterTarget
    {
        public event Action TryBuild;

        public Vector3 GetPosition()
        {
            return transform.position;
        }

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
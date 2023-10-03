using System;
using UnityEngine;

namespace Core.Building.View
{
    public class BuildingView : MonoBehaviour
    {
        public event Action TryBuild;

        public void OnTryBuild()
        {
            TryBuild?.Invoke();
        }

        public void ShowProgression()
        {
            Debug.Log("BUILDING!!!!");
        }
    }
}
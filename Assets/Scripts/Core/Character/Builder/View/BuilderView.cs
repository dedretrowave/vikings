using System;
using Core.Building.View;
using UnityEngine;

namespace Core.Character.Builder.View
{
    public class BuilderView : MonoBehaviour
    {
        public event Action<BuildingView> FoundBuilding;
        public event Action<BuildingView> LeftBuilding;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out BuildingView building)) return;
            
            FoundBuilding?.Invoke(building);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out BuildingView building)) return;
            
            LeftBuilding?.Invoke(building);
        }
    }
}
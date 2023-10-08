using System;
using Core.Character.Interfaces;
using UnityEngine;

namespace Core.Character
{
    public class TargetInteractionView : MonoBehaviour
    {
        public event Action<ICharacterTarget> Found;
        public event Action<ICharacterTarget> Left;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ICharacterTarget site)) return;
            
            Found?.Invoke(site);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out ICharacterTarget site)) return;
            
            Left?.Invoke(site);
        }
    }
}
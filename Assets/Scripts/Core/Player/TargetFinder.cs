using System;
using UnityEngine;

namespace Core.Player
{
    public class TargetFinder : MonoBehaviour
    {
        public event Action<ICharacterTarget> Found;
        public event Action Left;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ICharacterTarget interactable)) return;
            
            Found?.Invoke(interactable);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out ICharacterTarget _)) return;
            
            Left?.Invoke();
        }
    }
}
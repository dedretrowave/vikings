using UnityEngine;

namespace Core
{
    public interface ICharacterTarget
    {
        Vector3 GetInteractZone();
        
        void TryInteract();
    }
}
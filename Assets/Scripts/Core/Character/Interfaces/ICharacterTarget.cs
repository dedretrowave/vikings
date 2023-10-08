using UnityEngine;

namespace Core.Character.Interfaces
{
    public interface ICharacterTarget
    {
        Vector3 GetPosition();
        
        void TryInteract();
    }
}
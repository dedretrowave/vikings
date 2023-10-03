using UnityEngine;

namespace Core
{
    public interface ICharacterTarget
    {
        Transform GeTransform();
        
        void TryInteract();
    }
}
using System;
using UnityEngine;

namespace Core.Character.Helpers
{
    public class CharacterFinder : MonoBehaviour
    {
        public event Action<Character> Found;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Character character)) return;
            Found?.Invoke(character);
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Player.CharacterGroup.Model
{
    public class CharacterGroupModel
    {
        private Dictionary<Character.Character, Transform> _charactersPoints;
        private CharacterGroupSettings _settings;

        public CharacterGroupModel(CharacterGroupSettings settings)
        {
            _settings = settings;
            _charactersPoints = new();
        }

        public Transform AddAndReturnPlace(Character.Character character)
        {
            Transform place = _settings.Places[_charactersPoints.Count];

            _charactersPoints.Add(character, place);
            return place;
        }

        public bool Contains(Character.Character character)
        {
            return _charactersPoints.ContainsKey(character);
        }

        public void ForEach(Action<Character.Character> callback)
        {
            foreach ((Character.Character character, Transform _) in _charactersPoints)
            {
                callback(character);
            }
        }

        public void ForEach(Action<Character.Character, Transform> callback)
        {
            foreach ((Character.Character character, Transform place) in _charactersPoints)
            {
                callback(character, place);
            }
        }
    }
    
    [Serializable]
    public class CharacterGroupSettings
    {
        [SerializeField] private List<Transform> _places;

        public List<Transform> Places => new(_places);
    }
}
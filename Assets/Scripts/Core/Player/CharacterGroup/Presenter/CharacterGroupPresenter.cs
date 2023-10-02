using System;
using Core.Player.CharacterGroup.Model;
using UnityEngine;

namespace Core.Player.CharacterGroup.Presenter
{
    public class CharacterGroupPresenter
    {
        private CharacterGroupModel _model;

        public CharacterGroupPresenter(CharacterGroupSettings settings)
        {
            _model = new(settings);
        }

        public void Add(Character.Character character)
        {
            Transform place = _model.AddAndReturnPlace(character);
            character.transform.SetParent(place);
            character.Move(Vector3.zero);
        }

        public void InvokeForEach(Action<Character.Character> callback)
        {
            _model.ForEach(callback);
        }

        public bool Contains(Character.Character character)
        {
            return _model.Contains(character);
        }
    }
}
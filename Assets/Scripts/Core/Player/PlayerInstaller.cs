using Core.Character.Helpers;
using Core.Character.Movement.Presenter;
using Core.Player.CharacterGroup.Model;
using Core.Player.CharacterGroup.Presenter;
using Core.Player.Movement.View;
using UnityEngine;

namespace Core.Player
{
    public class PlayerInstaller : MonoBehaviour
    {
        
        [SerializeField] private CharacterGroupSettings _characterGroupSettings;
        [SerializeField] private CharacterFinder _characterFinder;

        [SerializeField] private float _moveSpeed = 200f;
        [SerializeField] private MovementView _movementView;
        
        private Input.Input _input;

        private CharacterGroupPresenter _characterGroup;
        private MovementPresenter _movement;

        public void Construct()
        {
            _input = new();

            _characterGroup = new(_characterGroupSettings);
            _characterGroup.InvokeForEach(InitCharacter);

            _movement = new(_movementView, _moveSpeed);

            _input.Move += _movement.Move;
            _characterFinder.Found += AddCharacter;
        }

        public void Disable()
        {
            _characterGroup.InvokeForEach(DisableCharacter);
            
            _input.Move -= _movement.Move;
            _characterFinder.Found -= AddCharacter;
            
            _input.Disable();
        }

        private void AddCharacter(Character.Character character)
        {
            if (_characterGroup.Contains(character)) return;

            _characterGroup.Add(character);
            InitCharacter(character);
        }

        private void InitCharacter(Character.Character character)
        {
            _input.Move += character.Move;
        }

        private void DisableCharacter(Character.Character character)
        {
            _input.Move -= character.Move;
        }
    }
}
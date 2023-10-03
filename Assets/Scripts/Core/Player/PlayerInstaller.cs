using Core.Character.Helpers;
using Core.Player.CharacterGroup.Model;
using Core.Player.CharacterGroup.Presenter;
using UnityEngine;

namespace Core.Player
{
    public class PlayerInstaller : MonoBehaviour
    {
        
        [SerializeField] private CharacterGroupSettings _characterGroupSettings;
        [SerializeField] private CharacterFinder _characterFinder;
        [SerializeField] private TargetFinder _interactableFinder;
        [SerializeField] private Character.Character _initialCharacter;

        private Input.Input _input;

        private CharacterGroupPresenter _characterGroup;

        public void Construct()
        {
            _input = new();
            
            _characterGroup = new(_characterGroupSettings);
            _characterGroup.Add(_initialCharacter);
            InitCharacter(_initialCharacter);
            _characterGroup.InvokeForEach(InitCharacter);

            _interactableFinder.Found += AssignCharacters;
            _interactableFinder.Left += ReturnCharacters;
            _characterFinder.Found += AddCharacter;
        }

        public void Disable()
        {
            _characterGroup.InvokeForEach(DisableCharacter);
            
            _interactableFinder.Found -= AssignCharacters;
            _interactableFinder.Left -= ReturnCharacters;
            _characterFinder.Found -= AddCharacter;
            
            _input.Disable();
        }

        private void AssignCharacters(ICharacterTarget site)
        {
            _characterGroup.AssignToPointAll(site.GeTransform());
        }

        private void ReturnCharacters()
        {
            _characterGroup.AssignToBasePointsAll();
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
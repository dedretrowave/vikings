using Core.Character.Excavation.Presenter;
using Core.Character.Excavation.View;
using Core.Character.Movement.View;
using UnityEngine;

namespace Core.Character
{
    public class Character : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] private CharacterMovementView _movement;
        [SerializeField] private ExcavationView _excavationView;

        private ExcavationPresenter _excavation;

        private void Start()
        {
            _excavation = new(_excavationView);
        }

        public void Move(Vector3 point)
        {
            _movement.Move(point);
        }
    }
}
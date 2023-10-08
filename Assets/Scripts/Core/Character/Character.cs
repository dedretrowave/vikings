using Core.Character.Builder.Presenter;
using Core.Character.Builder.View;
using Core.Character.Excavation.Presenter;
using Core.Character.Excavation.View;
using Core.Character.Movement.Presenter;
using Core.Character.Movement.View;
using UnityEngine;

namespace Core.Character
{
    public class Character : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] private MovementView _movementView;
        [SerializeField] private ExcavationView _excavationView;
        [SerializeField] private BuilderView _builderView;

        private MovementPresenter _movement;
        private ExcavationPresenter _excavation;
        private BuilderPresenter _builder;

        private void Awake()
        {
            _movement = new(_movementView);
            _excavation = new(_excavationView);
            _builder = new(_builderView);
        }

        public void Move(Vector3 direction)
        {
            _movement.Move(direction);
        }

        public void MoveToTarget(Vector3 point)
        {
            _movement.MoveToTargetPoint(point);
        }

        public void MoveToBasePoint(Transform point)
        {
            _movement.MoveToBasePoint(point);
        }
    }
}
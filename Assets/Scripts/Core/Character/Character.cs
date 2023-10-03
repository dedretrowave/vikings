using Core.Character.Builder.Presenter;
using Core.Character.Builder.View;
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
        [SerializeField] private BuilderView _builderView;

        private ExcavationPresenter _excavation;
        private BuilderPresenter _builder;

        private void Start()
        {
            _excavation = new(_excavationView);
            _builder = new(_builderView);
        }

        public void Move(Vector3 point)
        {
            _movement.Move(point);
        }
    }
}
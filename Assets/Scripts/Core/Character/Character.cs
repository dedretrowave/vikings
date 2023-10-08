using Core.Building.View;
using Core.Character.Builder.Presenter;
using Core.Character.Combat.Presenter;
using Core.Character.Excavation.Presenter;
using Core.Character.Health.Model;
using Core.Character.Health.Presenter;
using Core.Character.Health.View;
using Core.Character.Interfaces;
using Core.Character.Movement.Presenter;
using Core.Character.Movement.View;
using Core.Excavation.Site.View;
using UnityEngine;

namespace Core.Character
{
    public class Character : MonoBehaviour, IDamageable
    {
        [Header("Settings")]
        [SerializeField] private HealthSettings _healthSettings;
        [Header("Views")]
        [SerializeField] private MovementView _movementView;
        [SerializeField] private TargetInteractionView _excavationView;
        [SerializeField] private TargetInteractionView _builderView;
        [SerializeField] private TargetInteractionView _combatView;
        [SerializeField] private HealthView _healthView;

        private MovementPresenter _movement;
        private ExcavationPresenter _excavation;
        private BuilderPresenter _builder;
        private HealthPresenter _health;
        private CombatPresenter<Enemy> _combat;

        private void OnEnable()
        {
            _movement = new(_movementView);
            _excavation = new(_excavationView);
            _builder = new(_builderView);
            _health = new(_healthView, _healthSettings);
            _combat = new(_combatView);

            _health.OutOfHealth += OnOutOfHealth;
        }

        private void OnDisable()
        {
            Disable();
        }

        private void Disable()
        {
            _movement = null;
            _excavation = null;
            _builder = null;
            _health = null;
            _combat = null;

            _health.OutOfHealth -= OnOutOfHealth;
        }

        private void OnOutOfHealth()
        {
            Disable();
            Debug.Log($"{name} IS DEAD(((");
            
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

        public void TakeDamage()
        {
            _health.Reduce();
        }
    }
}
using System;
using Core.Character.Combat.Presenter;
using Core.Character.Health.Model;
using Core.Character.Health.Presenter;
using Core.Character.Health.View;
using Core.Character.Interfaces;
using UnityEngine;

namespace Core.Character
{
    public class Enemy : MonoBehaviour, ICharacterTarget, IDamageable
    {
        [SerializeField] private HealthSettings _healthSettings;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private TargetInteractionView _combatView;

        private HealthPresenter _health;
        private CombatPresenter<Character> _combat;

        private void OnEnable()
        {
            _health = new(_healthView, _healthSettings);
            _combat = new(_combatView);
            
            _health.OutOfHealth += OnOutOfHealth;
        }

        private void OnDisable()
        {
            _health.OutOfHealth -= OnOutOfHealth;
        }

        public void TakeDamage()
        {
            _health.Reduce();
        }

        private void OnOutOfHealth()
        {
            _combat = null;
            Debug.Log($"{name} IS DEAD(((");
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void TryInteract()
        {
            _health.Reduce();
        }
    }
}
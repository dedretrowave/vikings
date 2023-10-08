using System;
using UnityEngine;

namespace Core.Character.Health.Model
{
    public class HealthModel
    {
        private float _health;
        private float _maxHealth;
        private float _fullRegenTimeout;

        public float Health => _health;
        public float FullRegenTimeout => _fullRegenTimeout;
        public float MaxHealth => _maxHealth;

        public HealthModel(HealthSettings settings)
        {
            _health = settings.MaxHealth;
            _maxHealth = settings.MaxHealth;
            _fullRegenTimeout = settings.FullRegenTimeoutInSecs;
        }

        public void Reduce(float amount = 1)
        {
            float reduced = _health - amount;

            if (reduced < 0)
            {
                _health = 0;
                throw new Exception("OUT OF HEALTH");
            }

            _health = reduced;
        }

        public void FullRegen()
        {
            _health = _maxHealth;
        }
    }

    [Serializable]
    public class HealthSettings
    {
        [SerializeField] private float _maxHealth = 2f;
        [SerializeField] private float _fullRegenTimeoutInSecs = 10f;

        public float MaxHealth => _maxHealth;
        public float FullRegenTimeoutInSecs => _fullRegenTimeoutInSecs;
    }
}
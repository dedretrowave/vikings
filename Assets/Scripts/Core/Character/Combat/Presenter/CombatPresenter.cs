using System.Threading.Tasks;
using Core.Character.Interfaces;
using Core.Excavation.Site.View;
using UnityEngine;

namespace Core.Character.Combat.Presenter
{
    public class CombatPresenter<T> where T : IDamageable
    {
        private TargetInteractionView _view;

        private T _currentEnemy;

        public CombatPresenter(TargetInteractionView view)
        {
            _view = view;

            _view.Found += OnFound;
            _view.Left += OnLeft;
        }

        ~CombatPresenter()
        {
            _view.Found -= OnFound;
            _view.Left -= OnLeft;
        }

        private void OnFound(ICharacterTarget target)
        {
            Debug.Log(target.GetType());
            if (target is not T enemy) return;

            _currentEnemy = enemy;
            AttackContinuously();
        }

        private void OnLeft(ICharacterTarget target)
        {
            if (target is not T enemy) return;
            
            if (enemy.Equals(_currentEnemy))
            {
                _currentEnemy = default;
            }
        }

        private async void AttackContinuously()
        {
            try
            {
                if (_currentEnemy == null)
                {
                    return;
                }
                
                _currentEnemy.TakeDamage();
                await Task.Delay(GlobalSettings.DELAY_BETWEEN_ENEMY_INTERACTION_IN_MSECS);
                AttackContinuously();
            }
            catch
            {
                // ignored
            }
        }
    }
}
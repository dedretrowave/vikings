using System;
using System.Threading.Tasks;
using Core.Character.Health.Model;
using Core.Character.Health.View;

namespace Core.Character.Health.Presenter
{
    public class HealthPresenter
    {
        private HealthModel _model;
        private HealthView _view;

        public event Action OutOfHealth;

        public HealthPresenter(HealthView view, HealthSettings settings)
        {
            _model = new(settings);

            _view = view;
            _view.Init(_model.MaxHealth);
        }

        public void Reduce(float amount = 1)
        {
            try
            {
                _model.Reduce(amount);
            }
            catch
            {
                OutOfHealth?.Invoke();
            }
            finally
            {
                _view.Set(_model.Health);
            }
        }
        
        private void Regen()
        {
            _model.FullRegen();
            _view.Set(_model.Health);
        }

        private async void RegenAfterTimeout()
        {
            await Task.Delay((int) (_model.FullRegenTimeout * GlobalSettings.SECS_TO_MILLISECS));
            Regen();
        }
    }
}
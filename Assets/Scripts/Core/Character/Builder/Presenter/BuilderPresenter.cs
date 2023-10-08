using System.Threading.Tasks;
using Core.Building.View;
using Core.Character.Interfaces;

namespace Core.Character.Builder.Presenter
{
    public class BuilderPresenter
    {
        private TargetInteractionView _view;

        private BuildingView _currentBuilding;

        public BuilderPresenter(TargetInteractionView view)
        {
            _view = view;

            _view.Found += OnFound;
            _view.Left += OnLeft;
        }

        ~BuilderPresenter()
        {
            _currentBuilding = null;
            _view.Found -= OnFound;
            _view.Left -= OnLeft;
        }

        private void OnFound(ICharacterTarget target)
        {
            if (target is not BuildingView building) return;
            
            _currentBuilding = building;
            BuildContinuously();
        }

        private void OnLeft(ICharacterTarget target)
        {
            if (target is not BuildingView building) return;
            
            if (_currentBuilding != null && _currentBuilding.Equals(building))
            {
                _currentBuilding = null;
            }
        }

        private async void BuildContinuously()
        {
            try
            {
                if (_currentBuilding == null)
                {
                    return;
                }
                
                _currentBuilding.TryInteract();
                await Task.Delay(GlobalSettings.DELAY_BETWEEN_BUILD_INTERACTION_IN_MSECS);
                BuildContinuously();
            }
            catch
            {
                _currentBuilding = null;
            }
        }
    }
}
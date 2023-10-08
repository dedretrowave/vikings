using System.Threading.Tasks;
using Core.Building.View;
using Core.Character.Builder.View;

namespace Core.Character.Builder.Presenter
{
    public class BuilderPresenter
    {
        private BuilderView _view;

        private BuildingView _currentBuilding;

        public BuilderPresenter(BuilderView view)
        {
            _view = view;

            _view.FoundBuilding += OnFound;
            _view.LeftBuilding += OnLeft;
        }

        ~BuilderPresenter()
        {
            _currentBuilding = null;
            _view.FoundBuilding -= OnFound;
            _view.LeftBuilding -= OnLeft;
        }

        private void OnFound(BuildingView building)
        {
            _currentBuilding = building;
            BuildContinuously();
        }

        private void OnLeft(BuildingView building)
        {
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
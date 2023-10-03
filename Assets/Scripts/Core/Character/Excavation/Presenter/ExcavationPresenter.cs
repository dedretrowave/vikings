using System.Threading.Tasks;
using Core.Character.Excavation.View;
using Core.Excavation.Site.View;

namespace Core.Character.Excavation.Presenter
{
    public class ExcavationPresenter
    {
        private ExcavationView _view;

        private ExcavationSiteView _currentSite;

        public ExcavationPresenter(ExcavationView view)
        {
            _view = view;

            _view.FoundSite += OnFoundSite;
            _view.LeftSite += OnLeftSite;
        }

        ~ExcavationPresenter()
        {
            _view.FoundSite -= OnFoundSite;
            _view.LeftSite -= OnLeftSite;
        }

        private void OnFoundSite(ExcavationSiteView site)
        {
            _currentSite = site;
            MineContinuously();
        }

        private void OnLeftSite(ExcavationSiteView site)
        {
            if (site.Equals(_currentSite))
            {
                _currentSite = null;
            }
        }

        private async void MineContinuously()
        {
            try
            {
                if (_currentSite == null)
                {
                    return;
                }
                
                _currentSite.TryInteract();
                await Task.Delay(GlobalSettings.DELAY_BETWEEN_MINE_INTERACTION_IN_MSECS);
                MineContinuously();
            }
            catch
            {
                // ignored
            }
        }
    }
}
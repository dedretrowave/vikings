using System.Threading.Tasks;
using Core.Character.Interfaces;
using Core.Excavation.Site.View;

namespace Core.Character.Excavation.Presenter
{
    public class ExcavationPresenter
    {
        private TargetInteractionView _view;

        private ExcavationSiteView _currentSite;

        public ExcavationPresenter(TargetInteractionView view)
        {
            _view = view;

            _view.Found += OnFoundSite;
            _view.Left += OnLeftSite;
        }

        ~ExcavationPresenter()
        {
            _view.Found -= OnFoundSite;
            _view.Left -= OnLeftSite;
        }

        private void OnFoundSite(ICharacterTarget target)
        {
            if (target is not ExcavationSiteView site) return;
            
            _currentSite = site;
            MineContinuously();
        }

        private void OnLeftSite(ICharacterTarget target)
        {
            if (target is not ExcavationSiteView site) return;
            
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
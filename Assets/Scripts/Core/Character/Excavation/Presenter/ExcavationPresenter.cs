using System;
using System.Threading.Tasks;
using Core.Character.Excavation.View;
using Core.Excavation.Resource;
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
        }

        ~ExcavationPresenter()
        {
            _view.FoundSite -= OnFoundSite;
        }

        private void OnFoundSite(ExcavationSiteView site)
        {
            _currentSite = site;
            MineContinuously();
        }

        private async void MineContinuously()
        {
            try
            {
                _currentSite.OnTryMine();
                await Task.Delay(1000);
                MineContinuously();
            }
            catch
            {
                // ignored
            }
        }
    }
}
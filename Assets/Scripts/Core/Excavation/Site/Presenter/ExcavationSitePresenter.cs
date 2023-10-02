using Core.Excavation.Site.Model;
using Core.Excavation.Site.View;

namespace Core.Excavation.Site.Presenter
{
    public class ExcavationSitePresenter
    {
        private ExcavationSiteModel _model;
        private ExcavationSiteView _view;

        public ExcavationSitePresenter(ExcavationSiteView view, ExcavationSiteSettings settings)
        {
            _model = new(settings);
            _view = view;

            _view.TryMine += GetResource;
        }

        ~ExcavationSitePresenter()
        {
            _view.TryMine -= GetResource;
        }

        private void GetResource()
        {
            _model.Decrease();
            _view.Mine(_model.Resource);
        }
    }
}
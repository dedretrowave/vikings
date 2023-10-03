using Core.Resources.Container.Model;
using Core.Resources.Container.View;

namespace Core.Resources.Container.Presenter
{
    public class ResourceContainerPresenter
    {
        private ResourceContainerModel _model;

        private ResourceContainerView _view;

        public ResourceContainerPresenter(ResourceContainerView view)
        {
            _model = new();

            _view = view;
        }

        public void Add(Resources.Resource.Resource resource)
        {
            _model.Add(resource);
            _view.Clear();
            _model.ForEach((resource, amount) =>
            {
                _view.Draw(resource, amount);
            });
        }

        public void Reduce(Resource.Resource resource)
        {
            _model.Decrease(resource);
            _view.Clear();
            _model.ForEach((resource, amount) =>
            {
                _view.Draw(resource, amount);
            });
        }
    }
}
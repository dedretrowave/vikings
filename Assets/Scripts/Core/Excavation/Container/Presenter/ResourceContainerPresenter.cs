using Core.Excavation.Container.Model;
using Core.Excavation.Container.View;

namespace Core.Excavation.Container.Presenter
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

        public void Add(Resource.Resource resource)
        {
            _model.Add(resource);
            _view.Clear();
            _model.ForEach((resource, amount) =>
            {
                _view.Draw(resource, amount);
            });
        }
    }
}
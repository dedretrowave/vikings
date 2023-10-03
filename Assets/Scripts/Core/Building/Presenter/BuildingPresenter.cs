using System;
using Core.Building.Model;
using Core.Building.View;
using Core.Resources.Container.Model;
using Core.Resources.Resource;

namespace Core.Building.Presenter
{
    public class BuildingPresenter
    {
        private BuildingModel _model;

        private BuildingView _view;

        public event Action<Resource> ResourceRequired;

        public BuildingPresenter(BuildingView view, ResourcesContainerSettings settings)
        {
            _model = new(settings);

            _view = view;

            _view.TryBuild += OnTryBuild;
        }

        ~BuildingPresenter()
        {
            _view.TryBuild -= OnTryBuild;
        }

        public void OnTryBuild()
        {
            if (_model.IsBuilt)
            {
                return;
            }
            
            _model.MarkBuilt();
            _model.ForEach((resource, _) =>
            {
                if (_model.GetAmount(resource) > 0)
                {
                    _model.MarkNotBuilt();
                    ResourceRequired?.Invoke(resource);
                }
            });
        }

        public void AddResource(Resource resource)
        {
            try
            {
                _model.Decrease(resource);
                _view.ShowProgression();
            }
            catch
            {
                // ignored
            }
        }
    }
}
using Core.Building.Presenter;
using Core.Building.View;
using Core.Resources.Container.Model;
using Core.Resources.Container.Presenter;
using Core.Resources.Resource;
using DI;
using UnityEngine;

namespace Core.Building
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private ResourcesContainerSettings _requiredResourcesSettings;
        [SerializeField] private BuildingView _view;

        private BuildingPresenter _presenter;
        private ResourceContainerPresenter _resourceContainer;

        private void Start()
        {
            _presenter = new(_view, _requiredResourcesSettings);

            _resourceContainer = 
                DependencyContext.Dependencies.Get<ResourceContainerPresenter>();

            _presenter.ResourceRequired += OnResourceRequired;
        }

        private void OnDisable()
        {
            _presenter.ResourceRequired -= OnResourceRequired;
        }

        private void OnResourceRequired(Resource resource)
        {
            try
            {
                _resourceContainer.Reduce(resource);
                _presenter.AddResource(resource);
            }
            catch
            {
                // ignored;
            }
        }
    }
}
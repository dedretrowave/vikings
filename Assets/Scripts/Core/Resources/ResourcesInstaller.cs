using Core.Resources.Container.Presenter;
using Core.Resources.Container.View;
using Core.Resources.Resource;
using DI;
using UnityEngine;

namespace Core.Resources
{
    public class ResourcesInstaller : MonoBehaviour
    {
        [SerializeField] private ResourceCollector _collector;
        [SerializeField] private ResourceContainerView _resourceContainerView;

        private ResourceContainerPresenter _resourceContainer;

        public void Construct()
        {
            _resourceContainer = new(_resourceContainerView);
            
            DependencyContext.Dependencies.Add(
                new(typeof(ResourceContainerPresenter), () => _resourceContainer));

            _collector.Pickup += _resourceContainer.Add;
        }

        public void Disable()
        {
            _collector.Pickup -= _resourceContainer.Add;
        }
    }
}
using Core.Excavation.Container.Presenter;
using Core.Excavation.Container.View;
using Core.Excavation.Resource;
using UnityEngine;

namespace Core.Excavation
{
    public class ExcavationInstaller : MonoBehaviour
    {
        [SerializeField] private ResourceCollector _collector;
        [SerializeField] private ResourceContainerView _resourceContainerView;

        private ResourceContainerPresenter _resourceContainer;

        public void Construct()
        {
            _resourceContainer = new(_resourceContainerView);

            _collector.Pickup += _resourceContainer.Add;
        }

        public void Disable()
        {
            _collector.Pickup -= _resourceContainer.Add;
        }
    }
}
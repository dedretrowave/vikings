using System.Collections.Generic;
using Core.Resources.Resource;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Resources.Container.View
{
    public class ResourceContainerView : MonoBehaviour
    {
        [SerializeField] private ResourceUI _uiPrefab;
        [SerializeField] private LayoutGroup _layout;

        private List<ResourceUI> _uis = new();

        public void Clear()
        {
            _uis.ForEach(ui => Destroy(ui.gameObject));
            _uis.Clear();
        }

        public void Draw(Resources.Resource.Resource resource, int amount)
        {
            ResourceUI ui = Instantiate(_uiPrefab, _layout.transform);
            
            ui.Show(resource.Icon, amount);

            _uis.Add(ui);
        }
    }
}
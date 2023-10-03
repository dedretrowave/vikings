using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Resources.Container.Model
{
    public class ResourceContainerModel
    {
        private Dictionary<string, ResourceItem> _resources;

        public ResourceContainerModel(ResourcesContainerSettings settings = null)
        {
            _resources = new();
            
            if (settings != null)
            {
                settings.Resources.ForEach(item =>
                {
                    string key = item.Resource.Key;
                    
                    _resources.Add(key, item);
                });

                return;
            }
        }

        public int GetAmount(Resources.Resource.Resource resource)
        {
            return _resources[resource.Key].Amount;
        }

        public void Decrease(Resources.Resource.Resource resource)
        {
            _resources[resource.Key].DecreaseAmount();
        }

        public void Add(Resources.Resource.Resource resource)
        {
            string key = resource.Key;

            if (!_resources.ContainsKey(key))
            {
                _resources.Add(key, new(resource, 1));
                return;
            }
            
            _resources[key].IncreaseAmount();
        }

        public void ForEach(Action<Resources.Resource.Resource, int> callback)
        {
            foreach ((string _, ResourceItem item) in _resources)
            {
                callback(item.Resource, item.Amount);
            }
        }
    }

    [Serializable]
    public class ResourcesContainerSettings
    {
        [SerializeField] private List<ResourceItem> _resources;

        public List<ResourceItem> Resources => new(_resources);
    }

    [Serializable]
    public class ResourceItem
    {
        [SerializeField] private Resources.Resource.Resource _resource;
        [SerializeField] private int _amount;
        
        public Resources.Resource.Resource Resource => _resource;
        public int Amount => _amount;

        public ResourceItem(Resources.Resource.Resource resource, int amount)
        {
            _resource = resource;
            _amount = amount;
        }

        public void IncreaseAmount()
        {
            _amount++;
        }

        public void DecreaseAmount()
        {
            int newAmount = _amount - 1;

            if (newAmount < 0)
            {
                _amount = 0;
                throw new Exception($"{Resource.name} OUT OF STOCK");
            }

            _amount = newAmount;
        }
    }
}
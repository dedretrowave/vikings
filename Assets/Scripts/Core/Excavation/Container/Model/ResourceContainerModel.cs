using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Excavation.Container.Model
{
    public class ResourceContainerModel
    {
        private Dictionary<string, ResourceItem> _resources;

        public ResourceContainerModel()
        {
            _resources = new();
        }

        public int Get(Resource.Resource resource)
        {
            return _resources[resource.name].Amount;
        }

        public void Add(Resource.Resource resource)
        {
            string key = resource.name;

            if (!_resources.ContainsKey(key))
            {
                _resources.Add(key, new(resource, 1));
                return;
            }
            
            _resources[key].IncreaseAmount();
        }

        public void ForEach(Action<Resource.Resource, int> callback)
        {
            foreach ((string _, ResourceItem item) in _resources)
            {
                callback(item.Resource, item.Amount);
            }
        }
    }

    internal class ResourceItem
    {
        private Resource.Resource _resource;
        private int _amount;
        
        public Resource.Resource Resource => _resource;
        public int Amount => _amount;

        public ResourceItem(Resource.Resource resource, int amount)
        {
            _resource = resource;
            _amount = amount;
        }

        public void IncreaseAmount()
        {
            _amount++;
        }
    }
}
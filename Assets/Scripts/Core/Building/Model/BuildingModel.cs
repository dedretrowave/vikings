using System;
using System.Collections.Generic;
using Core.Resources.Container.Model;

namespace Core.Building.Model
{
    public class BuildingModel
    {
        private Dictionary<string, ResourceItem> _resources;

        private bool _isBuilt;

        public bool IsBuilt => _isBuilt;
        
        public BuildingModel(ResourcesContainerSettings settings = null)
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

        public void MarkBuilt()
        {
            _isBuilt = true;
        }

        public void MarkNotBuilt()
        {
            _isBuilt = false;
        }
        
        public int GetAmount(Resources.Resource.Resource resource)
        {
            return _resources[resource.Key].Amount;
        }

        public void Decrease(Resources.Resource.Resource resource)
        {
            _resources[resource.Key].DecreaseAmount();
        }
        
        public void ForEach(Action<Resources.Resource.Resource, int> callback)
        {
            foreach ((string _, ResourceItem item) in _resources)
            {
                callback(item.Resource, item.Amount);
            }
        }
    }
}
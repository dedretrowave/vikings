using System;
using UnityEngine;

namespace Core.Excavation.Site.Model
{
    public class ExcavationSiteModel
    {
        private Resources.Resource.Resource _resource;
        private int _amount;
        
        public Resources.Resource.Resource Resource => _resource;
        public int Amount => _amount;

        public ExcavationSiteModel(ExcavationSiteSettings settings)
        {
            _resource = settings.Resource;
            _amount = settings.Amount;
        }

        public void Decrease(int amount = 1)
        {
            int newAmount = _amount - amount;

            if (newAmount < 0)
            {
                _amount = 0;
                throw new Exception("NO MATERIAL LEFT");
            }

            _amount = newAmount;
        }
    }

    [Serializable]
    public class ExcavationSiteSettings
    {
        [SerializeField] private Resources.Resource.Resource _resource;
        [SerializeField] private int _amount;
        
        public Resources.Resource.Resource Resource => _resource;
        public int Amount => _amount;
    }
}
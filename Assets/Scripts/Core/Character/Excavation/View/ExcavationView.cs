using System;
using Core.Excavation.Site.View;
using UnityEngine;

namespace Core.Character.Excavation.View
{
    public class ExcavationView : MonoBehaviour
    {
        public event Action<ExcavationSiteView> FoundSite;
        public event Action<ExcavationSiteView> LeftSite;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ExcavationSiteView site)) return;
            
            FoundSite?.Invoke(site);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out ExcavationSiteView site)) return;
            
            LeftSite?.Invoke(site);
        }
    }
}
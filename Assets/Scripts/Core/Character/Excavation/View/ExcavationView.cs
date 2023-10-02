using System;
using Core.Excavation.Site.View;
using UnityEngine;

namespace Core.Character.Excavation.View
{
    public class ExcavationView : MonoBehaviour
    {
        public event Action<ExcavationSiteView> FoundSite;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ExcavationSiteView site)) return;
            
            FoundSite?.Invoke(site);
        }
    }
}
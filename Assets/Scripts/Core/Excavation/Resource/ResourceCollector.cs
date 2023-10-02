using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Excavation.Resource
{
    public class ResourceCollector : MonoBehaviour
    {
        [SerializeField] private Transform _sendPoint;
        
        public event Action<Resource> Pickup;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Resource resource)) return;
            
            Pickup?.Invoke(resource);
            resource.transform.DOMove(_sendPoint.position, GlobalSettings.RESOURCE_TWEEN_SPEED);
        }
    }
}
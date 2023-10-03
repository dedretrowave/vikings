using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Resources.Resource
{
    public class ResourceCollector : MonoBehaviour
    {
        [SerializeField] private Transform _sendPoint;
        
        public event Action<Resources.Resource.Resource> Pickup;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Resources.Resource.Resource resource)) return;
            
            Pickup?.Invoke(resource);
            resource.transform.DOMove(_sendPoint.position, GlobalSettings.RESOURCE_TWEEN_SPEED);
        }
    }
}
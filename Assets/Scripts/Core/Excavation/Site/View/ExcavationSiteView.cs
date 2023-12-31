using System;
using Core.Character.Interfaces;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Excavation.Site.View
{
    public class ExcavationSiteView : MonoBehaviour, ICharacterTarget
    {
        [SerializeField] private float _propsSpawnOffsetX = 5f;
        [SerializeField] private float _propsSpawnOffsetZ = 5f;

        public event Action TryMine;

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void TryInteract()
        {
            TryMine?.Invoke();
        }

        public void Mine(Resources.Resource.Resource resource)
        {
            Spawn(resource);
        }

        public void Spawn(Resources.Resource.Resource resource)
        {
            Vector3 place = new(
                Random.Range(-_propsSpawnOffsetX, _propsSpawnOffsetX),
                0f,
                Random.Range(-_propsSpawnOffsetZ, _propsSpawnOffsetZ)
                );
            Transform prop = 
                Instantiate(resource, transform.position, Quaternion.identity).transform;

            prop.DOMove(place, GlobalSettings.RESOURCE_TWEEN_SPEED);
        }
    }
}
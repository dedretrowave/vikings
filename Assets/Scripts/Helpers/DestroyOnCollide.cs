using System;
using DG.Tweening;
using UnityEngine;

namespace Helpers
{
    public class DestroyOnCollide : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.transform.DOKill();
            Destroy(other.gameObject);
        }
    }
}
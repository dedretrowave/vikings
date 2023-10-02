using System;
using UnityEngine;

namespace Helpers
{
    public class DestroyOnCollide : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
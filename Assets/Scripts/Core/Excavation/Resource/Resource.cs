using UnityEngine;

namespace Core.Excavation.Resource
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private Sprite _icon;

        public Sprite Icon => _icon;
    }
}
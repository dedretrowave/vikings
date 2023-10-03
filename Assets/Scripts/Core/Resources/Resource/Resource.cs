using UnityEngine;

namespace Core.Resources.Resource
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _key;

        public Sprite Icon => _icon;
        public string Key => _key;
    }
}
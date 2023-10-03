using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Resources.Resource
{
    public class ResourceUI : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _amount;

        public void Show(Sprite icon, int amount = 0)
        {
            _icon.sprite = icon;
            _amount.text = amount.ToString();
        }
    }
}
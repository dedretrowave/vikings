using UnityEngine;
using UnityEngine.UI;

namespace Core.Character.Health.View
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Init(float maxValue)
        {
            _slider.maxValue = maxValue;
        }

        public void Set(float health)
        {
            _slider.value = health;
        }
    }
}
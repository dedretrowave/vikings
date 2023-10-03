using Core.Player;
using Core.Resources;
using UnityEngine;

namespace Scenes
{
    public class TestScene : MonoBehaviour
    {
        [SerializeField] private PlayerInstaller _player;
        [SerializeField] private ResourcesInstaller _excavation;

        private void Awake()
        {
            _player.Construct();
            _excavation.Construct();
        }

        private void OnDisable()
        {
            _player.Disable();
            _excavation.Disable();
        }
    }
}
using System;
using Core;
using Core.Excavation;
using Core.Player;
using UnityEngine;

namespace Scenes
{
    public class TestScene : MonoBehaviour
    {
        [SerializeField] private PlayerInstaller _player;
        [SerializeField] private ExcavationInstaller _excavation;

        private void Start()
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
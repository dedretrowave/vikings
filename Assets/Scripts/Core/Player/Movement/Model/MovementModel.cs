using System;
using UnityEngine;

namespace Core.Character.Movement.Model
{
    public class MovementModel
    {
        private float _moveSpeed;

        public float MoveSpeed => _moveSpeed;

        public MovementModel(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        public void SetMoveSpeed(float speed)
        {
            if (speed <= 0) return;

            _moveSpeed = speed;
        }
    }

    [Serializable]
    public struct MovementSettings
    {
        [SerializeField] private float _moveSpeed;

        public float MoveSpeed => _moveSpeed;
    }
}
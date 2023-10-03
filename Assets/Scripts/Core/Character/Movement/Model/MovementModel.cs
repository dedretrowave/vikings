using System;
using UnityEngine;

namespace Core.Character.Movement.Model
{
    public class MovementModel
    {
        private Transform _basePoint;

        public Vector3 BasePoint => _basePoint.position;

        public void SetBasePoint(Transform basePoint)
        {
            _basePoint = basePoint;
        }
    }
}
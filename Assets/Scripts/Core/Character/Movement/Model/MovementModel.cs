using System;
using UnityEngine;

namespace Core.Character.Movement.Model
{
    public class MovementModel
    {
        private Transform _basePoint;
        private Vector3 _targetPoint;

        public Vector3 BasePoint => _basePoint.position;
        public Vector3 TargetPoint => _targetPoint;

        public void SetBasePoint(Transform basePoint)
        {
            _basePoint = basePoint;
        }

        public void SetTargetPoint(Vector3 point)
        {
            _targetPoint = point;
        }
    }
}
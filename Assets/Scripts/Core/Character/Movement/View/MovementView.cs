using DG.Tweening;
using UnityEngine;

namespace Core.Character.Movement.View
{
    public class MovementView : MonoBehaviour
    {
        [SerializeField] private float _speed = 200f;
        
        private const float TweenMoveSpeed = 1;
        private const float TweenTurnSpeed = .5f;

        private Vector3 _direction;
        private Vector3 _targetPoint;
        private bool _hasArrived = true;

        public void MoveTo(Vector3 point)
        {
            _targetPoint = new Vector3(point.x, transform.position.y, point.z);
            
            if (_direction != Vector3.zero ||
                Vector3.Distance(transform.position, _targetPoint) <= 3f)
            {
                _hasArrived = true;
                return;
            }

            _hasArrived = false;

            transform
                .DOMove(_targetPoint, TweenMoveSpeed)
                .onComplete = OnArrive;

            void OnArrive() => _hasArrived = true;
        }

        public void Move(Vector3 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            if (!_hasArrived) return;

            Vector3 movement = transform.position + _direction * (_speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, movement) <= 1f)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, movement, .3f);
            // transform.DOMove(movement, TweenMoveSpeed);
            transform.DOLookAt(movement, TweenTurnSpeed);
        }
    }
}
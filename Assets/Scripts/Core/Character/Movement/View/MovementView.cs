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
        private Vector3 _point;
        private bool _hasArrived = true;

        public void MoveTo(Vector3 point)
        {
            if (_direction != Vector3.zero)
            {
                return;
            }
            
            _hasArrived = false;
            _point = new(point.x, transform.position.y, point.z);

            transform
                .DOMove(_point, TweenMoveSpeed)
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

            Debug.Log(_direction);
            Vector3 movement = transform.position + _direction * (_speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, movement) <= 1f)
            {
                return;
            }
            
            transform.DOMove(movement, TweenMoveSpeed);
            transform.DOLookAt(movement, TweenTurnSpeed);
        }
    }
}
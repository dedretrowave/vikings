using DG.Tweening;
using UnityEngine;

namespace Core.Player.Movement.View
{
    public class MovementView : MonoBehaviour
    {
        private const float TweenMoveSpeed = 1;
        private const float TweenTurnSpeed = .5f;

        private Vector3 _direction;
        private float _speed;

        public void Move(Vector3 direction, float speed)
        {
            _direction = direction;
            _speed = speed;
        }

        private void FixedUpdate()
        {
            Vector3 movement = transform.position + _direction * (_speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movement) <= 1f) return;

            transform.DOMove(movement, TweenMoveSpeed);
            transform.DOLookAt(movement, TweenTurnSpeed);
        }
    }
}
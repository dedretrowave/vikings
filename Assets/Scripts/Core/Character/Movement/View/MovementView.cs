using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Character.Movement.View
{
    public class MovementView : MonoBehaviour
    {
        [SerializeField] private Transform _model;
        [SerializeField] private float _speed = 200f;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        // private const float TweenMoveSpeed = 1;
        private const float TweenTurnSpeed = .5f;

        private Vector3 _direction;
        // private Vector3 _targetPoint;
        private bool _hasArrived = true;

        public void MoveTo(Vector3 point)
        {
            _navMeshAgent.destination = point;
        }

        public void Move(Vector3 direction)
        {
            _direction = direction;
        }

        private void PointMove()
        {
            if (_direction != Vector3.zero ||
                Vector3.Distance(transform.position, _navMeshAgent.destination) <= 3f)
            {
                _navMeshAgent.destination = transform.position;
            }
        }

        private void DirectionalMove()
        {
            Vector3 movement = transform.position + _direction * (_speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, movement) <= 1f)
            {
                return;
            }
            
            transform.position = Vector3.MoveTowards(transform.position, movement, .3f);
            _model.DOLookAt(movement, TweenTurnSpeed);
        }

        private void FixedUpdate()
        {
            PointMove();
            DirectionalMove();
        }
    }
}
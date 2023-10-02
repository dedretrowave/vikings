using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Character.Movement.View
{
    public class CharacterMovementView : MonoBehaviour
    {
        [SerializeField] private float _speed = 200f;
        [SerializeField] private float _tweenLookDuration = .3f;
        
        private Vector3 _point;

        private void Start()
        {
            _point = transform.position;
        }

        public void Move(Vector3 point)
        {
            _point = point;
        }

        private void FixedUpdate()
        {
            // if (Vector3.Distance(transform.localPosition, _point) <= 2f)
            // {
            //     transform.localPosition = Vector3.zero;
            //     return;
            // }
            //
            // transform.localPosition = Vector3.MoveTowards(transform.localPosition, _point, _speed * Time.deltaTime);
        }
    }
}
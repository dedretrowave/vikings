using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class Input
    {
        private Controls _controls;
        private bool _isHeld;

        public event Action<Vector3> Move;

        public Input()
        {
            _controls = new();

            _controls.Enable();

            _controls.Movement.Move.started += OnMove;
            _controls.Movement.Move.performed += OnMove;
            _controls.Movement.Move.canceled += OnMove;
        }

        public void Disable()
        {
            _controls.Movement.Move.started -= OnMove;
            _controls.Movement.Move.performed -= OnMove;
            _controls.Movement.Move.canceled -= OnMove;
            
            _controls.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Move?.Invoke(context.ReadValue<Vector3>());
        }
    }
}
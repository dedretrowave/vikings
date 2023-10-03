using System.Collections.Generic;
using Core.Character.Movement.Model;
using Core.Character.Movement.View;
using UnityEngine;

namespace Core.Character.Movement.Presenter
{
    public class MovementPresenter
    {
        private MovementModel _model;
        
        private MovementView _view;

        public MovementPresenter(MovementView view, float moveSpeed)
        {
            _model = new();

            _view = view;
        }

        public void AssignToPoint(Transform point)
        {
            _model.SetBasePoint(point);
            MoveTo(point.position);
        }

        public void MoveTo(Vector3 point)
        {
            _view.MoveTo(point);
        }

        public void Move(Vector3 direction)
        {
            _view.Move(direction);
            
            if (direction == Vector3.zero)
            {
                MoveTo(_model.BasePoint);
            }
        }
    }
}
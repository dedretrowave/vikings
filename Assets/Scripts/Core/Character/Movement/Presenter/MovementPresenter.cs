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

        public MovementPresenter(MovementView view)
        {
            _model = new();

            _view = view;
        }

        public void MoveToBasePoint(Transform point)
        {
            _model.SetBasePoint(point);
            _model.SetTargetPoint(Vector3.down);
            MoveTo(point.position);
        }

        public void MoveToTargetPoint(Vector3 point)
        {
            _model.SetTargetPoint(point);
            MoveTo(_model.TargetPoint);
        }

        private void MoveTo(Vector3 point)
        {
            _view.MoveTo(point);
        }

        public void Move(Vector3 direction)
        {
            _view.Move(direction);
            
            if (direction == Vector3.zero)
            {
                if (_model.TargetPoint == Vector3.down)
                {
                    MoveTo(_model.BasePoint);
                    return;
                }
                
                MoveTo(_model.TargetPoint);
            }
        }
    }
}
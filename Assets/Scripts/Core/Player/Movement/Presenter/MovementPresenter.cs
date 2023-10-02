using System.Collections.Generic;
using Core.Character.Movement.Model;
using Core.Player.Movement.View;
using UnityEngine;

namespace Core.Character.Movement.Presenter
{
    public class MovementPresenter
    {
        private MovementModel _model;
        
        private MovementView _view;

        public MovementPresenter(MovementView view, float moveSpeed)
        {
            _model = new(moveSpeed);

            _view = view;
        }

        public void Move(Vector3 direction)
        {
            _view.Move(direction, _model.MoveSpeed);
        }
    }
}
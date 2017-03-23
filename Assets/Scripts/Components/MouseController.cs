using System;
using UnityEngine;
using SnakeGame.Core;
using SnakeGame.Contracts;

namespace SnakeGame.Components
{
    [DisallowMultipleComponent]
    public class MouseController: MonoBehaviour, IMouseController
    {
        [SerializeField]
        private Sprite sprite;

        private IGameLogic _gameLogic;
        private Coordinate _currentCoordinate;

        public void SubscribeToGameLogic(IGameLogic gameLogic)
        {
            if (gameLogic == null)
                throw new ArgumentNullException("gameLogic");
            _gameLogic = gameLogic;
        }

        public void UnsubscribeFromGameLogic()
        {
            _gameLogic = null;
        }

        public void ToStart()
        {
            CreateMouse();
        }

        public void NewMouse()
        {
            CreateMouse();
        }

        private void CreateMouse()
        {
            _currentCoordinate = _gameLogic.FieldController.GetMouseCoordinate();
            switch (_gameLogic.FieldController.GetCellType(_currentCoordinate))
            {
                case CellType.Normal:
                    _gameLogic.FieldController.SetCell(_currentCoordinate, CellType.Mouse, sprite);
                    break;
                default:
                    _gameLogic.Win();
                    break;
            }
        }
    }
}

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

        public Coordinate CurrentCoordinate
        {
            get { return _currentCoordinate; }
        }

        public void ToStart()
        {
            _currentCoordinate = _gameLogic.FieldController.GetMouseCoordinate();
            _gameLogic.FieldController.SetCell(_currentCoordinate, CellType.Mouse, sprite);
        }
    }
}

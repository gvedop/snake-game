using System;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Contracts;
using SnakeGame.Core;

namespace SnakeGame.Components
{
    [DisallowMultipleComponent]
    public class SnakeController: MonoBehaviour, ISnakeController
    {
        [SerializeField]
        private Sprite sprite;
        
        private IGameLogic _gameLogic;
        private SnakeDirection _direction = SnakeDirection.Up;
        private LinkedList<Coordinate> _body = new LinkedList<Coordinate>();

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
            _direction = SnakeDirection.Up;
            _body.Clear();
            var head = _gameLogic.FieldController.GetSnakeStartCoordinate();
            _body.AddLast(head);
            _gameLogic.FieldController.SetCell(head, CellType.Snake, sprite);
        }
    }
}

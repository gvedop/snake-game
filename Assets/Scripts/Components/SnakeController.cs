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
        [SerializeField]
        private float speed = 0.35f;
        [SerializeField]
        private float decSpeed = 0f;
        
        private IGameLogic _gameLogic;
        private SnakeDirection _direction = SnakeDirection.Up;
        private LinkedList<Coordinate> _body = new LinkedList<Coordinate>();
        private float _currentTime = 0f;
        private float _currentSpeed = 0f;

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
            _currentTime = 0f;
            _currentSpeed = speed;
            _direction = SnakeDirection.Up;
            _body.Clear();
            AddHead(_gameLogic.FieldController.GetSnakeStartCoordinate());
        }

        public void TurnRight()
        {
            _direction = SnakeDirection.Right;
        }

        public void TurnDown()
        {
            _direction = SnakeDirection.Down;
        }

        public void TurnLeft()
        {
            _direction = SnakeDirection.Left;
        }

        public void TurnUp()
        {
            _direction = SnakeDirection.Up;
        }

        private void Update()
        {
            if (!_gameLogic.IsPlay)
                return;
            _currentTime += Time.deltaTime;
            if (_currentTime > _currentSpeed)
            {
                Move();
                _currentTime = 0f;
            }
        }

        private void Move()
        {
            var nextCoordinate = GetNextCoordinate();
            switch(_gameLogic.FieldController.GetCellType(nextCoordinate))
            {
                case CellType.Border:
                case CellType.Wall:
                case CellType.Snake:
                    _gameLogic.Loss();
                    break;
                case CellType.Mouse:
                    _gameLogic.IncScore();
                    AddHead(nextCoordinate);
                    IncSpeed();
                    break;
                case CellType.Normal:
                    RemoveTail();
                    AddHead(nextCoordinate);
                    break;
            }
        }

        private Coordinate GetNextCoordinate()
        {
            var head = _body.First.Value;
            switch (_direction)
            {
                case SnakeDirection.Up:
                    return head.Up;
                case SnakeDirection.Right:
                    return head.Right;
                case SnakeDirection.Down:
                    return head.Down;
                case SnakeDirection.Left:
                    return head.Left;
                default:
                    throw new ArgumentException("Direction not recognized.");
            }
        }

        private void IncSpeed()
        {
            _currentSpeed -= decSpeed;
        }

        private void AddHead(Coordinate coordinate)
        {
            _body.AddFirst(coordinate);
            _gameLogic.FieldController.SetCell(coordinate, CellType.Snake, sprite);
        }

        private void RemoveTail()
        {
            var tail = _body.Last.Value;
            _gameLogic.FieldController.SetCellToNormal(tail);
            _body.RemoveLast();
        }
    }
}

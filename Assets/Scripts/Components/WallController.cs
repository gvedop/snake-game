using System;
using UnityEngine;
using SnakeGame.Core;
using SnakeGame.Contracts;

namespace SnakeGame.Components
{
    public class WallController: MonoBehaviour, IWallController
    {
        [SerializeField]
        private Sprite sprite;
        [SerializeField]
        private int count = 0;

        private IGameLogic _gameLogic;

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
            if (count == 0)
                return;
            for (int i = 0; i < count; i++)
            {
                var coordinate = _gameLogic.FieldController.GetCoordinateFreeCell();
                _gameLogic.FieldController.SetCell(coordinate, CellType.Wall, sprite);
            }
        }

        public void SetCount(int count)
        {
            this.count = count;
        }
    }
}

using System;
using UnityEngine;
using SnakeGame.Contracts;

namespace SnakeGame.Components
{
    [DisallowMultipleComponent]
    public class SnakeController: MonoBehaviour, ISnakeController
    {
        [SerializeField]
        private Sprite sprite;

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

        }
    }
}

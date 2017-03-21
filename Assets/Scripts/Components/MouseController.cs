using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using SnakeGame.Contracts;

namespace SnakeGame.Components
{
    [DisallowMultipleComponent]
    public class MouseController: MonoBehaviour, IMouseController
    {
        private IGameLogic _gameLogic;

        [SerializeField]
        private Sprite sprite;

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
    }
}

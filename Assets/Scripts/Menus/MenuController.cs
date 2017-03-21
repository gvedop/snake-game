using System;
using UnityEngine;
using SnakeGame.Contracts;

namespace SnakeGame.Menus
{
    public class MenuController: MonoBehaviour, IMenuController
    {
        private IGameLogic _gameLogic;
        private MainMenu _mainMenu;
        private ExitMenu _exitMenu;
        private GameMenu _gameMenu;

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

        public void ShowMainMenu()
        {
            _mainMenu.gameObject.SetActive(true);
        }

        public void HideMainMenu()
        {
            _mainMenu.gameObject.SetActive(false);
        }

        public void SetMaxScoreInMainMenu(int score)
        {
            _mainMenu.SetMaxScore(score);
        }

        public void SetCurrentScoreInMainMenu(int score)
        {
            _mainMenu.SetCurrentScore(score);
        }

        public void ShowExitMenu()
        {
            _exitMenu.gameObject.SetActive(true);
        }

        public void HideExitMenu()
        {
            _exitMenu.gameObject.SetActive(false);
        }

        public void ShowGameMenu()
        {
            _gameMenu.gameObject.SetActive(true);
        }

        public void HideGameMenu()
        {
            _gameMenu.gameObject.SetActive(false);
        }

        public void SetCurrentScoreInGameMenu(int score)
        {

        }

        private void Awake()
        {
            _mainMenu = GetComponentInChildren<MainMenu>(true);
            _exitMenu = GetComponentInChildren<ExitMenu>(true);
            _gameMenu = GetComponentInChildren<GameMenu>(true);
        }
    }
}

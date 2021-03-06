﻿using System;
using SnakeGame.Contracts;
using UnityEngine;

namespace SnakeGame.App
{
    public class GameLogic: IGameLogic
    {
        private ISceneController _sceneController;
        private IMenuController _menuController;
        private IFieldController _fieldController;
        private ISnakeController _snakeController;
        private IMouseController _mouseController;
        private IWallController _wallController;
        private bool _isPlay = false;
        private int _currentScore = 0;

        public GameLogic(ISceneController sceneController)
        {
            if (sceneController == null)
                throw new ArgumentNullException("scenecontroller");
            _sceneController = sceneController;
        }

        public IMenuController MenuController
        {
            get { return _menuController; }
        }

        public IFieldController FieldController
        {
            get {  return _fieldController; }
        }

        public ISnakeController Snakecontroller
        {
            get { return _snakeController; }
        }

        public IMouseController MouseController
        {
            get { return _mouseController; }
        }

        public IWallController WallController
        {
            get { return _wallController; }
        }

        public void RegisterMenuController(IMenuController menuController)
        {
            if (menuController == null)
                throw new ArgumentNullException("menuController");
            _menuController = menuController;
            _menuController.SubscribeToGameLogic(this);
        }

        public void UnregisterMenuController()
        {
            if (_menuController != null)
            {
                _menuController.UnsubscribeFromGameLogic();
                _menuController = null;
            }
        }

        public void RegisterFieldController(IFieldController fieldController)
        {
            if (fieldController == null)
                throw new ArgumentNullException("fieldController");
            _fieldController = fieldController;
            _fieldController.SubscribeToGameLogic(this);
        }

        public void UnregisterFieldController()
        {
            if (_fieldController != null)
            {
                _fieldController.UnsubscribeFromGameLogic();
                _fieldController = null;
            }
        }

        public void RegisterSnakeController(ISnakeController snakeController)
        {
            if (snakeController == null)
                throw new ArgumentNullException("snakeController");
            _snakeController = snakeController;
            _snakeController.SubscribeToGameLogic(this);
        }

        public void UnregisterSnakeController()
        {
            if (_snakeController != null)
            {
                _snakeController.UnsubscribeFromGameLogic();
                _snakeController = null;
            }
        }

        public void RegisterMouseController(IMouseController mouseController)
        {
            if (mouseController == null)
                throw new ArgumentNullException("mouseController");
            _mouseController = mouseController;
            _mouseController.SubscribeToGameLogic(this);
        }

        public void UnregisterMouseController()
        {
            if (_mouseController != null)
            {
                _mouseController.UnsubscribeFromGameLogic();
                _mouseController = null;
            }
        }

        public void RegisterWallController(IWallController wallController)
        {
            if (wallController == null)
                throw new ArgumentNullException("wallController");
            _wallController = wallController;
            _wallController.SubscribeToGameLogic(this);
        }

        public void UnregisterWallController()
        {
            if (_wallController != null)
            {
                _wallController.UnsubscribeFromGameLogic();
                _wallController = null;
            }
        }

        public void UnregisterAllControllers()
        {
            UnregisterMenuController();
            UnregisterFieldController();
            UnregisterMouseController();
            UnregisterSnakeController();
            UnregisterWallController();
        }

        public bool IsPlay
        {
            get { return _isPlay; }
        }

        public void Init()
        {
            _isPlay = false;
            _currentScore = 0;
            _fieldController.Init();
            _menuController.HideGameMenu();
            _menuController.HideExitMenu();
            _menuController.ShowMainMenu(Property.Instance.MaxScoreResult);
        }

        public void NewGame()
        {
            _fieldController.ToStart();
            _snakeController.ToStart();
            _wallController.ToStart();
            _mouseController.ToStart();
            _currentScore = 0;
            _menuController.SetCurrentScoreInGameMenu(_currentScore);
            _menuController.HideMainMenu();
            _menuController.HideExitMenu();
            _menuController.ShowGameMenu();
            _isPlay = true;
        }

        public void ResumeGame()
        {
            if (!_isPlay)
            {
                _menuController.HideMainMenu();
                _menuController.HideExitMenu();
                _menuController.ShowGameMenu();
                _isPlay = true;
            }
        }

        public void PauseGame()
        {
            //_fieldController.ToStart();
            //_wallController.ToStart();
            //_mouseController.ToStart();
            if (_isPlay)
            {
                _isPlay = false;
                _menuController.HideGameMenu();
                _menuController.HideExitMenu();
                _menuController.ShowPauseMainMenu(Property.Instance.MaxScoreResult, _currentScore);
            }
        }

        public void Exit()
        {
            Debug.Log("try exit");
            if (_isPlay)
            {
                Debug.Log("question exit");
                _isPlay = false;
                _menuController.HideGameMenu();
                _menuController.ShowExitMenu();
                _menuController.HideGameMenu();
            }
            else
            {
                Debug.Log("exit");
                Property.Instance.Save();
                Application.Quit();
            }
        }

        public void Loss()
        {
            _isPlay = false;
            _sceneController.PlayLoss();
            _menuController.HideGameMenu();
            _menuController.HideExitMenu();
            _menuController.ShowLossMainMenu(Property.Instance.MaxScoreResult, _currentScore);
        }

        public void IncScore()
        {
            _currentScore++;
            Property.Instance.MaxScoreResult = _currentScore;
            _menuController.SetCurrentScoreInGameMenu(_currentScore);
            _mouseController.EatMouse();
        }

        public void Win()
        {
            _isPlay = false;
            _sceneController.PlayWin();
            _menuController.HideGameMenu();
            _menuController.HideExitMenu();
            _menuController.ShowWinMainMenu(Property.Instance.MaxScoreResult, _currentScore);
        }
    }
}

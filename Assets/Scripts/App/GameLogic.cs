using System;
using SnakeGame.Contracts;

namespace SnakeGame.App
{
    public class GameLogic: IGameLogic
    {
        private IMenuController _menuController;
        private IFieldController _fieldController;
        private ISnakeController _snakeController;
        private IMouseController _mouseController;
        private bool _isPlay = false;
        private int _currentScore = 0;

        public GameLogic()
        {

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

        public void UnregisterAllControllers()
        {
            UnregisterFieldController();
            UnregisterMouseController();
            UnregisterSnakeController();
        }

        public void Init()
        {
            _isPlay = false;
            _currentScore = 0;
            _fieldController.Init();
        }

        public void NewGame()
        {
            _currentScore = 0;
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
            if (_isPlay)
            {
                _isPlay = false;
                _menuController.HideGameMenu();
                _menuController.HideExitMenu();
                _menuController.ShowMainMenu(Property.Instance.MaxScoreResult, _currentScore, true, true);
            }
        }
    }
}

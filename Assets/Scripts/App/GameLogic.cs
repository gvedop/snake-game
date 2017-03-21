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
            _fieldController.Init();
        }
    }
}

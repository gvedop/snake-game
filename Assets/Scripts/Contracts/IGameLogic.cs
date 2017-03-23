
namespace SnakeGame.Contracts
{
    public interface IGameLogic
    {
        IMenuController MenuController { get; }
        IFieldController FieldController { get; }
        ISnakeController Snakecontroller { get; }
        IMouseController MouseController { get; }
        IWallController WallController { get; }

        void RegisterMenuController(IMenuController menuController);
        void UnregisterMenuController();

        void RegisterFieldController(IFieldController fieldController);
        void UnregisterFieldController();

        void RegisterSnakeController(ISnakeController snakeController);
        void UnregisterSnakeController();

        void RegisterMouseController(IMouseController mouseController);
        void UnregisterMouseController();

        void RegisterWallController(IWallController wallController);
        void UnregisterWallController();

        void UnregisterAllControllers();
        
        bool IsPlay { get; }
        void Init();
        void NewGame();
        void ResumeGame();
        void PauseGame();
        void Exit();

        void Win();
        void Loss();
        void IncScore();
    }
}

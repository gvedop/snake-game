
namespace SnakeGame.Contracts
{
    public interface IGameLogic
    {
        IFieldController FieldController { get; }
        ISnakeController Snakecontroller { get; }
        IMouseController MouseController { get; }

        void RegisterFieldController(IFieldController fieldController);
        void UnregisterFieldController();

        void RegisterSnakeController(ISnakeController snakeController);
        void UnregisterSnakeController();

        void RegisterMouseController(IMouseController mouseController);
        void UnregisterMouseController();

        void UnregisterAllControllers();
        
        void Init();
    }
}

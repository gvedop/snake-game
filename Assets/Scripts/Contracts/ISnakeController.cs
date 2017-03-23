
namespace SnakeGame.Contracts
{
    public interface ISnakeController : IGameLogicSubscriber
    {
        void ToStart();
        void TurnRight();
        void TurnDown();
        void TurnLeft();
        void TurnUp();
    }
}

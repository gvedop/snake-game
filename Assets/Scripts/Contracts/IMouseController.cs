using SnakeGame.Core;

namespace SnakeGame.Contracts
{
    public interface IMouseController : IGameLogicSubscriber
    {
        void ToStart();
        void EatMouse();
    }
}

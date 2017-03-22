using SnakeGame.Core;

namespace SnakeGame.Contracts
{
    public interface IMouseController : IGameLogicSubscriber
    {
        Coordinate CurrentCoordinate { get; }
        void ToStart();
    }
}

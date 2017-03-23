
namespace SnakeGame.Contracts
{
    public interface IWallController : IGameLogicSubscriber
    {
        void ToStart();
        void SetCount(int count);
    }
}


namespace SnakeGame.Contracts
{
    public interface IGameLogicSubscriber
    {
        void SubscribeToGameLogic(IGameLogic gameLogic);
        void UnsubscribeFromGameLogic();
    }
}

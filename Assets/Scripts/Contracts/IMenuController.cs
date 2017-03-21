
namespace SnakeGame.Contracts
{
    public interface IMenuController: IGameLogicSubscriber
    {
        void ShowMainMenu(int maxScore, int currentScore, bool isShowCurrentScore, bool isShowResume);
        void HideMainMenu();

        void ShowExitMenu();
        void HideExitMenu();

        void ShowGameMenu();
        void HideGameMenu();
        void SetCurrentScoreInGameMenu(int score);
    }
}

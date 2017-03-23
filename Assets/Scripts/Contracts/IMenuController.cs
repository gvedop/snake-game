
namespace SnakeGame.Contracts
{
    public interface IMenuController: IGameLogicSubscriber
    {
        void ShowMainMenu(int maxScore);
        void ShowPauseMainMenu(int maxScore, int currentScore);
        void ShowWinMainMenu(int maxScore, int currentScore);
        void ShowLossMainMenu(int maxScore, int currentScore);
        void HideMainMenu();

        void ShowExitMenu();
        void HideExitMenu();

        void ShowGameMenu();
        void HideGameMenu();
        void SetCurrentScoreInGameMenu(int score);
    }
}

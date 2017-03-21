
namespace SnakeGame.Contracts
{
    public interface IMenuController: IGameLogicSubscriber
    {
        void ShowMainMenu();
        void HideMainMenu();
        void SetMaxScoreInMainMenu(int score);
        void SetCurrentScoreInMainMenu(int score);

        void ShowExitMenu();
        void HideExitMenu();

        void ShowGameMenu();
        void HideGameMenu();
        void SetCurrentScoreInGameMenu(int score);
    }
}

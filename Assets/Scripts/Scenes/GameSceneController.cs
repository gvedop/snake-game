using UnityEngine;
using SnakeGame.App;
using SnakeGame.Contracts;
using SnakeGame.Menus;
using SnakeGame.Components;

namespace SnakeGame.Scenes
{
    public class GameSceneController: MonoBehaviour
    {
        protected IGameLogic gameLogic = new GameLogic();

        public void NewGame()
        {
            gameLogic.NewGame();
        }

        public void ResumeGame()
        {
            gameLogic.ResumeGame();
        }

        public void PauseGame()
        {
            gameLogic.PauseGame();
        }

        public void ExitGame()
        {

        }

        private void Awake()
        {
            gameLogic.RegisterMenuController(FindObjectOfType<MenuController>());
            gameLogic.RegisterFieldController(GetComponent<FieldController>());
            gameLogic.RegisterSnakeController(GetComponent<SnakeController>());
            gameLogic.RegisterMouseController(GetComponent<MouseController>());
            gameLogic.RegisterWallController(GetComponent<WallController>());
        }

        private void Start()
        {
            gameLogic.Init();
        }

        private void OnDestroy()
        {
            gameLogic.UnregisterAllControllers();
        }
    }
}

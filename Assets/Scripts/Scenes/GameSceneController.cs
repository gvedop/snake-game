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

        private void Awake()
        {
            gameLogic.RegisterMenuController(FindObjectOfType<MenuController>());
            gameLogic.RegisterFieldController(GetComponent<FieldController>());
            gameLogic.RegisterSnakeController(GetComponent<SnakeController>());
            gameLogic.RegisterMouseController(GetComponent<MouseController>());
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

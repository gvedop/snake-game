﻿using UnityEngine;
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

        public void TurnUp()
        {
            gameLogic.Snakecontroller.TurnUp();
        }

        public void TurnRight()
        {
            gameLogic.Snakecontroller.TurnRight();
        }

        public void TurnDown()
        {
            gameLogic.Snakecontroller.TurnDown();
        }

        public void TurnLeft()
        {
            gameLogic.Snakecontroller.TurnLeft();
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

        private void Update()
        {
            if (!gameLogic.IsPlay)
                return;
            if (Input.GetKeyDown(KeyCode.UpArrow))
                TurnUp();
            if (Input.GetKeyDown(KeyCode.RightArrow))
                TurnRight();
            if (Input.GetKeyDown(KeyCode.DownArrow))
                TurnDown();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                TurnLeft();
        }

        private void OnDestroy()
        {
            gameLogic.UnregisterAllControllers();
            gameLogic.Exit();
        }
    }
}

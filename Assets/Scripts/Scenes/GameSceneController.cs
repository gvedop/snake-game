using UnityEngine;
using SnakeGame.App;
using SnakeGame.Contracts;
using SnakeGame.Menus;
using SnakeGame.Components;

namespace SnakeGame.Scenes
{
    public class GameSceneController: MonoBehaviour, ISceneController
    {
        [SerializeField]
        private AudioClip winClip;
        [SerializeField]
        private AudioClip lossClip;

        protected IGameLogic gameLogic;
        private AudioSource _audioSource;

        public void PlayWin()
        {
            if (_audioSource != null && winClip != null)
                _audioSource.PlayOneShot(winClip);
        }

        public void PlayLoss()
        {
            if (_audioSource != null && lossClip != null)
                _audioSource.PlayOneShot(lossClip);
        }

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
            gameLogic.Exit();
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
            _audioSource = GetComponent<AudioSource>();
            gameLogic = new GameLogic(this);
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
            if (Input.GetKeyDown(KeyCode.Escape))
                ExitGame();
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
        }
    }
}

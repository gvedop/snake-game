using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnakeGame.Scenes
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField]
        private SceneType sceneType = SceneType.Automatic;

        private void Start()
        {
            LoadScene(sceneType);
        }

        private void LoadScene(SceneType sceneType)
        {
            var sceneName = sceneType.ToSceneName();
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}

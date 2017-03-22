using UnityEngine;
using UnityEngine.SceneManagement;
using SnakeGame.App;
using SnakeGame.Core;

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

        private void OnDestroy()
        {
            Property.Instance.Save();
        }

        private void LoadScene(SceneType sceneType)
        {
            var sceneName = sceneType.ToSceneName();
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}

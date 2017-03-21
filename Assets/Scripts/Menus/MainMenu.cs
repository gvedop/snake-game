using UnityEngine;
using UnityEngine.UI;

namespace SnakeGame.Menus
{
    [DisallowMultipleComponent]
    public class MainMenu: MonoBehaviour
    {
        [SerializeField]
        private Text maxScoreValue;
        [SerializeField]
        private Text currentScoreValue;

        public void SetMaxScore(int score)
        {
            if (maxScoreValue != null)
                maxScoreValue.text = score.ToString();
        }

        public void SetCurrentScore(int score)
        {
            if (currentScoreValue != null)
                currentScoreValue.text = score.ToString();
        }
    }
}

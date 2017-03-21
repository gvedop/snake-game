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
        private Text currentScoreTitle;
        [SerializeField]
        private Text currentScoreValue;
        [SerializeField]
        private Button resumeGameButton;

        public void Show(int maxScore, int currentScore, bool isShowCurrentScore, bool isShowResume)
        {
            if (maxScoreValue != null)
            {
                maxScoreValue.text = maxScore.ToString();
            }
            if (currentScoreTitle != null && currentScoreValue != null)
            {
                currentScoreValue.text = currentScore.ToString();
                currentScoreTitle.gameObject.SetActive(isShowCurrentScore);
                currentScoreValue.gameObject.SetActive(isShowCurrentScore);
            }
            if (resumeGameButton != null)
            {
                resumeGameButton.gameObject.SetActive(isShowResume);
            }
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

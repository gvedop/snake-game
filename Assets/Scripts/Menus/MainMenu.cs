using UnityEngine;
using UnityEngine.UI;

namespace SnakeGame.Menus
{
    [DisallowMultipleComponent]
    public class MainMenu: MonoBehaviour
    {
        [SerializeField]
        private Text resultTitle;
        [SerializeField]
        private Text maxScoreValue;
        [SerializeField]
        private Text currentScoreTitle;
        [SerializeField]
        private Text currentScoreValue;
        [SerializeField]
        private Button resumeGameButton;

        public void Show(int maxScore)
        {
            if (resultTitle != null)
            {
                resultTitle.gameObject.SetActive(false);
            }
            if (maxScoreValue != null)
            {
                maxScoreValue.text = maxScore.ToString();
            }
            if (currentScoreTitle != null && currentScoreValue != null)
            {
                currentScoreValue.text = string.Empty;
                currentScoreTitle.gameObject.SetActive(false);
                currentScoreValue.gameObject.SetActive(false);
            }
            if (resumeGameButton != null)
            {
                resumeGameButton.gameObject.SetActive(false);
            }
            gameObject.SetActive(true);
        }

        public void ShowPause(int maxScore, int currentScore)
        {
            if (resultTitle != null)
            {
                resultTitle.gameObject.SetActive(false);
            }
            if (maxScoreValue != null)
            {
                maxScoreValue.text = maxScore.ToString();
            }
            if (currentScoreTitle != null && currentScoreValue != null)
            {
                currentScoreValue.text = currentScore.ToString();
                currentScoreTitle.gameObject.SetActive(true);
                currentScoreValue.gameObject.SetActive(true);
            }
            if (resumeGameButton != null)
            {
                resumeGameButton.gameObject.SetActive(true);
            }
            gameObject.SetActive(true);
        }

        public void ShowWin(int maxScore, int currentScore)
        {
            if (resultTitle != null)
            {
                resultTitle.text = "You Win!";
                resultTitle.color = new Color32(42, 212, 71, 255);
                resultTitle.gameObject.SetActive(true);
            }
            if (maxScoreValue != null)
            {
                maxScoreValue.text = maxScore.ToString();
            }
            if (currentScoreTitle != null && currentScoreValue != null)
            {
                currentScoreValue.text = currentScore.ToString();
                currentScoreTitle.gameObject.SetActive(true);
                currentScoreValue.gameObject.SetActive(true);
            }
            if (resumeGameButton != null)
            {
                resumeGameButton.gameObject.SetActive(false);
            }
            gameObject.SetActive(true);
        }

        public void ShowLoss(int maxScore, int currentScore)
        {
            if (resultTitle != null)
            {
                resultTitle.text = "You Loss!";
                resultTitle.color = new Color32(212, 42, 42, 255);
                resultTitle.gameObject.SetActive(true);
            }
            if (maxScoreValue != null)
            {
                maxScoreValue.text = maxScore.ToString();
            }
            if (currentScoreTitle != null && currentScoreValue != null)
            {
                currentScoreValue.text = currentScore.ToString();
                currentScoreTitle.gameObject.SetActive(true);
                currentScoreValue.gameObject.SetActive(true);
            }
            if (resumeGameButton != null)
            {
                resumeGameButton.gameObject.SetActive(false);
            }
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

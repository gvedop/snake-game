using UnityEngine;
using UnityEngine.UI;

namespace SnakeGame.Menus
{
    [DisallowMultipleComponent]
    public class GameMenu: MonoBehaviour
    {
        [SerializeField]
        private Text scoreValue;

        public void SetScore(int score)
        {
            if (scoreValue != null)
            {
                scoreValue.text = string.Format("Curretn score: {0}", score);
            }
        }
    }
}

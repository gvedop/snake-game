using UnityEngine;

namespace SnakeGame.App
{
    public class Property
    {
        public const string MAX_SCORE_RESULT_PREF = "MaxScoreResultPref";

        private static volatile Property _instance;
        private static object _sync = new object();

        public static Property Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(_sync)
                    {
                        if (_instance == null)
                            _instance = new Property();
                    }
                }
                return _instance;
            }
        }

        public int MaxScoreResult { get; set; }

        public void Save()
        {
            PlayerPrefs.SetInt(MAX_SCORE_RESULT_PREF, MaxScoreResult);
            PlayerPrefs.Save();
        }

        private Property()
        {
            Load();
        }

        private void Load()
        {
            MaxScoreResult = PlayerPrefs.GetInt(MAX_SCORE_RESULT_PREF, 0);
        }
    }
}

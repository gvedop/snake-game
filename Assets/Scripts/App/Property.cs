using UnityEngine;

namespace SnakeGame.App
{
    public class Property
    {
        public const string MAX_SCORE_RESULT_PREF = "MaxScoreResultPref";

        private static volatile Property _instance;
        private static object _sync = new object();

        private int _maxScoreResult = 0;

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

        public int MaxScoreResult
        {
            get
            {
                return _maxScoreResult;
            }
            set
            {
                if (value > _maxScoreResult)
                    _maxScoreResult = value;
            }
        }

        public void Save()
        {
            PlayerPrefs.SetInt(MAX_SCORE_RESULT_PREF, _maxScoreResult);
            PlayerPrefs.Save();
        }

        private Property()
        {
            Load();
        }

        private void Load()
        {
            _maxScoreResult = PlayerPrefs.GetInt(MAX_SCORE_RESULT_PREF, 0);
        }
    }
}

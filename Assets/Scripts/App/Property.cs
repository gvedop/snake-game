using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Assets.Scripts.App
{
    public class Property
    {
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

        public void Save()
        {

        }

        private Property()
        {
            Load();
        }

        private void Load()
        {

        }
    }
}

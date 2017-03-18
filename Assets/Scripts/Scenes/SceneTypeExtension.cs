using System;

namespace SnakeGame.Scenes
{
    public static class SceneTypeExtension
    {
        public static string ToSceneName(this SceneType obj)
        {
            switch (obj)
            {
                case SceneType.PC:
                    return Const.PC_GAME_SCENE_NAME;
                case SceneType.Mobile:
                    return Const.MOBILE_GAME_SCENE_NAME;
                default:
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER
                    return Const.PC_GAME_SCENE_NAME;
#else
                    return Const.MOBILE_GAME_SCENE_NAME;
#endif
            }
        }
    }
}

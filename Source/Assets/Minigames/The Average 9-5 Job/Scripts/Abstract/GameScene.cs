using System;
using UnityEngine.Events;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.TheAverage9To5Job.Abstract
{
    [Serializable]
    public struct GameScene
    {
        public string[] Options;
        public string Text;
        public string Title;

        public GameScene(string text, params string[] options) => this = new GameScene("", text, options);
        public GameScene(string title, string text, params string[] options)
        {
            Title = title;
            Text = text;
            Options = options;
        }
    }
}

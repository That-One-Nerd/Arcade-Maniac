using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.TheAverage9To5Job.Abstract
{
    [Serializable]
    public struct GameScene
    {
        public string Title;
        [TextArea]
        public string Text;
        public float TextSpeed;
        public string[] Options;

        public GameScene(string text, params string[] options) => this = new GameScene("", text, 1, options);
        public GameScene(string title, string text, float textSpeed, params string[] options)
        {
            Title = title;
            Text = text;
            TextSpeed = textSpeed;
            Options = options;
        }
    }
}

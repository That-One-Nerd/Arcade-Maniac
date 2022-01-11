using System;
using System.Collections;
using System.Collections.Generic;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.TheAverage9To5Job.Abstract;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.TheAverage9To5Job
{
    public class InputHandler : MonoBehaviour
    {
        private InputField input;
        private SceneManager manager;

        private void Awake()
        {
            input = GetComponent<InputField>();

            manager = FindObjectOfType<SceneManager>();
            manager.OnSceneChange += SceneChange;

            input.onSubmit.AddListener(FieldSubmit);
        }

        public void FieldSubmit(string value)
        {
            int val = int.Parse(value);

            if (val < 0 || val >= manager.CurrentScene.Options.Length) return;

            manager.OnInput(val);
        }

        private void SceneChange(GameScene? oldScene, GameScene newScene) =>
            input.characterLimit = newScene.Options.Length.ToString().Length;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.TheAverage9To5Job.Abstract;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.TheAverage9To5Job
{
    public class SceneManager : MonoBehaviour
    {
        public GameScene CurrentScene
        {
            get => p_CurrentScene;
            set
            {
                OnSceneChange(p_CurrentScene, value);
                p_CurrentScene = value;
            }
        }
        public Action<int> OnInput { get; set; } = delegate { };
        public Action<GameScene?, GameScene> OnSceneChange { get; set; } = delegate { };

        public GameScene[] scenes;

        private MethodInfo[] optionMethods;
        private GameScene p_CurrentScene;
        private TextRenderer ren;
        private List<GameScene> sceneList;

        private void Awake()
        {
            ren = FindObjectOfType<TextRenderer>();
            if (scenes.Length == 0)
            {
                Debug.LogWarning("There must be at least one game scene in the list.");
                Destroy(this);
                return;
            }
            p_CurrentScene = scenes[0];

            OnInput += InputMade;
            OnSceneChange += SceneChange;

            optionMethods = GetType().GetMethods().Where(x => x.Name.StartsWith("Scene")).ToArray();
            sceneList = new List<GameScene>(scenes);
        }

        private void Start() => OnSceneChange(null, scenes[0]);

        private void InputMade(int value)
        {
            MethodInfo method = optionMethods.FirstOrDefault(x => x.Name == "Scene" +
                sceneList.IndexOf(p_CurrentScene) + "Option" + value);

            Debug.Log("Scene" + sceneList.IndexOf(p_CurrentScene) + "Option" + value);

            if (method == default) return;

            Debug.Log("found");

            method.Invoke(this, null);
        }
        private void SceneChange(GameScene? oldScene, GameScene newScene)
        {
            ren.Flush();

            string write = (newScene.Title == "" ? "" : newScene.Title + "\n\n\n") + newScene.Text + "\n\n\n";
            for (int i = 0; i < newScene.Options.Length; i++) write += i + " - " + newScene.Options[i] + "\n";

            ren.WriteText(write);
        }

        // Begin option code

        private void Scene0Option0()
        {
            Debug.Log("Option 0");
        }
        private void Scene0Option1()
        {
            Debug.Log("Option 1");
        }
    }
}

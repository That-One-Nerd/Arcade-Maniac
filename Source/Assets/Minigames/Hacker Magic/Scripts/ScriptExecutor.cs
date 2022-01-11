using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.HackerMagic
{
    public class ScriptExecutor : MonoBehaviour
    {
        public EnvironmentVariable[] variables;

        [Header("Error Color")]
        public ColorBlock badCol;
        [Header("Success Color")]
        public ColorBlock goodCol;
        [Header("In Progress Color")]
        public ColorBlock progressCol;

        private Button button;
        private Dictionary<string, object> internalVars;
        private Dictionary<string, GameObject> variableDict;
        private bool working;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.colors = goodCol;

            variableDict = new Dictionary<string, GameObject>();
            foreach (EnvironmentVariable var in variables) variableDict.Add(var.Name, var.GameObject);

            internalVars = new Dictionary<string, object>();
        }

        public async void ExecuteCode()
        {
            if (working) return;

            button.colors = progressCol;
            working = true;

            try
            {
                await Execute();
                button.colors = goodCol;
            }
            catch { button.colors = badCol; }

            working = false;
        }

        private async Task Execute()
        {
            internalVars = new Dictionary<string, object>();
            
        }
    }
}

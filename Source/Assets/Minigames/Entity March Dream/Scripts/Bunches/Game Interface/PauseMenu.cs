using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool IsPaused { get; private set; }

        public Action<bool> OnActiveChanged { get; set; }
        public bool Active
        {
            get => p_Active;
            set
            {
                if (p_Active == value) return;
                p_Active = value;
                OnActiveChanged.Invoke(value);
            }
        }

        private bool p_Active;
        private RawImage rima;

        private void Awake()
        {
            rima = GetComponent<RawImage>();
            OnActiveChanged += ActiveChanged;
            OnActiveChanged.Invoke(Active);
        }

        private void Update() { if (Input.GetButtonDown("Cancel")) Active = !Active; }

        private void ActiveChanged(bool newVal)
        {
            rima.enabled = newVal;
            for (int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.SetActive(newVal);

            IsPaused = newVal;
        }
    }
}

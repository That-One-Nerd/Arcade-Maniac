using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface
{
    public class PauseButton : MonoBehaviour
    {
        public UnityEvent onKeyPress;
        public KeyCode triggerKey;

        private PauseMenu menu;

        private void Awake() => menu = FindObjectOfType<PauseMenu>();

        private void Update() { if (Input.GetKeyDown(triggerKey)) onKeyPress.Invoke(); }

        public void ResumeButton() => menu.Active = false;
        public void RestartButton() => Transition.Instance.FadeTransition(SceneManager.GetActiveScene().name);
        public void QuitButton()
        {
            new SaveData().Save();
            Transition.Instance.FadeTransition("EMD Title Screen");
        }
    }
}

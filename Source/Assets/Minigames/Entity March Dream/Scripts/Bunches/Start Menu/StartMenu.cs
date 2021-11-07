using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.StartMenu
{
    public class StartMenu : MonoBehaviour
    {
        public static bool AnyKeyPressed;

        public GameObject[] SetActiveOnKeyPressed;

        private void Update()
        {
            if (Input.anyKeyDown && !AnyKeyPressed)
            {
                AnyKeyPressed = true;
                foreach (GameObject g in SetActiveOnKeyPressed) g.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

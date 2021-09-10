using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc
{
    public static class GameManager
    {
        public static bool Submit => Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0);
    }
}

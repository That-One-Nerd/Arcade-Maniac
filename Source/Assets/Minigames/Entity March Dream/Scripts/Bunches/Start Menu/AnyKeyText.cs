using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.StartMenu
{
    public class AnyKeyText : MonoBehaviour
    {
        private void Update() { if (StartMenu.AnyKeyPressed) Destroy(gameObject); }
    }
}

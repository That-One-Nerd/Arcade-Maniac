using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using UnityEngine;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface
{
    public class WorldIndicator : MonoBehaviour
    {
        public GameObject textBackdrop;

        private Text txt;
        private Text txtBack;

        private void Awake()
        {
            txt = GetComponent<Text>();
            txtBack = textBackdrop.GetComponent<Text>();
        }

        private void Update()
        {
            txt.text = "World " + Statistics.Instance.world + " / " + Statistics.Instance.worldLevel;
            txtBack.text = txt.text;
        }
    }
}

using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using UnityEngine;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface
{
    public class CoinCounter : MonoBehaviour
    {
        public GameObject textBackdrop;

        private Animator coinAnim;
        private Text txt;
        private Text txtBack;

        private void Awake()
        {
            coinAnim = GetComponentInChildren<Animator>();
            txt = GetComponent<Text>();
            txtBack = textBackdrop.GetComponent<Text>();

            coinAnim.Play("Coin Collect", 1, 1);
        }

        private void Update()
        {
            txt.text = Statistics.Instance.CoinsCollected.ToString("000");
            txtBack.text = txt.text;
        }

        public void OnCoinCollected() => coinAnim.Play("Coin Collect", 1, 0);
    }
}

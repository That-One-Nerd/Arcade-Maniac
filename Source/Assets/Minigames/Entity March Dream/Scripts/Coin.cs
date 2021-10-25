using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class Coin : MonoBehaviour
    {
        public float bobIntensity;
        public float bobSpeed;

        private Collider2D col;
        private Player p;
        private Vector2 startPos;
        private float timer;

        private void Awake()
        {
            col = GetComponent<Collider2D>();
            p = FindObjectOfType<Player>();
            startPos = transform.position;
        }

        private void Update()
        {
            if (PauseMenu.IsPaused) return;

            timer += Time.deltaTime * bobSpeed;

            transform.position = startPos + new Vector2(0, Mathf.Sin(timer) * bobIntensity);

            if (p.col != null && col.IsTouching(p.col))
            {
                Statistics.Instance.CoinsCollected++;
                Destroy(gameObject);
            }
        }
    }
}

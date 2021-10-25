using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class FallingPlatform : MonoBehaviour
    {
        public bool PlayerTouching => Physics2D.OverlapBoxAll(transform.position, col.size, 0).Any(x => x == p.col);

        public bool disableOnJump;
        public float gravityScale;

        private bool activated;
        private BoxCollider2D col;
        private Player p;
        private Rigidbody2D rb;
        private SpriteRenderer sr;

        private void Awake()
        {
            col = gameObject.AddComponent<BoxCollider2D>();
            p = FindObjectOfType<Player>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            rb.simulated = !PauseMenu.IsPaused;
            if (PauseMenu.IsPaused) return;

            col.size = sr.bounds.size;

            bool touching = PlayerTouching;
            activated = (!disableOnJump && activated) || touching;

            if (activated)
            {
                rb.velocity += gravityScale * Time.deltaTime * Physics2D.gravity;
                p.rb.gravityScale = touching ? gravityScale * 10 : p.gravityScale; // using the 10 just to ensure that
                                                                                   // the player stays on the platform
                                                                                   // might not be the super best
                                                                                   // solution, but it'll do
            }
            else rb.velocity = Vector2.zero;
        }
    }
}

using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Abstract
{
    public abstract class Item : MonoBehaviour
    {
        protected Collider2D col;
        protected Player p;
        protected Rigidbody2D rb;
        protected SpriteRenderer sr;

        private float? oldGravityScale;
        private Vector2? oldVelocity;

        protected virtual void Awake() => AssignVars();

        protected virtual void Update()
        {
            rb.simulated = !PauseMenu.IsPaused;
            if (PauseMenu.IsPaused) return;

            rb.simulated = sr.isVisible;
            if (sr.isVisible) Move();

            if (Physics2D.OverlapBoxAll(col.bounds.center, col.bounds.size, 0).Any(x => x == p.col))
            {
                OnCollected();
                Destroy(gameObject);
            }
        }

        protected virtual void AssignVars()
        {
            col = GetComponent<Collider2D>();
            p = FindObjectOfType<Player>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();

            rb.sharedMaterial = new PhysicsMaterial2D("Item Physics Material")
            {
                bounciness = 0,
                friction = 0,
            };
        }

        protected abstract void OnCollected();
        protected abstract void Move();
    }
}

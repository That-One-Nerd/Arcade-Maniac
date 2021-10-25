using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Abstract
{
    public abstract class Enemy : MonoBehaviour
    {
        public float bounceHeight;
        public float bounceHeightExtra;
        public Loot deathLoot;

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
        }

        protected virtual void AssignVars()
        {
            col = GetComponent<Collider2D>();
            p = FindObjectOfType<Player>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();

            rb.sharedMaterial = new PhysicsMaterial2D("Enemy Physics Material")
            {
                bounciness = 0,
                friction = 0,
            };
        }

        protected virtual void Die()
        {
            if (deathLoot.Lottery) Instantiate(deathLoot.lootObject, transform.position, Quaternion.Euler(Vector3.zero));
            Destroy(gameObject);
        }
        protected abstract void OnHitPlayer();
        protected virtual void OnPlayerStomp()
        {
            Die();
            p.rb.velocity = new Vector2(p.rb.velocity.x, Input.GetAxisRaw("Vertical") > 0 ? bounceHeightExtra : bounceHeight);
        }
        protected abstract void Move();

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider != p.col) return;

            const float dividend = 100; // useful for rounding to every Nth increment
            if (Mathf.Round(p.rb.velocity.y * dividend) / dividend < 0) OnPlayerStomp();
            else OnHitPlayer();
        }
    }
}

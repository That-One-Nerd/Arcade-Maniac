using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Abstract
{
    public abstract class Enemy : MonoBehaviour
    {
        public float bounceHeight;
        public float bounceHeightExtra;

        protected Collider2D col;
        protected Player p;
        protected Rigidbody2D rb;
        protected Renderer ren;
        protected TilemapCollider2D tilemap;

        protected virtual void Awake() => AssignVars();

        protected virtual void Update()
        {
            rb.simulated = ren.isVisible;
            if (ren.isVisible) Move();

            if (Physics2D.OverlapBoxAll(col.bounds.center, col.bounds.size, 0).Any(x => x == p.col)) OnHitPlayer();
        }

        protected virtual void AssignVars()
        {
            col = GetComponent<Collider2D>();
            p = FindObjectOfType<Player>();
            rb = GetComponent<Rigidbody2D>();
            ren = GetComponent<Renderer>();
            tilemap = FindObjectsOfType<TilemapCollider2D>().FirstOrDefault(x => x.gameObject.name == "Collision");

            rb.sharedMaterial = new PhysicsMaterial2D("Enemy Physics Material")
            {
                bounciness = 0,
                friction = 0,
            };
        }

        protected abstract void Die();
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

using UnityEngine;
using UnityEngine.Tilemaps;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Abstract
{
    public abstract class Enemy : MonoBehaviour
    {
        protected Collider2D col;
        protected Player p;
        protected Rigidbody2D rb;
        protected TilemapCollider2D tilemap;

        protected virtual void Awake() => AssignVars();

        protected virtual void Update() => Move();

        protected virtual void AssignVars()
        {
            col = GetComponent<Collider2D>();
            p = FindObjectOfType<Player>();
            rb = GetComponent<Rigidbody2D>();
            tilemap = FindObjectOfType<TilemapCollider2D>();

            col.sharedMaterial = new PhysicsMaterial2D("Enemy Physics Material")
            {
                bounciness = 0,
                friction = 0,
            };
        }

        protected abstract void Die();
        protected abstract void OnHitPlayer();
        protected abstract void OnPlayerStomp();
        protected abstract void Move();
    }
}

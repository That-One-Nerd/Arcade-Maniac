using System;
using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Abstract;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class EnemyRolling : Enemy
    {
        public float damage;
        public float force;
        public ForceMode2D forceMode;
        public float friction;
        public float groundDist;

        private bool moveRight;

        protected override void Awake()
        {
            AssignVars();
            rb.sharedMaterial = new PhysicsMaterial2D("Rolling Enemy Physics Material")
            {
                bounciness = 0,
                friction = friction,
            };
        }

        protected override void Die() => Destroy(gameObject);

        protected override void OnHitPlayer() => Statistics.instance.PlayerHealth -= damage;

        protected override void Move()
        {
            rb.AddForce(Time.deltaTime * force * (moveRight ? Vector2.right : Vector2.left), forceMode);

            Vector2 rayPos = new Vector2((moveRight ? col.bounds.max : col.bounds.min).x, col.bounds.center.y);
            RaycastHit2D hit = Physics2D.RaycastAll(rayPos, Vector2.down, groundDist + (col.bounds.size.y / 2)).FirstOrDefault(x =>
                x.collider.gameObject == tilemap.gameObject);
            // ^ I must compare gameObjects instead of the colliders themselves, probably because the raycast hit
            // is a regular Collider2D, whileas the tilemap collider is a TilemapCollider2D.

            rb.gravityScale = hit.normal == Vector2.up || hit.normal == Vector2.zero ? 1 : 0;
        }

        protected void OnCollisionStay2D(Collision2D collision)
        {
            const float dividend = 10;
            if (collision.contacts.Any(x =>
                Mathf.Round(x.point.x * dividend) / dividend ==
                Mathf.Round((moveRight ? col.bounds.max : col.bounds.min).x * dividend) / dividend))
                    moveRight = !moveRight; // gotta round or it doesn't work.
                                            // change the dividend to change the rounding precision
        }
    }
}

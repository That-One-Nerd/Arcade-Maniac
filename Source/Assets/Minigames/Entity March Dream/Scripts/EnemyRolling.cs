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

        private bool moveRight;

        protected override void Awake()
        {
            AssignVars();
            col.sharedMaterial = new PhysicsMaterial2D("Rolling Enemy Physics Material")
            {
                bounciness = 0,
                friction = friction,
            };
        }

        protected override void Die()
        {
            throw new NotImplementedException();
        }

        protected override void OnHitPlayer() => Statistics.instance.PlayerHealth -= damage;

        protected override void OnPlayerStomp() => Die();

        protected override void Move()
        {
            rb.AddForce(Time.deltaTime * force * (moveRight ? Vector2.right : Vector2.left), forceMode);
            
            /*RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down);
            Debug.Log(hit.First(x => x.collider == tilemap).normal);

            ^ currently trying to make the enemy detect when they are at a slope, and disable gravity
            when they are, but the raycasts are being kind of stupid, and I'll work on it some more
            later. If this gets uncommented it will throw `Sequence contains no matching element` error
            no matter what, so this stays commented for now.*/
        }
    }
}

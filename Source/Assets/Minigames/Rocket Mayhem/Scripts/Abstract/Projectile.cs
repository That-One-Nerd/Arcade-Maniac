using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem.Abstract
{
    public abstract class Projectile : MonoBehaviour
    {
        public float lifetime;
        public float speed;
        public float speedRot;
        public Sprite sprite;

        internal PlayerRocket player;

        protected Rigidbody2D rb;
        protected SpriteRenderer sr;
        protected float time;

        protected virtual void Awake() => AssignVars();

        protected virtual void Update()
        {
            time += Time.deltaTime;

            if (time >= lifetime)
            {
                Despawn();
                return;
            }

            Move(player.transform.position);

            // TODO: Add detection for collision
        }

        protected virtual void AssignVars()
        {
            player = FindObjectOfType<PlayerRocket>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        protected virtual void Despawn() => Destroy(gameObject);
        protected virtual void OnHitPlayer() => Debug.Log("Hit");
        protected virtual void Move(Quaternion atRotation)
        {
            transform.rotation = transform.rotation.Interpolate(atRotation, speedRot); ;
            rb.velocity = speed * transform.up;
        }
        protected virtual void Move(Vector2 toPosition)
        {
            Vector2 dist = Vector2.ClampMagnitude(player.transform.position - transform.position, 1);
            Vector2 normalized = dist.normalized;

            float tan = Mathf.Atan2(normalized.y, normalized.x) * (180 / Mathf.PI);
            Move(Quaternion.Euler(Vector3.forward * (tan - 90)));
        }
    }
}

using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem.Abstract
{
    public abstract class Projectile : MonoBehaviour
    {
        public float activeTime;
        public float speed;
        public float speedIncrease;
        public float speedRot;

        internal PlayerRocket player;

        protected Collider2D col;
        protected Rigidbody2D rb;
        protected SpriteRenderer sr;
        protected float time;

        protected virtual void Awake()
        {
            AssignVars();
            Vector2 dist = Vector2.ClampMagnitude(player.transform.position - transform.position, 1);
            Vector2 normalized = dist.normalized;

            float tan = Mathf.Atan2(normalized.y, normalized.x) * (180 / Mathf.PI);
            transform.rotation = Quaternion.Euler(Vector3.forward * (tan - 90));
        }
        protected virtual void Update()
        {
            time += Time.deltaTime;

            if (time <= activeTime) MoveActive(player.transform.position);
            else if (!sr.isVisible) Despawn();
            else
            {
                MoveIdle();
                speed += speedIncrease * Time.deltaTime;
            }

            if (col.IsTouching(player.col)) HitPlayer();
        }

        protected virtual void AssignVars()
        {
            col = GetComponent<Collider2D>();
            player = FindObjectOfType<PlayerRocket>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        protected virtual void Despawn() => Destroy(gameObject);
        protected virtual void HitPlayer()
        {
            Debug.Log("hit");
            Despawn();
        }

        protected virtual void MoveActive(Quaternion toRot)
        {
            transform.rotation = transform.rotation.Interpolate(toRot, speedRot);
            rb.velocity = speed * transform.up;
        }
        protected virtual void MoveActive(Vector2 toPos)
        {
            Vector2 dist = Vector2.ClampMagnitude(player.transform.position - transform.position, 1);
            Vector2 normalized = dist.normalized;

            float tan = Mathf.Atan2(normalized.y, normalized.x) * (180 / Mathf.PI);
            MoveActive(Quaternion.Euler(Vector3.forward * (tan - 90)));
        }

        protected virtual void MoveIdle() => rb.velocity = speed * transform.up;
    }
}

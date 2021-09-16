using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class Player : MonoBehaviour
    {
        public bool IsGrounded => Physics2D.OverlapBoxAll(
            new float2(col.bounds.center.x, col.bounds.min.y - (maxGroundDist / 2)),
            new float2(col.bounds.extents.x, maxGroundDist), 0).Any(x => x.CompareTag(groundTag));

        public float animSpeed;
        public string groundTag;
        public float jumpHeight;
        public float maxGroundDist;
        public float speed;

        internal float coinsCollected;
        internal Collider2D col;

        private Animator anim;
        private Rigidbody2D rb;
        private SpriteRenderer sr;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            col = GetComponent<Collider2D>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();

            rb.sharedMaterial = new PhysicsMaterial2D("Player Physics Material")
            {
                bounciness = 0,
                friction = 0,
            };
        }

        private void Update()
        {
            Movement();
            Animation();
            Collision();
        }

        private void Movement()
        {
            float2 velocity = rb.velocity;

            velocity.x = Input.GetAxisRaw("Horizontal") * speed;

            if (Input.GetAxisRaw("Vertical") > 0 && IsGrounded) velocity.y = jumpHeight;

            rb.velocity = velocity;
        }

        private void Animation()
        {
            sr.flipX = rb.velocity.x <= 0 && (rb.velocity.x < 0 || sr.flipX);

            const float dividend = 10;
            float2 rounded = new float2(Mathf.Round(rb.velocity.x * dividend), Mathf.Round(rb.velocity.y * dividend)) / dividend;

            anim.SetInteger("Mode", IsGrounded ? rounded.x == 0 ? 0 : 1 : rounded.y > 0 ? 2 : 3);
            anim.SetFloat("Speed", Mathf.Abs(rounded.x * animSpeed));
        }

        private void Collision()
        {
            Vector2 offset = col.offset;

            offset.x = 0.0625f * (sr.flipX ? -1 : 1);

            col.offset = offset;
        }
    }
}

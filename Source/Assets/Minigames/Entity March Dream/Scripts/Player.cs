using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class Player : MonoBehaviour
    {
        public bool IsGrounded => col != null && Physics2D.OverlapBoxAll(
            new Vector2(col.bounds.center.x, col.bounds.min.y - (maxGroundDist / 2)),
            new Vector2(col.bounds.extents.x, maxGroundDist), 0).Any(x => x.CompareTag(groundTag));

        public float animSpeed;
        public AudioClip coinSound;
        public float deathDrag;
        public float deathFloor;
        public float fallSpeed;
        public float gravityScale;
        public string groundTag;
        public AudioClip healSound;
        public AudioClip hurtSound;
        public Color invulFlashColor;
        public float invulFlashSpeed;
        public float invulTime;
        public float jumpHeight;
        public float jumpHeightDeath;
        public AudioClip landSound;
        public AudioClip jumpSound;
        public float maxGroundDist;
        public float speed;
        public AudioClip stompSound;
        public AudioClip walkSound;

        internal Animator anim;
        internal AudioSource audioSource;
        internal Collider2D col;
        internal Rigidbody2D rb;

        private bool alive;
        private bool oldIsGrounded;
        private SpriteRenderer sr;

        private void Awake()
        {
            alive = true;

            anim = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
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
            rb.simulated = !PauseMenu.IsPaused;
            if (PauseMenu.IsPaused)
            {
                anim.SetFloat("Speed", 0);
                return;
            }

            if (alive)
            {
                Movement();
                Collision();
            }
            Animation();

            if (rb.velocity.y < 0) rb.velocity += Vector2.down * Mathf.Abs(fallSpeed * Time.deltaTime);

            if (!sr.isVisible) rb.velocity = Vector2.zero;
            if (transform.position.y < deathFloor) Die();

            if (Statistics.Instance != null)
            {
                if (Statistics.Instance.playerInvul.HasValue)
                    Statistics.Instance.playerInvul =
                        Statistics.Instance.playerInvul <= 0 ? null
                        : Statistics.Instance.playerInvul - Time.deltaTime;

                float colorVal = Mathf.Cos(alive ? (Statistics.Instance.playerInvul ?? 0) * invulFlashSpeed : Mathf.PI) / 2 + 0.5f;
                sr.color = Color.Lerp(invulFlashColor, Color.white, colorVal);
            }
        }

        private void Movement()
        {
            Vector2 velocity = rb.velocity;

            velocity.x = Input.GetAxisRaw("Horizontal") * speed;

            if (Input.GetAxisRaw("Vertical") > 0 && IsGrounded) velocity.y = jumpHeight;

            if (IsGrounded != oldIsGrounded)
            {
                if (IsGrounded) audioSource.PlayOneShot(landSound);
                else if (Input.GetAxisRaw("Vertical") > 0) audioSource.PlayOneShot(jumpSound);
            }

            rb.velocity = velocity;

            oldIsGrounded = IsGrounded;
        }
        private void Animation()
        {
            sr.flipX = rb.velocity.x <= 0 && (rb.velocity.x < 0 || sr.flipX);

            const float dividend = 10;
            Vector2 rounded = new Vector2(Mathf.Round(rb.velocity.x * dividend), Mathf.Round(rb.velocity.y * dividend)) / dividend;

            anim.SetInteger("Mode", IsGrounded ? rounded.x == 0 ? 0 : 1 : rounded.y > 0 ? 2 : 3);
            anim.SetFloat("Speed", Mathf.Abs(rounded.x * animSpeed));
        }
        private void Collision()
        {
            Vector2 offset = col.offset;

            offset.x = 0.0625f * (sr.flipX ? -1 : 1);

            col.offset = offset;
        }

        private void PlayWalkSound() => audioSource.PlayOneShot(walkSound);

        public void Die()
        {
            if (!alive) return;
            alive = false;
            Statistics.Instance.PlayerHealth = 0;
            rb.drag = deathDrag;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeightDeath);
            Destroy(col);
            audioSource.PlayOneShot(hurtSound);

            Transition.Instance.InstantTransition(SceneManager.GetActiveScene().name, 2.5f);
        }

        public enum InvulFlashMode
        {
            Transparent,
            Red,
        }
    }
}

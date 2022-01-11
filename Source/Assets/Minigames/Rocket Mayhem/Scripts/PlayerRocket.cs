using System.Collections;
using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem
{
    public class PlayerRocket : MonoBehaviour
    {
        public bool AnyMouseButton => Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2);

        public float activeDecreaseSpeed;
        public float activeIncreaseSpeed;
        public ParticleSystem[] particles;
        public Sprite[] possibleRockets;
        public float speed;
        public float speedRot;

        internal Collider2D col;

        private float active = 0;
        private Camera cam;
        private Rigidbody2D rb;
        private SpriteRenderer sr;

        private void Awake()
        {
            cam = FindObjectOfType<Camera>();
            col = FindObjectOfType<Collider2D>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();

            sr.sprite = possibleRockets[Random.Range(0, possibleRockets.Length)];
        }

        private void Update()
        {
            active = Mathf.Clamp01(active +
                Time.deltaTime * (AnyMouseButton ? activeIncreaseSpeed : Mathf.Abs(activeDecreaseSpeed) * -1));

            if (active == 0) return;

            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3 dist = Vector3.ClampMagnitude(mousePos - transform.position, 1);

            Vector3 normalized = dist.normalized;
            float tan = Mathf.Atan2(normalized.y, normalized.x) * (180 / Mathf.PI) - 90;

            Quaternion rot = transform.rotation;

            Quaternion newRot = rot.Interpolate(Quaternion.Euler(Vector3.forward * tan), speedRot * active);

            transform.rotation = newRot;

            rb.velocity = active * speed * transform.up;
        }
    }
}

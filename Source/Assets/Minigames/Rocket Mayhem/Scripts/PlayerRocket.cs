using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem
{
    public class PlayerRocket : MonoBehaviour
    {
        public bool AnyMouseButton => Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2);

        public float activeDecreaseSpeed;
        public float activeIncreaseSpeed;
        public Sprite[] possibleRockets;
        public float speed;
        public float speedRot;

        private float active = 0;
        private Camera cam;
        private Rigidbody2D rb;
        private SpriteRenderer sr;

        private void Awake()
        {
            cam = FindObjectOfType<Camera>();
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();

            sr.sprite = possibleRockets[Random.Range(0, possibleRockets.Length)];
        }

        private void Update()
        {
            active = Mathf.Clamp01(active +
                Time.deltaTime * (AnyMouseButton ? activeIncreaseSpeed : Mathf.Abs(activeDecreaseSpeed) * -1));

            if (active == 0) return;

            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition),
                dist = mousePos - transform.position;

            rb.velocity = active * speed * dist.normalized;

            float hypo = Mathf.Sqrt(dist.x * dist.x + dist.y * dist.y),
                tan = Mathf.Atan2(dist.y / hypo, dist.x / hypo) * (180 / Mathf.PI);

            const float addive = 360;
            float rot = transform.rotation.eulerAngles.z + addive;
            transform.rotation = Quaternion.Euler(Vector3.forward * (rot.Interpolate(tan + 270, speedRot) - addive));
            // TODO: make rotation better
        }
    }
}

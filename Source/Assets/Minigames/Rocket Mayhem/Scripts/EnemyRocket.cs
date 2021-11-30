using UnityEngine;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem
{
    public class EnemyRocket : MonoBehaviour
    {
        public PlayerRocket player;
        public float rocketSpeed;
        public float speedRot;

        private Rigidbody2D rb;

        private void Start() => rb = GetComponent<Rigidbody2D>();

        private void Update()
        {
            Vector3 dist = Vector3.ClampMagnitude(player.transform.position - transform.position, 1);
            Vector3 normalized = dist.normalized;

            float tan = Mathf.Atan2(normalized.y, normalized.x) * (180 / Mathf.PI) - 90;
            Quaternion rot = transform.rotation;
            Quaternion newRot = rot.Interpolate(Quaternion.Euler(Vector3.forward * tan), speedRot);

            transform.rotation = newRot;
            rb.velocity = rocketSpeed * transform.up;
        }
    }
}

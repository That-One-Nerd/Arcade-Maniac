using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class PlayerCamera : MonoBehaviour
    {
        private Collider2D col;
        private Player p;

        private void Awake()
        {
            col = GetComponent<Collider2D>();
            p = FindObjectOfType<Player>();
        }

        private void Update()
        {
            Vector3 position = transform.position;
            Vector4 dist = new Vector4(
                p.transform.position.x - col.bounds.min.x,
                p.transform.position.y - col.bounds.min.y,
                p.transform.position.x - col.bounds.max.x,
                p.transform.position.y - col.bounds.max.y);

            position.x += dist.x < 0 ? dist.x : dist.z > 0 ? dist.z : 0;
            position.y += dist.y < 0 ? dist.y : dist.w > 0 ? dist.w : 0;

            position.x = position.x < 0 ? 0 : position.x;
            position.y = position.y < 0 ? 0 : position.y;

            transform.position = position;
        }
    }
}

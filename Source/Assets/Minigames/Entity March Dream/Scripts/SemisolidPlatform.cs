using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class SemisolidPlatform : MonoBehaviour
    {
        public float detectionGiveRoom;
        public float colliderSize;

        private bool above;
        private BoxCollider2D col;
        private Player p;
        private SpriteRenderer sr;

        private void Awake()
        {
            col = gameObject.AddComponent<BoxCollider2D>();
            p = FindObjectOfType<Player>();
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            above = p.col == null ? above : p.col.bounds.min.y + (detectionGiveRoom * (above ? 1 : -1)) >= col.bounds.max.y;

            col.enabled = above;
            col.size = new Vector2(sr.bounds.size.x - colliderSize / 2, colliderSize);
            col.offset = Vector2.up * (sr.bounds.size.y / 2 - 0.01f);
        }
    }
}

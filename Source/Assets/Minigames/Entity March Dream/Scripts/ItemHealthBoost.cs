using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Abstract;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class ItemHealthBoost : Item
    {
        public Mode mode;
        public float speed;

        private bool moveRight = true;

        protected override void Move() => rb.velocity = new Vector2(speed * (moveRight ? 1 : -1), rb.velocity.y);

        protected override void OnCollected() => Statistics.Instance.PlayerHealth += mode switch
        {
            Mode.QuarterHealth => 0.25f,
            Mode.HalfHealth => 0.5f,

            _ => 0,
        };

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.GetContact(0).point.y > col.bounds.min.y)
                moveRight = !moveRight;
        }

        public enum Mode : byte
        {
            QuarterHealth,
            HalfHealth,
        }
    }
}

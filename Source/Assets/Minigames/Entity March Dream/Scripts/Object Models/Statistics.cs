using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels
{
    public class Statistics
    {
        public static Statistics instance = new Statistics();

        public float PlayerHealth
        {
            get => p_PlayerHealth;
            set
            {
                value = Mathf.Clamp01(value);
                if (p_PlayerHealth == value || playerInvul.HasValue) return;

                p_PlayerHealth = value;
                if (value == 0) player.Die();
                else playerInvul = player.invulTime;
            }
        }

        public int coinsCollected;
        public Player player = Object.FindObjectOfType<Player>();
        public float? playerInvul;

        private float p_PlayerHealth = 1;
    }
}

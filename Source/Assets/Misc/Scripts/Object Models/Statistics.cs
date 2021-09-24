using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels
{
    public class Statistics
    {
        public static Statistics instance = new Statistics();

        public float CompletedPercent => completedGames / (float)requiredGames * 100;
        public float CompletedPercentTotal => completedGames / (float)totalGames * 100;

        public int PlayerHealth
        {
            get => p_PlayerHealth;
            set
            {
                if (value < 0) player.Die();
                p_PlayerHealth = value;
            }
        }

        public int completedGames = 0;
        public Player player = Object.FindObjectOfType<Player>();
        public int requiredGames = 12;
        public int totalGames = 20;

        private int p_PlayerHealth;
    }
}

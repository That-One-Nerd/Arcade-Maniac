using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels
{
    public class GeneralStats
    {
        public static GeneralStats instance = new GeneralStats();

        public float CompletedPercent => completedGames / (float)requiredGames * 100;
        public float CompletedPercentTotal => completedGames / (float)totalGames * 100;

        public int completedGames = 0;
        public int requiredGames = 12;
        public int totalGames = 20;
    }
}

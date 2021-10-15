using System.Collections.Generic;
using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels
{
    public class Statistics
    {
        public static Statistics instance = new Statistics();

        public Statistics()
        {
            canvas = Object.FindObjectsOfType<Canvas>().FirstOrDefault(x => x.name == "Game Interface");
            canvasComponents = new Dictionary<GameObject, MonoBehaviour[]>();
            for (int i = 0; i < canvas.transform.childCount; i++)
            {
                GameObject child = canvas.transform.GetChild(i).gameObject;
                canvasComponents.Add(child, child.GetComponents<MonoBehaviour>());
            }

            player = Object.FindObjectOfType<Player>();
        }

        public float PlayerHealth
        {
            get => p_PlayerHealth;
            set
            {
                value = Mathf.Clamp01(value);
                if (p_PlayerHealth == value) return;
                else
                {
                    HealthBar health = (HealthBar)canvasComponents.FirstOrDefault(x => x.Key.name == "Health").Value
                        .FirstOrDefault(x => x.GetType() == typeof(HealthBar));

                    if (p_PlayerHealth > value)
                    {
                        if (playerInvul.HasValue) return;
                        health.OnLoseHealth();
                        if (value == 0) player.Die();
                        else playerInvul = player.invulTime;
                    }
                    else health.OnGainHealth();
                }

                p_PlayerHealth = value;
            }
        }

        public Canvas canvas;
        public Dictionary<GameObject, MonoBehaviour[]> canvasComponents;
        public int coinsCollected;
        public Player player;
        public float? playerInvul;

        private float p_PlayerHealth = 1;
    }
}

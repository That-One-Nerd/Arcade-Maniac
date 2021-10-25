using System.Collections.Generic;
using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels
{
    public class Statistics : MonoBehaviour
    {
        public static Statistics Instance { get; private set; }

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;

            canvas = FindObjectsOfType<Canvas>().FirstOrDefault(x => x.name == "Game Interface");
            canvasComponents = new Dictionary<GameObject, MonoBehaviour[]>();
            for (int i = 0; i < canvas.transform.childCount; i++)
            {
                GameObject child = canvas.transform.GetChild(i).gameObject;
                canvasComponents.Add(child, child.GetComponents<MonoBehaviour>());
            }

            player = FindObjectOfType<Player>();

            Instance = this;
        }

        public int CoinsCollected
        {
            get => p_CoinsCollected;
            set
            {
                if (p_CoinsCollected == value) return;
                CoinCounter counter = (CoinCounter)canvasComponents.FirstOrDefault(x => x.Key.name == "Coin Counter").Value
                    .FirstOrDefault(x => x.GetType() == typeof(CoinCounter));

                counter.OnCoinCollected();

                p_CoinsCollected = value;
            }
        }
        public float PlayerHealth
        {
            get => p_PlayerHealth;
            set
            {
                value = Mathf.Clamp01(value);
                if (p_PlayerHealth == value) return;
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

                p_PlayerHealth = value;
            }
        }

        internal Canvas canvas;
        internal Dictionary<GameObject, MonoBehaviour[]> canvasComponents;
        internal Player player;
        internal float? playerInvul;

        // these are strings in case you want to include special levels, like "Bonus/Miniboss"
        public string world;
        public string worldLevel;

        private int p_CoinsCollected;
        private float p_PlayerHealth = 1;
    }
}

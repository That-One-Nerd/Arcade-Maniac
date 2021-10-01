using System;
using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class Spikes : MonoBehaviour
    {
        public float damage;
        public float extraDamage;
        public float extraDamageSpeed;

        Player p;

        private void Awake() => p = FindObjectOfType<Player>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != p.col) return;
            Statistics.instance.PlayerHealth -= Math.Abs(p.rb.velocity.y) >= extraDamageSpeed ? extraDamage : damage;
        }
    }
}

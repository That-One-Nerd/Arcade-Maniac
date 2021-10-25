using System;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels
{
    [Serializable]
    public struct Loot
    {
        public bool Lottery => UnityEngine.Random.Range(0f, 1f) <= chance;

        public float chance;
        public GameObject lootObject;

        public Loot(float chance, GameObject lootObject)
        {
            this.chance = chance;
            this.lootObject = lootObject;
        }
    }
}

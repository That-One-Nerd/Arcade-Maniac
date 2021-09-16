using System;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Arcade
{
    public class Floor : MonoBehaviour
    {
        public static Action<Material> onGlowMatChange;

        public float glowDelay;
        public Material glowMat;

        private float glowTimer;

        private void Awake() => onGlowMatChange += ColorChange;

        private void Update()
        {
            glowTimer += Time.deltaTime;

            if (glowTimer > glowDelay)
            {
                onGlowMatChange.Invoke(glowMat);
                glowTimer = 0;
            }
        }

        private static void ColorChange(Material mat) => mat.color = Color.HSVToRGB(UnityEngine.Random.Range(0, 1f), 1, 1);
    }
}

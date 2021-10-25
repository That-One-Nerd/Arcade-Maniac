using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels;
using UnityEngine;
using UnityEngine.UI;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface
{
    public class HealthBar : MonoBehaviour
    {
        public ShakeData loseHealthShake;
        public float speed;

        private Animator anim;
        private Slider slider;

        public void Awake()
        {
            Camera cam = FindObjectOfType<Camera>();

            anim = GetComponent<Animator>();
            slider = GetComponent<Slider>();
            float ratio = cam.pixelWidth / cam.pixelHeight;
            loseHealthShake.intensity = new Vector3
            {
                x = loseHealthShake.intensity.x * (cam.pixelWidth / (cam.orthographicSize * 2)),
                y = loseHealthShake.intensity.y * (cam.pixelHeight / (cam.orthographicSize * 2)) * ratio,
            };

            anim.Play("Gain Health", -1, 1);
        }
        public void Update() => slider.value = slider.value.Interpolate(Statistics.Instance.PlayerHealth, speed);

        public void OnGainHealth() => anim.Play("Gain Health", -1, 0);
        public void OnLoseHealth() => this.Shake(loseHealthShake);
    }
}

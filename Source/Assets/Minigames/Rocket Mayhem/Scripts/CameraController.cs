using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem
{
    public class CameraController : MonoBehaviour
    {
        private PlayerRocket p;

        private void Awake() =>
            p = FindObjectOfType<PlayerRocket>();

        private void FixedUpdate()
        {
            transform.position = transform.position.Interpolate(new Vector3
            {
                x = p.transform.position.x,
                y = p.transform.position.y,
                z = -10,
            });
        }
    }
}

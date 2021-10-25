using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Arcade
{
    public class Cabinet : MonoBehaviour
    {
        public bool Avaliable => Physics.OverlapSphere(transform.position, activationRadius).Any(x => x.transform == p.transform);

        public float activationRadius;
        public float camMovementSpeed;
        public Transform camSetting;
        public float maxCamTimer;
        public string sceneName;
        public Texture transitionImage;

        private bool activated;
        private float camTimer;
        private Player p;

        private void Awake() => p = FindObjectOfType<Player>();
        private void Update()
        {
            if (activated == false) activated = Avaliable && GameManager.Submit;

            if (activated)
            {
                Player.canMove = false;
                Player.canRot = false;
                camTimer += Time.deltaTime;

                p.cam.transform.position += camMovementSpeed * Time.deltaTime * (camSetting.position - p.cam.transform.position);

                const float overAccount = 360;
                Vector3 desRot = camSetting.eulerAngles + (Vector3.one * overAccount), rot = p.cam.transform.eulerAngles + (Vector3.one * overAccount);
                rot = rot.Interpolate(desRot, camMovementSpeed);
                p.cam.transform.eulerAngles = rot - (Vector3.one * overAccount);

                if (camTimer >= maxCamTimer) Transition.Instance.ImageTransition(sceneName, 1);
            }
        }
    }
}

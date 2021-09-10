using System.Linq;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Arcade
{
    public class Door : MonoBehaviour
    {
        public DoorMode Mode
        {
            get => p_Mode;
            set
            {
                if (p_Mode != value) anim.Play(animName + " " + value, -1, 0);
                p_Mode = value;
            }
        }

        public float activationRadius;
        public string animName = "Door";

        private Animator anim;
        private DoorMode p_Mode;
        private Player p;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            p = FindObjectOfType<Player>();
        }
        private void Start() => anim.Play(animName + " " + p_Mode, -1, 1);
        private void Update() => Mode = Physics.OverlapSphere(transform.position, activationRadius).Any(x => x.transform == p.transform) ? DoorMode.Open : DoorMode.Closed;

        public enum DoorMode
        {
            Closed,
            Open,
        }
    }
}

using System.Collections;
using System.Linq;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.ObjectModels;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class Finish : MonoBehaviour
    {
        public float playerSpeed;
        public string transitionScene;
        public float transitionSpeed;

        private bool triggered;
        private Player p;
        private BoxCollider2D trigger;

        private void Awake()
        {
            p = FindObjectOfType<Player>();
            trigger = GetComponents<BoxCollider2D>().First(x => x.isTrigger);
        }

        private void Update()
        {
            if (PauseMenu.IsPaused) return;

            if (Physics2D.OverlapBoxAll(trigger.bounds.center, trigger.size, 0).Any(x => x == p.col) && !triggered)
            {
                StartCoroutine(IFinish());
                triggered = true;
            }
        }

        private IEnumerator IFinish()
        {
            GameObject p = this.p.gameObject;
            Animator pAnim = this.p.anim;
            this.p.rb.gravityScale = 0;
            this.p.rb.velocity = Vector2.zero;
            Destroy(this.p);
            pAnim.SetInteger("Mode", 1);

            const float dividend = 20;
            Vector2 roundedPos = new Vector2(
                    Mathf.Round(transform.position.x * dividend) / dividend,
                    Mathf.Round((transform.position.y - 0.1875f) * dividend) / dividend),
                playerPos = Vector2.positiveInfinity;

            while (roundedPos != playerPos)
            {                
                playerPos = new Vector2(
                    Mathf.Round(p.transform.position.x * dividend) / dividend,
                    Mathf.Round(p.transform.position.y * dividend) / dividend);

                p.transform.position = p.transform.position.Interpolate(roundedPos, playerSpeed);

                yield return null;
            }

            pAnim.SetInteger("Mode", 0);
            p.transform.position = transform.position + Vector3.down * 0.1875f;

            new SaveData().Save();
            Transition.Instance.FadeTransition(transitionScene, transitionSpeed);
        }
    }
}

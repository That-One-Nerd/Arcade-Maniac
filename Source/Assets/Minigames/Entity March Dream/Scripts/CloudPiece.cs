using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Handlers;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class CloudPiece : MonoBehaviour
    {
        [Header("(Sin)wave")]
        public float waveOffset;
        public float waveSize;
        public float waveSpeed;

        private PoolHandler.PoolObject pooled;
        private float startedSeen;
        private Renderer ren;
        private float waveTimer;

        private void Awake()
        {
            pooled = GetComponent<PoolHandler.PoolObject>();
            ren = GetComponent<Renderer>();
            waveTimer = waveOffset;
        }

        private void Update()
        {
            startedSeen += startedSeen == -1 ? 0 : Time.deltaTime;
            transform.position += new Vector3(Time.deltaTime, 0, 0);
            if (ren.isVisible) startedSeen = -1;
            else if ((!ren.isVisible && startedSeen == -1) || startedSeen >= 2) pooled.Handler.Deposit(gameObject);

            waveTimer += Time.deltaTime * waveSpeed;
            transform.localScale = Vector3.one * (((Mathf.Cos(waveTimer) + 1) * waveSize / 2) + 1);
        }

        private void OnEnable() => startedSeen = 0;
    }
}

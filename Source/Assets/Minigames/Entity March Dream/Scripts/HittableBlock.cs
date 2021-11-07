using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class HittableBlock : MonoBehaviour
    {
        public float collisionGiveRoom;
        public Loot hitLoot;
        public Sprite hitSprite;
        public int maxHits;

        private Animator anim;
        private GameObject child;
        private Collider2D col;
        private int hits;
        private bool isHit;
        private Player p;
        private float? spawnTimer = null;
        private float timeUntilSpawn;

        private void Awake()
        {
            child = transform.GetChild(0).gameObject;
            anim = child.GetComponent<Animator>();
            col = GetComponent<Collider2D>();
            p = FindObjectOfType<Player>();

            anim.Play("Block Hit", -1, 1);
        }
        private void Update()
        {
            anim.speed = PauseMenu.IsPaused ? 0 : 1;
            if (PauseMenu.IsPaused) return;

            if (spawnTimer != null)
            {
                spawnTimer += Time.deltaTime;
                if (spawnTimer >= timeUntilSpawn)
                {
                    spawnTimer = null;
                    if (hitLoot.Lottery) 
                        Instantiate(hitLoot.lootObject, transform.position + new Vector3(0, 1), default, transform);
                    isHit = false;
                    hits++;

                    if (hits >= maxHits)
                    {
                        // I usually use `GetComponent<T>()` in the `Awake()` method exclusively, but I will make an
                        // exception if I use it only once. In this case, I am deleting this script directly after, so
                        // this only gets triggered once.
                        child.GetComponent<SpriteRenderer>().sprite = hitSprite;
                        Destroy(this);
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider != p.col || isHit) return;
            Bounds bounds = col.bounds, boundsP = collision.collider.bounds;

            if (bounds.min.y >= boundsP.max.y - collisionGiveRoom)
            {
                spawnTimer = 0;
                isHit = true;
                anim.Play("Block Hit", -1, 0);
                timeUntilSpawn = anim.GetCurrentAnimatorStateInfo(0).length;
            }
        }
    }
}

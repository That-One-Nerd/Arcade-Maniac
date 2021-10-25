using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class HittableBlock : MonoBehaviour
    {
        public float collisionGiveRoom;
        public Sprite hitSprite;
        public float timeUntilSpawn;
        public GameObject toSpawn;

        private Animator anim;
        private GameObject child;
        private Collider2D col;
        private bool hit;
        private Player p;
        private float? spawnTimer = null;

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
                    // I usually use `GetComponent<T>()` in the `Awake()` method exclusively, but I will make an
                    // exception if I use it only once. In this case, I am deleting this script directly after, so
                    // this only gets triggered once.
                    child.GetComponent<SpriteRenderer>().sprite = hitSprite;
                    spawnTimer = null;
                    Instantiate(toSpawn, transform.position + new Vector3(0, 1), default, transform);
                    Destroy(this);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider != p.col || hit) return;
            Bounds bounds = col.bounds, boundsP = collision.collider.bounds;

            if (bounds.min.y >= boundsP.max.y - collisionGiveRoom)
            {
                spawnTimer = 0;
                hit = true;
                anim.Play("Block Hit", -1, 0);
            }
        }
    }
}

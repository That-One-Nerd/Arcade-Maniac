using That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream.Bunches.GameInterface;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Handlers;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.EntityMarchDream
{
    public class Clouds : MonoBehaviour
    {
        public Transform aquiredTransform;
        public Transform poolTransform;

        private Camera cam;
        private float desiredTimer;
        private Player p;
        private PoolHandler pool;
        private float timer;

        private void Awake()
        {
            cam = FindObjectOfType<Camera>();
            p = FindObjectOfType<Player>();
            pool = new PoolHandler(poolTransform);
            foreach (GameObject obj in pool.PooledObjects) obj.AddComponent<CloudPiece>();
        }

        private void Update()
        {
            if (PauseMenu.IsPaused) return;

            if (timer >= desiredTimer)
            {
                desiredTimer = Random.Range(2.5f, 5);
                timer = 0;
                SummonCloud();
            }
            timer += Time.deltaTime;
        }

        public void SummonCloud()
        {
            bool spawnRight = p.rb.velocity.x > 1;
            int bunch = Random.Range(2, 5);
            GameObject[] objs = pool.Aquire(aquiredTransform, bunch);
            Vector2 points = cam.ScreenToWorldPoint(new Vector2(spawnRight ? cam.scaledPixelWidth : 0, cam.scaledPixelHeight));
            points.x += 1.5f * (spawnRight ? 1 : -1);

            foreach (GameObject obj in objs)
            {
                CloudPiece piece = obj.GetComponent<CloudPiece>();
                piece.waveOffset = Random.Range(0f, 1);
                piece.waveSize = Random.Range(0.25f, 0.5f);
                piece.waveSpeed = Random.Range(0.25f, 0.75f);
            }
            objs[0].transform.position = new Vector2(points.x, Random.Range(1, points.y));
            for (int i = 1; i < objs.Length; i++)
            {
                objs[i].transform.position = objs[0].transform.position -= new Vector3(Random.Range(bunch * -0.5f, 0.25f), Random.Range(-0.5f, 0.5f));
            }
        }
    }
}

using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Minigames.RocketMayhem
{
    public class EnemyRocketSpawner : MonoBehaviour
    {
        public EnemyRocket rocket;
        public PlayerRocket player;
        public float interval;

        private float seconds;

        private void Update()
        {
            seconds += Time.deltaTime;
            if (seconds >= interval)
            {
                seconds = 0;
                int rand = Random.Range(0, 4);

                // replaced the 4 if statements with a single one. you aren't expected to know this, don't worry.
                // just wanted to make it smaller.
                GameObject cloned = Instantiate(rocket.gameObject, rand switch
                {
                    0 => new Vector2(Random.Range(0, 20) - 10, -5),
                    1 => new Vector2(-10, Random.Range(0, 10) - 5),
                    2 => new Vector2(Random.Range(0, 20) - 10, 5),
                    3 => new Vector2(10, Random.Range(0, 10) - 5),

                    _ => Vector2.zero
                }, Quaternion.Euler(Vector3.zero));
                cloned.GetComponent<EnemyRocket>().player = player;
            }
        }
    }
}

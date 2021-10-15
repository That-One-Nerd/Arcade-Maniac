using System.Collections;
using That_One_Nerd.Unity.Games.ArcadeManiac.Misc.ObjectModels;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions
{
    public static class ShakeExtension
    {
        public static void Shake(this MonoBehaviour mono, ShakeData data) =>
            mono.StartCoroutine(IShake(mono.gameObject, data));
        public static void Shake(this MonoBehaviour mono, Vector3 intensity, float time, bool slowOverTime) => Shake(mono, new ShakeData
        {
            intensity = intensity,
            slowOverTime = slowOverTime,
            time = time,
        });
        public static void Shake(this MonoBehaviour mono, float intensityX, float intensityY, float intensityZ, float time, bool slowOverTime) => Shake(mono, new ShakeData
        {
            intensity = new Vector3(intensityX, intensityY, intensityZ),
            slowOverTime = slowOverTime,
            time = time,
        });

        private static IEnumerator IShake(GameObject obj, ShakeData data)
        {
            Vector3 startPos = obj.transform.position;

            for (float f = data.time; f > 0; f -= Time.deltaTime)
            {
                Vector3 random = new Vector3(Random.Range(-1f, 1), Random.Range(-1f, 1), Random.Range(-1f, 1));

                Vector3 multiply = new Vector3()
                {
                    x = data.intensity.x * random.x,
                    y = data.intensity.y * random.y,
                    z = data.intensity.z * random.z,
                };

                obj.transform.position = startPos + multiply * (data.slowOverTime ? f / data.time : 1);
                yield return null;
            }

            obj.transform.position = startPos;
        }
    }
}

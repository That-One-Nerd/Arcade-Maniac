using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions
{
    public static class InterpolateExtension
    {
        public static float Interpolate(this float f, float desiredValue, float speed = 1) =>
            Mathf.Lerp(f, desiredValue, speed * Time.deltaTime);

        public static Vector2 Interpolate(this Vector2 v, Vector2 desiredValue, float speed = 1) =>
            Vector2.Lerp(v, desiredValue, speed * Time.deltaTime);

        public static Vector3 Interpolate(this Vector3 v, Vector3 desiredValue, float speed = 1) =>
            Vector3.Lerp(v, desiredValue, speed * Time.deltaTime);

        public static Quaternion Interpolate(this Quaternion q, Quaternion desiredValue, float speed = 1) =>
            Quaternion.Lerp(q, desiredValue, speed * Time.deltaTime);
    }
}

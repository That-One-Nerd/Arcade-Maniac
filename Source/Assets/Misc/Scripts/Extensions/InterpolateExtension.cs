using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions
{
    public static class InterpolateExtension
    {
        public const float snapFPS = 18;

        public static float Interpolate(this float f, float desiredValue, float speed = 1) =>
            Time.deltaTime <= 1 / snapFPS ? f + speed * Time.deltaTime * (desiredValue - f) : desiredValue;

        public static Vector2 Interpolate(this Vector2 v, Vector2 desiredValue, float speed = 1) =>
            Time.deltaTime <= 1 / snapFPS ? v + speed * Time.deltaTime * (desiredValue - v) : desiredValue;

        public static Vector3 Interpolate(this Vector3 v, Vector3 desiredValue, float speed = 1) =>
            Time.deltaTime <= 1 / snapFPS ? v + speed * Time.deltaTime * (desiredValue - v) : desiredValue;

        public static Quaternion Interpolate(this Quaternion q, Quaternion desiredValue, float speed = 1) =>
            Quaternion.Lerp(q, desiredValue, speed * Time.deltaTime);
    }
}

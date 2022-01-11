using System;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions
{
    public static class GetPointAlongExtension
    {
        public static Vector2 GetPointAlong(this Rect r, float percent)
        {
            percent %= 1;

            Vector2 percentOfWhole = GetPercentOfWhole();
            Vector2[] keyVerts = GetKeyVerts();

            bool secondQuarter = percent > percentOfWhole.x;
            Vector2[] keyLine = GetKeyLine();

            if (secondQuarter) percent -= percentOfWhole.x;
            percent /= secondQuarter ? percentOfWhole.y : percentOfWhole.x;

            return Vector2.Lerp(keyLine[0], keyLine[1], percent);

            Vector2[] GetKeyVerts()
            {
                Vector2[] verts = new Vector2[4]
                {
                    new Vector2(r.min.x, r.min.y),
                    new Vector2(r.max.x, r.min.y),
                    new Vector2(r.max.x, r.max.y),
                    new Vector2(r.min.x, r.max.y)
                };

                bool secondHalf = percent > 0.5f;
                if (secondHalf)
                {
                    percent -= 0.5f;
                    percentOfWhole = new Vector2(percentOfWhole.y, percentOfWhole.x);
                }

                return new Vector2[3]
                {
                    verts[0],
                    verts[Convert.ToInt32(secondHalf) * 2 + 1],
                    verts[2]
                };
            }
            Vector2 GetPercentOfWhole()
            {
                Vector2 lengths = new Vector2(Mathf.Abs(r.max.x - r.min.x), Mathf.Abs(r.max.y - r.min.y));
                float lineLength = lengths.x * 2 + lengths.y * 2;
                return new Vector2(lengths.x / lineLength, lengths.y / lineLength);
            }
            Vector2[] GetKeyLine()
            {
                int index = Convert.ToInt32(secondQuarter);
                return new Vector2[2]
                {
                    keyVerts[index],
                    keyVerts[index + 1]
                };
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions
{
    public static class ContainsAtExtension
    {
        public static bool ContainsAt<T>(this IEnumerable<T> list, int index, IEnumerable<T> check)
            where T : IEquatable<T>
        {
            bool fits = true;

            int listLength = list.Count(), checkLength = check.Count();
            for (int i = index, j = 0; i < listLength && j < checkLength; i++, j++)
            {
                if (i == listLength - 1 && j != checkLength - 1) return false;
                fits &= list.ElementAt(i).Equals(check.ElementAt(j));
            }

            return fits;
        }
    }
}

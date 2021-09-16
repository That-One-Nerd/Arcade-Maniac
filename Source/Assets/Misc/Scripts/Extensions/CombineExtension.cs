namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions
{
    public static class CombineExtension
    {
        public static string Combine(this string current)
        {
            string finish = "";
            for (int i = 0; i < current.Length; i++)
            {
                if (i == 0) finish += char.ToUpper(current[i]);
                else if (current[i] == ' ')
                {
                    if (current[i + 1] == ' ') continue;
                    else
                    {
                        finish += char.ToUpper(current[i + 1]);
                        i++;
                    }
                }
                else finish += current[i];
            }

            return finish;
        }
    }
}

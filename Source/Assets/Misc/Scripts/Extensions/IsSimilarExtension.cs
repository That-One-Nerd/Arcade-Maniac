namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions
{
    public static class IsSimilarExtension
    {
        public static bool IsSimilar(this string a, string b) => a.Trim().ToLower() == b.Trim().ToLower();
    }
}

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Extensions
{
    public static class DifferenceExtension
    {
        public static string GetDifference(this string a, string b) => b.Replace(a, "");
    }
}

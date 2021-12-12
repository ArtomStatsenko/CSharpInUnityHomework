namespace ArtomStatsenko
{
    public static class Extensions
    {
        public static bool TryBool(this string self)
        {
            return bool.TryParse(self, out var result) && result;
        }

        public static float TryFloat(this string self)
        {
            return float.TryParse(self, out float result) ? result : default;
        }
    }
}
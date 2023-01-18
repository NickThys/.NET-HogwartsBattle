namespace DotNetHogwartsBattle.Common
{
    public static class ListExtenstion
    {
        public static List<T> Randomize<T>(this List<T> source)
        {
            var rnd = new Random();
            return source.AsEnumerable().OrderBy((_) => rnd.Next()).ToList();
        }
    }
}
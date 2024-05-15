namespace K16231MilkWebAPI.Utils
{
    public static class EnumerableUtil
    {
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}

namespace Otus_Homework_12;

public static partial class Enumerable
{
    public static IEnumerable<TSource> Top<TSource>(this IEnumerable<TSource> source, int percent, bool sort = true)
    {
        CheckSourceAndPercent(source, percent);

        var sorted = source;

        if (sort) sorted = source.OrderByDescending(v => v);

        return GetPercent(sorted, percent);
    }

    public static IEnumerable<TSource> Top<TSource, TValue>(this IEnumerable<TSource> source, int percent,
        Func<TSource, TValue> value)
    {
        return source.OrderByDescending(value).Top(percent, false);
    }

    private static void CheckSourceAndPercent<TSource>(IEnumerable<TSource>? source, int percent)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (percent > 100 || percent < 1) throw new ArgumentException("Parameter 'count' must be between 1% and 100%");
    }

    private static IEnumerable<TSource> GetPercent<TSource>(IEnumerable<TSource> sorted, int percent)
    {
        var count = sorted.Count();

        var percentCount = (int)Math.Ceiling((float)count * percent / 100);

        return sorted.Take(percentCount);
    }
}
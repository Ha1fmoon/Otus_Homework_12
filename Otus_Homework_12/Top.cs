namespace Otus_Homework_12;

public static partial class Enumerable
{
    public static IEnumerable<TSource> Top<TSource>(this IEnumerable<TSource> source, int percent)
    {
        CheckSourceAndPercent(source, percent);

        var enumerable = source.OrderByDescending(v => v).ToList();
        
        return enumerable.Take(GetPercent(enumerable, percent));
    }

    public static IEnumerable<TSource> Top<TSource, TValue>(this IEnumerable<TSource> source, int percent, Func<TSource, TValue> value)
    {
        CheckSourceAndPercent(source, percent);
        
        var enumerable = source.OrderByDescending(value).ToList();
        
        return enumerable.Take(GetPercent(enumerable, percent));
    }
    
    private static void CheckSourceAndPercent<TSource>(IEnumerable<TSource>? source, int percent)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (percent > 100 || percent < 1)
        {
            throw new ArgumentException("Parameter 'count' must be between 1% and 100%");
        }
    }

    private static int GetPercent<TSource>(this List<TSource>enumerable, int percent)
    {
        var percentValue = (float)enumerable.Count * percent / 100;
        return (int)Math.Ceiling(percentValue);
    }
}
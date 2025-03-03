namespace Otus_Homework_12;

public static partial class Enumerable
{
    public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count)
    {
        ArgumentNullException.ThrowIfNull(collection);

        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Element count must be positive.");

        for (var i = 0; i < count; i++) yield return collection.ElementAt(i);
    }
}
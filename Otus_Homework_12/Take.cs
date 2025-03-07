namespace Otus_Homework_12;

public static partial class Enumerable
{
    public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count)
    {
        ArgumentNullException.ThrowIfNull(collection);

        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Element count must be positive.");

        if (count == 0) yield break;

        var counter = 0;

        foreach (var item in collection)
            if (counter < count)
            {
                yield return item;
                counter++;
            }
            else
            {
                yield break;
            }
    }
}
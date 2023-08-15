using System.Collections;

namespace Lab8;

public static class Extensions
{
    private static bool GetTrue<T>(T obj) => true;

    public static T First<T>(this IEnumerable<T>? collection, Predicate<T>? predicate = null)
    {
        if (collection != null)
        {
            predicate ??= GetTrue;

            foreach (var elem in collection)
            {
                if (predicate(elem))
                {
                    return elem;
                }
            }
        }

        throw new InvalidOperationException("There is no element that satisfies the criteria");
    }

    public static T? FirstOrDefault<T>(this IEnumerable<T>? collection, Predicate<T>? predicate = null)
    {
        if (collection != null)
        {
            predicate ??= GetTrue;

            foreach (var elem in collection)
            {
                if (predicate(elem))
                {
                    return elem;
                }
            }
        }

        return default(T);
    }

    public static IEnumerable<T>? Where<T>(this IEnumerable<T>? collection, Predicate<T>? predicate = null)
    {
        LinkedList<T>? result = null;
        
        if (collection != null)
        { 
            result = new LinkedList<T>();
            predicate ??= GetTrue;

            foreach (var elem in collection)
            {
                if (predicate(elem))
                {
                    result.AddLast(elem);
                }
            }
        }

        return result;
    }

    public static bool Any<T>(this IEnumerable<T>? collection, Predicate<T>? predicate = null)
    {
        if (collection != null)
        {
            predicate ??= GetTrue;
            foreach (var elem in collection)
            {
                if (predicate(elem))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
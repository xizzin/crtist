using System.Collections.Generic;

internal static class ExtensionsHelpers
{
    public static T[] Append<T>(this T[] array, T item)
    {
        List<T> list = new List<T>(array);
        list.Add(item);

        return list.ToArray();
    }
}
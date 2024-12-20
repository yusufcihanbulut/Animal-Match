using System.Collections.Generic;

public static class UnityHelpers
{
    public static T GetRandom<T>(this T[] list)
    {
        if (list == null || list.Length == 0)
            throw new System.IndexOutOfRangeException("List is empty!");
        
        return list[UnityEngine.Random.Range(0, list.Length)];
    }

    public static T RemoveRandom<T>(this IList<T> list)
    {
        if (list == null || list.Count == 0)
            throw new System.IndexOutOfRangeException("List is empty!");

        var index = UnityEngine.Random.Range(0, list.Count);
        var rndItem = list[index];
        list.RemoveAt(index);

        return rndItem;
    }

    public static List<T> Shuffle<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
            throw new System.IndexOutOfRangeException("List is empty!");
        
        for (int i = 0; i < list.Count; i++)
        {
            var temp = list[i];
            var rndIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[rndIndex];
            list[rndIndex] = temp;
        }

        return list;
    }
}

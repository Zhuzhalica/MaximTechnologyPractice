namespace Practice;

public static class Sorts
{
    public static T[] QuickSort<T>(this T[] elements, int startIndex, int lastIndex) where T : IComparable
    {
        if (startIndex >= lastIndex)
        {
            return elements;
        }

        var pivotIndex = PivotSplit(elements, startIndex, lastIndex);
        QuickSort(elements, startIndex, pivotIndex - 1);
        QuickSort(elements, pivotIndex + 1, lastIndex);

        return elements;
    }

    private static int PivotSplit<T>(T[] array, int startIndex, int lastIndex) where T : IComparable
    {
        var pivot = startIndex - 1;
        for (var i = startIndex; i < lastIndex; i++)
        {
            if (array[i].CompareTo(array[lastIndex]) < 0)
            {
                pivot++;
                (array[pivot], array[i]) = (array[i], array[pivot]);
            }
        }

        pivot++;
        (array[pivot], array[lastIndex]) = (array[lastIndex], array[pivot]);
        return pivot;
    }


    public static T[] TreeSort<T>(this T[] elements) where T : IComparable
    {
        var root = new BinaryTreeNode<T>(elements[0]);
        for (var i = 1; i < elements.Length; i++)
        {
            root.Add(elements[i]);
        }

        return root.ToArray();
    }
}
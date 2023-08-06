namespace Practice;

public class BinaryTreeNode<T> where T: IComparable
{
    public BinaryTreeNode<T> LeftChild { get; set; }
    public BinaryTreeNode<T> RightChild { get; set; }
    public T Value { get; set; }
    
    public BinaryTreeNode(T value)
    {
        Value = value;
    }

    public void Add(T value)
    {
        var node = this;
        while (true)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new BinaryTreeNode<T>(value);
                    break;
                }
                node = node.LeftChild;
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new BinaryTreeNode<T>(value);
                    break;
                }
                node = node.RightChild;
            }
        }
    }


    public T[] ToArray(List<T>? result = null)
    {
        result ??= new List<T>();
        
        if (LeftChild != null)
            LeftChild.ToArray(result);

        result.Add(Value);
        
        if (RightChild != null)
           RightChild.ToArray(result);

        return result.ToArray();
    }
}
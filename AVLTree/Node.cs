public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Height { get; set; }

    public Node(int value)
    {
        Value = value;
        Height = 1;
    }

    public int GetBalanceFactor()
    {
        int leftHeight = Left?.Height ?? 0;
        int rightHeight = Right?.Height ?? 0;
        return leftHeight - rightHeight;
    }

    public void UpdateHeight()
    {
        int leftHeight = Left?.Height ?? 0;
        int rightHeight = Right?.Height ?? 0;
        Height = Math.Max(leftHeight, rightHeight) + 1;
    }
}
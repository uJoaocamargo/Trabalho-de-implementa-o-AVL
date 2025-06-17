public class AVLTree
{
    public Node Root { get; private set; }

    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }

    private Node Insert(Node node, int value)
    {
        if (node == null)
            return new Node(value);

        if (value < node.Value)
            node.Left = Insert(node.Left, value);
        else if (value > node.Value)
            node.Right = Insert(node.Right, value);
        else
            return node; // Valor já existe

        node.UpdateHeight();
        return Balance(node);
    }

    public void Remove(int value)
    {
        Root = Remove(Root, value);
    }

    private Node Remove(Node node, int value)
    {
        if (node == null)
            return null;

        if (value < node.Value)
            node.Left = Remove(node.Left, value);
        else if (value > node.Value)
            node.Right = Remove(node.Right, value);
        else
        {
            if (node.Left == null || node.Right == null)
            {
                Node temp = node.Left ?? node.Right;
                if (temp == null)
                {
                    temp = node;
                    node = null;
                }
                else
                {
                    node = temp;
                }
            }
            else
            {
                Node temp = MinValueNode(node.Right);
                node.Value = temp.Value;
                node.Right = Remove(node.Right, temp.Value);
            }
        }

        if (node == null)
            return null;

        node.UpdateHeight();
        return Balance(node);
    }

    private Node MinValueNode(Node node)
    {
        Node current = node;
        while (current.Left != null)
            current = current.Left;
        return current;
    }

    public bool Search(int value)
    {
        return Search(Root, value);
    }

    private bool Search(Node node, int value)
    {
        if (node == null)
            return false;

        if (value < node.Value)
            return Search(node.Left, value);
        if (value > node.Value)
            return Search(node.Right, value);
        
        return true;
    }

    public string PreOrder()
    {
        List<int> values = new List<int>();
        PreOrder(Root, values);
        return string.Join(" ", values);
    }

    private void PreOrder(Node node, List<int> values)
    {
        if (node != null)
        {
            values.Add(node.Value);
            PreOrder(node.Left, values);
            PreOrder(node.Right, values);
        }
    }

    public string BalanceFactors()
    {
        List<string> factors = new List<string>();
        BalanceFactors(Root, factors);
        return string.Join("\n", factors);
    }

    private void BalanceFactors(Node node, List<string> factors)
    {
        if (node != null)
        {
            factors.Add($"Nó {node.Value}: Fator de balanceamento {node.GetBalanceFactor()}");
            BalanceFactors(node.Left, factors);
            BalanceFactors(node.Right, factors);
        }
    }

    public int GetHeight()
    {
        return Root?.Height ?? 0;
    }

    private Node Balance(Node node)
    {
        int balanceFactor = node.GetBalanceFactor();

        // Rotação à direita (RR)
        if (balanceFactor > 1 && node.Left.GetBalanceFactor() >= 0)
            return RotateRight(node);

        // Rotação à esquerda (LL)
        if (balanceFactor < -1 && node.Right.GetBalanceFactor() <= 0)
            return RotateLeft(node);

        // Rotação dupla à direita (LR)
        if (balanceFactor > 1 && node.Left.GetBalanceFactor() < 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        // Rotação dupla à esquerda (RL)
        if (balanceFactor < -1 && node.Right.GetBalanceFactor() > 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private Node RotateRight(Node y)
    {
        Node x = y.Left;
        Node T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.UpdateHeight();
        x.UpdateHeight();

        return x;
    }

    private Node RotateLeft(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.UpdateHeight();
        y.UpdateHeight();

        return y;
    }
}
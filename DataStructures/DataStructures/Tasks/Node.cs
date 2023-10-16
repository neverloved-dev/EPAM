namespace Tasks;
public class Node<Y>
{
    public Y Value { get; }
    public Node<Y> Next { get; set; }
    public Node<Y> Previous { get; set; }

    public Node(Y value)
    {
        Value = value;
    }
}
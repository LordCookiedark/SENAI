class Node
{
    public int X, Y;
    public int G, H, F;
    public Node Pai;

    public Node(int x, int y, int g, int h, Node pai)
    {
        X = x;
        Y = y;
        G = g;
        H = h;
        F = g + h;
        Pai = pai;
    }
}

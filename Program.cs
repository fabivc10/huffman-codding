namespace huffman_coding;

class Node
{
    public string Letter { get; }
    public int Appearances { get; }
    public Node Left { get; }
    public Node Right { get; }
    
    public Node(string letter, int appearances = 0)
    {
        Letter = letter;
        Appearances = appearances;
        Left = null;
        Right = null;
    }

    public Node(string letter, int appearances, Node left, Node right)
    {
        Letter = letter;
        Appearances = appearances;
        Left = left;
        Right = right;
    }
}

class HuffmanCoding
{
    private List<Node> GetAppeacesList(string inputText)
    {
        var appearancesList = inputText
            .GroupBy(item => item)
            .Select(item => new Node(item.Key.ToString(), item.Count()))
            .ToList();

        return appearancesList;
    }

    private List<Node> GenerateTree(List<Node> list)
    {
        if (list.Count <= 1) { return list; }

        Node minor, secondMinor;
            
        minor = secondMinor = list[0];

        foreach (var node in list)
        {
            if (minor.Appearances <= node.Appearances)
            {
                if (node.Appearances < secondMinor.Appearances)
                {
                    secondMinor = node;
                }
            }
            minor = node;
        }
        
        list.RemoveAll(item => item.Letter == minor.Letter || item.Letter == secondMinor.Letter);
        
        list.Add(new Node(
            minor.Letter + secondMinor.Letter,
            minor.Appearances + secondMinor.Appearances,
            minor, 
            secondMinor
        ));
        
        return GenerateTree(list);
    }

    public void Run(String inputText)
    {
        List<Node> appeacesList = GetAppeacesList(inputText);
        
        Node solution = GenerateTree(appeacesList).First();
        
        GetSolution(solution);
    }

    private void GetSolution(Node root, string nodeType = "")
    {
        if (root == null) { return; }

        if (root.Letter.Length == 1)
        {
            Console.WriteLine($"({root.Letter}, {root.Appearances}): {nodeType}");
        }

        GetSolution(root.Left,  nodeType + "0");
        GetSolution(root.Right, nodeType + "1");
    }

    public static void Main(string[] args)
    {
        HuffmanCoding huffmanCoding = new HuffmanCoding();

        huffmanCoding.Run("mississippi");
    }
}
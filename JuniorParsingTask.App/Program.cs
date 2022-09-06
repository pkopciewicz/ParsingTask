using JuniorParsingTask;


//tree for searching
var tree = TreeService.Create();

bool TryGetNode(string value, out Node node) 
{
    if (tree != null)
    {
        Stack<Node> stack = new();
        node = tree.Root;
        foreach(Node n in node.Children)
        {
            stack.Push(n);
        }
        while (stack.Count != 0) 
        {
            Node parent = stack.Pop();
            if(parent.Value == value)
            {
                node = parent;
                Console.WriteLine("value found, success");
                return true;
            }
            else
            {
                foreach(Node n in parent.Children)
                {
                    if (n.Value == value)
                    {
                        node = n;
                        Console.WriteLine("value found, success");
                        return true;
                    }
                    else
                    {
                        stack.Push((Node)n);
                    }
                }
            }
        }
        node = null!;
        Console.WriteLine("value NOT found :(");
        return false;
    }
    else
    {
        node = null!;
        Console.WriteLine("tree = null");
        return false;
    }
}

Console.WriteLine("Type searched string: ");
string? str = Console.ReadLine();

if (str != null)
{
    Node nod;
    TryGetNode(str, out nod);
}
else

Console.ReadKey();

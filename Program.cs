internal static class Program
{
    private static void Print(object msg) => Console.WriteLine(msg);

    private static void Main(string[] args)
    {
        Print("Binary Tree (Get Left and Right Values!)");

        // creating nodes
        var a = new Node() { Value = "A" };
        var b = new Node() { Value = "B" };
        var c = new Node() { Value = "C" };
        var d = new Node() { Value = "D" };
        var e = new Node() { Value = "E" };
        var f = new Node() { Value = "F" };

        // connecting nodes
        a.Left = b;
        a.Right = c;
        b.Left = d;
        b.Right = e;
        c.Right = f;
        // visual representation
        /*
                     a
                    /  \
                   b    c
                  / \    \
                 d   e    f
        */

        // using depth first algorithm
        // get values: [a,b,d,e,c,f]
        // we use a stack to filter the values by depth:
        /*
            use push(child) and pop(child) to array[]
                b
                c
                _____
                stack
                _____
        */
        // then we store the filtered values to array or some variable
        // the complexity of depth first is n = # of nodes time: 0(n)
        var leftValues = GetLeftAndRightValues(a.Left);
        Print("Node left values:");
        for (int i = 0; i < leftValues.Count; i++)
        {
            Print(leftValues[i]);
        }
        Print("Node right values:");
        var rightValues = GetLeftAndRightValues(a.Right);
        for (int i = 0; i < rightValues.Count; i++)
        {
            Print(rightValues[i]);
        }
    }

    private static List<string> GetLeftAndRightValues(Node node)
    {
        var results = new List<string>();
        var stack = new Stack<Node>();
        stack.Push(node); // initializing or starting with root value
        while (stack.Count() > 0)
        {
            var current = stack.Pop();
            results.Add(current.Value);
            if (current != null)
            {
                if (current.Right != null)
                {
                    stack.Push(current.Right);
                    var r = stack.Pop();
                    results.Add(r.Value);
                }

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                    var l = stack.Pop();
                    results.Add(l.Value);
                }
            }
            break;
        }
        return results;
    }
}

internal class Node
{
    public string Value { get; set; } = string.Empty;
    public Node? Left { get; set; } = null;
    public Node? Right { get; set; } = null;
}

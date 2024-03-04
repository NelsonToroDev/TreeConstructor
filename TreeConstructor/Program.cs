using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TreeConstructor;

public class ProgramTreeConstructor
{
    public static bool TreeConstructor(string[] strArr)
    {
        Node root = null;
        int[] values;
        List<Node> orphans = new List<Node>();
        /// 
        /// 4
        /// 2
        /// 1   7
        ///     5
        ///     9
        /// 
        ///
        foreach (string str in strArr)
        {
            values = Regex.Replace(str, "[()]", string.Empty).Split(',').Select(c =>
            {
                return int.Parse(c);
            }).ToArray();

            int parent = values[1];
            int child = values[0];
            if (root == null)
            {
                root = new Node(parent, child);
            }
            else
            {
                bool res = root.Insert(parent, child, ref root);
                if(res == false)
                {
                    // Add to orphanList
                    orphans.Add(new Node(parent, child));
                    return res;
                }
            }
            
        }

        return true;

    }

    

    class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public Node(int value, int childValue)
        {
            this.Value = value;
            this.Left = new Node(childValue);
            this.Right = null;
        }

        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public bool Insert(int parent, int childValue, ref Node root)
        {
            Node parentNode = DeepSearch(parent);
            if(parentNode == null)
            {
                Node childNode = DeepSearch(childValue);
                if(childNode == null)
                {
                    return false;
                }

                Node newRoot = new Node(parent);
                newRoot.Left = childNode;
                root = newRoot;
                return true;
            }

            if(parentNode.Left == null)
            {
                parentNode.Left = new Node(childValue);
                return true;
            }

            if(parentNode.Right == null)
            {
                parentNode.Right = new Node(childValue);
                return true;
            }

            return false;
        }

        public Node DeepSearch(int searchingValue)
        {
            if(searchingValue == Value)
            {
                return this;
            }

            Node leftNode = null;
            Node rightNode = null;

            if (Left != null)
            {
                leftNode = Left.DeepSearch(searchingValue);
            }

            if (Right != null)
            {
                rightNode = Right.DeepSearch(searchingValue);
            }

            return leftNode ?? rightNode;
        }
    }

    static void Main()
    {

        // keep this function call here
        Console.WriteLine(TreeConstructor(Console.ReadLine().Split(' ')));

    }
}
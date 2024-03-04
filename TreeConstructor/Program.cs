using System.ComponentModel;
using System.Text.RegularExpressions;

namespace TreeConstructor;

public class ProgramTreeConstructor
{
    ///* <summary>
    /// * Binary Tree constructor
    /// constraints
    /// -------------------
    /// 1. Parents have at most 2 children
    /// 2. Each child has at most one parent
    /// 3. Iterate across strArr and check all conditions remain true
    /// </summary>
    /// <param name="strArr"></param>
    /// <returns></returns>
    public static bool TreeConstructor(string[] strArr)
    {
        SortedList<int, List<int>> parents = new SortedList<int, List<int>>();
        SortedList<int, int> children = new SortedList<int, int>();

        foreach (string str in strArr)
        {
            var values = Regex.Replace(str, "[()]", string.Empty).Split(',').Select(c =>
            {
                return int.Parse(c);
            }).ToArray();

            int child = values[0];
            int parent = values[1];

            if (!parents.ContainsKey(parent))
            {
                parents[parent] = new List<int>() { child };
            }
            else
            {
                parents[parent].Add(child);
            }

            if (parents[parent].Count > 2)
            {
                // The parent contains more than two children
                return false;
            }

            // Check if the child only has one parent
            if (children.ContainsKey(child))
            {
                // A previous child was already processed and it breaks the rule that a child only should have one parent
                return false;
            }
            else
            {
                children.Add(child, parent);
            }
        }

        // everything was proccessed and passes the constraints for a binary tree
         return true;
    }

    static void Main()
    {

        // keep this function call here
        Console.WriteLine(TreeConstructor(Console.ReadLine().Split(' ')));

    }
}
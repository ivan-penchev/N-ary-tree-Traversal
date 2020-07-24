using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Playground
{

    public static class NodeExtensions
    {
        private static List<Node> CalculateAllPossiblePaths(this Node node)
        {
            List<Node> list = new List<Node>();
            list.Add(node);
            foreach (var child in node.Children)
                list.AddRange(child.CalculateAllPossiblePaths());
            return list;
        }

        private static Node FindRoot(Node node)
        {
            if (node.Parent == null)
                return node;
            return FindRoot(node.Parent);
        }

        public static Node Next(this Node node)
        {
            var root = FindRoot(node);
            var allPaths = CalculateAllPossiblePaths(root);

            try
            {
                var nextNode = allPaths[allPaths.IndexOf(node) + 1];
                return nextNode;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
    }
}

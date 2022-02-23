using System;
using System.Collections.Generic;

namespace LeetCode133
{
    class Program
    {
        static Dictionary<int, Node> createdNodes = new Dictionary<int, Node>();
        static void Main(string[] args)
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);

            node1.neighbors.Add(node2);
            node1.neighbors.Add(node4);
            node2.neighbors.Add(node1);
            node2.neighbors.Add(node3);
            node3.neighbors.Add(node2);
            node3.neighbors.Add(node4);
            node4.neighbors.Add(node1);
            node4.neighbors.Add(node3);

            var returnNode = CloneGraph(node1);
        }

        static Node CloneGraph(Node node)
        {
            if (node == null) return null;
            Node result = new Node();
            result.val = node.val;

            createdNodes.Add(node.val, result);

            foreach(var item in node.neighbors)
            {
                if(!createdNodes.ContainsKey(item.val))
                {
                    result.neighbors.Add(CloneGraph(item));
                }
                else
                {
                    result.neighbors.Add(createdNodes[item.val]);
                }
            }
            return result;
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}

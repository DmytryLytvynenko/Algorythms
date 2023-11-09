using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(2);
            binaryTree.Add(5);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(14);
            binaryTree.Add(16);

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(3);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(8);
            binaryTree.PrintTree();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(binaryTree.FindNode(10).ParentNode == null);
            Console.WriteLine($"FindNode(16): {binaryTree.ReverseFindNode(10)}" );

            Console.ReadLine();
        }
    }
}

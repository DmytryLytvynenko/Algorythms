using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class BinaryTree<T> where T : IComparable
    {
        /// Корень бинарного дерева
        public BinaryTreeNode<T> RootNode { get; set; }

        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }

        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }

        ///Прямой поиск
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = data.CompareTo(startWithNode.Data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }
        public BinaryTreeNode<T> ReverseFindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            if (startWithNode == null)
            {
                startWithNode = FindLastLeft(startWithNode);
            }
            if (startWithNode.ParentNode.RightNode == startWithNode)
            {
                startWithNode = FindLastLeft(startWithNode);
            }
            if (Convert.ToInt32(startWithNode.Data) == 10)
            {
                Console.WriteLine(startWithNode.ParentNode = null);
            }
            startWithNode.Marked = true;
            BinaryTreeNode<T> result = null;
            switch (data.CompareTo(startWithNode.Data))
            {
                case 0:
                    result = startWithNode;
                    return result;

                default:
                    if (startWithNode.RightNode != null && !startWithNode.RightNode.Marked)
                    {
                        result = ReverseFindNode(data, startWithNode.RightNode);
                    }
                    else if (startWithNode.ParentNode != null && startWithNode.ParentNode.RightNode != null && startWithNode.ParentNode.RightNode != startWithNode )
                    {

                        result = ReverseFindNode(data, startWithNode.ParentNode.RightNode);
                    }
                    else
                    {
                        if (startWithNode.ParentNode == null)
                        {
                            result = null;
                            return result;
                        }
                        else
                        {
                            result = ReverseFindNode(data, startWithNode.ParentNode);
                        }
                    }
                    return result;
            } 
        }
        private BinaryTreeNode<T> FindLastLeft(BinaryTreeNode<T> startNode)
        {
            startNode = startNode ?? RootNode;
            return startNode.LeftNode == null ? startNode : FindLastLeft(startNode.LeftNode);
        }

        /// Удаление узла бинарного дерева
        public void Remove(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            //если у узла нет подузлов, можно его удалить
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            //если нет левого, то правый ставим на место удаляемого 
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            //если нет правого, то левый ставим на место удаляемого 
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            //если оба дочерних присутствуют, 
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }
        public void Remove(T data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }
        public void PrintTree()
        {
            PrintTree(RootNode);
        }
        /// Вывод бинарного дерева начиная с указанного узла
        private void PrintTree(BinaryTreeNode<T> startNode, string indent = " ", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);
                //рекурсивный вызов для левой и правой веток
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }
    }
}

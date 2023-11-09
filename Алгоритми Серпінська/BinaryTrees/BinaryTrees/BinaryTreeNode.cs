using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    /// Расположения узла относительно родителя
    public enum Side
    {
        Left,
        Right
    }

    public class BinaryTreeNode<T> where T : IComparable
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        /// Данные которые хранятся в узле
        public T Data { get; set; }
        public bool Marked { get; set; } = false;

        /// Левая ветка
        public BinaryTreeNode<T> LeftNode { get; set; }

        /// Правая ветка
        public BinaryTreeNode<T> RightNode { get; set; }

        /// Родитель
        public BinaryTreeNode<T> ParentNode { get; set; }

        /// Расположение узла относительно его родителя
        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;

        public override string ToString() => Data.ToString();
    }
}

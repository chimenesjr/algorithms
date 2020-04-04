using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithms.Tree
{
    class BinarySearchTree
    {
        public BinarySearchTree()
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(37);
            bst.Insert(24);
            bst.Insert(17);
            bst.Insert(28);
            bst.Insert(31);
            bst.Insert(29);
            bst.Insert(15);
            bst.Insert(12);
            bst.Insert(20);

            foreach (var item in bst.TraverseInOrder())
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine($"Min: {bst.Min()}");
            System.Console.WriteLine($"Max: {bst.Max()}");

            System.Console.WriteLine($"Get 20: {bst.GetNode(20).Value}");
        }
    }
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

        public TreeNode<T> GetNode(T value)
        {
            return _root?.Get(value);
        }

        public T Min()
        {
            if (_root == null)
                throw new InvalidOperationException();
            
            return _root.Min();
        }

        public T Max()
        {
            if (_root == null)
                throw new InvalidOperationException();
            
            return _root.Max();
        }

        public void Insert(T value)
        {
            if (_root == null)
                _root = new TreeNode<T>(value);
            else
                _root.Insert(value);
        }

        public IEnumerable<T> TraverseInOrder()
        {
            if (_root != null)
                return _root.TraverseInOrder();
            
            return Enumerable.Empty<T>();
        }

        public void Remove(T value)
        {
            _root = Remove(_root, value);
        }

        public TreeNode<T> Remove(TreeNode<T> subTree, T value)
        {
            if (subTree == null)
                return null;

            int compare = value.CompareTo(subTree.Value);

            if(compare < 0) // procurando
            {
                subTree.Left = Remove(subTree.Left, value);
            }
            else if (compare > 0) // procurando
            {
                subTree.Right = Remove(subTree.Right, value);
            }
            else
            {
                // subTree deve ser excluido
                if (subTree.Left == null)
                    return subTree.Right;
                if (subTree.Right == null)
                    return subTree.Left;

                // subTree tem 2 nodes abaixo

                subTree.Value = subTree.Right.Min();
                subTree.Right = Remove(subTree.Right, subTree.Value);
            }
            
            return subTree;
        }

    }
}
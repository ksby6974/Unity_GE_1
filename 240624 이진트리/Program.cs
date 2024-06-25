using System;

namespace GE_240624
{
    // 트리는 자식이 부모보다 값이 작아야 한다
    internal class Program
    {
        public class Node
        {
            public Node? right;
            public Node? left;
            public int? data;
        }

        static public Node CreateNode(int data, Node left, Node right)
        {
            Node? node = new Node();
            node.data = data;
            node.left = left;
            node.right = right;
            return node;
        }

        // 전위 순회
        static void Preorder(Node root)
        {
            if (root != null)
            {
                Console.WriteLine($"{root.data}");
                Preorder(root.left);
                Preorder(root.right);
            }
        }

        // 중위 순회
        static void Inorder(Node root)
        {
            if (root != null)
            {
                Inorder(root.left);
                Console.WriteLine($"{root.data}");
                Inorder(root.right);
            }
        }

        // 후위 순회
        static void Postorder(Node root)
        {
            if (root != null)
            {
                Postorder(root.left);
                Postorder(root.right);
                Console.WriteLine($"{root.data}");
            }
        }

        public class BinaryTree<T>
        {
            public class Node
            {
                public Node? right;
                public Node? left;
                public T? data;
            }

            Node? nRoot;
            int iHeight;

            public BinaryTree()
            {
                nRoot = null;
                iHeight = 0;
            }

            public Node CreateNode(T data, Node left, Node right)
            {
                Node? node = new Node();
                node.data = data;
                node.left = left;
                node.right = right;
                return node;
            }

            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.Write($"BinaryTree");
                Console.WriteLine($"");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"─────────────────────────────────");
                Console.ResetColor();

                Node? node = nRoot;
                int iCount = 0;

                while (node != null)
                {
                    iCount++;
                    Console.WriteLine($"【{iCount}】:{node.data}");

                    node = node.left;
                }
            }
        }


        static void Main(string[] args)
        {
            //BinaryTree<int> tree = new BinaryTree<int>();

            Node node7 = CreateNode(7, null, null);
            Node node6 = CreateNode(6, null, null);
            Node node5 = CreateNode(5, null, null);
            Node node4 = CreateNode(4, null, null);
            Node node3 = CreateNode(3, node6, node7);
            Node node2 = CreateNode(2, node4, node5);
            Node node1 = CreateNode(1, node2, node3);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ResetColor();
            Console.Write($"Preorder");
            Console.WriteLine($"");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"─────────────────────────────────");
            Console.ResetColor();
            Preorder(node1);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ResetColor();
            Console.Write($"Inorder");
            Console.WriteLine($"");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"─────────────────────────────────");
            Console.ResetColor();
            Inorder(node1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ResetColor();
            Console.Write($"Postorder");
            Console.WriteLine($"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"─────────────────────────────────");
            Console.ResetColor();
            Postorder(node1);
        }
    }
}

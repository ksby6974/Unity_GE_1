using System.Xml;
using static GE_240627.Program;

namespace GE_240627
{
    internal class Program
    {
        public class BinarySearchTree<T>
        {
            public class Node
            {
                public T? data;
                public Node? left;
                public Node? right;
            }

            public Node? nRoot;
            public int iError = -9999;

            public BinarySearchTree()
            {
                nRoot = null;
            }

            public void Insert(T data)
            {
                if (nRoot == null)
                {
                    nRoot = CreateNode(data);
                }
                else
                {
                    Node node = nRoot;
                    bool bLoop = true;
                    while (bLoop)
                    {
                        int iResult = GetCs(node.data!, data);

                        switch (iResult)
                        {
                            // 부모의 값이 큼
                            case 1:
                                if (node.left == null)
                                {
                                    node.left = CreateNode(data);
                                    bLoop = false;
                                }
                                else
                                {
                                    node = node.left;
                                }
                                break;

                            // 자식의 값이 큼
                            case -1:
                                if (node.right == null)
                                {
                                    node.right = CreateNode(data);
                                    bLoop = false;
                                }
                                else
                                {
                                    node = node.right;
                                }
                                break;

                            // 값 동일
                            default:
                                break;
                        }
                    }
                }
            }

            public Node CreateNode(T data)
            {
                Node node = new Node();
                node.data = data;
                node.left = null;
                node.right = null;

               // Console.WriteLine($"{data} 값의 노드 생성");

                return node;
            }

            public bool Find(T data)
            {
                Node node = nRoot!;

                while (node != null)
                {
                    if (GetCs(node.data!,data) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        if (GetCs(node.data!, data) == 1)
                        {
                            node = node.left!;
                        }
                        else if (GetCs(node.data!, data) == -1)
                        {
                            node = node.right!;
                        }
                    }
                }

                return false;
            }

            public int GetCs(T x, T y)
            {
                if ((x == null) || (y == null))
                {
                    return iError;
                }

                int iResult = 0;
                int iX = int.Parse(x!.ToString()!);
                int iY = int.Parse(y!.ToString()!);

                if (iX == iY)
                {
                    iResult = 0;
                }
                else if(iX > iY)
                {
                    iResult = 1;
                }
                else if(iX < iY)
                {
                    iResult = -1;
                }

                //Console.WriteLine($"{iX}와 {iY} 비교결과 = {iResult}");

                return iResult;
            }

            public void Inorder(Node root)
            {
                if (root != null)
                {
                    Inorder(root.left!);
                    Console.WriteLine($"{root.data}");
                    Inorder(root.right!);
                }
            }

            public void Remove(T data)
            {
                Node? node = nRoot!;
                Node? parent = node;

                if (node == null)
                {
                    Console.WriteLine($"Tree is Empty.");
                    return;
                }
                else
                {
                    // 값을 보유한 노드 찾기
                    while (GetCs(node!.data!, data) != 0)
                    {
                        parent = node;

                        // 왼쪽이 큼
                        if (GetCs(node.data!, data) == 1)
                        {
                            node = node.left;
                        }
                        // 오른쪽이 큼
                        else if (GetCs(node.data!, data) == -1)
                        {
                            node = node.right;
                        }
                    }

                    if (node == null)
                    {
                        Console.WriteLine($"Data is not found.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Remove {data} : 부모{parent.data}");

                        // 자식 노드가 없을 때
                        if (node!.left == null && node.right == null)
                        {
                            if (parent != null)
                            {
                                if (parent.left == node)
                                {
                                    parent.left = null;
                                }
                                else
                                {
                                    parent.right = null;
                                }
                            }
                            else
                            {
                                nRoot = null;
                            }
                        }
                        // 자식 노드가 하나 있을 때 (미완)
                        else if (node!.left == null || node.right == null)
                        {
                            if (parent != null)
                            {
                                if (parent.left == node)
                                {
                                    parent.left = node.right;
                                }
                                else
                                {
                                    parent.right = node.left;
                                }
                            }
                            else
                            {
                                if (nRoot!.left == node)
                                {
                                    nRoot = nRoot!.left;
                                }
                                else
                                {
                                    nRoot = nRoot!.right;
                                }
                            }
                        }
                        // 자식 노드가 둘 다 있을 때
                        else if (node!.left != null && node.right != null)
                        {
                            Node? find = node.right;
                            Node? trace = find;
                            
                            while(find.left != null)
                            {
                                trace = find;
                                find = find.left;
                            }

                            node.data = find.data;
                            trace.left = find.right;
                        }

                    }
                }
            }

            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.Write($"BinarySearchTree");

                if (nRoot != null)
                {
                    Console.Write($"（nRoot:{nRoot.data}）");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"─────────────────────────────────");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(19);
            tree.Insert(14);
            tree.Insert(23);
            tree.Insert(21);


            tree.Show();
            tree.Inorder(tree.nRoot!);

            //Console.WriteLine($"{tree.Find(10)}, {tree.Find(20)}");

            tree.Remove(19);
            tree.Show();
            tree.Inorder(tree.nRoot!);
        }
    }
}

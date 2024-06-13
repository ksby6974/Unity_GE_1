using System.Diagnostics.Tracing;

namespace GE_240613
{
    internal class Program
    {
        public class CircleLinkedList<T>
        {
            private class Node
            {
                public T? data;
                public Node? next;
            }

            private Node? head;

            public CircleLinkedList()
            {
                head = null;
                Console.WriteLine($"CircleLinkedList 생성");
            }

            public int GetSize()
            {
                int iCount = 0;

                Node? current = head;
                Node? end = head;

                while (current != null)
                {
                    iCount += 1;
                    if (current.next == end)
                    {
                        break;
                    }
                    else
                    {
                        current = current.next;
                    }
                }

                return iCount;
            }

            public void PushBack(T data)
            {
                Node? node = new Node();

                if (head == null)
                {
                    head = node;
                    node.data = data;
                    node.next = head;
                }
                else
                {
                    node.data = data;
                    node.next = head.next;
                    head.next = node;
                    head = node;
                }
            }

            public void Show()
            {
                if (head == null)
                {
                    Console.WriteLine($"Show : CircleLinkedList 비었음");
                }
                else
                {
                    // View
                    Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    Console.WriteLine($"원형 연결 리스트 크기 : {GetSize()}");
                    ShowDetail();
                    Console.WriteLine($"─────────────────────────────────");

                    //
                    int iCount = 0;
                    Node? currentNode = head;

                    while (currentNode != null)
                    {
                        iCount += 1;
                        Console.Write($"【{iCount}】:［");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{currentNode.data}");
                        Console.ResetColor();

                        if (currentNode.next != null)
                        {
                            Console.Write($"/{currentNode.next.data}］");
                        }
                        else
                        {
                            Console.Write($"/null］");
                        }

                        currentNode = currentNode.next;

                        Console.WriteLine();
                    }
                }
            }

            public void ShowDetail()
            {
                Node? current = head;

                Console.Write($"Current Head = ");

                if (current != null)
                {
                    Console.Write($"［");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{current.data}");
                    Console.ResetColor();
                    Console.Write($"/");

                    if (current.next != null)
                    {
                        Console.Write($"{current.next.data}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"null");
                        Console.ResetColor();
                    }
                    Console.Write($"］");
                    Console.WriteLine();
                }
            }
        }


        static void Main(string[] args)
        {
            CircleLinkedList<int> circleLinkedList = new CircleLinkedList<int>();

            //circleLinkedList.PushBack(30);
            //circleLinkedList.PushBack(20);
            circleLinkedList.PushBack(10);

            circleLinkedList.Show();
        }
    }
}

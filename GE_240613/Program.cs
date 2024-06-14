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

                while (current != null)
                {
                    iCount += 1;
                    current = current.next;

                    if (current == head)
                    {
                        break;
                    }
                }

                return iCount;
            }

            public void PushBack(T data)
            {
                Node? newnode = new Node();

                if (head == null)
                {
                    head = newnode;
                    newnode.data = data;
                    newnode.next = head;
                }
                else
                {
                    Node? node = head;

                    while (node != null)
                    {
                        if (node.next == head)
                        {
                            node.next = newnode;
                            break;
                        }
                        else
                        {
                            node = node.next;
                        }
                    }

                    newnode.data = data;
                    newnode.next = head;
                }
            }

            public void PushFront(T data)
            {
                Node? newnode = new Node();

                if (head == null)
                {
                    head = newnode;
                    newnode.data = data;
                    newnode.next = head;
                }
                else
                {
                    Node? node = head;

                    while (node != null)
                    {
                        if (node.next == head)
                        {
                            node.next = newnode;
                            break;
                        }
                        else
                        {
                            node = node.next;
                        }
                    }

                    newnode.data = data;
                    newnode.next = head;
                    head = newnode;
                }
            }

            public void RemoveFront()
            {
                if (head == null)
                {
                    Console.WriteLine($"RemoveFront : CircleLinkedList 비었음");
                }
                else
                {
                    if (head == head.next)
                    {
                        head = null;
                    }
                    else
                    {
                        //head = head.next.next;

                        head = head.next;
                    }
                }
            }

            public void RemoveBack()
            {
                if (head == null)
                {
                    Console.WriteLine($"RemoveFront : CircleLinkedList 비었음");
                }
                else
                {
                    if (head == head.next)
                    {
                        head = null;
                    }
                    else
                    {
                        Node? current = head;

                        for (int i = 0; i < GetSize() - 1; i++)
                        {
                            current = current!.next;
                        }
                    }
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
                    Node? current = head;

                    while (current != null)
                    {
                        iCount += 1;
                        Console.Write($"【{iCount}】:［");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{current.data}");
                        Console.ResetColor();
                        Console.Write($"/{current.next.data}］");
                        Console.WriteLine();
                        current = current.next;

                        if (current == head)
                        {
                            break;
                        }
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

            circleLinkedList.PushFront(50);
            circleLinkedList.PushFront(40);
            circleLinkedList.PushFront(30);
            circleLinkedList.PushFront(20);
            circleLinkedList.PushFront(10);


            circleLinkedList.PushBack(60);
            circleLinkedList.PushBack(70);
            circleLinkedList.PushBack(80);
            circleLinkedList.PushBack(90);
            circleLinkedList.PushBack(100);

            circleLinkedList.RemoveFront();

            circleLinkedList.Show();
        }
    }
}

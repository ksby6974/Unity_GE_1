using System.ComponentModel;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace GE_240611
{
    public class DoubleLinkedList<T>
    {
        public class Node
        {
            public T? data;
            public Node? pre;
            public Node? next;
        }

        private Node? head;
        private Node? tail;

        public DoubleLinkedList()
        {
            head = null;
            tail = null;
            Console.WriteLine($"DoubleLinkedList 생성");
        }

        // 노드 뒤 값 삽입
        public void AddAfter(Node position, T data)
        {
            if (position == tail)
            {
                //Console.WriteLine($"Tail 뒤에는 값을 삽입할 수 없습니다.");
                PushBack(data);
            }
            else
            {
                Node? node = new Node();
                node.data = data;
                node.pre = position;
                node.next = position.next;

                position.next!.pre = node;
                position.next = node;
            }
        }

        public int GetSize()
        {
            int iCount = 0;
            Node? currentNode = head;

            while (currentNode != null)
            {
                currentNode = currentNode.next;
                iCount += 1;
            }

            return iCount;
        }

        public void PushBack(T data)
        {
            Node? node = new Node();

            if (tail == null)
            {
                head = node;
                tail = head;

                node.data = data;
                node.pre = null;
                node.next = null;
            }
            else
            {
                // 테일 앞에 새로운 노드를 생성해서 이어붙임
                tail.next = node;
                node.pre = tail;
                tail = node;

                node.data = data;
                node.next = null;
            }
        }

        public void PushFront(T data)
        {
            Node? node = new Node();

            if (head == null)
            {
                head = node;
                tail = head;

                node.data = data;
                node.pre = null;
                node.next = null;
            }
            else
            {
                // 헤드 앞에 새로운 노드를 생성해서 이어붙임
                node.next = head;
                head.pre = node;
                head = node;

                node.data = data;
                node.pre = null;
            }
        }

        public void RemoveBack()
        {
            if (tail == null)
            {
                Console.WriteLine($"RemoveBack : DoubleLinkedList 비었음");
            }
            else
            {
                tail.pre!.next = null;
                tail = tail.pre;
            }
        }

        public void RemoveFront()
        {
            if (head == null)
            {
                Console.WriteLine($"RemoveBack : DoubleLinkedList 비었음");
            }
            else
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head.next!.pre = null;
                    head = head.next;
                }
            }

        }

        public Node SearchFirst()
        {
            return head!;
        }

        public Node SearchLast()
        {
            return tail!;
        }

        public void Show()
        {
            if (tail == null)
            {
                Console.WriteLine($"Show : DoubleLinkedList 비었음");
            }
            else
            {
                // View
                Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine($"양방향 연결 리스트 크기 : {GetSize()}");
                ShowDetail(0);
                ShowDetail(1);
                Console.WriteLine($"─────────────────────────────────");

                //
                int iCount = 0;
                Node? currentNode = head;

                while (currentNode != null)
                {
                    iCount += 1;
                    Console.Write($"【{iCount}】");

                    if (currentNode.pre != null)
                    {
                        Console.Write($"［{currentNode.pre.data}/");
                    }
                    else
                    {
                        Console.Write($"［null/");
                    }

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

        public void ShowDetail(int iSet = 0)
        {
            Node? current = null;
            string s = "null";

            if (iSet == 0)
            {
                current = head;
                s = "Head";
            }
            else
            {
                current = tail;
                s = "Tail";
            }


            Console.Write($"Current {s} = ");

            if (current != null)
            {
                Console.Write($"［");
                if (current.pre != null)
                {
                    Console.Write($"{current.pre.data}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"null");
                    Console.ResetColor();
                }

                Console.Write($"/");
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


    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> doubleLinkedList = new DoubleLinkedList<int>();
            doubleLinkedList.PushFront(50);
            doubleLinkedList.PushFront(40);
            doubleLinkedList.PushFront(30);
            doubleLinkedList.PushFront(10);

            doubleLinkedList.Show();
            Console.WriteLine($"＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝");

            doubleLinkedList.AddAfter(doubleLinkedList.SearchFirst(), 20);
            doubleLinkedList.AddAfter(doubleLinkedList.SearchLast(), 60);
            doubleLinkedList.Show();

            //Console.WriteLine($"{doubleLinkedList.SearchFirst().data}, {doubleLinkedList.SearchLast().data}");
        }
    }
}

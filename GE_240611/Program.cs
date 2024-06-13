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
                PushBack(data);
            }
            else
            {
                if (position == null)
                {
                    Console.WriteLine($"AddAfter : Node에 값을 삽입할 수 없습니다.");
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
        }

        public bool Find(T data)
        {
            bool bResult = false;
            Node? node = head;

            while (node != null)
            {
                if (node.data != null && data!.ToString() == node.data.ToString())
                {
                    bResult = true;
                    //Console.WriteLine($"Find : 값 {data}은 리스트에 존재합니다.");
                    break;
                }
         
                node = node.next;
            }

            return bResult;
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

        public void Remove(T data)
        {
            bool bTemp = false;
            Node? node = head;

            if (node == null)
            {
                Console.WriteLine($"Remove : DoubleLinkedList 비었음");
            }
            else
            {
                if (Find(data) == true)
                {
                    while (node != null)
                    {
                        if (node.data != null && data!.ToString() == node.data.ToString())
                        {
                            bTemp = true;
                            break;
                        }
                        node = node.next;
                    }

                    if (!bTemp)
                        return;

                    // 값이 head이자 tail
                    if (head == tail)
                    {
                        head = null;
                        tail = null;
                    }
                    // 값이 head
                    else if (node == head)
                    {
                        //node!.next!.pre = null; 
                        //head = node.next;
                        RemoveFront();
                    }
                    // 값이 tail
                    else if (node == tail)
                    {
                        //node.pre!.next = null;
                        //tail = node.pre;
                        RemoveBack();
                    }
                    // 값이 head와 tail 사이
                    else
                    {
                        node!.pre!.next = node.next;
                        node.next!.pre = node.pre;
                        node = null;
                    } 
                }
                else
                {
                    Console.WriteLine($"Remove : 리스트에 {data}값은 존재하지 않습니다.");
                }
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
            doubleLinkedList.AddAfter(doubleLinkedList.SearchFirst(), 20);

            doubleLinkedList.Show();

            Console.WriteLine($"\n＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝");


            doubleLinkedList.Remove(70);
            doubleLinkedList.Remove(10);
            doubleLinkedList.Remove(30);
            doubleLinkedList.Remove(50);
            doubleLinkedList.Show();

            Console.WriteLine($"\n＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝");
        }
    }
}

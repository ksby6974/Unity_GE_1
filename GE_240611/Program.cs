using System.ComponentModel;
using System.Xml.Linq;

namespace GE_240611
{
    public class DoubleLinkedList<T>
    {
        private class Node
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

        public void PushBack(T data)
        {
            Node? node = new Node();

            if (tail == null)
            {
                head = node;
                tail = node;

                node.data = data;
                node.pre = null;
                node.next = null;
            }
            else
            {
                tail.next = node;
                node.pre = tail;
                tail = node;

                node.data = data;
                node.next = null;
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

        public void Show()
        {
            int iCount = 0;
            Node? currentNode = head;

            while (currentNode != null)
            {
                iCount += 1;
                Console.WriteLine($"【{iCount}】 : {currentNode.data}");
                currentNode = currentNode.next;
            }

            Console.WriteLine($"양방향 연결 리스트 크기 : {GetSize()}");
        }
        
    }

        internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> doubleLinkedList = new DoubleLinkedList<int>();
            doubleLinkedList.PushBack(10);
            doubleLinkedList.PushBack(20);

            doubleLinkedList.Show();
        }
    }
}

namespace GE_240610
{
    // T = 추상 자료형, 후에 선언할 때 명시해줘야함
    public class SingleLinkedList<T>
    {
        private class Node
        {
            public T? data;
            public Node? next;
        }

        //private int iSize;
        private Node? head;

        public SingleLinkedList()
        {
            //iSize = 0;
            head = null;
            Console.WriteLine($"SingleLinkedList 생성");
        }


        public void PushBack(T data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node? currentNode = head;

                if (currentNode.next == null)
                {
                    Node? newNode = new Node();
                    newNode.data = data;
                    currentNode.next = newNode;
                }
                else
                {
                    while (currentNode.next != null)
                    {
                        currentNode = currentNode.next;
                    }

                    Node? newNode = new Node();
                    newNode.data = data;
                    currentNode.next = newNode;
                }
            }
        }

        public void PushFront(T data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node node = new Node();
                node.data = data;
                node.next = head;
                head = node;
            }

        }

        public void RemoveBack()
        {
            if (head == null)
            {
                Console.WriteLine($"RemoveFront : Linked List is Empty.");
            }
            else
            {
                if (head.next == null)
                {
                    head = null;
                }
                else
                {
                    Node? currentNode = head;

                    if (currentNode.next == null)
                    {
                        currentNode = currentNode.next;
                    }
                    else
                    {
                        Node? preNode = null;

                        while (currentNode.next != null)
                        {
                            preNode = currentNode;
                            currentNode = currentNode.next;
                        }

                        preNode!.next = null;
                    }
                }
            }
        }

        public void RemoveFront()
        {
            if (head == null)
            {
                Console.WriteLine($"RemoveFront : Linked List is Empty.");
            }
            else
            {
                head = head.next;
            }
        }

        public int GetSize()
        {
            int iResult = 0;
            Node? currentNode = head;

            while (currentNode != null)
            {
                iResult += 1;
                currentNode = currentNode.next;
            }

            return iResult;
        }

        public void Show()
        {
            int iCount = 0;
            Node? currentNode = head;

            while(currentNode != null)
            {
                iCount += 1;
                Console.WriteLine($"【{iCount}】:{currentNode.data}");
                currentNode = currentNode.next;
            }

            if (iCount > 0)
            {
                Console.WriteLine($"연결 리스트 크기 : {GetSize()}");
            }
            else
            {
                Console.WriteLine($"Show : Linked List is Empty.");
            }
        }
    }

    internal class Program
    {
        //static int iNodeIndex = 0;

        static void Main(string[] args)
        {
            SingleLinkedList<int> singleLinkedList = new SingleLinkedList<int>();
            singleLinkedList.PushFront(30);
            singleLinkedList.PushFront(20);
            singleLinkedList.PushBack(40);
            singleLinkedList.PushFront(10);
            singleLinkedList.Show();

            Console.WriteLine($"\n────────────────────\n");
            singleLinkedList.RemoveBack();
            singleLinkedList.Show();
        }
    }
}

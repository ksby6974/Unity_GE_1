namespace GE_240610
{

    // T = 추상 자료형, 후에 선언할 때 명시해줘야함
    public class SingleLinkedList<T>
    {
        private class Node
        {
            public T data;
            public Node next;

            public Node()
            {
                //
            }

            public void SetData(T data)
            {
                this.data = data;
            }

            public void ShowData()
            {
                Console.WriteLine($"데이터 : {this.data}");
            }
        }

        private int iSize;
        private Node head;

        public SingleLinkedList()
        {
            iSize = 0;
            head = null;
            Console.WriteLine($"SingleLinkedList 생성");
        }

        public void PushBack(T data)
        {
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

        public int GetSize()
        {
            int iResult = 0;
            Node currentNode = head;

            while (currentNode != null)
            {
                iResult += 1;
                currentNode = currentNode.next;
            }

            return iResult;
        }

        public void Show()
        {
            Node currentNode = head;

            while(currentNode != null)
            {
                Console.WriteLine($"{currentNode.data}");
                currentNode = currentNode.next;
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
            singleLinkedList.PushFront(10);

            singleLinkedList.Show();
            Console.WriteLine($"연결 리스트 크기 : {singleLinkedList.GetSize()}");

            //singleLinkedList.head.next.Show_Data();
        }
    }
}

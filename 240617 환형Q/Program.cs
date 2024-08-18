using System.Linq.Expressions;

namespace GE_240617_2
{
    internal class Program
    {
        public class CircleQueue<T>
        {
            private T[] aArray;
            private int iArraySize;
            private T? error;

            private int count;
            private int front;
            private int rear;

            public CircleQueue()
            {
                count = 0;
                iArraySize = 10;
                front = iArraySize - 1;
                rear = iArraySize - 1;
                aArray = new T[iArraySize];
            }

            public void Enqueue(T data)
            {
                if (front == (rear + 1) % iArraySize)
                {
                    Console.WriteLine($"Queue : is Full");
                }
                else
                {
                    rear = (rear + 1) % iArraySize;
                    count++;
                    aArray[rear] = data;
                }
            }

            public T Dequeue()
            {
                if (front == rear)
                {
                    Console.WriteLine($"Queue : is Empty");
                    return error!;
                }
                else
                {
                    front = (front + 1) % iArraySize;
                    count--;
                    return aArray[front];
                }
            }

            public int GetCount()
            {
                return count;
                //return iArraySize - (int)MathF.Abs(front - rear);
            }

            public T Peek()
            {
                return aArray[(front + 1) % iArraySize];
            }

            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.WriteLine($"환형 Queue");
                Console.WriteLine($"front（{front}）　rear（{rear}）");
                Console.WriteLine($"Peek（{Peek()}）, count（{GetCount()}）");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"─────────────────────────────────");
                Console.ResetColor();

                for (int i = 0; i < aArray.Length; i++)
                {
                    Console.WriteLine($"【{i}】:{aArray[i]}");
                }
            }
        }



        static void Main(string[] args)
        {
            CircleQueue<int> circleQueue = new CircleQueue<int>();
            int iLimit = 10;

            for (int i = 1; i < iLimit + 1; i++)
            {
                circleQueue.Enqueue(i);
            }

            while(circleQueue.GetCount() != 0)
            {
                Console.WriteLine(circleQueue.Dequeue());
            }

            circleQueue.Show();
        }
    }
}

namespace GE_240617
{
    internal class Program
    {
        public class LinearQueue<T>
        {
            private T[] aArray;
            private int iArraySize;
            private T? error;

            private int count;
            private int front;
            private int rear;

            public LinearQueue()
            {
                count = 0;
                front = 0;
                rear = 0;
                iArraySize = 10;

                aArray = new T[iArraySize];
            }

            public T Dequeue()
            {
                if (rear == front)
                {
                    Console.WriteLine($"Queue : is Empty");
                    return error!;
                }
                else
                {
                    T data = aArray[front++];
                    aArray[front] = default!;
                    return data;
                }

            }

            public void Enqueue(T data)
            {
                if (aArray.Length - 1 <= rear)
                {
                    Console.WriteLine($"Queue : is Full");
                }
                else
                {
                    for (int i = rear; i > 0; i--)
                    {
                        aArray[i] = aArray[i - 1];
                    }

                    aArray[front] = data;
                    ++rear;
                }
            }

            public int GetCount()
            {
                return rear;
            }

            public T Peek()
            {
                if (rear == front)
                {
                    //Console.WriteLine($"Queue : is Empty");
                    return error!;
                }
                else
                {
                    return aArray[rear];
                }
            }

            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.WriteLine($"Quere");
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
            LinearQueue<int> linearQueue = new LinearQueue<int>();
            int iLimit = 10;

            for (int i = 1; i < iLimit + 1; i++)
            {
                linearQueue.Enqueue(i);
            }

            //linearQueue.Dequeue();

            linearQueue.Show();
        }
    }
}

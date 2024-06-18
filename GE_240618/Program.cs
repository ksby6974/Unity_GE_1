namespace GE_240618
{
    internal class Program
    {
        public class Vector<T>
        {
            private int iSize;
            private int iCapacity;      // 배열의 실제 메모리 크기
            private T[] aArray;

            public Vector()
            {
                iSize = 0;
                iCapacity = 0;
                aArray = null!;
            }

            public void Add(T data)
            {
                if (iCapacity <= 0)
                {
                    Resize(1);
                }
                else if (iSize >= iCapacity)
                {
                    Resize(iCapacity * 2);
                }

                aArray[iSize++] = data;
            }

            public void RemoveAt(int index)
            {
                // 값 부재
                if (aArray[index] == null)
                {
                    Console.WriteLine($"RemoveAt : {index}에 해당하는 값이 없습니다.");
                }
                else
                {
                    aArray[index] = default!;

                    for (int i = index; i < iSize - 1; i++)
                    {
                        if (aArray[i + 1] != null)
                        {
                            aArray[i] = aArray[i + 1];
                        }
                    }

                    aArray[iSize - 1] = default!;
                    iSize--;
                }
            }

            public void Reserve(int newSize)
            {
                if (newSize < iCapacity)
                {
                    iSize = newSize;
                }

                Resize(newSize);
            }

            public void Resize(int newSize)
            {
                iCapacity = newSize;
                T[] newArray = new T[iCapacity];

                for (int i = 0; i < newArray.Length; i++)
                {
                    // 초기화
                    newArray[i] = default!;

                    // 기존 배열의 값 할당
                    if (i < iSize)
                    {
                        newArray[i] = aArray[i];
                    }
                }

                // 참조 재지정
                aArray = newArray;
            }

            public int GetCapa()
            {
                return iCapacity;
            }

            public int GetSize()
            {
                return iSize;
            }

            public T this[int index]
            {
                get { return aArray[index]; }
            }

            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.WriteLine($"Vector");
                Console.WriteLine($"Capa:（{GetCapa()}）, Size:（{GetSize()}）");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"─────────────────────────────────");
                Console.ResetColor();

                for (int i = 0; i < aArray.Length; i++)
                {
                    Console.Write($"【{i}】:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{aArray[i]}");
                    Console.ResetColor();
                }
            }
        }

        static void Main(string[] args)
        {
            Vector<int> vector = new Vector<int>();

            vector.Add(10);
            vector.Add(20);
            vector.Add(30);
            vector.Add(40);
            vector.Add(50);
            vector.Add(60);
            vector.Add(70);
            vector.Add(80);

            vector.RemoveAt(2);

            vector.Show();

            vector.Reserve(16);

            vector.Show();

            vector.Reserve(4);

            vector.Show();

            //Console.WriteLine("Hello, World!");
        }
    }
}

namespace GE_240625
{
    internal class Program
    {
        public class Heap<T>
        {
            int iArraySize;
            int iSize;
            T[] aArray;

            public Heap()
            {
                iArraySize = 8;
                iSize = 0;
                aArray = new T[iArraySize];
            }

            public void Insert(T data)
            {
                if (iSize >= iArraySize - 1)
                {
                    Console.WriteLine($"Error : is Full");
                }
                else
                {
                    aArray[++iSize] = data;
                    int child = iSize;
                    int parent = iSize / 2;

                    //Console.WriteLine($"[{iSize}], P:{parent}, C:{child}");

                    while (parent > 0 && child > 0)
                    {
                        int iParent = int.Parse(aArray[parent]!.ToString()!);
                        int iChild = int.Parse(aArray[child]!.ToString()!);

                        if (iParent < iChild)
                        {
                            Swap(ref aArray[parent], ref aArray[child]);
                        }

                        if (parent == child)
                        {
                            parent = parent / 2;
                        }
                        else
                        {
                            child = child / 2;
                        }

                        /*
                        child = parent;
                        parent = child / 2;
                        */
                    }

                }
            }

            public void Remove()
            {
                if (iSize == 0)
                {
                    Console.WriteLine($"Heap is Empty");
                }
                else
                {
                    // 임시 변수에 array[1] 값을 보관
                    T tTemp = aArray[1];

                    // index로 가리키는 배열의 값을 첫번째 원소에 할당
                    aArray[1] = aArray[iSize];

                    // index를 가리키는 배열의 값을 초기화
                    aArray[iSize] = default!;
                    --iSize;


                    int parent = 1;
                    int child = parent;

                    while (iSize > child)
                    {
                        //Console.WriteLine($"Remove : {parent}, {child}");

                        int iParent = int.Parse(aArray[parent]!.ToString()!);
                        int iChild = int.Parse(aArray[child]!.ToString()!);

                        if (iParent < iChild)
                        {
                            Swap(ref aArray[parent], ref aArray[child]);
                        }

                        if (child / 2 == parent)
                        {
                            child = child + 1;
                            parent = child / 2;
                        }
                        else
                        {
                            child = child * 2;
                        }
                    }
                }
            }

            //정답용
            public void Remove_R()
            {
                int parent = 1;

                while (parent * 2 <= iSize)
                {
                    int child = parent * 2;

                    // 왼쪽 자식 노드보다 오른쪽 자식 노드가 더 클 떄
                    if (int.Parse(aArray[child].ToString()) < int.Parse(aArray[child + 1].ToString()))
                    {
                        child++;
                    }

                    // 부모 노드의 key값이 자식 노드의 key값보다 크다면 반복문 종료
                    if (int.Parse(aArray[child].ToString()) < int.Parse(aArray[parent].ToString()))
                    {
                        break;
                    }

                    Swap(ref aArray[parent], ref aArray[child]);
                    parent = child;
                }
            }


            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.Write($"Heap");
                Console.WriteLine($"（{iArraySize}）");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"─────────────────────────────────");

                Console.ResetColor();
                for (int i = 1; i < iArraySize; i++) 
                {
                    Console.WriteLine($"【{i}】:{aArray[i]}");
                }
            }

            public void Swap(ref T data1, ref T data2)
            {
                //Console.WriteLine($"swap: {data1}↔{data2}");

                T tTemp = data1;

                data1 = data2;
                data2 = tTemp;
            }
        }

        static void Main(string[] args)
        {
            Heap<int> heap = new Heap<int>();

            for (int i = 1; i < 8; i++)
            {
                heap.Insert(i);
            }

            heap.Show();

            heap.Remove();

            heap.Show();
        }
    }
}

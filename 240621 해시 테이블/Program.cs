using System.Globalization;
using System.Linq;

namespace GE_240621
{
    internal class Program
    {
        public class HashTable<KEY, VALUE>
        {
            public class Bucket
            {
                public int count;
                public Node? head;

                public Bucket()
                {
                    count = 0;
                }
            }

            public class Node
            {
                public KEY? key;
                public VALUE? value;
                public Node? next;
            }

            private readonly int iArraySize;
            public Bucket[] buckets;

            public HashTable()
            {
                iArraySize = 10;
                buckets = new Bucket[iArraySize];

                for (int i = 0; i < iArraySize; i++)
                {
                    buckets[i] = new Bucket();
                }
            }

            private Node CreateNode(KEY key, VALUE value)
            {
                Node node = new Node();
                node.value = value;
                node.key = key;
                node.next = null!;

                return node; 
            }

            public int GetCount()
            {
                int iResult = 0;

                for (int i = 0; i < iArraySize; i++)
                {
                    Node node = buckets[i].head!;

                    while (node != null)
                    {
                        iResult++;
                        node = node.next!;
                    }
                }

                return iResult;
            }


            private int HashFunction(KEY key)
            {
                return int.Parse(key!.ToString()!) % iArraySize;
            }

            public void Insert(KEY key, VALUE value)
            {
                //해시 함수를 통해서 값을 받는 임시 변수
                int iIndex = HashFunction(key);
                Node node = CreateNode(key, value);

                //Console.WriteLine($"{iIndex}");

                if (buckets[iIndex].count <= 0)
                {
                    buckets[iIndex].head = node;
                    buckets[iIndex].count++;
                }
                else
                {
                    node.next = buckets[iIndex].head;
                    buckets[iIndex].head = node;
                    buckets[iIndex].count++;
                }
            }

            public void Remove(KEY key) 
            {
                bool bResult = false;
                //해시 함수를 통해서 값을 받는 임시 변수
                int iIndex = HashFunction(key);
                
                //Node 탐색용 순회용 포인터
                Node? node = buckets[iIndex].head;

                // 이전 Node 저장용 포인터 선언
                Node? prenode = null;

                // currentNode 탐색
                if (node == null)
                {
                    Console.WriteLine($"Remove : {key} is absence.");
                    return;
                }
                else
                {
                    while (node != null)
                    {
                        if (node.key!.ToString() == key!.ToString())
                        {
                            // 삭제하고자 하는 key가 head
                            if (node == buckets[iIndex].head)
                            {
                                buckets[iIndex].head = node.next;
                            }
                            else
                            {
                                prenode!.next = node.next;
                            }

                            buckets[iIndex].count--;
                            return;
                        }
                        else
                        {
                            prenode = node;
                            node = node.next;
                        }
                    }
                }

                Console.WriteLine($"Remove : {key} is absence.");
            }


            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.Write($"HashTalbe :: ");
                Console.WriteLine($"（{GetCount()}）");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"─────────────────────────────────");
                Console.ResetColor();

                //Console.WriteLine($"HashTable : Is Empty");
                for (int i = 0; i < iArraySize; i++)
                {
                    Node node = buckets[i].head!;

                    while (node != null)
                    {
                        Console.Write($"【{i}】");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{node.key}");
                        Console.ResetColor();
                        Console.Write($":");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"{node.value}");
                        Console.ResetColor();

                        Console.WriteLine($"");
                        node = node.next!;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            HashTable<int,string> hashTable = new HashTable<int, string>();

            hashTable.Insert(10, "Punch");
            hashTable.Insert(6, "Kick");
            hashTable.Insert(4, "Slash");

            hashTable.Remove(4);

            hashTable.Show();
        }
    }
}

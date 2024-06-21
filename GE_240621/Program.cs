using System.Globalization;

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

            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.Write($"HashTalbe :: ");
                Console.WriteLine($"");

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
                        Console.WriteLine($"{node.value}");
                        Console.ResetColor();
                        node = node.next!;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            HashTable<int,string> hashTable = new HashTable<int, string>();

            hashTable.Insert(10,"Punch");
            hashTable.Insert(6, "Kick");
            hashTable.Insert(4, "Slash");

            hashTable.Show();
        }
    }
}

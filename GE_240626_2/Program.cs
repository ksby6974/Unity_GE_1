﻿using static GE_240626_2.Program;

namespace GE_240626_2
{

    internal class Program
    {
        #region 인접 리스트
        // 그래프의 각 정점에 인접한 정점들을 연결 리스트로 표현하는 방법

        // 【장점】
        // 그래프의 모든 간선의 수를 O(V+E)로 표현할 수 있음

        // 【단점】
        // 두 정점을 연결하는 간선을 조회하거나 정점의 차수를 알기 위해
        // 정점의 인접 리스트를 모두 탐색해야 하므로 정점의 차수만큼의 시간 필요
        #endregion

        public class AdjacencyList<T>
        {
            private int iSize;
            private int iArraySize;
            private T[] tVertex;
            private Node[] nList;

            public class Node
            {
                public T? data;
                public Node? next;

                public Node(T data, Node link = null!)
                {
                    this.data = data;
                    this.next = link;
                }
            }

            public AdjacencyList()
            {
                iSize = 0;
                iArraySize = 10;
                tVertex = new T[iArraySize];
                nList = new Node[iArraySize];
            }

            public void Insert(T data)
            {
                if (iSize >= iArraySize)
                {
                    Console.WriteLine($"List is Full");
                }
                else
                {
                    tVertex[iSize] = data;
                    Node node = new Node(data,null);
                    node.data = data;
                    node.next = null;

                    if (iSize > 0)
                    {
                        node.next = nList[iSize - 1];
                    }

                    nList[iSize] = node;
                }

                iSize++;
            }

            public void Connect(Node a, Node b)
            {

            }

            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.Write($"AdjacencyList");
                Console.WriteLine($"『{iSize}』");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"─────────────────────────────────");
                Console.ResetColor();

                if (iSize == 0)
                {
                    Console.WriteLine($"List is Empty");
                    return;
                }

                for (int i = 0; i < iSize; i++)
                {
                    Console.Write($"{tVertex[i]}:");

                    Console.Write($"{nList[i].data} → {nList[i].next}");
                }

                Console.WriteLine($"");
            }
        }

        static void Main(string[] args)
        {
            AdjacencyList<int> list = new AdjacencyList<int>();

            list.Insert('A');
            list.Insert('B');
            list.Insert('C');
            list.Insert('D');

            list.Show();
        }
    }
}

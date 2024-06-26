using System;
using System.Xml.Serialization;

namespace GE_240626
{
    #region 그래프
    // 요소들이 서로 복잡하게 연결되어있는 관계를 표현하는 자료 구조
    // 정점과 간선들의 집합으로 구성됨

    // 정점 (Vertex)
    // 노드(Node) 데이터가 저장되는 그래프의 기본 원소

    // 간선 (Edge)
    // 노드들을 연결하는 선

    // 인접 정점(Adjacency Vertex)
    // 간선으로 직접 연결된 정점

    // 차수 (Degree)
    // 정점에 연결된 간선의 수를 의미

    // 경로 (Path)
    // 정점들을 연결하는 간선들의 순서
    #endregion

    #region 그래프의 종류
    // 무방향 그래프
    // 간선에 방향이 없는 그래프

    // 방향 그래프
    // 간선에 방향이 있는 그래프

    // 가중치 그래프
    // 간선에 가중치가 있는 그래프
    #endregion

    internal class Program
    {
        #region 인접 행렬
        // 정점들 간의 연결 관계를 2차원 배열로 표현하는 방식
        // 정점의 개수가 V일 때 V 크기의 2차원 배열 사용

        // 【장점】
        // 1. 두 정점이 연결되어 있는가 확인하기 쉬움
        // 2. 두 정점 사이의 간선의 가중치를 쉽게 확인가능

        // 【단점】
        // 1. 정점의 개수가 많을 때 메모리 낭비가 큼
        #endregion

        public class AdjacencyMatrix<T>
        {
            private int iSize;          // 정점의 수
            private int iArraySize;
            T[] tVertex;                // 정점의 집합
            private int[,] aMatrix;     // 인접 행렬


            public AdjacencyMatrix()
            {
                iSize = 0;
                iArraySize = 10;
                tVertex = new T[iArraySize];
                aMatrix = new int [iArraySize, iArraySize];

            }

            public void Insert(T data)
            {
                if (iSize >= iArraySize)
                {
                    Console.WriteLine($"Matrix is Full");
                }
                else
                {
                    tVertex[iSize++] = data;
                }
            }
            
            public void Connect(int i, int j)
            {
                if (iSize <= 0)
                {
                    Console.WriteLine($"Matrix is Empty");
                    return;
                }

                if (iSize <= i || iSize <= j)
                {
                    Console.WriteLine("Index Out of Range");
                    return;
                }

                aMatrix[i, j] = 1;
                aMatrix[j, i] = 1;
            }


            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.Write($"Matrix");
                Console.WriteLine($"（{iArraySize},{iArraySize}）『{iSize}』");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"─────────────────────────────────");
                Console.ResetColor();

                if (iSize <= 0)
                {
                    Console.WriteLine($"Matrix is Empty");
                    return;
                }

                for (int i = 0; i < iSize; i++)
                {
                    Console.Write(tVertex[i] + "\t");

                    for (int j = 0; j < iSize; j++)
                    {
                        Console.Write($"{aMatrix[i, j]}\t");
                    }
                    Console.WriteLine($"");
                }
            }
        }

        static void Main(string[] args)
        {
            AdjacencyMatrix<int> matrix = new AdjacencyMatrix<int>();

            matrix.Insert('A');
            matrix.Insert('B');
            matrix.Insert('C');
            matrix.Insert('D');

            matrix.Connect(0,1);
            matrix.Connect(1, 2);
            matrix.Connect(1, 3);

            matrix.Show();
        }
    }
}

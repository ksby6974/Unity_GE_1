namespace GE_240614
{
    public class Stack<T>
    {
        public Stack()
        {
            top = -1;
            arraySize = 10;
            array = new T[arraySize];
        }

        private readonly int arraySize;
        private int top;
        private T?[] array;

        public void Push(T data)
        {
            if (top >= arraySize - 1)
            {
                Console.WriteLine($"Stack : Overflow");
            }
            else
            {
                array[++top] = data;
            }

            //Console.WriteLine($"Push : {data} 값 삽입");
        }

        public bool Contains(T data)
        {
            for (int i = 0; i < top; i++)
            {
                if (array[i]!.ToString() == data!.ToString())
                {
                    //Console.WriteLine($"Contains : {data} 값이 존재합니다.");
                    return true;
                }
            }

            //Console.WriteLine($"Contains : {data} 값 없음…");
            return false;
        }

        public T Peek()
        {
            if (top > -1)
            {
                //Console.WriteLine($"Peek : {top + 1}번째 {array[top]} 값");
                return array[top]!;
            }
            else
            {
                Console.WriteLine($"Peek : Stack에 값 없음");
                return default!;
            }
        }

        public T Pop()
        {
            if (top > -1)
            {
                //Console.WriteLine($"Pop에 의해 값 삭제됨");
                return array[top--]!;
            }
            else
            {
                Console.WriteLine($"Pop : Stack에 값 없음");
                return default!;
            }
        }

        public int GetSize()
        {
            return top;
        }

        public bool IsEmpty()
        {
            if (top < 0)
                return true;
            else
                return false;
        }

        public bool IsFull()
        {
            if (arraySize <= top)
                return true;
            else
                return false;
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ResetColor();
            Console.WriteLine($"Stack :（{top}）");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"─────────────────────────────────");
            Console.ResetColor();

            if (top == -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Stack : Empty");
                Console.ResetColor();
            }
            else
            {
                for (int i = 0; i < top + 1; i++)
                {
                    Console.Write($"【{i}】:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{array[i]}");
                    Console.ResetColor();
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            stack.Pop();
            //stack.Peek();
            //stack.Contains(50);

            stack.Show();

            CheckBracket("{{(1234}}");
            CheckBracket("[((asdf))]");
        }

        static public bool CheckBracket(string sMain)
        {
            bool bResult = true;

            Stack<char> stack = new Stack<char>();
            char[] cTemp = sMain.ToCharArray();

            //값 넣기
            for (int i = 0; i < cTemp.Length; i++)
            {
                if (CheckOpen(cTemp[i]) == true)
                {
                    stack.Push(cTemp[i]);
                }
                else if (CheckClosed(cTemp[i], stack.Peek()) == true)
                {
                    stack.Pop();
                }
            }

            stack.Show();

            if (stack.IsEmpty() == true)
            {
                Console.WriteLine($"{sMain} 결점 없음");
            }
            else
            {
                bResult = false;
                Console.WriteLine($"{sMain} 오작동");
            }

            return bResult;
        }

        static public bool CheckOpen(char c)
        {
            if ((c == '(') || (c == '{') || (c == '['))
            {
                return true;
            }

            return false;
        }

        static public bool CheckClosed(char c, char v)
        {
            if (c == ')' && v == '(')
            {
                return true;
            }

            if (c == '}' && v == '{')
            {
                return true;
            }

            if (c == ']' && v == '[')
            {
                return true;
            }

            return false;
        }
    }
}

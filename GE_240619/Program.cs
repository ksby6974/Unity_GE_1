using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace GE_240619
{
    internal class Program
    {
        public class StringList
        {
            int iError;
            int iSize;
            char[] aArray;

            public StringList()
            {
                iError = -1;
                iSize = 0;
                aArray = null!;
            }

            public void Add(char[] cTemp)
            {
                aArray = new char[cTemp.Length + 1];

                for (int i = 0; i < cTemp.Length; i++)
                {
                    aArray[i] = cTemp[i];
                }
            }

            public void Concat(char[] cTemp)
            {
                if (cTemp == null)
                {
                    Console.WriteLine($"StringList : Input Error");
                }
                else
                {
                    if (aArray == null)
                    {
                        Add(cTemp);
                    }
                    else
                    {
                        char[] aTemp = new char[aArray.Length + cTemp.Length];

                        for (int i = 0; i < aArray.Length; i++)
                        {
                            aTemp[i] = aArray[i];
                        }

                        for (int i = 0; i < cTemp.Length; i++)
                        {
                            aTemp[aArray.Length - 1 + i] = cTemp[i];
                        }

                        aArray = aTemp;
                    }
                }
            }

            public bool Equals(char[] cTemp)
            {
                bool bResult = true;

                if (aArray == null)
                {
                    Console.WriteLine($"StringList : is Empty");
                    bResult = false;
                }
                else
                {
                    if (aArray.Length - 1 == cTemp.Length)
                    {
                        for (int i = 0; i < aArray.Length - 1; i++)
                        {
                            if (cTemp[i] != aArray[i])
                            {
                                bResult = false;
                                break;
                            }
                        }
                    }
                }

                return bResult;
            }

            public int GetSize()
            {
                if (aArray == null)
                {
                    Console.WriteLine($"StringList : is Empty");
                    return 0;
                }
                else
                {
                    return aArray.Length;
                }
            }

            public int IndexOf(char c)
            {
                int iResult = iError;

                if (aArray == null)
                {
                    Console.WriteLine($"StringList : is Empty");
                    return 0;
                }
                else
                {
                    for (int i = 0; i < aArray.Length; i++)
                    {
                        if (c == aArray[i])
                        {
                            iResult = i;
                            break;
                        }
                    }
                }

                return iResult;
            }

            public void Renewal(string s)
            {
                if (s == null)
                {
                    Console.WriteLine($"StringList : Input Error");
                }
                else
                {
                    char[] cTemp = s.ToCharArray();

                    if (iSize < cTemp.Length)
                    {
                        iSize = cTemp.Length;
                    }

                    aArray = cTemp;
                }
            }

            public void Show()
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ResetColor();
                Console.Write($"String :: ");
                ShowDetail();
                Console.WriteLine($"Size:（{GetSize()}）");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"─────────────────────────────────");
                Console.ResetColor();

                if (aArray == null)
                {
                    Console.WriteLine($"StringList : is Empty");
                }
                else
                {
                    for (int i = 0; i < aArray.Length; i++)
                    {
                        Console.Write($"【{i,2}】:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{aArray[i]}");
                        Console.ResetColor();
                    }
                }
            }

            public void ShowDetail()
            {
                if (aArray == null)
                {
                    
                }
                else
                {
                    for (int i = 0; i < aArray.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{aArray[i]}");
                        Console.ResetColor();
                    }

                    Console.WriteLine($"");
                }
            }
        }

        static void Main(string[] args)
        {
            StringList stringlist = new StringList();
            stringlist.Add(new char[] { 'A', 'B', 'C' });

            stringlist.Show();

            stringlist.Concat(new char[] { '1', '2', '3' });

            stringlist.Show();
            Console.WriteLine($"Index : 2 - {stringlist.IndexOf('2')}번째");

            char[] cTemp = new char[] { 'A', 'B', 'C', '1', '2', '3' };
            for (int i = 0; i < cTemp.Length; i++)
            {
                Console.WriteLine($"{cTemp[i]}");
            }

            Console.WriteLine($"비고 : {stringlist.Equals(cTemp)}");
        }
    }
}

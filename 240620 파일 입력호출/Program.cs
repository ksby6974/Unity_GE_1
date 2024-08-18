namespace GE_240620
{
    internal class Program
    {
        // 아스키 아트

        static void LoadText(string stream)
        {
            StreamReader streamReader = new StreamReader(stream);

            while (streamReader.Peek() >= 0)
            {
                Console.WriteLine(streamReader.ReadLine());
            }

            streamReader.Close();
        }

        static void Main(string[] args)
        {
            #region File
            // File
            // 파일에 대한 생성, 복사, 이동 및 열기를 위한 클래스

            // FileInfo
            // 파일에 대한 생성, 복사, 이동 및 열기에 대한 속성

            // FileStream
            // 파일에 대한 스트림을 제공하여 동기 및 비동기 읽기쓰기를 지원

            // StreamReader
            // 문자열에서 읽어오는 TextReader 구현

            // StreamWriter
            // TextWriter를 구현
            #endregion

            /*
            FileStream fileStream = File.Create("data.txt");

            fileStream.Close();
            */

            /*
            StreamWriter streamWriter = new StreamWriter("data.txt");

            streamWriter.WriteLine("HP 100");
            streamWriter.WriteLine("Level 10");
            streamWriter.WriteLine("Name Warrior");

            streamWriter.Close();
            */

            LoadText("mt1.txt");
        }
    }
}

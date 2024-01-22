namespace Seminar1;
class Program
{
    //   cd Lesson_Geek\C#_abstract\NetWork\Seminar\Seminar1\Seminar1\bin\Debug\net8.0
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Server.AcceptMsg();
        }
        else
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    new Thread(() =>
            //    {
            //        Client.SendMsg($"{args[0]} {i}");
            //    }).Start();
            //}
            Client.SendMsg($"{args[0]}");
        }
    }
}

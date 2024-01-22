using System.Net;
using System.Net.Sockets;
using System.Text;


namespace Seminar1;
internal class Server
{
    static ConsoleKey stop;
    public static void AcceptMsg()
    {
        IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
        UdpClient udpClient = new UdpClient(16874);
        Console.WriteLine("Сервер ожидает сообщение");

        while (true)
        {
            stop = Console.ReadKey().Key;
            if (stop == ConsoleKey.Escape) break;

            byte[] buffer = udpClient.Receive(ref ep);
            string data = Encoding.UTF8.GetString(buffer);

            Thread tr = new Thread(() =>
            {
                Message msg = Message.FromJson(data);
                Console.WriteLine(msg.ToString());
                Message responseMsg = new Message("Server", "Message accept on serv!");
                string responseMsgJs = responseMsg.ToString();
                byte[] responseDate = Encoding.UTF8.GetBytes(responseMsgJs);
                udpClient.Send(responseDate, ep);
            });
            tr.Start();
        }
    }
}


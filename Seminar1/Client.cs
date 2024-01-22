using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Seminar1;
internal class Client
{
    public static void SendMsg(string name)
    {
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16874);
        UdpClient udpClient = new UdpClient();

        while (true)
        {

            Console.WriteLine("Введите сообщение");
            string message = Console.ReadLine()!;
            Message msg = new Message(name, message);
            if (message.ToLower() == "exit")
            {
                Console.WriteLine("Завершение работы");
                Console.ReadKey();
                udpClient.Close();
                break;
                //udpClient.Dispose();
            }

            string responseMsgJs = msg.ToJSon();
            byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
            udpClient.Send(responseData, ep);
            byte[] answerData = udpClient.Receive(ref ep);
            string answerMsgJs = Encoding.UTF8.GetString(responseData);
            Message answerMsg = Message.FromJson(answerMsgJs);
            Console.WriteLine(answerMsg.ToString());



        }

    }

}

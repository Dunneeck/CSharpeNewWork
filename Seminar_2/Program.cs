using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Seminar2;

public class Program
{
    static int[] arr1 = { 1, 2, 3 };
    static int[] arr2 = { 2, 3, 4 };
    static int val1, val2;
    public static void Summ1()
    {
        val1 = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            val1 += arr1[i];
        }
    }
    public static void Summ2()
    {
        val2 = 0;
        for (int i = 0; i < arr2.Length; i++)
        {
            val2 += arr2[i];
        }
    }
    static void Main()
    {
        //Task_1();
        //Task_2();


    }
    public static void Task_1()
    {
        Thread thread1 = new Thread(Summ1);
        thread1.Start();
        thread1.Join();

        Thread thread2 = new Thread(Summ2);
        thread2.Start();
        thread2.Join();
        Console.WriteLine($"{val1} + {val2} = {val1 + val2}");
    }
    public static void Task_2()
    {
        string resources = "yandex.ru";

        var IPAdresses = Dns.GetHostAddresses(resources, AddressFamily.InterNetwork);

        foreach (var address in IPAdresses)
        {
            Console.WriteLine(address);
        }
        Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();
        List<Thread> threads = new List<Thread>();
        foreach (var address in IPAdresses)
        {
            var tr = new Thread(() =>
            {
                Ping ping = new Ping(); 
                PingReply pingReply = ping.Send(address);

                pings.Add(address, pingReply.RoundtripTime);
            });
            threads.Add(tr);
            tr.Start();
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }
        long min = long.MaxValue;
        //var minimum = pings.Min(t => t.Value);

        foreach (var ping in pings)
        {
            if(ping.Value < min) min = ping.Value;

            Console.WriteLine($"IP: {ping.Key}, ping: {ping.Value}");
        }
        Console.WriteLine($"min ping {min}");


    }
}

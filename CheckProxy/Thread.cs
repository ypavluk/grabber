using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckProxy
{
    public class Thread
    {
        public static bool finish = false;

        public static void iThread (List<Proxy> listProxy, int threadNumber, int vkcount)
        {
             
            Task thread = Task.Run(() =>
            {
                foreach (var proxy in listProxy)
                {
                    if (VkPost.vkList.Count > vkcount)
                    {
                        finish = true;
                        break;
                    }
                Task t = Task.Run(() =>
                    {
                        // Just loop.
                        proxy.checkProxy();
                        Console.Write(proxy.ip + ":" + proxy.port);
                        if (proxy.status == "OK")
                        {
                            VkPost.vkList.Add(proxy);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("  -  OK");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" - Thread - " + threadNumber);
                            var time = DateTime.Now;
                            //proxy.checkTime = time.ToString();
                            proxy.checkTime = time.Hour + ":" + time.Minute + ":" + time.Second + " Msk ";
                            Console.Write(" DateTime - " + proxy.checkTime + " Total good: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(VkPost.vkList.Count);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (proxy.status == "OFF")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("  -  OFF");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" - Thread - " + threadNumber);
                            
                        }
                    });
                    t.Wait();
                    t.Dispose();
                }
            });
         
        }

        public static void iThread2(Proxy proxy)
        {
                    Task t = Task.Run(() =>
                    {
                        // Just loop.
                        proxy.checkProxy();
                        Console.Write(proxy.ip + ":" + proxy.port);
                        if (proxy.status == "OK")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("  -  OK");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" - Thread - ");
                        }
                        if (proxy.status == "OFF")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("  -  OFF");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" - Thread - ");
                            var time = DateTime.UtcNow;
                            proxy.checkTime = time.Hour + ":" + time.Minute + ":" + time.Second;
                            Console.WriteLine(" DateTime - " + proxy.checkTime);
                        }
                    });
                    t.Wait();
                    t.Dispose();
       
        }


    }
}

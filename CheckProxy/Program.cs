using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckProxy
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;

            Files fileReader = new Files();
            int threadNumber = 4;

            fileReader.readProxyFile();
            if (!fileReader.haveFile)
                return;

             for (var i =1; i<=threadNumber; i++)
             {
             Thread.iThread(fileReader.fullMassProxy[i-1], i, VkPost.vkCount);
             }

            while(true)
            {
                if (Thread.finish)
                    break;
            }
            VkPost.vkList.Reverse(); //отразить
            VkPost.postMesage(VkPost.vkList);

            Console.WriteLine("Завершение метода Main");
        } 
    }
}

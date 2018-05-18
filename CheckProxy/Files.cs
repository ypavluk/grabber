using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CheckProxy
{
    public class Files
    {
        public string path = "D:\\TestProxtList1.txt";
        public bool haveFile = true;

        public List<string> proxyFromFile = new List<string>();
        public List<string> proxyFromFile2 = new List<string>();
        public List<string> proxyFromFile3 = new List<string>();
        public List<string> proxyFromFile4 = new List<string>();

        public List<Proxy> oldListProxy = new List<Proxy>();
        public List<Proxy> oldListProxy2 = new List<Proxy>();
        public List<Proxy> oldListProxy3 = new List<Proxy>();
        public List<Proxy> oldListProxy4 = new List<Proxy>();

        public List<Proxy>[] fullMassProxy;
        Random rnd = new Random();
        public void readProxyFile()
        {
            if (!File.Exists(path))
            {
                haveFile = false;
                Console.Write("File not exist. Program exit after press any key ...");
                Console.ReadLine();
                return;
            }

            using (StreamReader fs = new StreamReader(path))
            {
                while (true)
                {
                    // Читаем строку из файла во временную переменную.
                    string temp = fs.ReadLine();

                    // Если достигнут конец файла, прерываем считывание.
                    if (temp == null) break;

                    var tempRnd = rnd.Next(1, 400);
                    if (tempRnd < 100)
                        proxyFromFile.Add(temp);
                    if (tempRnd >= 100 && tempRnd < 200)
                        proxyFromFile2.Add(temp);
                    if (tempRnd >= 200 && tempRnd < 300)
                        proxyFromFile3.Add(temp);
                    if (tempRnd >= 300)
                        proxyFromFile4.Add(temp);
                    // Пишем считанную строку в итоговую переменную.
                }
            }
            

            oldListProxy = split(proxyFromFile);
            oldListProxy2 = split(proxyFromFile2);
            oldListProxy3 = split(proxyFromFile3);
            oldListProxy4 = split(proxyFromFile4);

            fullMassProxy = new List<Proxy>[] { oldListProxy, oldListProxy2, oldListProxy3, oldListProxy4 };
        }

        public void delim (List<Proxy> listProxy, int thread)
        {
            List<Proxy>[] massListProxy = new List<Proxy>[thread];
            var count = listProxy.Count;
            var listNumber = count / thread;

            for (var i = 0; i < thread-1; i++)
            {
                List<Proxy> temp = new List<Proxy>();
                massListProxy[i] = temp;
            }
        }

        public List<Proxy> split(List<string> proxyFromFile)
        {
            List<Proxy> tempList = new List<Proxy>();
            foreach (var str in proxyFromFile)
            {
                var temp = str.Split(new char[] { ':' });
                Proxy tempProxy = new Proxy(temp[0], temp[1]);
                tempList.Add(tempProxy);
            }
            revertList(tempList);
            return tempList;
        }

        public void revertList (List<Proxy> data)
        { 

        for (int i = data.Count - 1; i >= 1; i--)
        {
                Random rnd = new Random();
                int j = rnd.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = data[j];
                data[j] = data[i];
                data[i] = temp;
            }
        }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CheckProxy
{
    public class VkPost
    {
        public static string url = "https://api.vk.com/method/wall.post?owner_id=-17843423&v=5.0&from_group=1&signed=0";
        //owner_id=-5346436  от id группы для группы "-"
        //from_group - От имени сообщества
        //signed - не обязательно
        //access_toke - токен
        public static string access_token = "access_token=b9349d8ce6236f32b45f4a4735bcd89305b4c15e5a3eb562bfd5c";
        public static string message = "message=";
        public string oldPost;
        public static List<Proxy> vkList = new List<Proxy>();
        public static int vkCount = 14; // количество срок в месседже

        public static void postMesage(List<Proxy> listProxy)
        {
            message += "список прокси";
            message += "\n\r";
            message += "\n\r";
            foreach (var proxy in listProxy)
            {
                message += proxy.ip + ":" + proxy.port + " - " + proxy.protocol + " -  [check: " + proxy.checkTime + "]";
                message += "\n\r";
            }

            var oldPost = url + "&" + message + "&" + access_token;


            using (var webClient = new WebClient())
            {
                 var response = webClient.DownloadString(oldPost);
            }
        }
    }
}

    
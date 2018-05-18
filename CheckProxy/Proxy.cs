using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace CheckProxy
{
    public class Proxy
    {
        public string ip;
        public string port;
        public string protocol = "http/s";
        public string status;
        public string lastError;
        public string checkTime;

        public Proxy(string _ip, string _port, string _protocol)
        {
            ip = _ip;
            port = _port;
            protocol = _protocol;
        }

        public Proxy(string _ip, string _port)
        {
            ip = _ip;
            port = _port;
        }
        public void checkProxy()
        {
            try
            {
                using (var request = new HttpRequest())
                {
                    if (protocol == "socks")
                        request.Proxy = Socks5ProxyClient.Parse(ip + ":" + port);
                    if (protocol == "http/s")
                        request.Proxy = HttpProxyClient.Parse(ip + ":" + port);
                    //request.Proxy.Username = "user";
                    //request.Proxy.Password = "pass";
                    request.ConnectTimeout = 5;
                    request.Get("google.com");
                    if (request.Response.IsOK)
                    {
                        status = "OK";

                    }

                }
            }
            catch (HttpException ex)
            {
                status = "OFF";

                lastError = "Error: " + ex.Message;

                switch (ex.Status)
                {
                    case HttpExceptionStatus.Other:
                        //Console.WriteLine("Неизвестная ошибка");
                        break;

                    case HttpExceptionStatus.ProtocolError:
                        //Console.WriteLine("Код состояния: {0}", (int)ex.HttpStatusCode);
                        break;

                    case HttpExceptionStatus.ConnectFailure:
                        //Console.WriteLine("Не удалось соединиться с HTTP-сервером.");
                        break;

                    case HttpExceptionStatus.SendFailure:
                        //Console.WriteLine("Не удалось отправить запрос HTTP-серверу.");
                        break;

                    case HttpExceptionStatus.ReceiveFailure:
                        //Console.WriteLine("Не удалось загрузить ответ от HTTP-сервера.");
                        break;
                }
            }
        }

    }
}

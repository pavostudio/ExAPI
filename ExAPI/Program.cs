using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PavoStudio.ExApi;

namespace ExAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger.AddListener(OnMessage, LocalMsg.OnOpen, LocalMsg.OnClose, LocalMsg.OnError);

            ExClient.Instance.Connect();
            Console.ReadLine();

            Messenger.RemoveListener(OnMessage, LocalMsg.OnOpen, LocalMsg.OnClose, LocalMsg.OnError);
            ExClient.Instance.Close();
        }

        static void OnMessage(BaseMessage bm) {
            switch (bm.msg) {
                case LocalMsg.OnOpen:
                    ApiTest.SetBackground();
                    break;
                case LocalMsg.OnError:
                case LocalMsg.OnClose:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

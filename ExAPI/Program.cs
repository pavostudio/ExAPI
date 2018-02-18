using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PavoStudio.ExApi;

namespace ExAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger.AddListener(OnMessage, LocalMsg.OnOpen, LocalMsg.OnClose, LocalMsg.OnError);

            ExClient.Instance.Start();
            Console.ReadLine();

            Messenger.RemoveListener(OnMessage, LocalMsg.OnOpen, LocalMsg.OnClose, LocalMsg.OnError);
            ExClient.Instance.Stop();
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

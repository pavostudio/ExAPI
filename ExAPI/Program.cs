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
            Messenger.AddListener(OnMessage, LocalMsg.OnOpen, LocalMsg.OnClose, LocalMsg.OnError, Msg.OnModelEvent, Msg.ShowTextBubble);

            ExClient.Instance.Start();
            Console.ReadLine();

            Messenger.RemoveListener(OnMessage, LocalMsg.OnOpen, LocalMsg.OnClose, LocalMsg.OnError, Msg.OnModelEvent);
            ExClient.Instance.Stop();
        }

        static void OnMessage(BaseMessage bm)
        {
            switch (bm.msg)
            {
                case LocalMsg.OnOpen:
                    Console.WriteLine("Connection Open");
                    ApiTest.SetBackground();
                    //ApiTest.NextExpression();
                    //ApiTest.RegisterModelEventListener();
                    //ApiTest.SetPosition();
                    //ApiTest.StartMotion(0, "tap_head");
                    //ApiTest.StartMotion(1, "motions/haru_normal_01.mtn");
                    //ApiTest.ShowTextBubble();
                    break;
                case LocalMsg.OnError:
                case LocalMsg.OnClose:
                    Environment.Exit(0);
                    break;
                case Msg.OnModelEvent:
                    ModelEvent evt = bm.GetData<ModelEvent>();
                    if (evt != null)
                        Console.WriteLine(evt.ToString());

                    ApiTest.UnregisterModelEventListener();
                    break;
                case Msg.ShowTextBubble:
                    Console.WriteLine(string.Format("msgId: {0}, data: {1}", bm.msgId, bm.IntValue));
                    break;
            }
        }
    }
}

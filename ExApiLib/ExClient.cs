using System;
using WebSocketSharp;

namespace PavoStudio.ExApi
{
    public class ExClient : Messenger.Sender
    {
        public static ExClient Instance
        {
            get
            {
                if (instance == null)
                    instance = new ExClient();
                return instance;
            }
        }

        private static ExClient instance;

        private WebSocket wsTray;

        public bool IsAlive
        {
            get
            {
                return wsTray != null && wsTray.IsAlive;
            }
        }

        private ExClient()
        {
            Messenger.SetSender(this);
        }

        private void WsTray_OnClose(object sender, CloseEventArgs e)
        {
            //Console.WriteLine("OnClose: " + e.Code);
            LocalMessage.Send(LocalMsg.OnClose);
        }

        private void WsTray_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            //Console.WriteLine("OnError: " + e.Message);
            LocalMessage.Send(LocalMsg.OnError);
        }

        private void WsTray_OnOpen(object sender, EventArgs e)
        {
            //Console.WriteLine("OnOpen");
            LocalMessage.Send(LocalMsg.OnOpen);
        }

        public void Connect()
        {
            string url = "ws://127.0.0.1:10086/api";

            wsTray = new WebSocket(url);
            wsTray.OnOpen += WsTray_OnOpen;
            wsTray.OnError += WsTray_OnError;
            wsTray.OnClose += WsTray_OnClose;

            wsTray.ConnectAsync();
        }
       
        public void Close()
        {
            if (IsAlive)
                wsTray.Close();
        }
        
        public void Send(string message)
        {
            if (!IsAlive)
                return;

            //Console.WriteLine("Send: " + message);
            wsTray.Send(message);
        }
    }
}

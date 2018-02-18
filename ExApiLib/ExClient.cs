using System;
using WebSocketSharp;
using System.Timers;

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
        private Timer timer;
        private int port;

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
            timer = new Timer(3000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!IsAlive)
                Connect();
        }

        private void WsTray_OnClose(object sender, CloseEventArgs e)
        {
            LocalMessage.Send(LocalMsg.OnClose);
        }

        private void WsTray_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            LocalMessage.Send(LocalMsg.OnError);
        }

        private void WsTray_OnOpen(object sender, EventArgs e)
        {
            LocalMessage.Send(LocalMsg.OnOpen);
        }

        private void Connect()
        {
            string url = string.Format("ws://127.0.0.1:{0:D}/api", port);

            wsTray = new WebSocket(url);
            wsTray.OnOpen += WsTray_OnOpen;
            wsTray.OnError += WsTray_OnError;
            wsTray.OnClose += WsTray_OnClose;

            wsTray.Connect();
        }

        public void Start(int port = 10086, bool autoReconnect = true) {
            if(IsAlive)
                return;

            this.port = port;
            if (autoReconnect)
                timer.Start();
            else
                Connect();
        }

        public void Stop() {
            timer.Stop();
            Close();
        }
       
        private void Close()
        {
            if (IsAlive)
                wsTray.Close();
        }
        
        public void Send(string message)
        {
            if (!IsAlive)
                return;

            wsTray.Send(message);
        }
    }
}

using System;
using WebSocketSharp;
using System.Timers;
using System.Collections.Generic;
using System.Text;

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

        public const int defaultPort = 10086;

        public bool IsOpen
        {
            get
            {
                return wsTray != null && wsTray.ReadyState == WebSocketState.Open;
            }
        }

        private static ExClient instance;

        private WebSocket wsTray;
        private Timer timer;
        private int port;
        private string keyValues = "";

        private ExClient()
        {
            Messenger.SetSender(this);
            timer = new Timer(3000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (wsTray == null)
                Connect();
        }

        private void WsTray_OnClose(object sender, CloseEventArgs e)
        {
            Close();
            LocalMessage.Send(LocalMsg.OnClose);
        }

        private void WsTray_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            Close();
            LocalMessage.Send(LocalMsg.OnError);
        }

        private void WsTray_OnOpen(object sender, EventArgs e)
        {
            LocalMessage.Send(LocalMsg.OnOpen);
        }

        private void WsTray_OnMessage(object sender, MessageEventArgs e)
        {
            Messenger.SendUnityMessage(e.Data, true);
        }

        private void Connect()
        {
            string url = string.Format("ws://127.0.0.1:{0}/api{1}", port, keyValues);
            wsTray = new WebSocket(url);
            wsTray.OnOpen += WsTray_OnOpen;
            wsTray.OnError += WsTray_OnError;
            wsTray.OnClose += WsTray_OnClose;
            wsTray.OnMessage += WsTray_OnMessage;

            wsTray.Connect();
        }

        public void Start(int port = defaultPort, bool autoReconnect = true, List<KeyValuePair<string, string>> keyValues = null)
        {
            if (wsTray != null)
                return;

            this.port = port;
            if (keyValues == null || keyValues.Count == 0) {
                this.keyValues = "";
            }
            else
            {
                StringBuilder sb = new StringBuilder("?");
                int len = keyValues.Count;
                for (int i = 0; i < len; i++) {
                    KeyValuePair<string, string> pair = keyValues[i];
                    if (pair.Key.IsNullOrEmpty() || pair.Value.IsNullOrEmpty())
                        continue;

                    sb.Append(pair.Key).Append("=").Append(pair.Value);

                    if (i < len - 1)
                        sb.Append("&");
                }
                this.keyValues = sb.ToString();
            }
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
            if (wsTray != null)
                wsTray.Close();

            wsTray = null;
        }
        
        public void Send(string message)
        {
            if (IsOpen)
                wsTray.Send(message);
        }
    }
}

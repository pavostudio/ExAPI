using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PavoStudio.ExApi
{
    public class Messenger
    {
        public interface Sender
        {
            void Send(string message);
        }

        public delegate void OnMessage(BaseMessage bm);

        private static Messenger instance;

        private Dictionary<int, OnMessage> listeners = new Dictionary<int, OnMessage>();
        private Sender sender;

        public static Messenger Get()
        {
            if (instance == null)
                instance = new Messenger();

            return instance;
        }

        public static void SetSender(Sender sender)
        {
            Get().sender = sender;
        }

        public static void AddListener(int msg, OnMessage onMessage)
        {
            if (!Get().listeners.ContainsKey(msg))
                Get().listeners.Add(msg, null);

            Get().listeners[msg] += onMessage;
        }

        public static void AddListener(OnMessage onMessage, params int[] msgs)
        {
            foreach (int msg in msgs)
            {
                AddListener(msg, onMessage);
            }
        }

        public static void RemoveListener(int msg, OnMessage onMessage)
        {
            if (!Get().listeners.ContainsKey(msg))
                return;

            Get().listeners[msg] -= onMessage;
        }

        public static void RemoveListener(OnMessage onMessage, params int[] msgs)
        {
            foreach (int msg in msgs)
            {
                RemoveListener(msg, onMessage);
            }
        }

        public static void SendUnityMessage(BaseMessage bm, bool sendToLocal = false)
        {
            if (sendToLocal)
                Get().OnMsgReceive(bm);
            else
                SendUnityMessage(JsonConvert.SerializeObject(bm));
        }

        public static void SendUnityMessage(string message, bool sendToLocal = false)
        {
            Messenger messenger = Get();
            if (sendToLocal)
                messenger.OnMsgReceive(message);
            else if (messenger.sender != null)
                messenger.sender.Send(message);
        }

        public void OnMsgReceive(string message)
        {
            //Debug.Log ("Receive: " + message);
            if (string.IsNullOrEmpty(message))
                return;

            JObject obj = JObject.Parse(message);
            if (obj == null)
                return;
            int msg = GetValue<int>(obj["msg"], 0);
            if (msg == 0)
                return;

            OnMsgReceive(new RemoteMessage(msg, GetValue<int>(obj["msgId"], 0), obj["data"]));
        }

        private static T GetValue<T>(JToken token, T defaultValue)
        {
            return token != null ? token.Value<T>() : defaultValue;
        }

        public void OnMsgReceive(BaseMessage bm)
        {
            if (!listeners.ContainsKey(bm.msg))
                return;

            OnMessage om = listeners[bm.msg];
            if (om != null)
                om(bm);
        }

    }
}

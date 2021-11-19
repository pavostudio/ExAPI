using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PavoStudio.ExApi
{
    public class RemoteMessage : BaseMessage
    {
        private JToken token;

        public RemoteMessage(int msg, int msgId, JToken token) : base(msg, msgId)
        {
            this.token = token;
        }

        public override T GetData<T>()
        {
            try
            {
                return token != null ? token.ToObject<T>() : default(T);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public void Send()
        {
            JObject obj = new JObject();
            obj.Add("msg", JToken.FromObject(msg));
            obj.Add("msgId", JToken.FromObject(msgId));
            if (token != null)
                obj.Add("data", token);
            Messenger.SendUnityMessage(obj.ToString());
        }

        public static void Send(int msg, int msgId, object data = null)
        {
            new RemoteMessage(msg, msgId, data == null ? null : JToken.FromObject(data)).Send();
        }

    }
}


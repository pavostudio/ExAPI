using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PavoStudio.ExApi
{
    public class RemoteMessage : BaseMessage
    {
        private JToken token;

        public RemoteMessage(int msg, JToken token) : base(msg)
        {
            this.token = token;
        }

        public override T GetData<T>()
        {
            return token != null ? token.Value<T>() : default(T);
        }

        public void Send()
        {
            JObject obj = new JObject();
            obj.Add("msg", JToken.FromObject(msg));
            if (token != null)
                obj.Add("data", token);
            Messenger.SendUnityMessage(obj.ToString());
        }

        public static void Send(int msg, object data = null)
        {
            new RemoteMessage(msg, data == null ? null : JToken.FromObject(data)).Send();
        }

    }
}


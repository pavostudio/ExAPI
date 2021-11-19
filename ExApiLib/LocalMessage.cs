using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PavoStudio.ExApi
{
    public class LocalMessage : BaseMessage
    {
        public object data;

        public LocalMessage(int msg, object data) : base(msg, 0)
        {
            this.data = data;
        }

        public override T GetData<T>()
        {
            try
            {
                return data == null ? default(T) : (T)data;
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public static void Send(int msg, object data = null)
        {
            Messenger.SendUnityMessage(new LocalMessage(msg, data), true);
        }
    }
}


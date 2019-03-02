using System;

namespace PavoStudio.ExApi
{
    public abstract class BaseMessage
    {
        public int msg;

        public int IntValue
        {
            get
            {
                return GetData<int>();
            }
        }

        public float FloatValue
        {
            get
            {
                return GetData<float>();
            }
        }

        public bool BoolValue
        {
            get
            {
                return GetData<bool>();
            }
        }

        public string StringValue
        {
            get
            {
                return GetData<string>();
            }
        }

        public BaseMessage(int msg)
        {
            this.msg = msg;
        }

        public abstract T GetData<T>();
    }
}

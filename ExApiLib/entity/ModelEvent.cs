using System;

namespace PavoStudio.ExApi
{
    [Serializable]
    public class ModelEvent
    {
        public class Type
        {
            public const int Tap = 0;
        }

        // event type
        public int type;
        // slot
        public int id;
        public string modelId;
        public string hitArea;

        public override string ToString()
        {
            return string.Format("type: {0}, id: {1}, modelId: {2}, hitArea: {3}", type, id, modelId, hitArea);
        }
    }


}

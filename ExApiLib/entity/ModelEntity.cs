using System;

namespace PavoStudio.ExApi
{
    [Serializable]
    public class ModelEntity
    {
        public int id;// index of model
        public string file;// model.json file path
        public string mtn;// motion to start, 'group:motion'
        public int expId;// index of expression
        public int type;
        public int layer;
        public int posX;
        public int posY;
    }
}

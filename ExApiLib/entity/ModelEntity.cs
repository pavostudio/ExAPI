using System;

namespace PavoStudio.ExApi
{
    [Serializable]
    public class ModelEntity
    {
        public int id;// index of model
        public string file;// model.json file path
        public int expId;// index of expression
        public int type;
        // type=0: 'group:motion'
        // type=1: absolute path of motion file
        public string mtn;
        public int layer;
        public int posX;
        public int posY;
    }
}

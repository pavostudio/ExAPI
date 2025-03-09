using System;

namespace PavoStudio.ExApi
{
    [Serializable]
    public class SoundEntity
    {
        public int id;// index of model
        public int channel;
        public float volume = 1;
        public int delay;
        public bool loop;
        public int type;

        // type=0: file path (mp3/ogg/wav)
        // type=1: base64 string of binary data
        public string sound;
    }
}

using System;
using System.Collections.Generic;

namespace PavoStudio.ExApi
{
    [Serializable]
    public class TextBubbleEntity
    {
        public int id;
        public string text;
        public string[] choices;
        public int bubbleColor = -1;
        public int textColor = -1;
        public int duration;
        public int textWidth;
    }
}


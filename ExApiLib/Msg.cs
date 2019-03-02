using System;

namespace PavoStudio.ExApi
{
    public class Msg
    {
        public const int RegisterModelEventListener = 10000;
        public const int UnregisterModelEventListener = 10001;
        public const int OnModelEvent = 10002;
        public const int ShowTextBubble = 11000;
        public const int SetBackground = 12000;
        public const int Set360Background = 12100;
        public const int SetModel = 13000;
        public const int RemoveModel = 13100;
        public const int StartMotion = 13200;
        public const int SetExpression = 13300;
        public const int NextExpression = 13301;
        public const int ClearExpression = 13302;
        public const int SetPosition = 13400;
        public const int SetEffect = 14000;
        public const int AddEffect = 14100;
        public const int RemoveEffect = 14200;
        public const int SyncResourceMonitor = 20000;
    }

    public class LocalMsg {
        public const int OnOpen = 0;
        public const int OnClose = 1;
        public const int OnError = 2;
    }
}


using System;

namespace PavoStudio.ExApi
{
    [Serializable]
    public class ResourceMonitorEntity
    {
        public Hardware[] hardware;

        public class HardwareType
        {
            public const int CPU = 0;
            public const int RAM = 1;
            public const int GPU = 2;
            public const int HDD = 3;
        }

        [Serializable]
        public class Hardware
        {
            public string name;
            public int type;
            public Sensor[] sensors;
        }

        public class SensorType
        {
            public const int Load = 0;
            public const int Temperature = 1;
            public const int Data = 2;
            public const int Fan = 3;
        }

        [Serializable]
        public class Sensor
        {
            public string name;
            public int type;
            public float value;
        }
    }
}

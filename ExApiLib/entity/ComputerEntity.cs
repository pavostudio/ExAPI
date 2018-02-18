using System;

[Serializable]
public class ComputerEntity
{
	public Hardware[] hardware;

	public class HardwareType
	{
		public const int CPU = 0;
		public const int RAM = 1;
		public const int GPU = 2;
		public const int HDD = 3;
		public const int NIC = 4;
	}

    public class CpuType
    {
        public const int Unknown = -1;
        public const int Intel = 0;
        public const int Amd = 1;
    }

    public class GpuType
    {
        public const int Unknown = -1;
        public const int Nivida = 0;
        public const int Ati = 1;
    }

    public class NicType
    {
        public const int Unknown = -1;
        public const int Ethernet = 0;
        public const int Wireless = 1;
    }

    [Serializable]
	public class Hardware
	{
		public string name;
		public int type;
        public int subType = -1;
		public Sensor[] sensors;
	}

	public class SensorType
	{
		public const int Load = 0;//%
		public const int Temperature = 1;//°C
		public const int Data = 2;//GB
		public const int SmallData = 3;//MB
		public const int NetUpSpeed = 4;//B/s
        public const int NetDownSpeed = 5;//B/s
    }

	[Serializable]
	public class Sensor
	{
		public string name;
		public int type;
		public float value;
	}
}


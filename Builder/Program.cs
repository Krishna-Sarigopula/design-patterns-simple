using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ISystemBuilder systemBuilder = new DesktopConcreteBuilder();
            systemBuilder.SetDisplay("LCD")
            .SetHardDisk("1TB")
            .SetRAM("8GB");
            Console.WriteLine(systemBuilder.GetSystemDetails());

            systemBuilder = new LaptopConcreteBuilder();
            systemBuilder.SetDisplay("LED")
            .SetHardDisk("512TB")
            .SetRAM("16GB");
            Console.WriteLine(systemBuilder.GetSystemDetails());
        }
    }

    class System
    {
        public string Type { get; set; }
        public string Display { get; set; }
        public string HardDisk { get; set; }
        public string RAM { get; set; }
    }

    public interface ISystemBuilder
    {
        ISystemBuilder SetDisplay(string display);
        ISystemBuilder SetHardDisk(string hardisk);
        ISystemBuilder SetRAM(string RAM);
        string GetSystemDetails();
    }

    public class DesktopConcreteBuilder : ISystemBuilder
    {
        private System system = new System();

        public DesktopConcreteBuilder()
        {
            system.Type = "Desktop";
        }

        public string GetSystemDetails()
        {
            return string.Format("{0}, {1}, {2}, {3}", system.Type, system.Display, system.HardDisk, system.RAM);
        }

        public ISystemBuilder SetDisplay(string display)
        {
            system.Display = display;
            return this;
        }

        public ISystemBuilder SetHardDisk(string hardisk)
        {
            system.HardDisk = hardisk;
            return this;
        }

        public ISystemBuilder SetRAM(string RAM)
        {
            system.RAM = RAM;
            return this;
        }
    }

    public class LaptopConcreteBuilder : ISystemBuilder
    {
        private System system = new System();

        public LaptopConcreteBuilder()
        {
            system.Type = "Laptop";
        }

        public string GetSystemDetails()
        {
            return string.Format("{0}, {1}, {2}, {3}", system.Type, system.Display, system.HardDisk, system.RAM);
        }

        public ISystemBuilder SetDisplay(string display)
        {
            system.Display = display;
            return this;
        }

        public ISystemBuilder SetHardDisk(string hardisk)
        {
            system.HardDisk = hardisk;
            return this;
        }

        public ISystemBuilder SetRAM(string RAM)
        {
            system.RAM = RAM;
            return this;
        }
    }


}

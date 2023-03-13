namespace ToolsAndDetailsServer
{
    public class Detail
    {
        public string Name { get; set; }
        public string Description { get; set; } = null;
        public int SerialNumber { get; set; }
        public int Year { get; set; }

        public Detail(string name, int serialNumber, int year, string description = null)
        {
            Name = name;
            Description = description;
            SerialNumber = serialNumber;
            Year = year;
        }

        public override string ToString()
        {
            if (Description == null)
                return $"{Name} {SerialNumber} ({Year})";
            return $"{Name} {SerialNumber} ({Year}) \nDescription: {Description}";
        }
    }
}

namespace ToolsAndDetailsServer
{
    public class Tool
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; } = null;
        public int Year { get; set; }

        public Tool(string name, string type, int year, string description = null)
        {
            Name = name;
            Type = type;
            Description = description;
            Year = year;
        }

        public override string ToString()
        {
            if (Description == null)
                return $"{Name} {Type} ({Year})";
            return $"{Name} {Type} ({Year}) \nDescription: {Description}";
        }
    }
}

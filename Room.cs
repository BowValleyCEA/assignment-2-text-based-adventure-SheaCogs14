namespace game1402_a2_starter
{
    [Serializable]
    public class Room
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Connections { get; set; } = new Dictionary<string, string>();
        public List<Item> items { get; set; } = new List<Item>(); 
    }
}

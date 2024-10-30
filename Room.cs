using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1402_a2_starter
{


    [Serializable]
    public class Room
    {
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> Connections { get; set; } = new Dictionary<string, string>();
        public List<GameObjects> Objects { get; set; } = new List<GameObjects>();

        public Room() { }

        


    }

}

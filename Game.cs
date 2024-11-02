
namespace game1402_a2_starter
{
    public class GameData
    {
        public string GameName { get; set; }
        public string Description { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();

    }

    public class Game
    {
        private GameData _gameData;
        public Room _currentRoom;
        private List<Item> _inventory = new List<Item>();

        bool gameWon = false;

        public Game(GameData data)
        {
            _gameData = data;
            _currentRoom = _gameData.Rooms[0];
        }


        public void Start()
        {
            Console.WriteLine($"Welcome to {_gameData.GameName}");
            Console.WriteLine(_gameData.Description);
            UpdateGame();

        }

        private void UpdateGame()
        {
            string command;

            do
            {
                displayRoomInfo();
                Console.Write("What do you want to do? ");
                command = Console.ReadLine();
                commandParse(command);

                if (gameWon)
                {

                    Console.WriteLine("You took the last escape pod! you will finally be able to return to earth!");
                    Console.WriteLine("Thank you for playing!");
                    break;

                }
            } while (command != "quit");
        }

        public void commandParse(string command)
        {
            command = command.Trim().ToLower();
            string[] cmds = command.Split(" ");

            switch (cmds.Length)
            {
                case 1:
                    handleSingleCmd(cmds[0]);
                    break;
                case 2:
                    handleTwoCmd(cmds[0], cmds[1]);
                    break;
                case 3:
                    handleThreeCmd(cmds[0], cmds[1], cmds[2]);
                    break;
                case 4:
                    handleFourthCmd(cmds[0], cmds[1], cmds[2], cmds[3]);
                    break;

            }
        }


        private void handleSingleCmd(string cmds)
        {
            if (cmds == "look")
            {
                Console.Clear();
                Console.WriteLine(_currentRoom.Description);
            }
            else if (cmds == "inventory")
            {
                if (_inventory.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Inventory: {string.Join(",", _inventory.Select(item => item.Name))}");
                }
                else
                {
                    Console.WriteLine("Your inventory is empty!s");
                }
            }

            else if (cmds == "sreach")
            {
                Console.WriteLine("You sreached the room and found");
                foreach (var item in _currentRoom.items)
                {
                    Console.WriteLine(item.Name + item.Description);
                }

            }
            else
            {
                Console.WriteLine("Invaild command");
            }

        }
        private void handleTwoCmd(string cmds1, string cmds2)
        {
            if (cmds1 == "go")
            {
                moveToRoom(cmds2);
            }
            else if (cmds1 == "take")
            {
                grabItem(cmds2);
            }
            else
            {
                Console.WriteLine("Invaild command");
            }
        }

        private void handleThreeCmd(string cmds1, string cmds2, string cmds3)
        {
            if (cmds1 == "examine" && cmds2 == "item" && cmds3 == "closely")
            {
                examObj();
            }
            else
            {
                Console.WriteLine("Invaild command");
            }

        }


        private void handleFourthCmd(string cmds1, string cmds2, string cmds3, string cmds4)
        {
            if (cmds1 == "use")
            {

                useItem(cmds2, cmds4);
            }
            else
            {
                Console.WriteLine("Invaild command");
            }
        }


        private void moveToRoom(string direction)
        {
            if (_currentRoom.Connections.TryGetValue(direction, out string nextRoomReference))
            {
                _currentRoom = _gameData.Rooms.FirstOrDefault(r => r.Reference == nextRoomReference);
                if (_currentRoom != null)
                {
                    Console.Clear();
                    Console.WriteLine($"You have moved to {_currentRoom.Name}.");
                }
                else
                {
                    Console.WriteLine("You cant go that way.");

                }
            }
            else
            {
                Console.WriteLine("You cant go that way.");

            }
        }


        private void grabItem(string itemName)
        {
            foreach (Item item in _currentRoom.items)
            {
                if (item.Name == itemName)
                {
                    _inventory.Add(item);
                    _currentRoom.items.Remove(item);
                    Console.WriteLine($"You took the {itemName}.");
                    return;
                }
            }
            Console.WriteLine($"{itemName} does not exist.");

        }
        private void useItem(string itemName, string targetObj)
        {
            var item = _inventory.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                Console.WriteLine($"You dont have that item {itemName}");
                return;
            }

            if (item.Name.Equals("keycard", StringComparison.OrdinalIgnoreCase) && targetObj.Equals("door", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("You swiped the key card, the espace lights up and opens");

                gameWon = true;
            }

        }


        private void displayRoomInfo()
        {
            Console.WriteLine($"\nYou are in {_currentRoom.Name}. {_currentRoom.Description}");

            if (_currentRoom.Connections.Count > 0)
            {
                Console.WriteLine("Connected rooms :");
                foreach (var direction in _currentRoom.Connections.Keys)
                {
                    Console.WriteLine(direction);
                }

            }
        }

        private void examObj()
        {
            var keycard = _inventory.FirstOrDefault(i => i.Name.Equals("Keycard", StringComparison.OrdinalIgnoreCase));

            if (keycard != null)
            {
                Console.Clear();
                Console.WriteLine("You looked at the keycard closey");
                Console.WriteLine(keycard.Description);
            }
        }

    }

}

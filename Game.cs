using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
        private Room _currentRoom;
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
                Console.Clear();
                Console.WriteLine($"\nYou are in {_currentRoom.Name}. {_currentRoom.Description}");
                Console.Write("What do you want to do? ");
                command = Console.ReadLine();
                commandParse(command);
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
                    handleFourthCmd(cmds[0], cmds[1], cmds[3], cmds[4]);
                    break;

            }
        }


        private void handleSingleCmd(string cmds)
        {
            if (cmds == "look")
            {
                Console.WriteLine(_currentRoom.Description);
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
            else
            {
                Console.WriteLine("Invaild command");
            }
        }

        private void handleThreeCmd(string cmds1, string cmds2, string cmds3)
        {
            if (cmds1 == "take")
            {
                Console.WriteLine("cmd4");
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

                Console.WriteLine("cmd4");
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
                    Console.WriteLine($"You have moved to {_currentRoom.Name}.");
                }
                else
                {
                    Console.WriteLine("You cant go that way.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("You cant go that way.");
                Console.ReadLine();
            }
        }

    }

}

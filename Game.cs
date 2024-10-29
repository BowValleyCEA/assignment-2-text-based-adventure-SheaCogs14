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
                Console.WriteLine($"\nYou are in {_currentRoom.Name}. {_currentRoom.Description}");
                Console.Write("What do you want to do? ");
                command = Console.ReadLine();
                commandParse(command);
            }while (command != "quit");
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
    }

}

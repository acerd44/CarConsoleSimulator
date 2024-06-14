using CarConsoleSimulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleSimulator
{
    public class App
    {
        private readonly ISimulator _simulator;
        public ConsoleColor DefaultColor { get; set; }
        public App(ISimulator simulator)
        {
            _simulator = simulator;
            DefaultColor = ConsoleColor.White;
            Console.ForegroundColor = DefaultColor;
        }

        public void Run()
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine($"Hello {_simulator.Driver.Title} {_simulator.Driver.FirstName} {_simulator.Driver.LastName}\n");
                Console.WriteLine($"The car's direction: {_simulator.Direction}");
                WriteColoredStatus("Fuel");
                WriteColoredStatus("Fatigue");
                Console.WriteLine($"Last action: {_simulator.Status}\n");
                WriteColoredStatus("Warning");
                Console.WriteLine("\n1. Turn left");
                Console.WriteLine("2. Turn right");
                Console.WriteLine("3. Go forward");
                Console.WriteLine("4. Back up");
                Console.WriteLine("5. Rest");
                Console.WriteLine("6. Fuel car");
                Console.WriteLine("7. Exit");
                Console.Write("What would you like to do? ");
                string? option = Console.ReadLine();
                while (string.IsNullOrEmpty(option) || !(int.TryParse(option, out int optionInt) && optionInt >= 1 && optionInt <= 7))
                {
                    option = Console.ReadLine();
                }
                switch (option)
                {
                    case "1":
                        _simulator.TurnLeft();
                        break;
                    case "2":
                        _simulator.TurnRight();
                        break;
                    case "3":
                        _simulator.Move("Going forward");
                        break;
                    case "4":
                        _simulator.Move("Backing up");
                        break;
                    case "5":
                        _simulator.Rest();
                        break;
                    case "6":
                        _simulator.Refuel();
                        break;
                    case "7":
                        showMenu = false;
                        break;
                }
            }
        }

        public void WriteColoredStatus(string status)
        {
            if (status.Equals("Fuel"))
            {
                Console.Write("Fuel: ");
                if (_simulator.Fuel == 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (_simulator.Fuel > 0 && _simulator.Fuel <= 8)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{_simulator.Fuel}/{_simulator.MaxFuel}");
                Console.ForegroundColor = DefaultColor;
            }
            if (status.Equals("Fatigue"))
            {
                Console.Write("Fatigue: ");
                if (_simulator.Fatigue >= 0 && _simulator.Fatigue <= 3)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (_simulator.Fatigue > 3 && _simulator.Fatigue < 7)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (_simulator.Fatigue >= 7)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{_simulator.Fatigue}/{_simulator.MaxFatigue}");
                Console.ForegroundColor = DefaultColor;
            }
            if (status.Equals("Warning"))
            {
                if (_simulator.Fatigue >= 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WARNING! You are too fatigued to continue driving! Please rest up now.");
                    Console.ForegroundColor = DefaultColor;
                }
                if (_simulator.Fatigue > 3 && _simulator.Fatigue < 7)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You're getting a bit fatigued, consider taking a break soon.");
                    Console.ForegroundColor = DefaultColor;
                }
                if (_simulator.Fuel == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WARNING! Your vehicle needs refueling!");
                    Console.ForegroundColor = DefaultColor;
                }
                if (_simulator.Fuel > 0 && _simulator.Fuel <= 8)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You're starting to run low on fuel, consider a visit to the gas station.");
                    Console.ForegroundColor = DefaultColor;
                }
            }
        }
    }
}

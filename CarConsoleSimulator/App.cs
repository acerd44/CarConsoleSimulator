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
                var option = Console.ReadKey(true);
                switch (option.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        _simulator.TurnLeft();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        _simulator.TurnRight();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        _simulator.Move("Going forward");
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        _simulator.Move("Backing up");
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        _simulator.Rest();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        _simulator.Refuel();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        showMenu = false;
                        break;
                    default:
                        continue;
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

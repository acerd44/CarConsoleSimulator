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
        private readonly Menu _menu;
        public App(ISimulator simulator, Menu menu)
        {
            _simulator = simulator;
            Console.ForegroundColor = ConsoleColor.White;
            _menu = menu;
        }
        public void Run()
        {
            _menu.DisplayMenu();
        }
    }
}

using CarConsoleSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleSimulator.Services
{
    public interface ISimulator
    {
        public int MaxFuel { get; set; }
        public int MaxFatigue { get; set; }
        public int FatigueLimit { get; set; }
        public Person Driver { get; set; }
        public string Status { get; set; }
        public int Fatigue { get; set; }
        public int Hunger { get; set; }
        public int Fuel { get; set; }
        public Direction Direction { get; set; }
        public bool Move(string status);
        public bool TurnLeft();
        public bool TurnRight();
        public void Refuel();
        public void Rest();

    }
}

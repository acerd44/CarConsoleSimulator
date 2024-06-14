using CarConsoleSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleSimulator.Services
{
    public interface IHungerService
    {
        public void Increase();
        public int HungerLevel { get; set; }
        public Hunger GetHungerState();
        public void Eat();
    }
}

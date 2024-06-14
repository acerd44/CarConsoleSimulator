using CarConsoleSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleSimulator.Services
{
    public class Simulator : ISimulator
    {
        private readonly IPersonService? _personService;
        public int MaxFuel { get; set; }
        public int MaxFatigue { get; set; }
        public int FatigueLimit { get; set; }
        public Person Driver { get; set; }
        public string Status { get; set; }
        public int Fatigue { get; set; }
        public int Hunger { get; set; }
        public int Fuel { get; set; }
        public Direction Direction { get; set; }
        public Simulator(IPersonService personService) : this()
        {
            _personService = personService;
            Driver = _personService.Get();
            //MaxFuel = 15;
            //MaxFatigue = 10;
            //FatigueLimit = 7;
            //Fatigue = 0;
            //Hunger = 0;
            //Fuel = 15;
            //Direction = Direction.North;
            //Status = "Starting";
        }
        public Simulator()
        {
            Setup();
            Driver = new Person { Title = "Mr", FirstName = "Hossén", LastName = "Rahimzadegan" };
        }

        private void Setup()
        {
            MaxFuel = 15;
            MaxFatigue = 10;
            FatigueLimit = 7;
            Fatigue = 0;
            Hunger = 0;
            Fuel = 15;
            Direction = Direction.North;
            Status = "Starting";
        }

        public bool Move(string status)
        {
            if (Fatigue < FatigueLimit && Fuel > 0)
            {
                Fatigue++;
                Fuel--;
                Status = status;
                return true;
            }
            return false;
        }

        public bool TurnLeft()
        {
            if (Fatigue < FatigueLimit && Fuel > 0)
            {
                switch (Direction)
                {
                    case Direction.North:
                        Direction = Direction.West;
                        break;
                    case Direction.West:
                        Direction = Direction.South;
                        break;
                    case Direction.South:
                        Direction = Direction.East;
                        break;
                    case Direction.East:
                        Direction = Direction.North;
                        break;
                }
            }
            return Move("Turning left");
        }

        public bool TurnRight()
        {
            if (Fatigue < FatigueLimit && Fuel > 0)
            {
                switch (Direction)
                {
                    case Direction.North:
                        Direction = Direction.East;
                        break;
                    case Direction.East:
                        Direction = Direction.South;
                        break;
                    case Direction.South:
                        Direction = Direction.West;
                        break;
                    case Direction.West:
                        Direction = Direction.North;
                        break;
                }
            }
            return Move("Turning right");
        }

        public void Refuel()
        {
            if (Fuel == MaxFuel) return;
            Fuel = MaxFuel;
            Fatigue++;
            Status = "Refueling";
        }

        public void Rest()
        {
            if (Fatigue == 0) return;
            Fatigue = 0;
            Status = "Resting up";
        }
    }
}

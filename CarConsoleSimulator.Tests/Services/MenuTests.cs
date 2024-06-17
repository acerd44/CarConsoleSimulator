using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConsoleSimulator.Services;
using Moq;

namespace CarConsoleSimulator.Tests.Services
{
    [TestClass]
    public class MenuTests
    {
        private readonly Mock<ISimulator> _mockSimulator;
        private readonly Menu _menu;
        public MenuTests()
        {
            _mockSimulator = new();
            _menu = new Menu(_mockSimulator.Object);
        }
        [TestMethod]
        public void Handle_Input_NumPad_1_Turn_Left()
        {
            var key = ConsoleKey.NumPad1;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.TurnLeft(), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_1_Turn_Left()
        {
            var key = ConsoleKey.D1;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.TurnLeft(), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_NumPad_2_Turn_Right()
        {
            var key = ConsoleKey.NumPad2;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.TurnRight(), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_2_Turn_Right()
        {
            var key = ConsoleKey.D2;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.TurnRight(), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_NumPad_3_Move()
        {
            var key = ConsoleKey.NumPad3;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.Move("Going forward"), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_3_Move()
        {
            var key = ConsoleKey.D3;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.Move("Going forward"), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_NumPad_4_Move()
        {
            var key = ConsoleKey.NumPad4;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.Move("Backing up"), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_4_Move()
        {
            var key = ConsoleKey.D4;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.Move("Backing up"), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_NumPad_5_Rest()
        {
            var key = ConsoleKey.NumPad5;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.Rest(), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_5_Rest()
        {
            var key = ConsoleKey.D5;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.Rest(), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_NumPad_6_Refuel()
        {
            var key = ConsoleKey.NumPad6;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.Refuel(), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_6_Refuel()
        {
            var key = ConsoleKey.D6;

            _menu.HandleInput(key);

            _mockSimulator.Verify(s => s.Refuel(), Times.Once);
        }
        [TestMethod]
        public void Handle_Input_NumPad_7_Exit()
        {
            var key = ConsoleKey.NumPad7;

            _menu.HandleInput(key);

            Assert.IsFalse(_menu.ShowMenu);
        }
        [TestMethod]
        public void Handle_Input_7_Exit()
        {
            var key = ConsoleKey.D7;

            _menu.HandleInput(key);

            Assert.IsFalse(_menu.ShowMenu);
        }

    }
}

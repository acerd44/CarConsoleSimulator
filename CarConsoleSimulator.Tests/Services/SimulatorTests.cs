using CarConsoleSimulator.Models;
using CarConsoleSimulator.Services;
using Moq;

namespace CarConsoleSimulator.Tests.Services
{
    [TestClass]
    public class SimulatorTests
    {
        private readonly Simulator _sut;
        public SimulatorTests()
        {
            _sut = new();
        }
        [TestMethod]
        public void Default_Driver_Is_Not_Null()
        {
            Assert.IsNotNull(_sut.Driver);
        }
        [TestMethod]
        public void Move_Returns_True()
        {
            var result = _sut.Move("");

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Move_Returns_False_When_Fatigued()
        {
            _sut.Fatigue = 10;

            var result = _sut.Move("");

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Move_Returns_False_When_Out_Of_Fuel()
        {
            _sut.Fuel = 0;

            var result = _sut.Move("");

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Move_Changes_Status()
        {
            var expected = "Hello";

            _sut.Move(expected);

            var result = _sut.Status;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Turn_Right_Returns_True()
        {
            var result = _sut.TurnRight();

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Turn_Right_Changes_Direction()
        {
            var expected = Direction.East;

            _sut.TurnRight();
            var result = _sut.Direction;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Turn_Left_Returns_True()
        {
            var result = _sut.TurnLeft();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Turn_Left_Changes_Direction()
        {
            var expected = Direction.West;

            _sut.TurnLeft();
            var result = _sut.Direction;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Refuel_Sets_Fuel_To_15()
        {
            _sut.Fuel = 0;
            var expectedFuel = 15;
            var expectedFatigue = 1;

            _sut.Refuel();

            var resultFuel = _sut.Fuel;
            var resultFatigue = _sut.Fatigue;

            Assert.AreEqual(expectedFuel, resultFuel);
            Assert.AreEqual(expectedFatigue, resultFatigue);
        }
        [TestMethod]
        public void Refuel_Doesnt_Change_Status_If_Full_Fuel()
        {
            _sut.Fuel = 15;
            var expected = _sut.Status;

            _sut.Refuel();
            var result = _sut.Status;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Rest_Sets_Fatigue_To_0()
        {
            _sut.Fatigue = 5;
            var expected = 0;

            _sut.Rest();
            var result = _sut.Fatigue;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Rest_Doesnt_Change_Status_If_0_Fatigue()
        {
            _sut.Fatigue = 0;
            var expected = _sut.Status;

            _sut.Rest();
            var result = _sut.Status;

            Assert.AreEqual(expected, result);
        }
    }
}
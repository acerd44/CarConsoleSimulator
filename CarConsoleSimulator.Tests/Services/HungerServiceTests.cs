using CarConsoleSimulator.Models;
using CarConsoleSimulator.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleSimulator.Tests.Services
{
    [TestClass]
    public class HungerServiceTests
    {
        private readonly Simulator _sut;
        private readonly Mock<IHungerService> _mockHungerService;
        public HungerServiceTests()
        {
            _mockHungerService = new();
            _mockHungerService.Setup(h => h.HungerLevel).Returns(0);
            _mockHungerService.Setup(h => h.Increase()).Callback(() => _mockHungerService.SetupGet(h => h.HungerLevel).Returns(_mockHungerService.Object.HungerLevel + 2));
            _mockHungerService.Setup(h => h.Eat()).Callback(() => _mockHungerService.SetupGet(h => h.HungerLevel).Returns(0));
            _mockHungerService.Setup(h => h.GetHungerState()).Returns(() =>
            {
                var hungerLevel = _mockHungerService.Object.HungerLevel;
                if (hungerLevel >= 0 && hungerLevel <= 5)
                {
                    return Hunger.Full;
                }
                else if (hungerLevel >= 6 && hungerLevel <= 10)
                {
                    return Hunger.Hungry;
                }
                else if (hungerLevel >= 11)
                {
                    return Hunger.Starving;
                }
                return Hunger.Full;
            });
            _sut = new(_mockHungerService.Object);
        }

        [TestMethod]
        public void Move_Increases_Hunger()
        {
            var expected = 2;

            _sut.Move("");

            Assert.AreEqual(expected, _mockHungerService.Object.HungerLevel);
        }
        [TestMethod]
        public void Eat_Resets_Hunger_Level()
        {
            var expected = 0;
            _mockHungerService.Setup(h => h.HungerLevel).Returns(7);

            _mockHungerService.Object.Eat();

            Assert.AreEqual(expected, _mockHungerService.Object.HungerLevel);
        }
        [TestMethod]
        public void Get_Hunger_State_Returns_Full()
        {
            var expected = Hunger.Full;
            _mockHungerService.Setup(h => h.HungerLevel).Returns(0);

            var result = _mockHungerService.Object.GetHungerState();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Get_Hunger_State_Returns_Hungry()
        {
            var expected = Hunger.Hungry;
            _mockHungerService.Setup(h => h.HungerLevel).Returns(7);

            var result = _mockHungerService.Object.GetHungerState();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Get_Hunger_State_Returns_Starving()
        {
            var expected = Hunger.Starving;
            _mockHungerService.Setup(h => h.HungerLevel).Returns(12);

            var result = _mockHungerService.Object.GetHungerState();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Move_Returns_False_When_16_Hunger()
        {
            _mockHungerService.Setup(h => h.HungerLevel).Returns(16);

            var result = _sut.Move("");

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Refuel_Doesnt_Work_When_16_Hunger()
        {
            var expected = 5;
            _mockHungerService.Setup(h => h.HungerLevel).Returns(16);
            _sut.Fuel = 5;

            _sut.Refuel();

            Assert.AreEqual(expected, _sut.Fuel);
        }
        [TestMethod]
        public void Rest_Doesnt_Work_When_16_Hunger()
        {
            var expected = 5;
            _mockHungerService.Setup(h => h.HungerLevel).Returns(16);
            _sut.Fatigue = 5;

            _sut.Rest();

            Assert.AreEqual(expected, _sut.Fatigue);
        }

    }
}

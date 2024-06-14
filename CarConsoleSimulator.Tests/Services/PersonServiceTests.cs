using CarConsoleSimulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleSimulator.Tests.Services
{
    [TestClass]
    public class PersonServiceTests
    {
        private readonly PersonService _sut;
        public PersonServiceTests()
        {
            _sut = new();
        }
        [TestMethod]
        public void Get_ReturnsValidRandomPerson()
        {
            var person = _sut.Get();

            Assert.IsNotNull(person);
            Assert.IsFalse(string.IsNullOrEmpty(person.Title));
            Assert.IsFalse(string.IsNullOrEmpty(person.FirstName));
            Assert.IsFalse(string.IsNullOrEmpty(person.LastName));
        }
    }
}

using CarConsoleSimulator.Services;

namespace CarConsoleSimulator.NUnitTests.Services
{
    public class PersonServiceNUnitTests
    {
        private PersonService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new();
        }

        [Test]
        public void Get_ReturnsValidRandomPerson_NUnit()
        {
            var person = _sut.Get();

            Assert.Multiple(() =>
            {
                Assert.That(person, Is.Not.Null);
                Assert.That(string.IsNullOrEmpty(person.Title), Is.False);
                Assert.That(string.IsNullOrEmpty(person.FirstName), Is.False);
                Assert.That(string.IsNullOrEmpty(person.LastName), Is.False);
            });
        }
    }
}
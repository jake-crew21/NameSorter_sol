using NUnit.Framework;

namespace NameSorter.nUnitTests
{
    public class NameSorterTests
    {
        private Person _person { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            _person = new Person();
        }

        [TestCase("Adonis Julius")]
        [TestCase("Vaughn")]
        [TestCase("Hunter Uriah Mathew")]
        [TestCase("Frankie Conner Ritter")]
        [TestCase("Leo Gardner")]
        public void FirstNameLimit_IsTrueTest(string firstName)
        {
            // Assign
            // Value in above TestCase

            // Act
            var nameLimit = _person.FirstNameLimit(firstName);

            // Assert
            Assert.IsTrue(nameLimit);
        }

        [TestCase("Hunter Uriah Mathew Clarke")]
        [TestCase("Janet Parsons Adonis Julius Archer")]
        [TestCase("Shelby Nathan Yoder Beau Tristan Bentley")]
        [TestCase("Leo Gardner Mikayla Lopez Frankie Conner Ritter")]
        [TestCase("Vaughn Lewis Marin Alvarez")]
        public void FirstNameLimit_IsFalseTest(string firstName)
        {
            // Assign
            // Value in above TestCase

            // Act
            var nameLimit = _person.FirstNameLimit(firstName);

            // Assert
            Assert.IsFalse(nameLimit);
        }
    }
}
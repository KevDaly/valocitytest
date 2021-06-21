using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CodingAssessment.Refactor;
using Cards;

namespace Tests
{
    // I haven't used XUnit in a while and didn't want to waste time looking up syntax
    // so these tests are written in a style I call "Stupid".
    public class UnitTest1
    {
        private List<Person> GetPeople(int numPeople)
        {
            var birthingUnit = new BirthingUnit();
            var people = birthingUnit.GetPeople(numPeople);
            return people; // I could've just returned the function result but the assignment makes debugging easier
        }
        private IEnumerable<Person> GetSomeBobs(bool olderThan30)
        {
            var birthingUnit = new BirthingUnit();
            var people = birthingUnit.GetPeople(1000);
            var bobs = birthingUnit.GetBobs(olderThan30);
            return bobs;
        }
        [Fact]
        public void PeopleShouldBeCreated()
        {
            var people = GetPeople(25);
            people.Count.Should().Be(25);
            
        }
        [Fact]
        public void BobsShouldBeBob()
        {
            var bobs = GetSomeBobs(false);
            
            bobs.Count(p => p.Name == "Betty").Should().Be(0);
        }
        [Fact]
        public void BobsOver30ShouldBeOver30()
        {
            var bobs = GetSomeBobs(true);
            var todayMinusThirty = DateTime.UtcNow.AddYears(-30);
            var areThereYoungBobs = bobs.Any(b => b.DOB > todayMinusThirty);
            areThereYoungBobs.Should().BeFalse();

        }
        [Fact]
        public void ShouldBe52Cards()
        {
            var deck = new Deck();
            deck.Cards.Count.Should().Be(52);
            
        }
    }
}

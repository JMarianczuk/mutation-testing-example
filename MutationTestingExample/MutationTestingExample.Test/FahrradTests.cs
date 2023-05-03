using FluentAssertions;
using UnitsNet;

namespace MutationTestingExample.Test
{
    public class FahrradTests
    {
        private IFahrrad Setup(Speed? geschwindigkeitProGang = null, Length? gestellH�he = null,
            Length? lenkerH�he = null, Length? maximaleSattelH�he = null, int anzahlG�nge = 7)
        {
            return new Fahrrad(
                geschwindigkeitProGang ?? Speed.FromMetersPerSecond(1),
                gestellH�he ?? Length.FromMeters(1),
                lenkerH�he ?? Length.FromCentimeters(20),
                maximaleSattelH�he ?? Length.FromCentimeters(60))
            {
                AnzahlG�nge = anzahlG�nge,
            };
        }

        [Fact]
        public void StehenTest()
        {
            // ARRANGE
            var fahrrad = Setup();

            // ASSERT
            fahrrad.AktuelleGeschwindigkeit.Should().Be(Speed.Zero);
        }

        [Fact]
        public void LosfahreTest()
        {
            // ARRANGE
            var fahrrad = Setup();

            // ACT
            fahrrad.Losfahren();

            // ASSERT
            fahrrad.AktuelleGeschwindigkeit.Should().BeGreaterThan(Speed.Zero);
        }
    }
}
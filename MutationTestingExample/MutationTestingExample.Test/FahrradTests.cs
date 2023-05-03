using FluentAssertions;
using UnitsNet;

namespace MutationTestingExample.Test
{
    public class FahrradTests
    {
        private IFahrrad Setup(Speed? geschwindigkeitProGang = null, Length? gestellHöhe = null,
            Length? lenkerHöhe = null, Length? maximaleSattelHöhe = null, int anzahlGänge = 7)
        {
            return new Fahrrad(
                geschwindigkeitProGang ?? Speed.FromMetersPerSecond(1),
                gestellHöhe ?? Length.FromMeters(1),
                lenkerHöhe ?? Length.FromCentimeters(20),
                maximaleSattelHöhe ?? Length.FromCentimeters(60))
            {
                AnzahlGänge = anzahlGänge,
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
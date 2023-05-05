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
        public void LosfahrenTest()
        {
            // ARRANGE
            var fahrrad = Setup();

            // ACT
            fahrrad.Losfahren();

            // ASSERT
            fahrrad.AktuelleGeschwindigkeit.Should().BeGreaterThan(Speed.Zero);
        }

        [Fact]
        public void BremsenTest()
        {
            // ARRANGE
            var fahrrad = Setup();

            // ACT
            fahrrad.Losfahren();
            fahrrad.Bremsen();

            // ASSERT
            fahrrad.AktuelleGeschwindigkeit.Should().Be(Speed.Zero);
        }

        [Fact]
        public void H�heTest()
        {
            // ARRANGE
            var fahrrad = Setup(
                gestellH�he: Length.FromMeters(1),
                lenkerH�he: Length.FromMeters(0.1),
                maximaleSattelH�he: Length.FromMeters(0.5));

            // ACT
            fahrrad.SattelEinstellen(Length.FromMeters(0.3));

            // ASSERT
            fahrrad.Gesamth�he.Meters.Should().BeApproximately(Length.FromMeters(1.3).Meters, 0.01d);
        }

        [Fact]
        public void SchaltenTest()
        {
            // ARRANGE
            var fahrrad = Setup(anzahlG�nge: 7);

            // ACT
            fahrrad.Hochschalten();

            // ASSERT
            fahrrad.AktuellerGang.Should().Be(2);
        }
    }
}
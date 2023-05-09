namespace MutationTestingExample.Test;

public class FahrradTests
{
    private IFahrrad Setup(
        Speed? geschwindigkeitProGang = null,
        Length? gestellHöhe = null,
        Length? lenkerHöhe = null,
        Length? maximaleSattelHöhe = null,
        int anzahlGänge = 7)
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
    public void HöheTest()
    {
        // ARRANGE
        var fahrrad = Setup(
            gestellHöhe: Length.FromMeters(1),
            lenkerHöhe: Length.FromMeters(0.1),
            maximaleSattelHöhe: Length.FromMeters(0.5));

        // ACT
        fahrrad.SattelEinstellen(Length.FromMeters(0.3));

        // ASSERT
        fahrrad.Gesamthöhe.Meters.Should().BeApproximately(Length.FromMeters(1.3).Meters, 0.01d);
    }

    [Fact]
    public void SchaltenTest()
    {
        // ARRANGE
        var fahrrad = Setup(anzahlGänge: 7);

        // ACT
        fahrrad.Hochschalten();

        // ASSERT
        fahrrad.AktuellerGang.Should().Be(2);
    }

    //[Fact]
    //public void Test()
    //{
    //    // ARRANGE
    //    var fahrrad = Setup();

    //    // ACT


    //    // ASSERT

    //}
}
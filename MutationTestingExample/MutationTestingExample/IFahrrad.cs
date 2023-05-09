namespace MutationTestingExample;

public interface IFahrrad
{
    Length SattelHöhe { get; }

    Length Gesamthöhe { get; }

    int AnzahlGänge { get; }

    int AktuellerGang { get; }

    void Hochschalten();

    void Runterschalten();

    Speed AktuelleGeschwindigkeit { get; }

    void Bremsen();

    void Losfahren();

    void SattelEinstellen(Length höhe);
}
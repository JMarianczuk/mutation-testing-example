using Bluehands.Diagnostics.LogExtensions;
using UnitsNet;

namespace MutationTestingExample
{
    public class Fahrrad : IFahrrad
    {
        private static readonly Log Log = Log.For<Fahrrad>();

        private readonly Speed geschwindigkeitProGang;
        private readonly Length gestellHöhe;
        private readonly Length lenkerHöhe;
        private readonly Length maximaleSattelHöhe;

        private bool istAmFahren = false;

        public Fahrrad(Speed geschwindigkeitProGang, Length gestellHöhe, Length lenkerHöhe, Length maximaleSattelHöhe)
        {
            this.geschwindigkeitProGang = geschwindigkeitProGang;
            this.gestellHöhe = gestellHöhe;
            this.lenkerHöhe = lenkerHöhe;
            this.maximaleSattelHöhe = maximaleSattelHöhe;
        }

        public Length SattelHöhe { get; private set; }

        public Length Gesamthöhe
        {
            get
            {
                if (this.SattelHöhe < this.lenkerHöhe)
                {
                    return this.gestellHöhe + this.lenkerHöhe;
                }
                else
                {
                    return this.gestellHöhe + this.SattelHöhe;
                }
            }
        }
        public required int AnzahlGänge { get; init; }
        public int AktuellerGang { get; private set; } = 1;

        public void Hochschalten()
        {
            if (this.AktuellerGang < this.AnzahlGänge)
            {
                this.AktuellerGang += 1;
            }
        }

        public void Runterschalten()
        {
            if (this.AktuellerGang > 1)
            {
                this.AktuellerGang -= 1;
            }
        }

        public Speed AktuelleGeschwindigkeit
        {
            get
            {
                if (this.istAmFahren)
                {
                    return this.geschwindigkeitProGang * this.AktuellerGang;
                }
                else
                {
                    return Speed.Zero;
                }
            }
        }

        public void Bremsen()
        {
            Log.Info("Bremsen");
            this.istAmFahren = false;
        }

        public void Losfahren()
        {
            Log.Info("Losfahren");
            this.istAmFahren = true;
        }

        public void SattelEinstellen(Length höhe)
        {
            if (höhe < Length.Zero || höhe > this.maximaleSattelHöhe)
            {
                Log.Warning("Ungültige Sattelhöhe");
                return;
            }

            this.SattelHöhe = höhe;
        }
    }
}
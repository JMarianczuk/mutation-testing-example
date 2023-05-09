# Mutation testing
Wie teste ich meine Unit Tests?

## Beispiel-Code: Ein Fahrrad
```csharp
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
```

## Tool: Dotnet Stryker:
https://stryker-mutator.io/docs/stryker-net/Getting-started

## Installation:
```
dotnet tool install -g dotnet-stryker
dotnet new tool-manifest
dotnet tool install dotnet-stryker
```

## Anlegen der stryker-config.json
```json
{
    "stryker-config":
    {
        "reporters": [
            "progress",
            "html"
        ]
    }
}
```

## Ausführen
```
dotnet-stryker
```
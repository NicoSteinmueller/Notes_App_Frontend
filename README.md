# Notes App – Frontend

Webclient einer Notiz-Verwaltung, umgesetzt als Blazor-Server-Anwendung mit MudBlazor.

Das Frontend ist der Client zur REST-API aus
[Notes_App](https://github.com/NicoSteinmueller/Notes_App): Registrierung und Login,
ein Dashboard mit allen Notizen des Nutzers sowie eine Einstellungsseite für Profil,
Passwort und Darstellung.

## Hintergrund

Das Projekt ist im 6. Semester des Studiengangs Wirtschaftsinformatik an der HWR Berlin
im Modul E-Business / Service Engineering (Prof. Dr. Schmietendorf) entstanden.

Aufgabenstellung war die Entwicklung einer Web-API mit mindestens sechs Operationen bzw.
Datenressourcen inklusive eines korrespondierenden Clients, dokumentiert über Analyse,
Design, Implementierung, Test und Deployment.

Team: Nico Steinmüller, Corentin Hamp, Nico Regenberg.

## Funktionen

* Registrierung und Login gegen die Backend-API, JWT wird im Protected Local Storage gehalten
* Dashboard mit allen Notizen als Karten, optional gefiltert auf Favoriten
* Notizen anlegen, bearbeiten und löschen über einen Dialog
* Favoriten-Status direkt auf der Karte umschalten
* Profildaten (Vor-, Nachname, E-Mail) und Passwort ändern
* Dark/Light Mode und Sprache als Nutzereinstellung, serverseitig am Account gespeichert

## Technologie-Stack

| Bereich    | Technologie                        |
|------------|------------------------------------|
| Sprache    | C# / .NET 7                        |
| Framework  | Blazor Server (ASP.NET Core)       |
| UI         | MudBlazor 6.2.0 (Material Design)  |
| Container  | Dockerfile (`mcr.microsoft.com/dotnet/aspnet:7.0`) |

.NET wurde gewählt, weil es plattformübergreifend, typsicher und gut dokumentiert ist und
sowohl Server- als auch WASM-Betrieb erlaubt. MudBlazor liefert dazu eine stabile,
gut dokumentierte Material-Design-Komponentenbibliothek.

## Aufbau

```
Notes_App_Frontend/
├── Pages/        Login (/), Dashboard (/Dashboard), Settings (/settings)
├── Components/   SimpleNote (Notizkarte), NoteEditDialog
├── Service/      Authentication, UserService, NoteService – HTTP-Zugriff auf die API
├── Models/       DTOs und Zustandsmodelle (User, Note, Settings, MenuSettings)
├── Shared/       MainLayout inkl. MudTheme und Navigation
└── wwwroot/      Statische Assets (CSS, Bilder, Icons)
```

Die Services werden in [Program.cs](Notes_App_Frontend/Program.cs) als Scoped Services
registriert und kapseln jeweils einen Bereich der API. Der angemeldete Nutzer und sein
Token liegen im scoped `IUser`-Service, das Darstellungs-Setting zusätzlich im
Protected Local Storage, damit es einen Reload übersteht.

## Setup

Voraussetzungen: .NET SDK 7, laufendes Backend.

1. Backend inklusive MongoDB starten – siehe
   [Notes_App](https://github.com/NicoSteinmueller/Notes_App). Es muss unter
   <http://localhost:8080> erreichbar sein.

2. Frontend starten:

   ```bash
   dotnet run --project Notes_App_Frontend
   ```

   Die App läuft dann auf <http://localhost:5129> bzw. <https://localhost:7235>.

Die Backend-Adresse ist derzeit in den Service-Klassen fest hinterlegt
(`http://localhost:8080/api/v0/...`) und noch nicht in die `appsettings.json` ausgelagert.

### Docker

```bash
docker build -f Notes_App_Frontend/Dockerfile -t notes-app-frontend .
docker run -p 8080:80 notes-app-frontend
```

## Tests

Das Frontend wurde im Rahmen des Projekts integrativ und manuell getestet: Datenbank,
Backend und Frontend starten, Funktionen durchgehen, Fehler dokumentieren und beheben.
Automatisierte Unit-Tests waren als nächster Schritt geplant, sind aber nicht mehr
umgesetzt worden.

## Deployment

Das Deployment erfolgt manuell über `dotnet publish` bzw. die Publish-Funktion von Rider.
Für eine produktive Weiterentwicklung war eine automatisierte Jenkins-Pipeline vorgesehen.

# Challenge: The Broken Order Dashboard

Welkom bij de Order Dashboard Debug Challenge.

Dit is een **realistische casus** in een gangbare enterprise-stack: een headless **ASP.NET Core** Web API en een **Vue 3 SPA** (Composition API, Pinia setup store, TypeScript). Front en back zijn gescheiden en praten alleen JSON (niet de hele enterprise-laag: geen EF Core, RabbitMQ of Kubernetes).

Het is ook een concreet voorbeeld van **starten in een bestaande opzet**. De repo is er al: controllers, een store, een router, een login. Jullie bouwen dit niet opnieuw. Jullie clonen, starten beide kanten, lezen de code, en halen de integratiebugs eruit.

Er zitten **3 kritieke integratie-bugs** in. Het fundament start; het dashboard gedraagt zich daarna niet zoals het hoort.

## Rollen & taakverdeling

- **Frontend:** verantwoordelijk voor bug 1 in de Vue 3 / Pinia frontend.
- **Backend:** verantwoordelijk voor bug 2 in de ASP.NET Core 8 Web API.
- **Samen (integratie):** verantwoordelijk voor bug 3 — het koppelvlak tussen frontend en backend.

De bugs zitten in de bestaande code. **Niet de hele app herschrijven.** Vind, begrijp, herstel.

## Wat er van jullie verwacht wordt

1. **Herstel de bugs.** Het dashboard moet functioneel, bugvrij en bruikbaar op desktop én smaller scherm werken: bestellingen laden, status wijzigen, tussen pagina’s navigeren, opnieuw laden.
2. **Schrijf een postmortem.** Kopieer [`POSTMORTEM-TEMPLATE.md`](./POSTMORTEM-TEMPLATE.md) naar `POSTMORTEM.md` in de root en vul die in.
3. **Pull Request.** Eén gezamenlijke PR naar `main`, uiterlijk op de afgesproken deadline.

## Deadline

Maandag 09:00 — afgeronde Pull Request inclusief ingevulde `POSTMORTEM.md`.

## Wat de app zou moeten doen

Na het inloggen zie je een orderbord (Open → Geannuleerd). Je kunt:

- bestellingen zoeken en opnieuw laden
- een status wijzigen (die wijziging blijft staan na herladen)
- een bestelling openen en terug naar het overzicht
- naar **Over** navigeren en daarna weer bestellingen ophalen

Aanmelden gaat via de API. Het token blijft in de browser (niet op het scherm); bestellingen vragen dat token daarna mee.

## Installeren (Windows of Mac)

Geen Docker. Geen Visual Studio verplicht. Dezelfde commando’s in PowerShell, Terminal of cmd.

1. **.NET SDK 8 of nieuwer**  
   Download: [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)  
   Windows: de installer (`.exe`). Mac: de `.pkg`.  
   Open daarna een **nieuw** terminalvenster. Check:

   ```text
   dotnet --version
   ```

   Je ziet een nummer dat met 8, 9 of 10 begint. Dat is genoeg.

2. **Node.js 20 of nieuwer** (LTS)  
   Download: [nodejs.org](https://nodejs.org)  
   Check:

   ```text
   node -v
   ```

3. **Git** — als `git` nog niet bestaat: [git-scm.com](https://git-scm.com)

### Repo ophalen

Je hebt toegang tot deze (private) repo nodig. Daarna:

```text
git clone https://github.com/EeKay/the_broken_order_dashboard.git
cd the_broken_order_dashboard
```

(GitHub Desktop mag ook; open daarna de map in een terminal.)

## Starten — twee vensters

**Venster 1 — API**

```text
cd backend
dotnet run
```

Wacht tot je dit ziet: `Now listening on: http://localhost:5080`

- Swagger: [http://localhost:5080/swagger](http://localhost:5080/swagger) — opent **zonder** inloggen  
- `POST /api/auth/login` kun je in Swagger uitproberen  
- `GET /api/orders` zonder token hoort **401** te geven

**Venster 2 — Vue-app**

```text
cd frontend
npm install
npm run dev
```

Wacht tot je dit ziet: `Local: http://localhost:5173/`

- App: [http://localhost:5173](http://localhost:5173)

### Demo-account (acceptatie)

```text
e-mail:     inkoop@leverportaal.nl
wachtwoord: Acceptatie-2026
```

Vul die gegevens in op het inlogscherm. De API geeft bij succes een token terug; de SPA bewaart dat zelf. Je ziet het token niet in de UI.

### Korte check vóór je gaat debuggen

| Check | Verwacht |
|-------|----------|
| Swagger opent | ja |
| Inlogscherm op :5173 | ja, lege e-mail- en wachtwoordvelden |
| Na “Aanmelden” een bord vol 12 bestellingen | **nee** — dat is de challenge |

Geen Vite-proxy: de SPA praat rechtstreeks met `http://localhost:5080/api`.

### Als het niet start

| Melding | Wat te doen |
|---------|-----------|
| `dotnet` is not recognized / command not found | SDK geïnstalleerd? **Nieuw** terminalvenster. |
| missing `Microsoft.NETCore.App` 8.0.0 | Installeer de SDK opnieuw (8 of 10). Dit project mag op een nieuwere runtime draaien. |
| `npm` / `node` not found | Node geïnstalleerd? **Nieuw** terminalvenster. |
| poort 5080 of 5173 in gebruik | Het andere programma sluiten. (Poort wijzigen mag, maar dan ook in `frontend/src/services/api.ts`.) |

## API-contract (kort)

| Methode | Pad | Auth | Body |
|---------|-----|------|------|
| `POST` | `/api/auth/login` | nee | `{ "email": "…", "password": "…" }` |
| `GET` | `/api/orders` | Bearer | — |
| `GET` | `/api/orders/{id}` | Bearer | — |
| `PATCH` | `/api/orders/{id}/status` | Bearer | `{ "status": "Shipped" }` |

Statuswaarden in JSON (ná een correcte fix): `Pending`, `Processing`, `Shipped`, `Delivered`, `Cancelled`.

## Werkwijze

1. Beide kanten starten. Open de browserconsole **en** het Network-tabblad **en** Swagger.
2. Reproduceren vóór je code wijzigt. Noteer symptoom, request, response, console.
3. Frontend en backend **eerst het JSON-contract afstemmen** (namen, enum/string, headers). Niet langs elkaar heen patchen.
4. Branch vanaf `main`, bijvoorbeeld `fix/debug-challenge`.
5. PR met wat je hersteld hebt en de ingevulde `POSTMORTEM.md`.

## Oplevering

In de PR:

- werkende app (frontend + backend)
- `POSTMORTEM.md` (niet alleen de lege template)
- geen secrets, geen `bin/`, `obj/`, `node_modules/` of `dist/`

## Repo-indeling

```text
.
├── backend/          # ASP.NET Core 8 Web API
├── frontend/         # Vue 3 + Vite + TypeScript + Pinia
├── POSTMORTEM-TEMPLATE.md
└── README.md
```

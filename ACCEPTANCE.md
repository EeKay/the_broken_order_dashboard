# Acceptatie — The Broken Order Dashboard

Dit is de **definitie van klaar** voor deze challenge. Geen lijst van bugs of fixes — alleen wat de app **gedraagt** als alles werkt.

Gebruik deze checks **vóór** jullie de PR openen. Bij start van de opdracht horen meerdere checks te **falen**. Bij oplevering moeten ze allemaal **slagen**.

**Voorwaarden:** API op [http://localhost:5080](http://localhost:5080), Vue-app op [http://localhost:5173](http://localhost:5173). Demo-account staat in de [README](./README.md).

Werk de checks **in deze volgorde** af. Noteer per regel: fail / pass (en kort wat je zag: statuscode, scherm, console).

---

## A — Swagger (API los van de SPA)

| # | Check | Pass wanneer |
|---|--------|--------------|
| A1 | Swagger opent | [http://localhost:5080/swagger](http://localhost:5080/swagger) laadt zonder fout |
| A2 | Login via Swagger | `POST /api/auth/login` met demo-account → **200** en JSON met `token` + `displayName` |
| A3 | Orders zonder token | `GET /api/orders` **zonder** Authorization → **401** |
| A4 | Orders met Bearer | Zelfde GET met header `Authorization: Bearer <token uit A2>` → **200** en een **array van 12** bestellingen |
| A5 | Status in JSON | In die GET-body is elk `status`-veld een **string** uit: `Pending`, `Processing`, `Shipped`, `Delivered`, `Cancelled` (geen kale getallen als enige statusvorm) |
| A6 | Status wijzigen | `PATCH /api/orders/1/status` met body `{ "status": "Shipped" }` en Bearer → **200**; daarna GET toont order 1 als `Shipped` |

---

## B — SPA: aanmelden en bord

Doe dit in **Chrome** op [http://localhost:5173](http://localhost:5173). Open DevTools: **Network**, **Console**, **Application**.

| # | Check | Pass wanneer |
|---|--------|--------------|
| B1 | Inlogscherm | Lege e-mail- en wachtwoordvelden; geen token zichtbaar in de UI |
| B2 | Aanmelden vanuit de SPA | Demo-account → je komt op het orderbord (geen blijvende “Network Error” / mislukte login in de Console) |
| B3 | Token bewaard | Application → Local Storage: `auth_token` is gezet |
| B4 | Bestellingen op het bord | Je ziet **12** bestellingen, verdeeld over de kolommen Open → Geannuleerd (niet “0 bestellingen” met een lege board) |
| B5 | Request met auth | Network: `GET …/api/orders` is **200** en stuurt een `Authorization`-header mee |

---

## C — Status, herladen, navigatie

| # | Check | Pass wanneer |
|---|--------|--------------|
| C1 | Status op het bord | Op een kaart (of detail) kies je een andere status → de kaart staat in de **juiste kolom** (of toont het juiste label) |
| C2 | Blijft staan na Opnieuw laden | Klik **Opnieuw laden** → die status blijft zoals na C1 (niet terug naar de oude waarde) |
| C3 | Detailpagina | Open een bestelling → detail toont dezelfde gegevens; status wijzigen daar werkt ook |
| C4 | Terug naar overzicht | Via de link terug → bord toont nog steeds de bestellingen |
| C5 | Over en terug | Ga naar **Over**, daarna terug naar bestellingen → bord laadt opnieuw zonder opnieuw inloggen / zonder 401-loop |
| C6 | Zoeken | Typ in het zoekveld iets dat één order matcht → alleen die (of die set) blijft zichtbaar; leegmaken toont weer alles |

---

## D — Bruikbaarheid (kort)

| # | Check | Pass wanneer |
|---|--------|--------------|
| D1 | Desktop | Bord is bruikbaar op een normale vensterbreedte (kolommen leesbaar) |
| D2 | Smaller scherm | Op ~375px breedte kun je nog inloggen, scrollen en een status kiezen (mag gestapeld/scrollend zijn) |

---

## Klaar voor de PR?

Alle checks A–D op **pass**, plus:

1. [`POSTMORTEM.md`](./POSTMORTEM.md) bestaat (gekopieerd van de template) en is ingevuld.
2. Eén gezamenlijke Pull Request naar `main`.

Jullie hoeven **geen** geautomatiseerde testsuite te schrijven voor deze challenge. Deze checklist **is** de acceptatie.

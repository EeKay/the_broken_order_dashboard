# Postmortem Report - Order Dashboard Challenge

Nummering = volgorde waarin de bugs zichtbaar werden.

## Bug 1: CORS Policy & Auth Header (eerst zichtbaar)

- **Toegewezen aan:** Frontend & Backend (samen)
- **Symptoom:** Wat ging er mis bij aanmelden en daarna bij het laden van bestellingen?
- **Root Cause:** Waar zat de mismatch tussen frontend en backend?
- **Gebruikte Tooling:** (VS Code; Chrome Network / Console / Application; Swagger)
- **Oplossing:** Hoe hebben jullie dit samen opgelost?

## Bug 2: State Mutation & Reactivity Broken

- **Toegewezen aan:** Frontend
- **Symptoom:** Wat merkte de gebruiker in de UI?
- **Root Cause:** Waarom ging het mis in de Vue/Pinia code?
- **Gebruikte Tooling:** (Vue.js DevTools in Chrome, VS Code + Volar, breakpoints)
- **Oplossing:** Hoe is het hersteld?

## Bug 3: Async/Await & Enum Deserialization

- **Toegewezen aan:** Backend
- **Symptoom:** Wat voor HTTP/API-foutmeldingen of JSON zag je (Swagger / Network)?
- **Root Cause:** Waar in de .NET controller/service zat de fout?
- **Gebruikte Tooling:** (VS Code + C# Dev Kit, breakpoints, Swagger)
- **Oplossing:** Hoe is de C# code aangepast?

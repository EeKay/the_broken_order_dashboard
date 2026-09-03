<template>
  <section class="about">
    <p class="eyebrow">Leverportaal</p>
    <h1>Over dit portaal</h1>
    <p class="lede">
      Interne inkoop voor zorglocaties: tilliften, wondzorg, diagnostiek, bedden.
      Locatiemanagers plaatsen een aanvraag; inkoop volgt de status tot levering.
    </p>

    <h2>Hoe het in elkaar zit</h2>
    <p>
      Dit is een bestaande opzet, geen groene weide. De browser draait een Vue 3-app
      (Composition API, Pinia, TypeScript). Die praat met een headless ASP.NET Core-API
      die alleen JSON teruggeeft — geen HTML vanaf de server. Aanmelden gaat via
      <code>POST /api/auth/login</code>; de API geeft een Bearer-token terug. Bestellingen
      en statuswijzigingen vereisen dat token. De orderlijst leeft in Pinia.
    </p>
    <p>
      Front en back zijn gescheiden. Nieuwe collega’s starten zoals hier: beide processen
      lokaal, daarna het contract (paden, headers, statuswaarden) lezen en aansluiten.
      Niet herschrijven; de structuur is er al.
    </p>

    <h2>Wat je hier doet</h2>
    <ul>
      <li>Openstaande bestellingen per status volgen</li>
      <li>Een status zetten als de leverancier of de locatie iets terugmeldt</li>
      <li>Een regel openen voor locatie, aanvrager en bedrag</li>
    </ul>

    <p>
      <router-link to="/">Naar het overzicht</router-link>
    </p>
  </section>
</template>

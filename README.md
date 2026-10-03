# Individueel-WPFW-portfolio
hier maak ik de portfolio opdrachten 


## Opdracht 2 - Technische toelichting

Voor Opdracht 2 heb ik JavaScript toegevoegd aan mijn bestaande portfoliosite.

### JavaScript-bestanden

Ik gebruik drie losse JavaScript-bestanden:

- `JS/script.js` voor de dynamische projectenlijst en het sorteren van projecten.
- `JS/contact.js` voor de validatie van het contactformulier.
- `JS/api.js` voor het ophalen en tonen van actuele weergegevens.

### Dynamische projectenlijst

De gegevens van mijn projecten staan in een JavaScript-array met objecten.

Met `forEach()` loop ik door de projecten. Met `document.createElement()` maak ik onder andere `article`, `h3` en `p` elementen. Met `textContent` zet ik de projectgegevens in deze elementen en met `appendChild()` voeg ik ze toe aan de pagina.

Met een knop en `addEventListener("click")` kunnen de projecten op titel worden gesorteerd.

### Contactformulier

Het contactformulier bevat de velden naam, e-mail en bericht.

Ik gebruik HTML-validatie met `required`, `type="email"` en `minlength`. In JavaScript gebruik ik `checkValidity()` om te controleren of de invoer geldig is.

Bij ongeldige invoer verschijnt per veld een foutmelding. Met `aria-describedby`, `aria-invalid` en `aria-live` is de feedback ook toegankelijker.

### Externe API

Ik gebruik de Open-Meteo API om actuele weergegevens voor Den Haag op te halen.

Met `fetch()` wordt een HTTP-request naar de API gestuurd. De JSON-response wordt met `response.json()` omgezet naar een JavaScript-object.

Ik gebruik `async/await` en `try/catch`. Tijdens het laden wordt een laadmelding getoond. Als de API niet bereikbaar is, verschijnt een foutmelding.

De opgehaalde temperatuur en windsnelheid worden met `createElement()`, `textContent` en `appendChild()` op de Blog-pagina getoond.
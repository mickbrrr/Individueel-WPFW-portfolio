const weerData = document.querySelector("#weer-data");

const url =
    "https://api.open-meteo.com/v1/forecast?latitude=52.07&longitude=4.30&current=temperature_2m,wind_speed_10m&timezone=Europe%2FAmsterdam";

async function haalWeerOp() {
    weerData.textContent = "Weergegevens laden...";

    try {
        const response = await fetch(url);
        const data = await response.json();

        weerData.textContent = "";

        const temperatuur = document.createElement("p");
        temperatuur.textContent =
            `Temperatuur: ${data.current.temperature_2m} ${data.current_units.temperature_2m}`;

        const wind = document.createElement("p");
        wind.textContent =
            `Windsnelheid: ${data.current.wind_speed_10m} ${data.current_units.wind_speed_10m}`;

        weerData.appendChild(temperatuur);
        weerData.appendChild(wind);
    } catch (error) {
        weerData.textContent =
            "Weergegevens konden niet worden geladen.";

        console.log(error);
    }
}

haalWeerOp();
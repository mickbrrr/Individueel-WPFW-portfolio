const projecten = [
    {
        titel: "Campus EventDesk - Klassendiagram",
        status: "Werk in uitvoering.",
        beschrijving:
            "Voor mijn vak Database ontwerp ik een UML-klassendiagram voor Campus EventDesk, een webapplicatie voor het beheren van onderwijsactiviteiten en deelnemersregistraties. Ik werk momenteel aan de klassen, relaties, multipliciteiten en bedrijfsregels.",
        extraBeschrijving: ""
    },
    {
        titel: "GameFlow / ParkDirector - Groepsproject",
        status: "Werk in uitvoering.",
        beschrijving:
            "In dit groepsproject ontwikkelen wij een serious game en bedrijfssimulatie waarin teams strategische beslissingen nemen en kunnen zien hoe deze beslissingen de bedrijfsresultaten over meerdere rondes beïnvloeden.",
        extraBeschrijving:
            "We zijn onlangs met het project begonnen en werken momenteel aan onze teamafspraken, planning, taakverdeling en projectaanpak."
    }
];

function toonProjecten() {
    const projectenLijst = document.querySelector("#projecten-lijst");

    projectenLijst.innerHTML = "";

    projecten.forEach((project) => {
        const article = document.createElement("article");

        const titel = document.createElement("h3");
        titel.textContent = project.titel;

        const status = document.createElement("p");
        status.textContent = project.status;

        const beschrijving = document.createElement("p");
        beschrijving.textContent = project.beschrijving;

        article.appendChild(titel);
        article.appendChild(status);
        article.appendChild(beschrijving);

        if (project.extraBeschrijving !== "") {
            const extraBeschrijving = document.createElement("p");
            extraBeschrijving.textContent = project.extraBeschrijving;
            article.appendChild(extraBeschrijving);
        }

        projectenLijst.appendChild(article);
    });
}

toonProjecten();

const sorteerKnop = document.querySelector("#sorteer-knop");

sorteerKnop.addEventListener("click", () => {
    projecten.sort((a, b) => {
        if (a.titel < b.titel) {
            return -1;
        }

        if (a.titel > b.titel) {
            return 1;
        }

        return 0;
    });

    toonProjecten();
});
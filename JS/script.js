const projecten = [
    {
        titel: "Campus EventDesk - Klassendiagram",
        vak: "Database",
        jaar: "2026",
        technieken: "UML, databases en modelleren",
        status: "Werk in uitvoering.",
        beschrijving:
            "Voor mijn vak Database ontwerp ik een UML-klassendiagram voor Campus EventDesk, een webapplicatie voor het beheren van onderwijsactiviteiten en deelnemersregistraties. Ik werk momenteel aan de klassen, relaties, multipliciteiten en bedrijfsregels.",
        extraBeschrijving: ""
    },
    {
        titel: "GameFlow / ParkDirector - Groepsproject",
        vak: "Project",
        jaar: "2026",
        technieken: "Samenwerken, planning en serious game",
        status: "Werk in uitvoering.",
        beschrijving:
            "In dit groepsproject ontwikkelen wij een serious game en bedrijfssimulatie waarin teams strategische beslissingen nemen en kunnen zien hoe deze beslissingen de bedrijfsresultaten over meerdere rondes beïnvloeden.",
        extraBeschrijving:
            "We zijn onlangs met het project begonnen en werken momenteel aan onze teamafspraken, planning, taakverdeling en projectaanpak."
    },
    {
        titel: "Mijn WPFW Portfolio",
        vak: "WPFW",
        jaar: "2026",
        technieken: "HTML, CSS en JavaScript",
        status: "Werk in uitvoering.",
        beschrijving:
            "Voor WPFW bouw ik mijn persoonlijke portfolio. Ik heb de website opgebouwd met HTML en CSS en later JavaScript toegevoegd voor dynamische inhoud, formuliervalidatie en externe data.",
        extraBeschrijving:
            "Met dit portfolio laat ik mijn projecten en mijn ontwikkeling als Software Engineering-student zien."
    }
];


function toonProjecten(projectLijst) {
    const projectenLijst = document.querySelector("#projecten-lijst");

    projectenLijst.innerHTML = "";

    projectLijst.forEach((project) => {
        const article = document.createElement("article");

        const titel = document.createElement("h3");
        titel.textContent = project.titel;

        const informatie = document.createElement("p");
        informatie.textContent = `${project.vak} - ${project.jaar}`;

        const status = document.createElement("p");
        status.textContent = project.status;

        const beschrijving = document.createElement("p");
        beschrijving.textContent = project.beschrijving;

        const technieken = document.createElement("p");
        technieken.textContent = `Technieken: ${project.technieken}`;

        article.appendChild(titel);
        article.appendChild(informatie);
        article.appendChild(status);
        article.appendChild(beschrijving);
        article.appendChild(technieken);

        if (project.extraBeschrijving !== "") {
            const extraBeschrijving = document.createElement("p");
            extraBeschrijving.textContent = project.extraBeschrijving;
            article.appendChild(extraBeschrijving);
        }

        projectenLijst.appendChild(article);
    });
}


const filterVak = document.querySelector("#filter-vak");
const sorteerTitel = document.querySelector("#sorteer-titel");
const projectAantal = document.querySelector("#project-aantal");


function werkProjectenBij() {
    const gekozenVak = filterVak.value;
    const sorteerKeuze = sorteerTitel.value;

    const geselecteerdeProjecten = [];

    projecten.forEach((project) => {
        if (gekozenVak === "alle" || project.vak === gekozenVak) {
            geselecteerdeProjecten.push(project);
        }
    });

    if (sorteerKeuze === "az") {
        geselecteerdeProjecten.sort((a, b) => {
            if (a.titel < b.titel) {
                return -1;
            }

            if (a.titel > b.titel) {
                return 1;
            }

            return 0;
        });
    }

    if (sorteerKeuze === "za") {
        geselecteerdeProjecten.sort((a, b) => {
            if (a.titel > b.titel) {
                return -1;
            }

            if (a.titel < b.titel) {
                return 1;
            }

            return 0;
        });
    }

    projectAantal.textContent =
        `${geselecteerdeProjecten.length} project(en) gevonden.`;

    toonProjecten(geselecteerdeProjecten);
}


filterVak.addEventListener("change", werkProjectenBij);
sorteerTitel.addEventListener("change", werkProjectenBij);

werkProjectenBij();
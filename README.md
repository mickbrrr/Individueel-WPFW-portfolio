# Portfolio API

## Technische informatie

- Framework: .NET 10
- API-stijl: ASP.NET Core Web API met Controllers
- Database: SQL Server LocalDB
- ORM: Entity Framework Core
- API-documentatie: Swagger UI (Swashbuckle.AspNetCore)

## Benodigdheden

- .NET 10 SDK
- SQL Server LocalDB
- Entity Framework Core CLI (`dotnet-ef`)

De versies kunnen worden gecontroleerd met:

`dotnet --version`

`dotnet ef --version`

## Projectstructuur

- **Controllers:** verwerken HTTP-verzoeken en geven HTTP-responses terug.
- **Services:** bevatten de applicatielogica, databasebewerkingen en DTO-mapping.
- **Data:** bevat `AppDbContext` voor EF Core-datatoegang.
- **Models:** bevat de entiteiten `Project` en `BlogPost`.
- **DTOs:** bevat de invoer- en uitvoerobjecten.
- **Migrations:** bevat de wijzigingen in het databaseschema.

## Database configureren

De applicatie gebruikt SQL Server LocalDB met de instantie `MSSQLLocalDB` en de database `PortfolioDb`.

De connection string staat in `PortfolioApi/appsettings.json`.

Voor een lokale Windows-installatie wordt de volgende configuratie gebruikt:

`"ConnectionStrings": { "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=PortfolioDb;Trusted_Connection=True;TrustServerCertificate=True;" }`

De connection string wordt in `Program.cs` opgehaald met `GetConnectionString("DefaultConnection")`.

## Database aanmaken

Open een terminal in de map `PortfolioApi`.

Voer het volgende commando uit:

`dotnet ef database update`

Hiermee worden de bestaande EF Core-migraties toegepast en worden de tabellen `Projects` en `BlogPosts` aangemaakt.

## Applicatie starten

Open een terminal in de hoofdmap van de repository.

Ga naar de API-map:

`cd PortfolioApi`

Start vervolgens de applicatie:

`dotnet run`

Open Swagger UI via het adres dat de terminal toont, met `/swagger` erachter.

Tijdens mijn lokale tests gebruikte ik:

`http://localhost:5156/swagger`

Het poortnummer kan op een andere computer verschillen.

## API-endpoints

De API ondersteunt vijf CRUD-endpoints voor projecten en vijf voor blogposts.

**Projecten:**

- GET `/api/projects`
- GET `/api/projects/{id}`
- POST `/api/projects`
- PUT `/api/projects/{id}`
- DELETE `/api/projects/{id}`

**Blogposts:**

- GET `/api/blogposts`
- GET `/api/blogposts/{id}`
- POST `/api/blogposts`
- PUT `/api/blogposts/{id}`
- DELETE `/api/blogposts/{id}`

## Gebruikte architectuur

Voor deze opdracht heb ik gekozen voor Controllers met een lagenarchitectuur.

De controller ontvangt het HTTP-verzoek en roept de bijbehorende service aan. De service gebruikt `AppDbContext` en Entity Framework Core om gegevens in SQL Server op te halen of te wijzigen.

De gegevens worden via DTO's uitgewisseld, zodat de database-entiteiten gescheiden blijven van de API-invoer en -uitvoer.

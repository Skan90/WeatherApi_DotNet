With Docker running, first download and install the image from PostgreSQL Alpine:

`docker pull postgres:alpine3.18`

After installing the PostgreSQL image `postgres:alpine3.18`, create a Container with the command:

`docker run -d --name dbcamp_dotnet -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=dbcamp_dotnet_db -p 5432:5432 postgres:alpine3.18`

In this line you have `--name dbcamp_dotnet` that's the name for the Container, `POSTGRES_DB=dbcamp_dotnet_db` where `dbcamp_dotnet_db` is the name for the Database that will be created. As for credentials, since no username whas given it's the deafult `postgres` and the `POSTGRES_PASSWORD=postgres` sets the password for a simple `postgres`.

Since the Startup for the project resides inside the Controller Solution instead of the Repository Solution, when creating a migration you need to specify the `--startup-project` in the `dotnet ef migrations add` and also tell the Entity Framework where the project is with  `--project`. The name for the migration can be set where the placeholder `MIGRATION_NAME` is located and last but no least, an output directory with `--output-dir Migrations`.

`dotnet ef migrations add --project DbCamp.DotNet.WeatherRepository\DbCamp.DotNet.WeatherRepository.csproj --startup-project DbCamp.DotNet.WeatherController\DbCamp.DotNet.WeatherController.csproj --context WeatherRepository.WeatherContext --configuration Debug MIGRATION_NAME --output-dir Migrations`

Running the update in the database:

`dotnet ef database update --project DbCamp.DotNet.WeatherRepository\DbCamp.DotNet.WeatherRepository.csproj --startup-project DbCamp.DotNet.WeatherController\DbCamp.DotNet.WeatherController.csproj --context WeatherRepository.WeatherContext --configuration Debug MIGRATION_NUMBER_AND_NAME`

dotnet ef database update
dotnet ef migrations add InitialCreate
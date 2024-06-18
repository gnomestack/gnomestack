bash := if os_family() == 'windows' {
    'C:\Program Files\Git\usr\bin\bash.exe'
} else {
    '/usr/bin/env bash'
}

add-migration MIGRATION: 
    #!{{bash}}
    export DOTNET_ROOT="$HOME/.dotnet"
    dotnet-ef migrations add {{ MIGRATION }} --project "./src/Database.Sqlite/Gs.Database.Sqlite.csproj"  --output-dir "Migrations" --context "SqliteGsDb" --verbose
    dotnet-ef migrations add {{ MIGRATION }} --project "./src/Database.Postgres/Gs.Database.Postgres.csproj"  --output-dir "Migrations" --context "PgGsDb" --verbose
    dotnet-ef migrations add {{ MIGRATION }} --project "./src/Database.Mssql/Gs.Database.Mssql.csproj"  --output-dir "Migrations" --context "MssqlGsDb" --verbose
    
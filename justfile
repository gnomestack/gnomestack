bash := if os_family() == 'windows' {
    'C:\Program Files\Git\usr\bin\bash.exe'
} else {
    '/usr/bin/env bash'
}

add-migration MIGRATION: 
    #!{{bash}}
    export DOTNET_ROOT="$HOME/.dotnet"
    dotnet-ef migrations add {{ MIGRATION }} --project "./src/Data.Migrations.Sqlite/Gs.Data.Migrations.Sqlite.csproj"  --output-dir "Migrations/Sqlite" --context "SqliteGsDbContext" --verbose 
    dotnet-ef migrations add {{ MIGRATION }} --project "./src/Data.Migrations.Pgsql/Gs.Data.Migrations.Pgsql.csproj" --output-dir "Migrations/Pgsql" --context "PgsqlGsDbContext" --verbose 
    dotnet-ef migrations add {{ MIGRATION }} --project "./src/Data.Migrations.Mssql/Gs.Data.Migrations.Mssql.csproj" --output-dir "Migrations/Mssql" --context "MssqlGsDbContext" --verbose 
    
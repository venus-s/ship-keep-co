rmdir /S /Q "Migrations"

dotnet ef --startup-project ../ShipKeepCo.API/ migrations add Initial
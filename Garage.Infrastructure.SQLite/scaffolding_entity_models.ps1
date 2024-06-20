function Main {
    Set-StrictMode -Version Latest
    $ErrorActionPreference = "Stop"

    ScaffoldEntityModels
}

function ScaffoldEntityModels {
    dotnet ef dbcontext scaffold "Data Source=garage.db" Microsoft.EntityFrameworkCore.Sqlite `
        --table Garages `
        --table ParkingLots `
        --table VehicleTypes `
        --table Vehicles `
        --output-dir AutoGenModels `
        --namespace Garage.Infrastructure.SQLite.AutoGenModels `
        --data-annotations `
        --context GarageDb
}

Main


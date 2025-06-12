# manage-db.ps1

param (
    [string]$DatabaseName = "TheMeaningDiscordancyDB",
    [string]$TableName = ""
)

$saUser = "sa"
$saPassword = "123Abc!!!"
$containerName = "mssql"

function Exec-Sql {
    param (
        [string]$Query
    )
    docker exec -i $containerName /opt/mssql-tools18/bin/sqlcmd `
        -S localhost `
        -U $saUser `
        -P $saPassword `
        -d master `
        -C -Q $Query
}

Write-Host "`n=== Database Management ===`n"
Write-Host "1. Drop entire database: $DatabaseName"
Write-Host "2. Delete single table (requires existing DB)"
Write-Host "3. Exit"
$choice = Read-Host "`nSelect option (1/2/3)"

switch ($choice) {
    "1" {
        Write-Host "Dropping entire database..."
        Exec-Sql "DROP DATABASE [$DatabaseName]"
        Write-Host "Database dropped."
    }
    "2" {
        if (-not $TableName) {
            $TableName = Read-Host "Enter table name to delete"
        }
        Write-Host " Deleting table '$TableName'..."
        Exec-Sql "USE [$DatabaseName]; DROP TABLE [$TableName];"
        Write-Host "Table dropped."
    }
    default {
        Write-Host "Cancelled."
    }
}

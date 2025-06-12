# run.ps1
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$projectRoot = Resolve-Path "$scriptPath\.."

# Navigate to the directory with docker-compose.yml
Push-Location $projectRoot

# Optional: Print which .env is being used
Write-Host "Using .env at: $projectRoot\.env"

# Build and run containers
docker-compose --env-file "$projectRoot\.env" up --build -d

Pop-Location
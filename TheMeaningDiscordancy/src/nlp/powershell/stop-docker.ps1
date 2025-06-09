# stop-docker.ps1

# Get the root directory (one level up from this script)
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$projectRoot = Resolve-Path "$scriptPath\.."

# Navigate to the docker-compose directory
Push-Location $projectRoot

Write-Host "Stopping and removing Docker containers..."

# Stop and remove containers (but keep volumes)
docker-compose down

# To also remove volumes (uncomment next line)
# docker-compose down --volumes

Pop-Location

Write-Host "Docker containers stopped..."
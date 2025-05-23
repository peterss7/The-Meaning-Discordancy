# Exit on error
$ErrorActionPreference = "Stop"

# Create venv if it doesn't exist
if (-Not (Test-Path ".\venv")) {
    Write-Host "🔧 Creating virtual environment..."
    python -m venv venv
}

# Activate venv
& .\venv\Scripts\Activate.ps1

# Install dependencies
Write-Host "Installing dependencies from requirements.txt..."
pip install -r requirements.txt

Write-Host "Install complete. Run the app with run.ps1"

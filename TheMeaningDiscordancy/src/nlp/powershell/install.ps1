# Exit on error
$ErrorActionPreference = "Stop"

# Create venv if it doesn't exist
if (-Not (Test-Path ".\.venv")) {
    Write-Host "🔧 Creating virtual environment..."
    python -m venv .venv
}

# Activate venv
& .\.venv\Scripts\Activate

# Install dependencies
Write-Host "📦 Installing dependencies..."
pip install --upgrade pip
pip install -r requirements.txt

Write-Host "Install complete. Run the app with run.ps1"
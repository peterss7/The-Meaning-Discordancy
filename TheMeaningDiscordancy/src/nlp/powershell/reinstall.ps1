$ErrorActionPreference = "Stop"

# Remove old venv
if (Test-Path ".\venv") {
    Write-Host "🔥 Removing old virtual environment..."
    Remove-Item -Recurse -Force ".\venv"
}  # ← ✅ this was missing

# Clean __pycache__ and .pyc files
Write-Host "🧼 Cleaning __pycache__..."
Get-ChildItem -Recurse -Include "__pycache__", "*.pyc" | Remove-Item -Force -Recurse

# Recreate venv
Write-Host "🧱 Creating new virtual environment..."
python -m venv venv
& .\venv\Scripts\Activate.ps1

# Reinstall requirements
Write-Host "📦 Installing dependencies..."
pip install --upgrade pip
pip install -r requirements.txt

Write-Host "✅ Reinstall complete. You can now run: .\run.ps1"

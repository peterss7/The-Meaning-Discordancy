$ErrorActionPreference = "Stop"

Write-Host "Reinstalling environment..."
Write-Host "Venv: $env:VIRTUAL_ENV"
Write-Host "Relaunched reinstall: $env:RELAUNCHED_REINSTALL"

if ($env:VIRTUAL_ENV -and -not $env:RELAUNCHED_REINSTALL) {
    Write-Host "Currently in a virtual environment. Relaunching outside it..."

    Start-Process powershell -ArgumentList @(
        "-NoExit",
        "-Command",
        "`$env:VIRTUAL_ENV=`$null; `$env:RELAUNCHED_REINSTALL=1; Set-Location '$PWD'; & '$PSScriptRoot\reinstall.ps1'"
    )
    exit
}

Write-Host "Terminating any running Python processes..."
Stop-Process -Name python -Force -ErrorAction SilentlyContinue
Start-Sleep -Milliseconds 500

# Remove old venv
if (Test-Path ".\venv") {
    Write-Host "Removing old virtual environment..."
    Remove-Item -Recurse -Force ".\venv"
}  

# Clean __pycache__ and .pyc files
Write-Host "Cleaning __pycache__..."
Get-ChildItem -Recurse -Include "__pycache__", "*.pyc" -ErrorAction SilentlyContinue | Remove-Item -Force -Recurse

# Recreate venv
Write-Host "Creating new virtual environment..."
python -m venv venv

Write-Host "📦 Installing dependencies..."
& .\venv\Scripts\python.exe -m pip install --upgrade pip
& .\venv\Scripts\python.exe -m pip install -r requirements.txt

Write-Host "✅ Reinstall complete."
Write-Host "👉 To activate the environment, run: .\venv\Scripts\Activate.ps1"
# Exit on error
$ErrorActionPreference = "Stop"

# Activate venv
$venvActivate = ".\venv\Scripts\Activate.ps1"

if (-Not (Test-Path $venvActivate)) {
    Write-Host "Virtual environment not found. Run install.ps1 first."
    exit 1
}

& $venvActivate

# Load environment variables from .env
if (Test-Path ".env") {
    Get-Content ".env" | ForEach-Object {
        if ($_ -match '^\s*([^#][^=]+)=(.*)$') {
            $key = $matches[1].Trim()
            $value = $matches[2].Trim()
            [System.Environment]::SetEnvironmentVariable($key, $value, "Process")
        }
    }
}

# Run Flask app in background
Start-Process "flask" "run" -NoNewWindow

# Give Flask time to start
Start-Sleep -Seconds 1

# Open browser
Start-Process "http://127.0.0.1:5000"
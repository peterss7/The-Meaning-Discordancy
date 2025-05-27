# === CONFIG ===
$headerFile = ""
$headerText = ""
$scriptPath = $PSScriptRoot

if (Test-Path ".env") {
    Get-Content ".env" | ForEach-Object {
        if ($_ -match '^\s*HEADER_FILE=(.+)$') {
            Write-Debug ""
            $rawPath = $matches[1].Trim()
            Write-Host "RawPath: $rawPath"
            if ([System.IO.Path]::IsPathRooted($rawPath)) {
                $headerFile = $rawPath
            }
            else {
                $headerFile = Join-Path $scriptPath $rawPath                
            }
            Write-Host "📄 Header file located in env: $headerFile"
        }
    }
}

if ($headerFile -and (Test-Path $headerFile)) {
    $headerText = Get-Content $headerFile -Raw -Encoding UTF8
    $headerText = $headerText.Trim()
    Write-Host "`n📜 Loaded header text:`n$headerText`n"
}
else {
    Write-Error "❌ Could not find header file: $headerFile"
    exit 1
}

$commentStyles = @{
    ".py"   = "#"
    ".cs"   = "//"
    ".ts"   = "//"
    ".css"  = "/*"   # handled specially
    ".html" = "<!--" # handled specially
}

$ignoredDirs = @(
    "venv", "node_modules", ".git", "dist", "build", ".vs", ".github",
    ".storybook"
)
$backupDir = Join-Path (Get-Location) "header_backups"
$restoreMode = $args -contains "--restore"


# === RESTORE MODE ===
if ($restoreMode) {
    if (-not (Test-Path $backupDir)) {
        Write-Error "❌ No backup directory found."
        Write-Host "`n🔍 Loaded header text:`n$headerText`n"
        exit 1
    }

    Get-ChildItem $backupDir -Recurse -File | ForEach-Object {
        $relativePath = $_.FullName.Substring($backupDir.Length + 1).TrimStart("\")
        $targetPath = Join-Path (Get-Location) $relativePath

        $targetDir = Split-Path $targetPath
        if (-not (Test-Path $targetDir)) {
            New-Item -ItemType Directory -Path $targetDir -Force | Out-Null
        }

        Copy-Item $_.FullName $targetPath -Force
        Write-Host "🔁 Restored: $targetPath"
    }

    Remove-Item $backupDir -Recurse -Force
    Write-Host "🗑️  Deleted backup folder: $backupDir"
    Write-Host "✅ Restore complete."
    exit 0
}

# === BACKUP AND HEADER INSERTION MODE ===
if (-not (Test-Path $backupDir)) {
    New-Item -ItemType Directory -Path $backupDir | Out-Null
}

Get-ChildItem -Recurse -Include *.py, *.cs, *.ts, *.css, *.html -File |
Where-Object {
    $path = $_.FullName.ToLower()
    -not ($ignoredDirs | Where-Object { $path -like "*\$_\*" })
} |
ForEach-Object {
    $file = $_.FullName
    $ext = $_.Extension.ToLower()
    if (-not $commentStyles.ContainsKey($ext)) { return }

    # === BACKUP BEFORE ANY MODIFICATION ===
    $relativePath = $file.Substring((Get-Location).Path.Length + 1)
    $backupPath = Join-Path $backupDir $relativePath
    $backupDirPath = Split-Path $backupPath
    if (-not (Test-Path $backupDirPath)) {
        New-Item -ItemType Directory -Path $backupDirPath -Force | Out-Null
    }
    Copy-Item $file $backupPath -Force

    # === Check for existing header ===
    $lines = Get-Content $file
    $firstLine = $lines | Select-Object -First 1
    if ($firstLine -match "Copyright.*Steven Peterson") {
        Write-Host "⏭️  Skipped (already has header): $file"
        return
    }

    # === Format and prepend header ===
    $comment = $commentStyles[$ext]
    switch ($ext) {
        ".css" {
            $formattedHeader = "/*`n$headerText`n*/"
        }
        ".html" {
            $formattedHeader = "<!--`n$headerText`n-->"
        }
        default {
            $prefix = $comment + " "
            $formattedHeader = ($headerText -split "`n" | ForEach-Object { "$prefix$_" }) -join "`n"
        }
    }

    $newContent = "$formattedHeader`n`n" + ($lines -join "`n")
    $newContent | Set-Content $file -Encoding utf8
    Write-Host "✅ Header added: $file"
}

Write-Host "`n💾 Backup saved to: $backupDir"
Write-Host "🔄 To restore original files, run:"
Write-Host "   .\add-headers.ps1 --restore"

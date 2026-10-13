
# Configuration
$acrName = "browsingacr"
$imageName = "browsingtestapp"
$appName = "browsingtestapp"

# Generate a unique tag for each deployment
$tag = Get-Date -Format "yyyyMMddHHmmss"
$fullImage = "$acrName.azurecr.io/${imageName}:$tag"

$ErrorActionPreference = "Stop"

# 1. Build the Docker image
docker build -t "${imageName}:$tag" .
if ($LASTEXITCODE -ne 0) { throw "Docker build failed" }

# 2. Sign in to ACR using your Azure CLI login
az acr login --name $acrName
if ($LASTEXITCODE -ne 0) { throw "ACR login failed" }

# 3. Tag the image for ACR
docker tag "${imageName}:$tag" $fullImage
if ($LASTEXITCODE -ne 0) { throw "Docker tag failed" }

# 4. Push the image
docker push $fullImage
if ($LASTEXITCODE -ne 0) { throw "Docker push failed" }

# 5. Update the existing Azure Container App
az containerapp update `
    --name $appName `
    --image $fullImage

if ($LASTEXITCODE -ne 0) { throw "Container App update failed" }

Write-Host "Deployment complete: $fullImage"

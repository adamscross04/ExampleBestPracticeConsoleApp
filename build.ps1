dotnet sonarscanner begin /k:"ExampleConsoleApplication" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="sqp_26f658c6fb0a2bfb860da38838f8de36fcd85331"

dotnet build
dotnet test

dotnet sonarscanner end /d:sonar.token="sqp_26f658c6fb0a2bfb860da38838f8de36fcd85331"

Write-Host "Starting delete of .sonarqube folder..."
# Remove .sonarqube folder
Remove-Item -Path ".sonarqube\conf" -Recurse -Force
Remove-Item -Path ".sonarqube\out" -Recurse -Force

Write-Host "Build and SonarQube analysis complete!"

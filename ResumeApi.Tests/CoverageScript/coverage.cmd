@echo off

REM Move to repo root (2 levels up from this script)
cd /d "%~dp0..\.."

echo Running tests with coverage...
dotnet test ResumeApi.Tests\ResumeApi.Tests.csproj --collect:"XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.ExcludeByFile="**/obj/**;**/bin/**"

echo Generating HTML coverage report...
reportgenerator -reports:ResumeApi.Tests\TestResults\**\coverage.cobertura.xml -targetdir:CoverageReport -reporttypes:Html -filefilters:-**\obj\**;-**\bin\**

echo Opening coverage report...
start CoverageReport\index.html

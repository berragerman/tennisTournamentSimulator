
dotnet test --collect:”XPlat Code Coverage” --p:CollectCoverage=true --p:CoverletOutputFormat=cobertura

$coverageFile="coverage.cobertura.xml";
$targetdir="coveragereport";
$folders=Get-ChildItem -Path ./TestResults | sort CreationDate -Descending 
$guid=$folders[0].Name
$reportsPath="TestResults\" + $guid  + "\" + $coverageFile
reportgenerator -reports:$reportsPath -targetdir:$targetdir -reporttypes:Html
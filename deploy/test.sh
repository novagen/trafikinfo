ApiKey=$1
Referer=$2

xbuild /p:Configuration=Release Trafikinfo.sln
mono ./testrunner/NUnit.ConsoleRunner.*/tools/nunit3-console.exe ./Trafikverket.Tests/bin/Release/Trafikverket.Tests.dll --params apiKey=$ApiKey --params apiReferer=$Referer
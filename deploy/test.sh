ApiKey=$1
ApiReferer=$2

xbuild /p:Configuration=Release Trafikinfo.sln
mono ./testrunner/NUnit.ConsoleRunner.*/tools/nunit3-console.exe ./Trafikverket.Tests/bin/Release/Apparent.Trafikverket.Tests.dll --params apiKey=$ApiKey --params apiReferer=$ApiReferer
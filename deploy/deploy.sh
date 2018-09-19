ApiKey=$1
Source=$2

nuget pack ./Trafikverket/Trafikinfo.nuspec -Verbosity detailed
nuget push ./Trafikinfo.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source
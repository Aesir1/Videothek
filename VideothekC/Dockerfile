# get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk AS build-env
WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything and build
COPY . ./
RUN dotnet publish -c Release -o out 
 
#Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "VideothekC.dll"]          
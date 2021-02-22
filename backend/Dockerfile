FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app
EXPOSE 5001
# Copy and restore as distinct layers
COPY src/. ./src
RUN dotnet restore src/Mekhnin.Shelter/Mekhnin.Shelter.Api.csproj

# Build
RUN dotnet publish src/Mekhnin.Shelter/Mekhnin.Shelter.Api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .


ENTRYPOINT ["dotnet", "Mekhnin.Shelter.Api.dll"]
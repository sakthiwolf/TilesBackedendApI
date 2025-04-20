# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the .csproj and restore dependencies
COPY TilesApi/TilesApi.csproj TilesApi/
RUN dotnet restore TilesApi/TilesApi.csproj

# Copy the full source code and publish
COPY . .
RUN dotnet publish TilesApi/TilesApi.csproj -c Release -o /app/publish

# Stage 2: Production image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Expose default HTTP port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "TilesApi.dll"]

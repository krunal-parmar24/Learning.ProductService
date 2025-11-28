# STAGE 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ./Learning.ProductService.slnx ./

# Copy the rest of the source
COPY . .

# Restore dependencies
RUN dotnet restore Learning.ProductService.API/Learning.ProductService.API.csproj
RUN dotnet restore Learning.ProductService.Tests/Learning.ProductService.Tests.csproj

# Build and publish
WORKDIR /src/Learning.ProductService.API
RUN dotnet publish -c Release -o /app/publish

# STAGE 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Set ASP.NET Core to listen on port 8080 (good default for containers)
ENV ASPNETCORE_URLS=http://+:8080

# Set environment - can be overridden at runtime with -e ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_ENVIRONMENT=Production

# Copy published output
COPY --from=build /app/publish .

# Expose port (for local clarity; Render mainly uses PORT env var)
EXPOSE 8080

# Run the API
ENTRYPOINT ["dotnet", "Learning.ProductService.API.dll"]
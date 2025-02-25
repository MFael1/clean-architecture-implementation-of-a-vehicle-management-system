FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["Motors.Api/Motors.Api.csproj", "Motors.Api/"]
COPY ["Motors.Application/Motors.Application.csproj", "Motors.Application/"]
COPY ["Motors.Domain/Motors.Domain.csproj", "Motors.Domain/"]
COPY ["Motors.Infrastructure/Motors.Infrastructure.csproj", "Motors.Infrastructure/"]
COPY ["global.json", "."]

RUN dotnet restore "Motors.Api/Motors.Api.csproj"

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build "Motors.Api/Motors.Api.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Motors.Api/Motors.Api.csproj" -c Release -o /app/publish

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 80

ENTRYPOINT ["dotnet", "Motors.Api.dll"]
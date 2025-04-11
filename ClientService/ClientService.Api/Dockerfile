# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# SDK build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia os .csproj
COPY ["ClientService.Api/ClientService.Api.csproj", "ClientService.Api/"]
COPY ["ClientService.Application/ClientService.Application.csproj", "ClientService.Application/"]
COPY ["ClientService.Domain/ClientService.Domain.csproj", "ClientService.Domain/"]
COPY ["ClientService.Infrastructure/ClientService.Infrastructure.csproj", "ClientService.Infrastructure/"]

# Restore
RUN dotnet restore "ClientService.Api/ClientService.Api.csproj"

# Copia o restante do código
COPY . .

# Build
WORKDIR "/src/ClientService.Api"
RUN dotnet build "ClientService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ClientService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientService.Api.dll"]
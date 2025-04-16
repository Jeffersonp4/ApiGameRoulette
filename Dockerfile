# Etapa base: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Etapa build: SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar la solución y los archivos del proyecto
COPY ["GameRouletteApi.sln", "./"]
COPY ["RoulettePresentation/RoulettePresentation.csproj", "RoulettePresentation/"]

# Restaurar dependencias
RUN dotnet restore "RoulettePresentation/RoulettePresentation.csproj"

# Copiar todo el código
COPY . .

# Compilar el proyecto
WORKDIR "/src/RoulettePresentation"
RUN dotnet build "RoulettePresentation.csproj" -c Release -o /app/build

# Publicar el proyecto
FROM build AS publish
RUN dotnet publish "RoulettePresentation.csproj" -c Release -o /app/publish

# Etapa final: runtime limpio
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoulettePresentation.dll"]
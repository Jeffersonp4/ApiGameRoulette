FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src
COPY ["GameRouletteApi.csproj", "./"]
RUN dotnet restore "GameRouletteApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "GameRouletteApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameRouletteApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameRouletteApi.dll"]

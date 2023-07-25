FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["uork-api/uork-api.csproj", "uork-api/"]
RUN dotnet restore "uork-api/uork-api.csproj"
COPY . .
WORKDIR "/src/uork-api"
RUN dotnet build "uork-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "uork-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "uork-api.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["apps/collect-service/WatchLog.Services.CollectService.csproj", "apps/collect-service/"]
COPY ["libs/dotnet/data-layer/WatchLog.Infra.Data.csproj", "libs/dotnet/data-layer/"]
RUN dotnet restore "apps/collect-service/WatchLog.Services.CollectService.csproj"
COPY . .
WORKDIR "/src/apps/collect-service/"
RUN dotnet build "WatchLog.Services.CollectService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WatchLog.Services.CollectService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WatchLog.Services.CollectService.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/migrations/migrations.csproj", "src/migrations/"]
COPY ["src/datalayer/datalayer.csproj", "src/datalayer/"]
COPY ["src/datalayer.abstraction/datalayer.abstraction.csproj", "src/datalayer.abstraction/"]
RUN dotnet restore "src/migrations/migrations.csproj"
COPY . .
WORKDIR "/src/src/migrations"
RUN dotnet build "migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "migrations.dll"]

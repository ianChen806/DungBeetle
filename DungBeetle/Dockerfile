FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DungBeetle/DungBeetle.csproj", "DungBeetle/"]
RUN dotnet restore "DungBeetle/DungBeetle.csproj"
COPY . .
WORKDIR "/src/DungBeetle"
RUN dotnet build "DungBeetle.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DungBeetle.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DungBeetle.dll"]

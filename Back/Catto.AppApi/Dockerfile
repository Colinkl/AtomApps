#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Back/Catto.AppApi/Catto.AppApi.csproj", "Back/Catto.AppApi/"]
COPY ["Back/Catto.DataLib/Catto.DataLib.csproj", "Back/Catto.DataLib/"]
COPY ["RoutePlanner.Lib/RoutePlanner.net.csproj", "RoutePlanner.Lib/"]
RUN dotnet restore "Back/Catto.AppApi/Catto.AppApi.csproj"
COPY . .
WORKDIR "/src/Back/Catto.AppApi"
RUN dotnet build "Catto.AppApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catto.AppApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catto.AppApi.dll"]
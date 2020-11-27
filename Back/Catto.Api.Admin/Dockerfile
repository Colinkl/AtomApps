#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Catto.Api.Admin/Catto.Api.Admin.csproj", "Catto.Api.Admin/"]
COPY ["Catto.DataLib/Catto.DataLib.csproj", "Catto.DataLib/"]
RUN dotnet restore "Catto.Api.Admin/Catto.Api.Admin.csproj"
COPY . .
WORKDIR "/src/Catto.Api.Admin"
RUN dotnet build "Catto.Api.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catto.Api.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catto.Api.Admin.dll"]
﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Hotel/src/Hotel.WebApi/Hotel.WebApi.csproj", "Hotel/src/Hotel.WebApi/"]
COPY ["Hotel/src/Hotel.Application/Hotel.Application.csproj", "Hotel/src/Hotel.Application/"]
COPY ["Hotel/src/Hotel.Domain/Hotel.Domain.csproj", "Hotel/src/Hotel.Domain/"]
COPY ["Library/NerdekalComRepository/NerdekalComRepository.csproj", "Library/NerdekalComRepository/"]
RUN dotnet restore "Hotel/src/Hotel.WebApi/Hotel.WebApi.csproj"
COPY . .
WORKDIR "/src/Hotel/src/Hotel.WebApi"
RUN dotnet build "Hotel.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Hotel.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hotel.WebApi.dll"]

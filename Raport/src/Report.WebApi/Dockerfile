FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Raport/src/Raport.WebApi/Raport.WebApi.csproj", "Raport/src/Raport.WebApi/"]
RUN dotnet restore "Raport/src/Report.WebApi/Report.WebApi.csproj"
COPY . .
WORKDIR "/src/Raport/src/Raport.WebApi"
RUN dotnet build "Raport.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Report.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Report.WebApi.dll"]

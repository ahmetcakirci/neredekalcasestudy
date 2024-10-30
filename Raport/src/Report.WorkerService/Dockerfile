FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Raport/src/Report.WorkerService/Report.WorkerService.csproj", "Raport/src/Report.WorkerService/"]
COPY ["Raport/src/Report.Domain/Report.Domain.csproj", "Raport/src/Report.Domain/"]
COPY ["Library/NerdekalComRepository/NerdekalComRepository.csproj", "Library/NerdekalComRepository/"]
COPY ["Raport/src/Report.Infrastructure/Report.Infrastructure.csproj", "Raport/src/Report.Infrastructure/"]
COPY ["Raport/src/Report.Application/Report.Application.csproj", "Raport/src/Report.Application/"]
COPY ["Library/NeredekalComPagination/NeredekalComPagination.csproj", "Library/NeredekalComPagination/"]
RUN dotnet restore "Raport/src/Report.WorkerService/Report.WorkerService.csproj"
COPY . .
WORKDIR "/src/Raport/src/Report.WorkerService"
RUN dotnet build "Report.WorkerService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Report.WorkerService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Report.WorkerService.dll"]

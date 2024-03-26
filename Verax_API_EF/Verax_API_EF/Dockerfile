#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API/API.csproj", "API/"]
COPY ["API_DbDataManager/API_DbDataManager.csproj", "API_DbDataManager/"]
COPY ["API_Services/API_Services.csproj", "API_Services/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["DbContextLib/DbContextLib.csproj", "DbContextLib/"]
COPY ["StubbedContextLib/StubbedContextLib.csproj", "StubbedContextLib/"]
COPY ["API_Mapping/API_Mapping.csproj", "API_Mapping/"]
COPY ["API_Model/API_Model.csproj", "API_Model/"]
RUN dotnet restore "./API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "./API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
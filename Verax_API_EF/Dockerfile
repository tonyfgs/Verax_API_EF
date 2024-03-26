FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /
COPY . Verax/
RUN cd Verax/
RUN cd Verax_API_EF/
RUN dotnet restore Verax_API_EF.sln
RUN dotnet publish -c Release -o out --no-restore Verax_API_EF.sln

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /
COPY --from=build-env /Verax/out .
ENTRYPOINT ["dotnet", "API.dll"]
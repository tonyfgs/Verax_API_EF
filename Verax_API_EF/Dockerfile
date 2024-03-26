FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /
COPY . Verax/
RUN dotnet restore /Verax/Verax_API_EF/Verax_API_EF.sln
RUN dotnet publish -c Release -o out --no-restore /Verax/Verax_API_EF/Verax_API_EF.sln

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /
COPY --from=build-env /out .
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false
ENV ASPNETCORE_HTTP_PORTS=80
ENTRYPOINT ["dotnet", "API.dll","--launch-profile Docker"]
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DriverSecurity.Api/DriverSecurity.Api.csproj", "DriverSecurity.Api/"]
RUN dotnet restore "DriverSecurity.Api/DriverSecurity.Api.csproj"
COPY . .
WORKDIR "/src/DriverSecurity.Api"
RUN dotnet build "DriverSecurity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DriverSecurity.Api.csproj" -c Release -o /app/publish

FROM base AS final
ENV TZ="America/Sao_Paulo"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DriverSecurity.Api.dll"]

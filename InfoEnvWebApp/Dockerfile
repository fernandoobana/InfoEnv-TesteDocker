FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

ENV INFO_VAR="Testando INFO VAR (Variável de ambiente)"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["InfoEnvWebApp/InfoEnvWebApp.csproj", "InfoEnvWebApp/"]
RUN dotnet restore "InfoEnvWebApp/InfoEnvWebApp.csproj"
COPY . .
WORKDIR "/src/InfoEnvWebApp"
RUN dotnet build "InfoEnvWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfoEnvWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InfoEnvWebApp.dll"]
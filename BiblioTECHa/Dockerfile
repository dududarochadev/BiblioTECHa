# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build-env /app/out .

# Expor a porta da aplicação
EXPOSE 80

# Entry point para iniciar a aplicação
ENTRYPOINT ["dotnet", "BiblioTECHa.dll"]

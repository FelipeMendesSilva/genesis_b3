# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo para dentro do contêiner
COPY . .

# Restaura e publica o projeto principal
RUN dotnet restore "Cdb.API/Cdb.API.csproj"
RUN dotnet publish "Cdb.API/Cdb.API.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Cdb.API.dll"]
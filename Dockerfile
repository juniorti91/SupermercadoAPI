# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiar apenas o .csproj primeiro
COPY ["SupermercadoAPI.csproj", "."]

# 2. Restaurar pacotes com configuração limpa
RUN dotnet restore "SupermercadoAPI.csproj" \
    --runtime linux-x64 \
    --verbosity detailed

# 3. Copiar o restante do código
COPY . .

# 4. Publicar explicitando runtime
RUN dotnet publish "SupermercadoAPI.csproj" \
    -c Release \
    -o /app/publish \
    --runtime linux-x64 \
    --self-contained false \
    /p:UseAppHost=false

# Estágio de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SupermercadoAPI.dll"]
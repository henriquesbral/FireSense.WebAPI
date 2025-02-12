# Etapa 1: Constru��o da aplica��o
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as depend�ncias
COPY ["FireSense.WebApi.csproj", "./"]
RUN dotnet restore

# Copia o restante dos arquivos e compila a aplica��o
COPY . .
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Constru��o da imagem final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copia a aplica��o publicada na etapa anterior
COPY --from=build /app/out .

# Define a porta exposta e o comando de entrada
EXPOSE 80
CMD ["dotnet", "FireSense.WebApi.dll"]
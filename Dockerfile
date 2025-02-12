# Etapa 1: Construção da aplicação
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY ["FireSense.WebApi.csproj", "./"]
RUN dotnet restore

# Copia o restante dos arquivos e compila a aplicação
COPY . .
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Construção da imagem final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copia a aplicação publicada na etapa anterior
COPY --from=build /app/out .

# Define a porta exposta e o comando de entrada
EXPOSE 80
CMD ["dotnet", "FireSense.WebApi.dll"]
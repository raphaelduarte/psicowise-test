# Use a imagem do SDK .NET 7.0 para construir o ambiente
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Exponha as portas necessárias
EXPOSE 80
EXPOSE 443

# Copie o arquivo de projeto e restaure as dependências
COPY ["Psicowise/Psicowise.csproj", "Psicowise/"]
RUN dotnet restore "Psicowise/Psicowise.csproj"

# Copie todos os arquivos da aplicação e publique o aplicativo
COPY Psicowise/. Psicowise/
WORKDIR /app/Psicowise
RUN dotnet publish -c Release -o out

# Use a imagem do runtime do .NET 7.0 para o container final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build-env /app/Psicowise/out .
COPY Psicowise/certs/https /app/certs/https
ENTRYPOINT ["dotnet", "Psicowise.dll"]
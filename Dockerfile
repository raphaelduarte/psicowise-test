# Usar uma imagem base do .NET ASP.NET para a fase de runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Usar uma imagem base do .NET SDK para a fase de build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar os arquivos de projeto e restaurar dependências
COPY ["Psicowise/Psicowise.csproj", "Psicowise/"]
COPY ["Psicowise.Infrastructure/Psicowise.Infrastructure.csproj", "Psicowise.Infrastructure/"]
COPY ["Psicowise.Domain/Psicowise.Domain.csproj", "Psicowise.Domain/"]
RUN dotnet restore "Psicowise/Psicowise.csproj"

# Copiar todo o código fonte e construir o projeto
COPY . .
WORKDIR "/src/Psicowise"
RUN dotnet build "Psicowise.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar o projeto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Psicowise.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Usar a imagem base do ASP.NET para a fase de runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Psicowise.dll"]
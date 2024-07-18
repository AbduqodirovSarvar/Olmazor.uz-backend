# Use the official .NET image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:5034

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OlmaTech.Api/OlmaTech.Api.csproj", "OlmaTech.Api/"]
COPY ["OlmaTech.Application/OlmaTech.Application.csproj", "OlmaTech.Application/"]
COPY ["OlmaTech.Domain/OlmaTech.Domain.csproj", "OlmaTech.Domain/"]
COPY ["OlmaTech.Infrastructure/OlmaTech.Infrastructure.csproj", "OlmaTech.Infrastructure/"]
RUN dotnet restore "./OlmaTech.Api/OlmaTech.Api.csproj"
COPY . .
WORKDIR "/src/OlmaTech.Api"
RUN dotnet build "./OlmaTech.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OlmaTech.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OlmaTech.Api.dll"]

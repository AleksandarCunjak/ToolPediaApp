#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ToolPedia/ToolPedia.Api.csproj", "ToolPedia/"]
COPY ["ToolPedia.Application/ToolPedia.Application.csproj", "ToolPedia.Application/"]
COPY ["ToolPedia.Domain/ToolPedia.Domain.csproj", "ToolPedia.Domain/"]
COPY ["ToolPedia.Infrastructure/ToolPedia.Infrastructure.csproj", "ToolPedia.Infrastructure/"]
RUN dotnet restore "./ToolPedia/ToolPedia.Api.csproj"
COPY . .
WORKDIR "/src/ToolPedia"
RUN dotnet build "./ToolPedia.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ToolPedia.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToolPedia.Api.dll"]
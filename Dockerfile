# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/MultiShop.Order.WebApi/MultiShop.Order.WebApi.csproj", "Presentation/MultiShop.Order.WebApi/"]
COPY ["Core/MultiShop.Order.Application/MultiShop.Order.Application.csproj", "Core/MultiShop.Order.Application/"]
COPY ["Core/MultiShop.Order.Domain/MultiShop.Order.Domain.csproj", "Core/MultiShop.Order.Domain/"]
COPY ["Infrastructure/MultiShop.Order.Persistence/MultiShop.Order.Persistence.csproj", "Infrastructure/MultiShop.Order.Persistence/"]
RUN dotnet restore "./Presentation/MultiShop.Order.WebApi/MultiShop.Order.WebApi.csproj"
COPY . .
WORKDIR "/src/Presentation/MultiShop.Order.WebApi"
RUN dotnet build "./MultiShop.Order.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MultiShop.Order.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultiShop.Order.WebApi.dll"]
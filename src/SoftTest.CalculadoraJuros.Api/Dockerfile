#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SoftTest.CalculadoraJuros.Api/SoftTest.CalculadoraJuros.Api.csproj", "SoftTest.CalculadoraJuros.Api/"]
COPY ["SoftTest.CalculadoraJuros.Data/SoftTest.CalculadoraJuros.Data.csproj", "SoftTest.CalculadoraJuros.Data/"]
COPY ["SoftTest.CalculadoraJuros.Domain/SoftTest.CalculadoraJuros.Domain.csproj", "SoftTest.CalculadoraJuros.Domain/"]
COPY ["SoftTest.Shared/SoftTest.Shared.csproj", "SoftTest.Shared/"]
RUN dotnet restore "SoftTest.CalculadoraJuros.Api/SoftTest.CalculadoraJuros.Api.csproj"

COPY . .
RUN dotnet build "SoftTest.CalculadoraJuros.Api/SoftTest.CalculadoraJuros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SoftTest.CalculadoraJuros.Api/SoftTest.CalculadoraJuros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftTest.CalculadoraJuros.Api.dll"]
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["FrogPay.Galdino/FrogPay.Galdino.csproj", "FrogPay.Galdino/"]
RUN dotnet restore "FrogPay.Galdino/FrogPay.Galdino.csproj"
COPY . .
WORKDIR "/src/FrogPay.Galdino"
RUN dotnet build "FrogPay.Galdino.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrogPay.Galdino.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrogPay.Galdino.dll"]

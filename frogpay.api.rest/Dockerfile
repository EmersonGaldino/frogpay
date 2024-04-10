FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["frogpay.api.rest/frogpay.api.rest.csproj", "frogpay.api.rest/"]
RUN dotnet restore "frogpay.api.rest/frogpay.api.rest.csproj"
COPY . .
WORKDIR "/src/frogpay.api.rest"
RUN dotnet build "frogpay.api.rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "frogpay.api.rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "frogpay.api.rest.dll"]

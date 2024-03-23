FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AICodingGame.WebAPI/AICodingGame.WebAPI.csproj", "AICodingGame.WebAPI/"]
RUN dotnet restore "AICodingGame.WebAPI/AICodingGame.WebAPI.csproj"
COPY . .
WORKDIR "/src/AICodingGame.WebAPI"
RUN dotnet build "AICodingGame.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AICodingGame.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AICodingGame.WebAPI.dll"]

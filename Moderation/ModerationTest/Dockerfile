FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ModerationTest/ModerationTest.csproj", "ModerationTest/"]
RUN dotnet restore "ModerationTest/ModerationTest.csproj"
COPY . .
WORKDIR "/src/ModerationTest"
RUN dotnet build "ModerationTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ModerationTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ModerationTest.dll"]

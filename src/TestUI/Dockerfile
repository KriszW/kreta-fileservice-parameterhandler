#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestUI/TestUI.csproj", "src/TestUI/"]
COPY ["src/Library/Library.csproj", "src/Library/"]
COPY ["src/Caching/Caching.csproj", "src/Caching/"]
RUN dotnet restore "src/TestUI/TestUI.csproj"
COPY . .
WORKDIR "/src/src/TestUI"
RUN dotnet build "TestUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestUI.dll"]
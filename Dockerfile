#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DOTNET-WEB-SAMPLE/DOTNET-WEB-SAMPLE.csproj", "DOTNET-WEB-SAMPLE/"]
RUN dotnet restore "DOTNET-WEB-SAMPLE/DOTNET-WEB-SAMPLE.csproj"
COPY . .
WORKDIR "/src/DOTNET-WEB-SAMPLE"
RUN dotnet build "DOTNET-WEB-SAMPLE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DOTNET-WEB-SAMPLE.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DOTNET-WEB-SAMPLE.dll"]
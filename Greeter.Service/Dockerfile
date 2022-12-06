#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Greeter.Service/Greeter.Service.csproj", "Greeter.Service/"]
COPY ["Greeter.Interfaces/Greeter.Interfaces.csproj", "Greeter.Interfaces/"]
RUN dotnet restore "Greeter.Service/Greeter.Service.csproj"
COPY . .
WORKDIR "/src/Greeter.Service"
RUN dotnet build "Greeter.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Greeter.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Greeter.Service.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80 #http默认端口
EXPOSE 443 #https默认端口

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SmartHealthcare.Api/SmartHealthcare.Api.csproj", "SmartHealthcare.Api/"]
COPY ["SmartHealthcare.Infrastructure/SmartHealthcare.Infrastructure.csproj", "SmartHealthcare.Infrastructure/"]
COPY ["SmartHealthcare.Domain/SmartHealthcare.Domain.csproj", "SmartHealthcare.Domain/"]
COPY ["SmartHealthcare.Interface/SmartHealthcare.Interface.csproj", "SmartHealthcare.Interface/"]
COPY ["SmartHealthcare.Service/SmartHealthcare.Service.csproj", "SmartHealthcare.Service/"]
RUN dotnet restore "SmartHealthcare.Api/SmartHealthcare.Api.csproj"
COPY . .
WORKDIR "/src/SmartHealthcare.Api"
RUN dotnet build "SmartHealthcare.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartHealthcare.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartHealthcare.Api.dll"]
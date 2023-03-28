#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Global.UserAudit.Api/Global.UserAudit.Api.csproj", "Global.UserAudit.Api/"]
RUN dotnet restore "Global.UserAudit.Api/Global.UserAudit.Api.csproj"
COPY . .
WORKDIR "/src/Global.UserAudit.Api"
RUN dotnet build "Global.UserAudit.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Global.UserAudit.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Global.UserAudit.Api.dll"]
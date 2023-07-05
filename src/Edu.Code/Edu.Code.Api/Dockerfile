FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# syntax = docker/dockerfile:1.2
RUN --mount=type=secret,id=_env,dst=/etc/secrets/.env cat /etc/secrets/.env

RUN ls /src

RUN ls /src/Edu.Code.Api

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Edu.Code.Api/Edu.Code.Api.csproj", "Edu.Code.Api/"]
RUN dotnet restore "Edu.Code.Api/Edu.Code.Api.csproj"
COPY . .
WORKDIR "/src/Edu.Code.Api"
RUN dotnet build "Edu.Code.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Edu.Code.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Edu.Code.Api.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# syntax = docker/dockerfile:1.2
RUN --mount=type=secret,id=_env,dst=/etc/secrets/.env cat /etc/secrets/.env
RUN echo $.env

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src
COPY ["Edu.Code.Api/Edu.Code.Api.csproj", "Edu.Code.Api/"]

COPY ./ ./

RUN dotnet restore "Edu.Code.Api/Edu.Code.Api.csproj"

WORKDIR /src/Edu.Code.Api
RUN dotnet build "Edu.Code.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Edu.Code.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Edu.Code.Api.dll"]
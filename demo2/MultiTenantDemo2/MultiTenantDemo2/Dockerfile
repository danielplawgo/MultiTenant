#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MultiTenantDemo2/MultiTenantDemo2.csproj", "MultiTenantDemo2/"]
RUN dotnet restore "MultiTenantDemo2/MultiTenantDemo2.csproj"
COPY . .
WORKDIR "/src/MultiTenantDemo2"
RUN dotnet build "MultiTenantDemo2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MultiTenantDemo2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultiTenantDemo2.dll"]
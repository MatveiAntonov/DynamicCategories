#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductApp.WebApi/ProductApp.WebApi.csproj", "ProductApp.WebApi/"]
COPY ["ProductApp.Persistence/ProductApp.Persistence.csproj", "ProductApp.Persistence/"]
COPY ["ProductApp.Application/ProductApp.Application.csproj", "ProductApp.Application/"]
COPY ["ProductApp.Domain/ProductApp.Domain.csproj", "ProductApp.Domain/"]
RUN dotnet restore "ProductApp.WebApi/ProductApp.WebApi.csproj"
COPY . .
WORKDIR "/src/ProductApp.WebApi"
RUN dotnet build "ProductApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductApp.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:9001
ENTRYPOINT ["dotnet", "ProductApp.WebApi.dll"]
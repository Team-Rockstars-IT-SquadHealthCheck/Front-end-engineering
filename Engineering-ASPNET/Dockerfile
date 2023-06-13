#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Engineering-ASPNET/Engineering-ASPNET.csproj", "Engineering-ASPNET/"]
COPY ["Engineering-ASPNET.BLL/Engineering-ASPNET.BLL.csproj", "Engineering-ASPNET.BLL/"]
COPY ["Engineering-ASPNET.DAL/Engineering-ASPNET.DAL.csproj", "Engineering-ASPNET.DAL/"]
COPY ["Engineering-ASPNET/wwwroot", "wwwroot/"]
RUN dotnet restore "Engineering-ASPNET/Engineering-ASPNET.csproj"
COPY . .
WORKDIR "/src/Engineering-ASPNET"
RUN dotnet build "Engineering-ASPNET.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Engineering-ASPNET.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Engineering-ASPNET.dll"]

RUN ls -la /app/wwwroot/images/Logo.png
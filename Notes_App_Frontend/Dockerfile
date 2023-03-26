FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Notes_App_Frontend/Notes_App_Frontend.csproj", "Notes_App_Frontend/"]
RUN dotnet restore "Notes_App_Frontend/Notes_App_Frontend.csproj"
COPY . .
WORKDIR "/src/Notes_App_Frontend"
RUN dotnet build "Notes_App_Frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notes_App_Frontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notes_App_Frontend.dll"]

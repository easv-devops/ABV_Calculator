FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ABV_Calculator/ABV_Calculator.csproj", "ABV_Calculator/"]
RUN dotnet restore "ABV_Calculator/ABV_Calculator.csproj"
COPY . .
WORKDIR "/src/ABV_Calculator"
RUN dotnet build "ABV_Calculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ABV_Calculator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ABV_Calculator.dll"]

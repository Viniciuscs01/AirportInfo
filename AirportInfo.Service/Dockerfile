FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 62788
EXPOSE 44303

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AirportInfo.Service/AirportInfo.Service.csproj", "AirportInfo.Service/"]
RUN dotnet restore "AirportInfo.Service/AirportInfo.Service.csproj"
COPY . .
WORKDIR "/src/AirportInfo.Service"
RUN dotnet build "AirportInfo.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AirportInfo.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AirportInfo.Service.dll"]
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CURD/CURD.csproj", "CURD/"]
COPY ["DataLayer/DataLayer.csproj", "DataLayer/"]
COPY ["Servises/Servises.csproj", "Servises/"]
RUN dotnet restore "CURD/CURD.csproj"
COPY . .
WORKDIR "/src/CURD"
RUN dotnet build "CURD.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CURD.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CURD.dll"]
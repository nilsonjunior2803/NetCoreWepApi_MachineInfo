FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ./ MachineInfo.API/
RUN dotnet restore MachineInfo.API/MachineInfo.API.csproj
COPY . .
WORKDIR /src/MachineInfo.API
RUN dotnet build MachineInfo.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MachineInfo.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MachineInfo.API.dll"]
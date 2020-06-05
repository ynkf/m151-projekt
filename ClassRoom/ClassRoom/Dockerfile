FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs
COPY ["ClassRoom/ClassRoom/ClassRoom.csproj", "ClassRoom/ClassRoom/"]
RUN dotnet restore "ClassRoom/ClassRoom/ClassRoom.csproj"
COPY . .
WORKDIR "/src/ClassRoom/ClassRoom"
RUN dotnet build "ClassRoom.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClassRoom.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassRoom.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebAppBot/*.csproj ./WebAppBot/
RUN dotnet restore "WebAppBot/WebAppBot.csproj"

# copy everything else and build app
COPY WebAppBot/. ./WebAppBot/
WORKDIR /source/WebAppBot
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "WebAppBot.dll"]
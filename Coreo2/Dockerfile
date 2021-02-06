# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln /app
COPY *.csproj /app
RUN ls -la
RUN dotnet restore
RUN ls -la

# copy everything else and build app
COPY . /app
RUN ls -l
RUN dotnet publish -c Release -o /app/out --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Coreo.dll", "subscribe"]
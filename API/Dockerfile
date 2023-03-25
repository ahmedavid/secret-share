FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
RUN dotnet tool install --global dotnet-ef
RUN dotnet ef database update

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
ENTRYPOINT [ "dotnet", "API.dll" ]
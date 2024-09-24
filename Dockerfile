# Use the official Microsoft .NET SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project and build the release version
COPY . ./
RUN dotnet publish -c Release -o /out

# Use the official Microsoft ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Expose the port your application will run on (e.g., 80)
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "WeatherUpdates.dll"]

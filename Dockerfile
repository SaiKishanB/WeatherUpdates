# Use the .NET SDK base image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project into the container
COPY . ./

# Build the release version of the application
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory in the runtime container
WORKDIR /app

# Copy the published output from the build container
COPY --from=build /app/out .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "WeatherUpdates.dll"]

#!/bin/bash

# Build and package UCP.NET for NuGet
set -e

echo "Building UCP.NET NuGet package..."

# Clean previous builds
rm -rf src/UCP.NET/bin src/UCP.NET/obj

# Restore dependencies
echo "Restoring dependencies..."
dotnet restore src/UCP.NET/UCP.NET.csproj

# Build in Release mode
echo "Building in Release mode..."
dotnet build src/UCP.NET/UCP.NET.csproj --configuration Release --no-restore

# Create NuGet package
echo "Creating NuGet package..."
dotnet pack src/UCP.NET/UCP.NET.csproj --configuration Release --no-build --output ./artifacts

echo "NuGet package created successfully!"
echo "Package location: ./artifacts/"
ls -lh ./artifacts/*.nupkg

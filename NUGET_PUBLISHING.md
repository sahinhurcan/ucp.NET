# Publishing UCP.NET to NuGet.org

This guide explains how to publish the UCP.NET library to NuGet.org.

## Prerequisites

1. **NuGet.org Account**: Create an account at [nuget.org](https://www.nuget.org/)
2. **API Key**: Generate an API key from your NuGet.org account settings
3. **GitHub Secret**: Add your NuGet API key as a secret named `NUGET_API_KEY` in your GitHub repository settings

## Automatic Publishing (Recommended)

The repository is configured with GitHub Actions to automatically publish to NuGet.org when you create a release.

### Steps:

1. **Update Version** (if needed):
   Edit `src/UCP.NET/UCP.NET.csproj` and update the `<Version>` property:
   ```xml
   <Version>1.0.1</Version>
   ```

2. **Commit and Push**:
   ```bash
   git add src/UCP.NET/UCP.NET.csproj
   git commit -m "chore: bump version to 1.0.1"
   git push origin main
   ```

3. **Create a Release on GitHub**:
   - Go to https://github.com/sahinhurcan/ucp.NET/releases/new
   - Create a new tag (e.g., `v1.0.1`)
   - Set release title (e.g., "v1.0.1")
   - Add release notes describing changes
   - Click "Publish release"

4. **Automatic Publishing**:
   GitHub Actions will automatically:
   - Build the project
   - Create the NuGet package
   - Publish to NuGet.org

5. **Verify**:
   Check your package at: https://www.nuget.org/packages/UCP.NET/

## Manual Publishing

If you prefer to publish manually:

### 1. Build and Pack

```bash
cd src/UCP.NET
dotnet build --configuration Release
dotnet pack --configuration Release --output ./nupkg
```

### 2. Publish to NuGet.org

```bash
dotnet nuget push ./nupkg/UCP.NET.1.0.0.nupkg \
  --api-key YOUR_NUGET_API_KEY \
  --source https://api.nuget.org/v3/index.json
```

### 3. Verify

Your package will be available at:
- https://www.nuget.org/packages/UCP.NET/

## Package Information

**Package Details:**
- **Package ID**: UCP.NET
- **Description**: A .NET client library for Universal Commerce Protocol (UCP)
- **License**: Apache-2.0
- **Repository**: https://github.com/sahinhurcan/ucp.NET
- **Target Framework**: .NET 8.0

**Package Contents:**
- UCP.NET.dll - Main library with all UCP models and client
- XML documentation for IntelliSense support
- README.md with quick start guide

## Installation

Once published, users can install the package via:

```bash
dotnet add package UCP.NET
```

Or via Package Manager Console:
```powershell
Install-Package UCP.NET
```

Or add to .csproj:
```xml
<PackageReference Include="UCP.NET" Version="1.0.0" />
```

## Version Management

This project follows [Semantic Versioning](https://semver.org/):

- **MAJOR version** (1.x.x): Incompatible API changes
- **MINOR version** (x.1.x): New functionality (backwards-compatible)
- **PATCH version** (x.x.1): Bug fixes (backwards-compatible)

### Version Update Checklist:

- [ ] Update `<Version>` in `src/UCP.NET/UCP.NET.csproj`
- [ ] Update CHANGELOG.md with changes
- [ ] Update README.md if API changed
- [ ] Commit changes
- [ ] Create GitHub release with tag
- [ ] Wait for automatic publishing
- [ ] Verify on NuGet.org

## Troubleshooting

### "Package already exists"
- Increment the version number
- NuGet.org doesn't allow republishing the same version

### "Invalid API Key"
- Verify your API key in GitHub Secrets
- Generate a new API key if needed

### "Build failed"
- Check GitHub Actions logs
- Ensure all tests pass
- Fix any build warnings/errors

### "Package not appearing"
- Wait a few minutes for indexing
- Check package validation status on NuGet.org

## Support

For issues or questions:
- GitHub Issues: https://github.com/sahinhurcan/ucp.NET/issues
- UCP Documentation: https://ucp.dev/

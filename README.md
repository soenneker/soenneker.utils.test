[![](https://img.shields.io/nuget/v/Soenneker.Utils.Test.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.Test/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.test/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.test/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.Test.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.Test/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.test/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.test/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.Test
A utility library for useful test-based operations.

## Installation

```bash
dotnet add package Soenneker.Utils.Test
```

## Quick start

```csharp
using Soenneker.Utils.Test;
```

Call the static `TestUtil` methods directly; no dependency-injection registration is required.

## Common operations

- `BuildConfig()` - Builds and returns an `IConfiguration` from appsettings.json in the current directory (optionally plus a child path if there are multiple appsettings needed).

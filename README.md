[![](https://img.shields.io/nuget/v/Soenneker.Utils.Test.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.Test/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.test/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.test/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.Test.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.Test/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.test/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.test/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.Test
A small test helper for building JSON configuration relative to the test process's working directory.

## Installation

```bash
dotnet add package Soenneker.Utils.Test
```

## Basic usage

```csharp
using Soenneker.Utils.Test;

IConfiguration configuration = TestUtil.BuildConfig();
```

This requires `appsettings.json` in `Directory.GetCurrentDirectory()`. The file is loaded once; change monitoring is disabled.

## Child directories and custom files

```csharp
IConfiguration configuration = TestUtil.BuildConfig(
    childPath: "Fixtures",
    fileName: "integration-settings.json");
```

That reads:

```text
<current working directory>/Fixtures/integration-settings.json
```

The base file is required. Missing files and malformed JSON propagate configuration-provider exceptions to the caller.

## Environment overlay

```csharp
IConfiguration configuration = TestUtil.BuildConfig(
    environmentName: "Development");
```

The helper first loads the required base file, then optionally loads `appsettings.Development.json` from the same directory. The environment file is optional and its values override the base configuration.

The overlay name is always `appsettings.{environmentName}.json`. Supplying a custom base filename does not change that convention.

Call `TestUtil.BuildConfig` directly; no dependency-injection registration is required. Because resolution starts from `Directory.GetCurrentDirectory()`, ensure your test runner copies settings files to its working directory or pass the appropriate child path.

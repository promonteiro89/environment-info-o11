# Environment Info Extension for OutSystems 11

[![CI](https://github.com/promonteiro89/environment-info-o11/actions/workflows/ci.yml/badge.svg)](https://github.com/promonteiro89/environment-info-o11/actions/workflows/ci.yml)
[![Platform](https://img.shields.io/badge/Platform-OutSystems_11-red.svg)](https://www.outsystems.com/)
[![.NET](https://img.shields.io/badge/.NET_Framework-4.8-blue.svg)](https://dotnet.microsoft.com/download/dotnet-framework/net48)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

An Integration Studio extension (.NET Framework 4.8) that gives OutSystems 11 apps information about the environment they run on: its name, key, hostname and server mode, the Front-End serving the request, the client IP, and server runtime details.

## Table of Contents

- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Action Reference](#action-reference)
- [Data Structures](#data-structures)
- [Build and Deployment](#build-and-deployment)
- [Best Practices](#best-practices)
- [Contributing](#contributing)
- [License](#license)

---

## Architecture

```
EnvironmentInfo_Ext.xif             # The extension: open this in Integration Studio
Source/NET/                         # Mirror of the .NET source packaged in the .xif
├── EnvironmentInfo_Ext.csproj      # Project definition (.NET Framework 4.8)
├── Interface.cs                    # Action signatures (IssEnvironmentInfo_Ext)
├── EnvironmentInfo_Ext.cs          # Implementation
├── AssemblyInfo.cs
├── Structures.cs / Records.cs / RecordLists.cs / Entities.cs   # Generated OutSystems data types
└── Bin/                            # Platform assemblies (not committed) and build output
```

### Design notes

- Environment name, key, server mode and Front-End name come from the platform's `AppInfo`; the hostname is the environment's configured default DNS name (`EspaceProperties.DefaultDnsName`).
- The extension has no inputs, no credentials, no Site Properties and no third-party dependencies, so there is nothing to configure.
- Every action only reads state and can be called from any server action, screen, Timer or BPT. Only `GetClientIPAddress` depends on the HTTP request.
- The platform reads the server mode from the system database on each call. If that read fails, the platform logs an error and reports `Development`.
- These actions are server-side diagnostics. Don't return their values to anonymous users, client-side logic or public REST APIs: the environment key, hostname, Front-End name and runtime details help an attacker map your infrastructure.
- Text outputs are never null: a value the platform can't provide is returned as an empty string.

---

## Prerequisites

- OutSystems 11 with Integration Studio (matching your environment version)
- .NET Framework 4.8 targeting pack

---

## Action Reference

None of the actions has inputs.

#### `GetEnvironmentName`
Retrieves the name of the current running environment.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `EnvironmentName` | Out | Text | Name of the environment |

#### `GetEnvironmentKey`
Retrieves the key of the current running environment.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `EnvironmentKey` | Out | Text | Key of the environment |

#### `GetEnvironmentHostname`
Returns the environment's default DNS name as configured in the platform, for example `env-dev.outsystemsenterprise.com`. It's read from configuration, not from the HTTP request, so Timers and BPTs get the same value as screens.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `Hostname` | Out | Text | The environment's default DNS name. Empty if none is configured. This is not the server's machine name (see `RuntimeInfo.MachineName`) |

#### `GetEnvironmentServerMode`
Retrieves the environment's current Server Mode, as the platform's numeric Id and enum name. See [`ServerMode`](#servermode) for the values.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `ServerMode` | Out | `ServerMode` | The current mode |

#### `GetEnvironmentServerModes`
Lists every value of the platform's server mode enum, with its Id. Unlike `GetEnvironmentServerMode`, which returns the current mode, this is a fixed list: it doesn't query the environment.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `ServerModes` | Out | List of `ServerMode` | Every valid server mode (Id and Name) |

#### `IsProductionEnvironment`
Checks whether the environment is configured as a Production environment. It returns a Boolean, so you can use it directly in an If.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `IsProductionEnvironment` | Out | Boolean | True if the server mode is Production (Id 4), False otherwise |

It returns False in every other mode, including Disaster Recovery. So "not production" isn't the same as "development": to switch on debug features, check for Development explicitly rather than negating this action.

#### `GetFrontEndName`
Retrieves the name of the Front-End server running the current process. Meant for diagnostics, technical logging and auditing: in a request, it tells you which Front-End handled it; in a Timer or BPT, which Front-End ran the job.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `FrontEndName` | Out | Text | Name of the Front-End server |

#### `GetClientIPAddress`
Returns the client IP address of the current HTTP request, using the platform's `RuntimePlatformUtils.GetRequestRealIP`. If trusted proxies are configured in Service Center, the `X-Forwarded-For` header is honoured only when it comes from one of them. Otherwise, the first `X-Forwarded-For` entry is used. Empty or `unknown` entries fall back to the connection's address. It returns an empty string when there's no HTTP request.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `IPAddress` | Out | Text | Client IP address. Empty when there is no HTTP request |

The value is informational. It's only trustworthy for security decisions when the trusted proxies setting in Service Center is configured.

#### `GetRuntimeInfo`
Returns server runtime information, useful for support diagnostics.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `RuntimeInfo` | Out | `RuntimeInfo` | CLR version, OS, machine name, CPU count and bitness |

---

## Data Structures

### `ServerMode`
A server mode of the environment: the platform's `ServerModes` enum value and name.
- `Id`: Integer
- `Name`: Text, the enum member name (multi-word names have no spaces)

| Id | Name |
|---|---|
| 0 | `Development` |
| 1 | `NonProduction` |
| 2 | `DisasterRecovery` |
| 3 | `Management` |
| 4 | `Production` |

Prefer `IsProductionEnvironment` or comparing `Name` over hard-coding the Id.

### `RuntimeInfo`
Runtime details of the server running the action.
- `CLRVersion`: Text. Despite the name, this is the .NET Framework description (`RuntimeInformation.FrameworkDescription`, such as `.NET Framework 4.8.<build>.0`), not the CLR version
- `OSVersion`: Text, from `Environment.OSVersion`
- `MachineName`: Text, the Windows name of the server that ran the action
- `ProcessorCount`: Integer
- `Is64BitOS`: Boolean
- `Is64BitProcess`: Boolean

---

## Build and Deployment

The project has no `packages.config` or `PackageReference`. Integration Studio needs referenced assemblies as plain DLLs in `Bin\`, referenced through `<HintPath>`.

The OutSystems platform assemblies are not in the repo; they are proprietary and come with Integration Studio. Copy these into `Source/NET/Bin/` from your Integration Studio installation, or from the `Bin\` folder of any extension in your environment:

- `OutSystems.RuntimeCommon.dll`
- `OutSystems.HubEdition.RuntimePlatform.dll`
- `OutSystems.HubEdition.DatabaseAbstractionLayer.dll`
- `OutSystems.REST.API.dll`
- `OutSystems.SOAP.API.dll`

To publish:

1. Open `EnvironmentInfo_Ext.xif` in Integration Studio.
2. To change the code, click **Edit Source Code .NET**, which opens the project in Visual Studio.
3. Run Verify, which compiles the .NET code.
4. Run 1-Click Publish to publish to your environment.

`Source/NET/` mirrors the source packaged in the `.xif`, so changes can be reviewed on GitHub. After changing the extension, copy its source files back into `Source/NET/` in the same commit.

---

## Best Practices

- Use the server mode to switch behaviour per environment instead of comparing the environment name, which differs between customers. Enable debug features only when the mode is `Development`, not whenever `IsProductionEnvironment` is False: that would also enable them in Disaster Recovery.
- Keep the outputs server-side. Don't show the environment key, hostname, Front-End name or runtime details to anonymous users or return them from public APIs.
- Log `GetFrontEndName` with errors and audit entries to trace a request to the Front-End that served it.
- Don't rely on `GetClientIPAddress` in Timers and BPTs: there's no end-user request there.

---

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for the workflow, build steps and coding conventions.

---

## License

MIT. See [LICENSE](LICENSE).

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
Source/NET/
├── EnvironmentInfo_Ext.csproj      # Project definition (.NET Framework 4.8)
├── Interface.cs                    # Action signatures (IssEnvironmentInfo_Ext)
├── EnvironmentInfo_Ext.cs          # Implementation
├── AssemblyInfo.cs
├── Structures.cs / Records.cs / RecordLists.cs / Entities.cs   # Generated OutSystems data types
└── Bin/                            # Platform assemblies (not committed) and build output
```

### Design notes

- Environment name, key, server mode and Front-End name come from the platform's `AppInfo`; the hostname comes from `EspaceProperties.DefaultDnsName`.
- The extension has no inputs, no credentials, no Site Properties and no third-party dependencies, so there is nothing to configure.
- Every action only reads state, so calling them is cheap and they can be called from any server action, screen, Timer or BPT.

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
Returns the hostname of the current environment, for example `env-dev.outsystemsenterprise.com`. In background jobs (Timers, BPTs) and other non-HTTP contexts the value is the same.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `Hostname` | Out | Text | The resolved hostname of the server |

#### `GetEnvironmentServerMode`
Retrieves the environment's current Server Mode, as an identifier and a readable name (for example Development or Production).

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `ServerMode` | Out | `ServerMode` | The current mode |

#### `GetEnvironmentServerModes`
Retrieves all supported Server Modes with their identifiers. Unlike `GetEnvironmentServerMode`, which returns the current mode, this returns the static list of every possible mode.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `ServerModes` | Out | List of `ServerMode` | Every valid server mode (Id and Name) |

#### `IsProductionEnvironment`
Checks whether the environment is configured as a Production environment. It returns a Boolean, so you can use it directly in an If.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `IsProductionEnvironment` | Out | Boolean | True if the server mode is Production (ID 2), False otherwise |

#### `GetFrontEndName`
Retrieves the name of the Front-End server running the current process. Meant for diagnostics, technical logging and auditing: it tells you which Front-End handled a request.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `FrontEndName` | Out | Text | Name of the Front-End server |

#### `GetClientIPAddress`
Returns the IP address of the client making the current HTTP request. Front-Ends usually sit behind a load balancer or reverse proxy, so the first entry of the `X-Forwarded-For` header is used when present, and the connection's address otherwise.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `IPAddress` | Out | Text | Client IP address. Empty in non-HTTP contexts (Timers, BPTs, async logic) |

`X-Forwarded-For` is set by the client or by a proxy, so treat the result as informational. Don't use it for access control unless your load balancer overwrites that header.

#### `GetRuntimeInfo`
Returns server runtime information, useful for support diagnostics.

| Parameter | Direction | Type | Description |
|---|---|---|---|
| `RuntimeInfo` | Out | `RuntimeInfo` | CLR version, OS, machine name, CPU count and bitness |

---

## Data Structures

### `ServerMode`
A server mode of the environment.
- `Id`: Integer (Production is `2`)
- `Name`: Text (for example `Production`)

### `RuntimeInfo`
Runtime details of the server running the action.
- `CLRVersion`: Text (the framework description)
- `OSVersion`: Text
- `MachineName`: Text
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

1. Open `Source/NET/EnvironmentInfo_Ext.sln` in Integration Studio.
2. Run Verify, which compiles the .NET code.
3. Run 1-Click Publish to publish to your environment.

---

## Best Practices

- Use `IsProductionEnvironment` to switch behaviour per environment (for example hiding debug screens) instead of comparing the environment name, which differs between customers.
- Log `GetFrontEndName` with errors and audit entries to trace a request to the Front-End that served it.
- Don't rely on `GetClientIPAddress` in Timers and BPTs: it returns an empty string there.

---

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for the workflow, build steps and coding conventions.

---

## License

MIT. See [LICENSE](LICENSE).

# Changelog

All notable changes to the Environment Info extension for OutSystems 11 are documented here. Versions follow [Semantic Versioning](https://semver.org/) and match the versions published on OutSystems Forge.

## [1.3.1]

### Fixed

- `GetClientIPAddress` now uses the platform's real-IP logic, so trusted proxies configured in Service Center are honoured. It returns an empty string instead of throwing an `HttpException` when the HTTP context has no request.
- `GetEnvironmentName`, `GetEnvironmentKey`, `GetFrontEndName`, `IsProductionEnvironment` and `GetEnvironmentServerMode` no longer throw when the platform context is unavailable. They return an empty string, `False`, or a `ServerMode` with Id 0 and an empty Name.

### Changed

- `GetRuntimeInfo` returns an empty `OSVersion` or `MachineName` when the server can't read it, instead of failing the whole action.
- Corrected the action and parameter descriptions in Service Studio. `Production` is server mode Id 4, not 2 (Id 2 is `DisasterRecovery`). The outputs are described as server-side only, and the hostname as the configured default DNS name.

## [1.3.0]

The version on OutSystems Forge when this repository was created. Earlier versions are not recorded here.

Actions: `GetEnvironmentName`, `GetEnvironmentKey`, `GetEnvironmentHostname`, `GetEnvironmentServerMode`, `GetEnvironmentServerModes`, `IsProductionEnvironment`, `GetFrontEndName`, `GetClientIPAddress` and `GetRuntimeInfo`. Structures: `ServerMode` and `RuntimeInfo`.

[1.3.1]: https://github.com/promonteiro89/environment-info-o11/releases/tag/v1.3.1
[1.3.0]: https://github.com/promonteiro89/environment-info-o11/tree/main

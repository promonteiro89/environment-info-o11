# Changelog

All notable changes to the Environment Info extension for OutSystems 11 are documented here. Versions follow [Semantic Versioning](https://semver.org/) and match the versions published on OutSystems Forge.

## [1.4.0]

### Added

- `scripts/update-cloudfront-ranges.py`, which regenerates the AWS CloudFront origin-facing IP ranges that `GetClientIPAddress` uses. The ranges come from `https://ip-ranges.amazonaws.com/ip-ranges.json`.
- A monthly GitHub workflow (`cloudfront-ranges.yml`) that fails when AWS changes the ranges, so they can be regenerated.
- Unit tests for the client IP resolver (`tests/run.sh`). CI runs them too.

### Fixed

- `GetEnvironmentName`, `GetEnvironmentKey`, `GetFrontEndName`, `IsProductionEnvironment` and `GetEnvironmentServerMode` no longer throw when the platform context is unavailable. They return an empty string, `False`, or a `ServerMode` with Id 0 and an empty Name.

### Changed

- **Breaking:** `GetClientIPAddress` now reads `X-Forwarded-For` from the right. When the platform's trusted proxies are enabled (they are on OutSystems Cloud), it skips them and AWS CloudFront's origin-facing IP ranges, and returns the first other address. On OutSystems Cloud, a forged `X-Forwarded-For` header used to return the forged value; it now returns the real visitor. When trusted proxies are disabled, it still returns the first `X-Forwarded-For` entry. Ports are removed, IPv6 is canonicalised, and empty, `unknown` or invalid values fall back to the connection address. It returns an empty string when there is no HTTP request. If you put your own CDN in front of OutSystems Cloud, the action now returns that CDN's edge address, unless you add its ranges as trusted proxies in Service Center.
- `GetRuntimeInfo` returns an empty `OSVersion` or `MachineName` when the server can't read it, instead of failing the whole action.
- Corrected the action and parameter descriptions in Service Studio. `Production` is server mode Id 4, not 2 (Id 2 is `DisasterRecovery`). The outputs are described as server-side only, and the hostname as the configured default DNS name.

## [1.3.0]

The version on OutSystems Forge when this repository was created. Earlier versions are not recorded here.

Actions: `GetEnvironmentName`, `GetEnvironmentKey`, `GetEnvironmentHostname`, `GetEnvironmentServerMode`, `GetEnvironmentServerModes`, `IsProductionEnvironment`, `GetFrontEndName`, `GetClientIPAddress` and `GetRuntimeInfo`. Structures: `ServerMode` and `RuntimeInfo`.

[1.4.0]: https://github.com/promonteiro89/environment-info-o11/releases/tag/v1.4.0
[1.3.0]: https://github.com/promonteiro89/environment-info-o11/tree/main

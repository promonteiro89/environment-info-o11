# Changelog

All notable changes to the Environment Info extension for OutSystems 11 are documented here. Versions follow [Semantic Versioning](https://semver.org/) and match the versions published on OutSystems Forge.

## [1.5.1]

Fixes for issues found in 1.5.0. No action or structure was added, removed or renamed.

### Fixed

- The Text attributes of `EnvironmentInfo`, `ModuleInfo` and `RequestInfo` were 50 characters long, so an entity created from these structures cut off URLs and user agents. `Url`, `Path`, `QueryString` and `Referrer` are now 2000 characters, `UserAgent` 500, and names, hosts and the hostname 250. Keys and the server mode name stay at 50.
- `GetEnvironmentName`, `GetEnvironmentKey`, `GetFrontEndName`, `IsProductionEnvironment`, `GetEnvironmentServerMode` and `GetEnvironmentHostname` could still throw when the platform lookup failed, for example on a licensing or system database error. They now return an empty string, `False` or an empty `ServerMode`, like the 1.5.0 actions.
- `GetClientIPAddress` could throw if the request headers or the trusted-proxy settings couldn't be read. It now returns the connection address instead, never the forgeable `X-Forwarded-For`.
- `GetRuntimeInfo` could throw on hosts that refuse to give the framework description, OS version or machine name. That value is now returned empty.
- `scripts/update-cloudfront-ranges.py` wrote an empty range list when the AWS feed had no CloudFront ranges. It now stops with an error and leaves the file unchanged.

### Documentation

- `IsDevelopmentEnvironment` and `GetEnvironmentInfo`: when the platform can't read the server mode, it reports Development, so `IsDevelopmentEnvironment` returns True even in Production. Don't use it alone to expose sensitive debug features.
- `GetRequestInfo`: the scheme, host, port and HTTPS flag describe the connection the Front-End received, on OutSystems Cloud too. The README no longer says they are always the public ones there.
- The README lists the length of every Text attribute in the new structures.

## [1.5.0]

New actions only. The existing actions and structures are unchanged, so current consumers don't need to change anything.

### Added

- `IsDevelopmentEnvironment`, `IsNonProductionEnvironment` and `IsDisasterRecoveryEnvironment`: Boolean checks for the other server modes, usable directly in an If like `IsProductionEnvironment`. Use `IsDevelopmentEnvironment` to turn on debug features instead of "not `IsProductionEnvironment`", which is also True in Disaster Recovery.
- `GetEnvironmentInfo`: the environment's name, key, hostname, Front-End name and server mode (Id, Name and one flag per mode) in one `EnvironmentInfo` structure. It reads the server mode once and has no request data, so it works the same in screens, Timers and BPTs.
- `GetCurrentModuleInfo`: the running module's name, key, Id and published version Id, and its application's name and key, in a `ModuleInfo` structure. Logic in a library runs inside the module that calls it, so a library gets its consumer's details.
- `GetRequestInfo`: the current HTTP request's method, scheme, host, port, path, query string, full URL, user agent, referrer and HTTPS flag, in a `RequestInfo` structure. `IsHttpRequest` is False outside a request (Timers, BPTs), and the rest is then empty.
- Like the existing actions, none of the new ones throws: a value the platform can't provide is returned empty, 0 or False.

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

[1.5.0]: https://github.com/promonteiro89/environment-info-o11/releases/tag/v1.5.0
[1.4.0]: https://github.com/promonteiro89/environment-info-o11/releases/tag/v1.4.0
[1.3.0]: https://github.com/promonteiro89/environment-info-o11/tree/main

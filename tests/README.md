# Tests

Cross-platform (plain `dotnet`) tests for the pure `ClientIpResolver` and `CloudFrontRanges`
regions of `Source/NET/EnvironmentInfo_Ext.cs`: the spec's Resolve test table, NormalizeIp and
IsCloudFrontOriginFacing edge cases. No NuGet packages.

Run from the repo root:

    bash tests/run.sh                          # Source/NET/EnvironmentInfo_Ext.cs
    bash tests/run.sh path/to/other-source.cs  # any file with the marker regions

The script extracts the `// <client-ip-resolver>` and `// <cloudfront-ranges>` regions, builds
`ClientIpResolver.Tests`, and exits 1 on any failure. `$DOTNET` overrides the dotnet binary.

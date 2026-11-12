using OutSystems.HubEdition.RuntimePlatform;
using System;
using System.Web;

namespace OutSystems.NssEnvironmentInfo_Ext {

	public class CssEnvironmentInfo_Ext: IssEnvironmentInfo_Ext {

		/// <summary>
		/// Checks whether the current environment&apos;s server mode is Development. Use it to turn on debug features: unlike &quot;not IsProductionEnvironment&quot;, it stays False in Disaster Recovery. Ideal for If widgets and conditions.
		/// </summary>
		/// <param name="ssIsDevelopmentEnvironment">True if the server mode is Development (Id 0). False otherwise, or if the platform context is unavailable.</param>
		public void MssIsDevelopmentEnvironment(out bool ssIsDevelopmentEnvironment) {
			ssIsDevelopmentEnvironment = false;
			try {
				AppInfo info = AppInfo.GetAppInfo();
				ssIsDevelopmentEnvironment = info != null && info.ServerMode == ServerModes.Development;
			} catch {
				ssIsDevelopmentEnvironment = false;
			}
		} // MssIsDevelopmentEnvironment

		/// <summary>
		/// Checks whether the current environment&apos;s server mode is NonProduction, the mode usually used for QA and test environments. Ideal for If widgets and conditions.
		/// </summary>
		/// <param name="ssIsNonProductionEnvironment">True if the server mode is NonProduction (Id 1). False otherwise, or if the platform context is unavailable.</param>
		public void MssIsNonProductionEnvironment(out bool ssIsNonProductionEnvironment) {
			ssIsNonProductionEnvironment = false;
			try {
				AppInfo info = AppInfo.GetAppInfo();
				ssIsNonProductionEnvironment = info != null && info.ServerMode == ServerModes.NonProduction;
			} catch {
				ssIsNonProductionEnvironment = false;
			}
		} // MssIsNonProductionEnvironment

		/// <summary>
		/// Checks whether the current environment&apos;s server mode is DisasterRecovery. Use it to pause Timers or integrations that must only run in the primary Production environment. Ideal for If widgets and conditions.
		/// </summary>
		/// <param name="ssIsDisasterRecoveryEnvironment">True if the server mode is DisasterRecovery (Id 2). False otherwise, or if the platform context is unavailable.</param>
		public void MssIsDisasterRecoveryEnvironment(out bool ssIsDisasterRecoveryEnvironment) {
			ssIsDisasterRecoveryEnvironment = false;
			try {
				AppInfo info = AppInfo.GetAppInfo();
				ssIsDisasterRecoveryEnvironment = info != null && info.ServerMode == ServerModes.DisasterRecovery;
			} catch {
				ssIsDisasterRecoveryEnvironment = false;
			}
		} // MssIsDisasterRecoveryEnvironment

		/// <summary>
		/// Returns the current environment&apos;s name, key, hostname, Front-End name and server mode in one call, reading the server mode only once. Works the same in screens, Timers and BPTs. Keep it server-side: it describes your infrastructure.
		/// </summary>
		/// <param name="ssEnvironmentInfo">The environment&apos;s details. Values the platform can&apos;t provide are empty, 0 or False.</param>
		public void MssGetEnvironmentInfo(out RCEnvironmentInfoRecord ssEnvironmentInfo) {
			ssEnvironmentInfo = new RCEnvironmentInfoRecord(null);

			// The hostname is read from configuration, not from the platform context, so it is
			// filled even when the context is unavailable.
			try {
				ssEnvironmentInfo.ssSTEnvironmentInfo.ssHostname = new EspaceProperties().DefaultDnsName ?? "";
			} catch {
				ssEnvironmentInfo.ssSTEnvironmentInfo.ssHostname = "";
			}

			AppInfo info = null;
			try {
				info = AppInfo.GetAppInfo();
			} catch {
				info = null;
			}

			if (info != null) {
				try {
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssEnvironmentName = info.EnvironmentName ?? "";
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssEnvironmentKey = info.EnvironmentKey ?? "";
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssFrontEndName = info.FrontendName ?? "";
				} catch {
				}

				// Read the server mode once: it queries the database on every access.
				try {
					ServerModes mode = info.ServerMode;
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssServerModeId = (int)mode;
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssServerModeName = mode.ToString();
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssIsDevelopment = mode == ServerModes.Development;
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssIsNonProduction = mode == ServerModes.NonProduction;
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssIsDisasterRecovery = mode == ServerModes.DisasterRecovery;
					ssEnvironmentInfo.ssSTEnvironmentInfo.ssIsProduction = mode == ServerModes.Production;
				} catch {
				}
			}
		} // MssGetEnvironmentInfo

		/// <summary>
		/// Returns the name, key and version of the module running the current request or Timer, and its application. Logic in a library runs inside the module that calls it, so a library gets its consumer&apos;s details. Useful for logs and audits.
		/// </summary>
		/// <param name="ssModuleInfo">The module and application details. Values the platform can&apos;t provide are empty or 0.</param>
		public void MssGetCurrentModuleInfo(out RCModuleInfoRecord ssModuleInfo) {
			ssModuleInfo = new RCModuleInfoRecord(null);

			AppInfo info = null;
			try {
				info = AppInfo.GetAppInfo();
			} catch {
				info = null;
			}
			if (info == null) {
				return;
			}

			try {
				ssModuleInfo.ssSTModuleInfo.ssModuleName = info.eSpaceName ?? "";
				ssModuleInfo.ssSTModuleInfo.ssModuleKey = info.eSpaceUID ?? "";
				ssModuleInfo.ssSTModuleInfo.ssModuleId = info.eSpaceId;
				ssModuleInfo.ssSTModuleInfo.ssModuleVersionId = info.eSpaceVersionId;
				ssModuleInfo.ssSTModuleInfo.ssApplicationKey = info.ApplicationUID ?? "";
			} catch {
			}

			// ApplicationName reads a platform setting, which can fail on its own.
			try {
				ssModuleInfo.ssSTModuleInfo.ssApplicationName = info.ApplicationName ?? "";
			} catch {
				ssModuleInfo.ssSTModuleInfo.ssApplicationName = "";
			}
		} // MssGetCurrentModuleInfo

		/// <summary>
		/// Returns details of the current HTTP request: method, scheme, host, port, path, query string, full URL, user agent, referrer and whether the connection used HTTPS. Outside a request (Timers, BPTs), IsHttpRequest is False and the rest is empty. Behind a load balancer, the scheme, host and port can be the internal ones, so don&apos;t use them to build links for emails: use GetEnvironmentHostname.
		/// </summary>
		/// <param name="ssRequestInfo">Details of the current request. Empty when there is no HTTP request.</param>
		public void MssGetRequestInfo(out RCRequestInfoRecord ssRequestInfo) {
			ssRequestInfo = new RCRequestInfoRecord(null);

			HttpContext context = HttpContext.Current;
			if (context == null) {
				// No HTTP context: nothing to report.
				return;
			}

			HttpRequest request;
			try {
				// Throws HttpException (it doesn't return null) when the context has no request.
				request = context.Request;
			} catch (HttpException) {
				return;
			}
			if (request == null) {
				return;
			}

			ssRequestInfo.ssSTRequestInfo.ssIsHttpRequest = true;

			// The method and headers are independent of the URL, so a failing URL doesn't blank them.
			try {
				ssRequestInfo.ssSTRequestInfo.ssMethod = request.HttpMethod ?? "";
				ssRequestInfo.ssSTRequestInfo.ssIsSecureConnection = request.IsSecureConnection;
				ssRequestInfo.ssSTRequestInfo.ssUserAgent = request.UserAgent ?? "";
				ssRequestInfo.ssSTRequestInfo.ssReferrer = request.Headers["Referer"] ?? "";
			} catch {
			}

			// The URL parts are independent of the method and headers, so a failing one doesn't blank them.
			try {
				Uri url = request.Url;
				if (url != null) {
					ssRequestInfo.ssSTRequestInfo.ssUrl = url.AbsoluteUri;
					ssRequestInfo.ssSTRequestInfo.ssScheme = url.Scheme;
					ssRequestInfo.ssSTRequestInfo.ssHost = url.Host;
					ssRequestInfo.ssSTRequestInfo.ssPort = url.Port;
					ssRequestInfo.ssSTRequestInfo.ssPath = url.AbsolutePath;
					string query = url.Query;
					ssRequestInfo.ssSTRequestInfo.ssQueryString = query.StartsWith("?") ? query.Substring(1) : query;
				}
			} catch {
			}
		} // MssGetRequestInfo


		/// <summary>
		/// Returns the IP address of the client making the current HTTP request. When the platform's trusted proxies are enabled (as on OutSystems Cloud), X-Forwarded-For is read from the right through trusted proxies and CloudFront, so forged entries are ignored. Otherwise the first X-Forwarded-For entry is used, which the client can forge. Ports are stripped and invalid values fall back to the connection address. Returns an empty string when there is no HTTP request.
		/// </summary>
		/// <param name="ssIPAddress">Client IP address, or empty when there is no HTTP request.</param>
		public void MssGetClientIPAddress(out string ssIPAddress) {
			ssIPAddress = "";

			HttpContext context = HttpContext.Current;
			if (context == null) {
				// No HTTP context: nothing to report.
				return;
			}

			HttpRequest request;
			try {
				// Throws HttpException (it doesn't return null) when the context has no request.
				request = context.Request;
			} catch (HttpException) {
				return;
			}
			if (request == null) {
				return;
			}

			// The platform's trusted-proxy rules (Service Center), with CloudFront's origin-facing
			// ranges also trusted, so OutSystems Cloud returns the visitor and ignores forged headers.
			// Without trusted proxies, the first X-Forwarded-For entry (as before). See ClientIpResolver.
			ssIPAddress = ClientIpResolver.Resolve(
				request.Headers["X-Forwarded-For"], request.UserHostAddress,
				RuntimePlatformSettings.InternalNetwork.EnableTrustedProxies.GetValue(),
				RuntimePlatformSettings.InternalNetwork.EnableFallbackToFirstTrustedWhenAllForwardedIPsTrusted.GetValue(),
				RuntimePlatformUtils.IsFromTrustedProxy) ?? "";
		} // MssGetClientIPAddress

		/// <summary>
		/// Returns server runtime information: .NET Framework description, OS version, machine name, CPU count and bitness. Useful for support diagnostics. Keep it server-side: it describes your infrastructure. If the server can't read the OS version or machine name, that field is returned empty.
		/// </summary>
		/// <param name="ssRuntimeInfo">Server runtime details.</param>
		public void MssGetRuntimeInfo(out RCRuntimeInfoRecord ssRuntimeInfo) {
			ssRuntimeInfo = new RCRuntimeInfoRecord(null);

			ssRuntimeInfo.ssSTRuntimeInfo.ssCLRVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription ?? "";
			try {
				ssRuntimeInfo.ssSTRuntimeInfo.ssOSVersion = Environment.OSVersion.ToString();
			} catch (InvalidOperationException) {
				ssRuntimeInfo.ssSTRuntimeInfo.ssOSVersion = "";
			}
			try {
				ssRuntimeInfo.ssSTRuntimeInfo.ssMachineName = Environment.MachineName;
			} catch (InvalidOperationException) {
				// The computer name can't be read on some locked-down hosts.
				ssRuntimeInfo.ssSTRuntimeInfo.ssMachineName = "";
			}
			ssRuntimeInfo.ssSTRuntimeInfo.ssProcessorCount = Environment.ProcessorCount;
			ssRuntimeInfo.ssSTRuntimeInfo.ssIs64BitOS = Environment.Is64BitOperatingSystem;
			ssRuntimeInfo.ssSTRuntimeInfo.ssIs64BitProcess = Environment.Is64BitProcess;
		} // MssGetRuntimeInfo

		/// <summary>
		/// Returns the name of the Front-End server running the current process: in a request, the Front-End that handled it; in a Timer or BPT, the one that ran the job. Use it for diagnostics, technical logging and auditing. Empty if the platform context is unavailable.
		/// </summary>
		/// <param name="ssFrontEndName">Name of the Front-End server.</param>
		public void MssGetFrontEndName(out string ssFrontEndName) {
			AppInfo info = AppInfo.GetAppInfo();
			ssFrontEndName = info != null ? (info.FrontendName ?? "") : "";
		} // MssGetFrontEndName

		/// <summary>
		/// Returns the key of the current environment. Keep it server-side: don't expose it to anonymous users or public APIs. Empty if the platform context is unavailable.
		/// </summary>
		/// <param name="ssEnvironmentKey">Key of the environment.</param>
		public void MssGetEnvironmentKey(out string ssEnvironmentKey) {
			AppInfo info = AppInfo.GetAppInfo();
			ssEnvironmentKey = info != null ? (info.EnvironmentKey ?? "") : "";
		} // MssGetEnvironmentKey

		/// <summary>
		/// Returns the name of the current environment. Empty if the platform context is unavailable.
		/// </summary>
		/// <param name="ssEnvironmentName">Name of the environment.</param>
		public void MssGetEnvironmentName(out string ssEnvironmentName) {
			AppInfo info = AppInfo.GetAppInfo();
			ssEnvironmentName = info != null ? (info.EnvironmentName ?? "") : "";
		} // MssGetEnvironmentName

		/// <summary>
		/// Lists every value of the platform's ServerModes enum (Id and Name): 0 Development, 1 NonProduction, 2 DisasterRecovery, 3 Management, 4 Production. Unlike GetEnvironmentServerMode, which returns the current mode, this is a fixed list and doesn't query the environment.
		/// </summary>
		/// <param name="ssServerModes">Every server mode value (Id and Name).</param>
		public void MssGetEnvironmentServerModes(out RLServerModeRecordList ssServerModes) {
			ssServerModes = new RLServerModeRecordList();
			foreach (ServerModes mode in Enum.GetValues(typeof(ServerModes))) {
				ssServerModes.Add(ToServerModeRecord(mode));
			}
		} // MssGetEnvironmentServerModes

		/// <summary>
		/// Checks whether the current environment's server mode is Production. Returns False in every other mode, including Disaster Recovery, so don't use "not production" to mean "development". Ideal for If widgets and conditions.
		/// </summary>
		/// <param name="ssIsProductionEnvironment">True if the server mode is Production (Id 4). False otherwise, or if the platform context is unavailable.</param>
		public void MssIsProductionEnvironment(out bool ssIsProductionEnvironment) {
			AppInfo info = AppInfo.GetAppInfo();
			ssIsProductionEnvironment = info != null && info.ServerMode == ServerModes.Production;
		} // MssIsProductionEnvironment

		/// <summary>
		/// Returns the current environment's server mode: the platform's ServerModes value (Id) and enum name (Name). Ids: 0 Development, 1 NonProduction, 2 DisasterRecovery, 3 Management, 4 Production. If the platform can't read the server mode, it reports Development. Name is empty if the platform context is unavailable.
		/// </summary>
		/// <param name="ssServerMode">The current server mode.</param>
		public void MssGetEnvironmentServerMode(out RCServerModeRecord ssServerMode) {
			AppInfo info = AppInfo.GetAppInfo();
			ssServerMode = info != null ? ToServerModeRecord(info.ServerMode) : new RCServerModeRecord(null);
		} // MssGetEnvironmentServerMode

		/// <summary>
		/// Returns the environment's default DNS name as configured in the platform (for example env-dev.outsystemsenterprise.com). It's read from configuration, not from the HTTP request, so Timers and BPTs get the same value. Returns an empty string if no default DNS name is configured.
		/// </summary>
		/// <param name="ssHostname">The environment's default DNS name, or empty if none is configured.</param>
		public void MssGetEnvironmentHostname(out string ssHostname) {
			ssHostname = new EspaceProperties().DefaultDnsName ?? "";
		} // MssGetEnvironmentHostname

		private static RCServerModeRecord ToServerModeRecord(ServerModes mode) {
			RCServerModeRecord rec = new RCServerModeRecord(null);
			rec.ssSTServerMode.ssId = (int)mode;
			rec.ssSTServerMode.ssName = mode.ToString();
			return rec;
		}

	} // CssEnvironmentInfo_Ext

	// <client-ip-resolver>
	internal static class ClientIpResolver {
		private static System.Collections.Generic.List<CloudFrontRange> parsedCloudFrontRanges;

		/// <summary>Resolves the client IP without throwing.</summary>
		public static string Resolve(string forwardedFor, string remoteAddress,
			bool trustedProxiesEnabled, bool fallbackToFirstTrusted,
			System.Func<string, bool> isPlatformTrustedProxy) {
			try {
				string remote = NormalizeIp(remoteAddress);
				if (remote == "") {
					remote = (remoteAddress ?? "").Trim();
				}

				if (!trustedProxiesEnabled) {
					string first = null;
					string normalizedFirst;
					int firstSeparator;
					if (forwardedFor != null && forwardedFor.Length != 0) {
						firstSeparator = forwardedFor.IndexOf(',');
						first = firstSeparator < 0 ? forwardedFor : forwardedFor.Substring(0, firstSeparator);
					}
					normalizedFirst = NormalizeIp(first);
					return normalizedFirst != "" ? normalizedFirst : remote;
				}

				if (remote == "" || !IsTrusted(remote, isPlatformTrustedProxy)) {
					return remote;
				}

				string lastSeen = "";
				bool allTrusted = true;
				if (forwardedFor != null && forwardedFor.Length != 0) {
					int end = forwardedFor.Length;
					while (end > 0) {
						int separator = forwardedFor.LastIndexOf(',', end - 1);
						int start = separator + 1;
						string normalized = NormalizeIp(forwardedFor.Substring(start, end - start));
						if (normalized == "") {
							allTrusted = false;
							break;
						}

						lastSeen = normalized;
						if (!IsTrusted(normalized, isPlatformTrustedProxy)) {
							return normalized;
						}

						if (separator < 0) {
							break;
						}
						end = separator;
					}
				}

				if (allTrusted && fallbackToFirstTrusted && lastSeen != "") {
					return lastSeen;
				}
				return remote;
			} catch {
				return (remoteAddress ?? "").Trim();
			}
		}

		/// <summary>Returns a canonical IP address, or an empty string.</summary>
		public static string NormalizeIp(string raw) {
			try {
				if (System.String.IsNullOrWhiteSpace(raw)) {
					return "";
				}

				string candidate = raw.Trim();
				if (System.String.Equals(candidate, "unknown", System.StringComparison.OrdinalIgnoreCase)) {
					return "";
				}

				if (candidate.StartsWith("[", System.StringComparison.Ordinal)) {
					int closingBracket = candidate.IndexOf(']');
					if (closingBracket < 1) {
						return "";
					}
					string remainder = candidate.Substring(closingBracket + 1);
					if (remainder.Length != 0) {
						if (!remainder.StartsWith(":", System.StringComparison.Ordinal) || !IsValidPort(remainder.Substring(1))) {
							return "";
						}
					}
					candidate = candidate.Substring(1, closingBracket - 1);
				} else {
					int firstColon = candidate.IndexOf(':');
					if (firstColon >= 0 && firstColon == candidate.LastIndexOf(':') && candidate.IndexOf('.') >= 0) {
						if (!IsValidPort(candidate.Substring(firstColon + 1))) {
							return "";
						}
						candidate = candidate.Substring(0, firstColon);
					}
				}

				int scope = candidate.IndexOf('%');
				if (scope >= 0) {
					candidate = candidate.Substring(0, scope);
				}
				if (candidate.IndexOf('.') < 0 && candidate.IndexOf(':') < 0) {
					return "";
				}

				System.Net.IPAddress address;
				if (!System.Net.IPAddress.TryParse(candidate, out address)) {
					return "";
				}
				byte[] bytes = address.GetAddressBytes();
				if (bytes.Length == 4 && CountCharacter(candidate, '.') != 3) {
					return "";
				}
				if (address.IsIPv4MappedToIPv6) {
					address = address.MapToIPv4();
				}

				string result = address.ToString();
				int resultScope = result.IndexOf('%');
				return resultScope < 0 ? result : result.Substring(0, resultScope);
			} catch {
				return "";
			}
		}

		/// <summary>Determines whether an IP is CloudFront origin-facing.</summary>
		public static bool IsCloudFrontOriginFacing(string ip) {
			try {
				string normalized = NormalizeIp(ip);
				System.Net.IPAddress address;
				if (normalized == "" || !System.Net.IPAddress.TryParse(normalized, out address)) {
					return false;
				}

				byte[] addressBytes = address.GetAddressBytes();
				System.Collections.Generic.List<CloudFrontRange> ranges = GetCloudFrontRanges();
				int index;
				for (index = 0; index < ranges.Count; index++) {
					if (IsInRange(addressBytes, ranges[index])) {
						return true;
					}
				}
				return false;
			} catch {
				return false;
			}
		}

		private static bool IsTrusted(string ip, System.Func<string, bool> isPlatformTrustedProxy) {
			bool platformTrusted = false;
			try {
				if (isPlatformTrustedProxy != null) {
					platformTrusted = isPlatformTrustedProxy(ip);
				}
			} catch {
				platformTrusted = false;
			}
			return platformTrusted || IsCloudFrontOriginFacing(ip);
		}

		private static bool IsValidPort(string port) {
			int value = 0;
			int index;
			if (port.Length == 0) {
				return false;
			}
			for (index = 0; index < port.Length; index++) {
				char character = port[index];
				if (character < '0' || character > '9') {
					return false;
				}
				value = (value * 10) + (character - '0');
				if (value > 65535) {
					return false;
				}
			}
			return value >= 1;
		}

		private static int CountCharacter(string value, char character) {
			int count = 0;
			int index;
			for (index = 0; index < value.Length; index++) {
				if (value[index] == character) {
					count++;
				}
			}
			return count;
		}

		private static System.Collections.Generic.List<CloudFrontRange> GetCloudFrontRanges() {
			System.Collections.Generic.List<CloudFrontRange> ranges = parsedCloudFrontRanges;
			if (ranges != null) {
				return ranges;
			}

			ranges = new System.Collections.Generic.List<CloudFrontRange>();
			try {
				string[] prefixes = CloudFrontRanges.Prefixes;
				int index;
				for (index = 0; prefixes != null && index < prefixes.Length; index++) {
					CloudFrontRange range = ParseCloudFrontRange(prefixes[index]);
					if (range != null) {
						ranges.Add(range);
					}
				}
			} catch {
			}
			parsedCloudFrontRanges = ranges;
			return ranges;
		}

		private static CloudFrontRange ParseCloudFrontRange(string prefix) {
			try {
				if (System.String.IsNullOrWhiteSpace(prefix)) {
					return null;
				}
				int slash = prefix.IndexOf('/');
				if (slash <= 0 || slash != prefix.LastIndexOf('/')) {
					return null;
				}
				string normalized = NormalizeIp(prefix.Substring(0, slash));
				System.Net.IPAddress address;
				int length;
				if (normalized == "" || !System.Net.IPAddress.TryParse(normalized, out address) ||
					!System.Int32.TryParse(prefix.Substring(slash + 1), out length)) {
					return null;
				}
				byte[] bytes = address.GetAddressBytes();
				if (length < 0 || length > bytes.Length * 8) {
					return null;
				}
				return new CloudFrontRange(bytes, length);
			} catch {
				return null;
			}
		}

		private static bool IsInRange(byte[] address, CloudFrontRange range) {
			int fullBytes;
			int remainingBits;
			int index;
			if (address.Length != range.Address.Length) {
				return false;
			}
			fullBytes = range.Length / 8;
			for (index = 0; index < fullBytes; index++) {
				if (address[index] != range.Address[index]) {
					return false;
				}
			}
			remainingBits = range.Length % 8;
			if (remainingBits == 0) {
				return true;
			}
			int mask = 256 - (1 << (8 - remainingBits));
			return (address[fullBytes] & mask) == (range.Address[fullBytes] & mask);
		}

		private sealed class CloudFrontRange {
			public readonly byte[] Address;
			public readonly int Length;

			public CloudFrontRange(byte[] address, int length) {
				Address = address;
				Length = length;
			}
		}
	}
	// </client-ip-resolver>

	// <cloudfront-ranges>
	// Generated by scripts/update-cloudfront-ranges.py from https://ip-ranges.amazonaws.com/ip-ranges.json
	// (service CLOUDFRONT_ORIGIN_FACING). Do not edit by hand.
	internal static class CloudFrontRanges {
		public const string SyncToken = "1794300425";
		public const string CreateDate = "2026-11-10-08-47-05";
		public static readonly string[] Prefixes = new string[] {
				"3.29.57.0/26",
				"3.172.0.0/18",
				"3.172.64.0/18",
				"13.124.199.0/24",
				"15.158.0.0/16",
				"18.68.0.0/16",
				"24.110.128.0/17",
				"51.74.20.0/24",
				"51.74.21.0/24",
				"51.74.22.0/24",
				"52.46.0.0/18",
				"52.82.128.0/23",
				"52.82.134.0/23",
				"54.182.128.0/20",
				"54.182.144.0/21",
				"54.182.154.0/23",
				"54.182.156.0/22",
				"54.182.160.0/21",
				"54.182.172.0/22",
				"54.182.176.0/21",
				"54.182.184.0/22",
				"54.182.188.0/23",
				"54.182.224.0/21",
				"54.182.240.0/21",
				"54.182.248.0/22",
				"54.239.134.0/23",
				"54.239.170.0/23",
				"54.239.204.0/22",
				"54.239.208.0/21",
				"64.252.64.0/18",
				"64.252.128.0/18",
				"70.132.0.0/18",
				"130.176.0.0/18",
				"130.176.64.0/21",
				"130.176.72.0/22",
				"130.176.76.0/24",
				"130.176.78.0/23",
				"130.176.80.0/22",
				"130.176.86.0/23",
				"130.176.88.0/21",
				"130.176.96.0/19",
				"130.176.128.0/21",
				"130.176.136.0/23",
				"130.176.140.0/22",
				"130.176.144.0/20",
				"130.176.160.0/19",
				"130.176.192.0/19",
				"204.246.166.0/24",
				"205.251.218.0/24",
				"2001:3fc6:4::/48",
				"2001:3fc6:5::/48",
				"2001:3fc6:3c::/47",
				"2406:da10:847f:a100::/56",
				"2406:da11:438:2300::/56",
				"2406:da12:4b:c200::/56",
				"2406:da12:8b2e:9c00::/56",
				"2406:da14:17bd:2f00::/56",
				"2406:da14:80bb:ea00::/56",
				"2406:da16:c01:c200::/56",
				"2406:da18:9fa:1b00::/56",
				"2406:da19:e19:4a00::/56",
				"2406:da1a:6df:6c00::/56",
				"2406:da1b:e7c:ad00::/56",
				"2406:da1c:787:2b00::/56",
				"2406:da1c:8d8c:4600::/56",
				"2406:da1e:705:1600::/56",
				"2406:da1f:396:9100::/56",
				"2600:1f11:e79:a800::/56",
				"2600:1f13:417:4d00::/56",
				"2600:1f16:1923:3000::/56",
				"2600:1f17:4356:f100::/56",
				"2600:1f18:7530:7200::/56",
				"2600:1f1a:4568:b500::/56",
				"2600:1f1c:da:600::/56",
				"2600:1f1e:a7:2300::/56",
				"2600:9000:1000::/36",
				"2600:9000:5200::/40",
				"2600:9000:6000::/36",
				"2a05:d011:531:1800::/56",
				"2a05:d012:581:b400::/56",
				"2a05:d014:1362:b000::/56",
				"2a05:d016:9ed:de00::/56",
				"2a05:d018:1a3a:2d00::/56",
				"2a05:d019:80b:e300::/56",
				"2a05:d01a:8a9:be00::/56",
				"2a05:d01c:343:c300::/56",
				"2a05:d025:e59:fb00::/56"
		};
	}
	// </cloudfront-ranges>

} // OutSystems.NssEnvironmentInfo_Ext

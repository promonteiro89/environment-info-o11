using OutSystems.HubEdition.RuntimePlatform;
using System;
using System.Web;

namespace OutSystems.NssEnvironmentInfo_Ext {

	public class CssEnvironmentInfo_Ext: IssEnvironmentInfo_Ext {

		/// <summary>
		/// Returns the IP address of the client making the current HTTP request, as the platform determines it. When trusted proxies are configured in Service Center, X-Forwarded-For is only honoured from those proxies; otherwise its first entry is used, which the client can forge. Returns an empty string when there is no HTTP request. Treat the value as informational, not for access control.
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

			// Same resolution the platform uses for its own logs (see GetRealClientIP).
			ssIPAddress = GetRealClientIP(request) ?? "";
		} // MssGetClientIPAddress

		// Mirrors RuntimePlatformUtils.GetRequestRealIP, which cannot be called here because its
		// other overload requires OutSystems.Application.Core, a dependency unavailable in this project.
		private static string GetRealClientIP(HttpRequest request) {
			string header = request.Headers["X-Forwarded-For"];
			if (RuntimePlatformSettings.InternalNetwork.EnableTrustedProxies.GetValue()) {
				string text = "";
				bool allTrusted = false;
				string first = "";
				if (RuntimePlatformUtils.IsFromTrustedProxy(request.UserHostAddress)) {
					text = RuntimePlatformUtils.GetTrustedAddressFromForwardHeader(header, out allTrusted, out first);
				}
				if (string.IsNullOrEmpty(text)) {
					if (allTrusted && RuntimePlatformSettings.InternalNetwork.EnableFallbackToFirstTrustedWhenAllForwardedIPsTrusted.GetValue()) {
						return first;
					}
					return request.UserHostAddress;
				}
				return text;
			} else {
				string text = header;
				if (text != null && text.IndexOf(',') > 0) {
					text = text.Substring(0, text.IndexOf(',')).Trim();
				} else if (string.IsNullOrEmpty(text) || text.ToLower() == "unknown") {
					text = request.UserHostAddress;
				}
				return text;
			}
		} // GetRealClientIP

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

} // OutSystems.NssEnvironmentInfo_Ext

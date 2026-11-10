using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimePublic.Db;
using System;
using System.Collections;
using System.Data;
using System.Web;

namespace OutSystems.NssEnvironmentInfo_Ext {

	public class CssEnvironmentInfo_Ext: IssEnvironmentInfo_Ext {

		/// <summary>
		/// Returns the IP address of the client making the current HTTP request. Returns empty string in non-HTTP contexts (Timers, BPT).
		/// </summary>
		/// <param name="ssIPAddress">Client IP address</param>
		public void MssGetClientIPAddress(out string ssIPAddress) {
			ssIPAddress = "";

			HttpContext context = HttpContext.Current;
			if (context == null || context.Request == null) {
				// Non-HTTP context (Timer, BPT, async logic) — no client request available.
				return;
			}

			HttpRequest request = context.Request;

			// Front-Ends typically sit behind a load balancer / reverse proxy, so the
			// originating client IP is carried in X-Forwarded-For (comma-separated:
			// "client, proxy1, proxy2"). The first entry is the original client.
			string forwardedFor = request.Headers["X-Forwarded-For"];
			if (!string.IsNullOrEmpty(forwardedFor)) {
				string clientIp = forwardedFor.Split(',')[0].Trim();
				if (!string.IsNullOrEmpty(clientIp)) {
					ssIPAddress = clientIp;
					return;
				}
			}

			ssIPAddress = request.UserHostAddress ?? "";
		} // MssGetClientIPAddress

		/// <summary>
		/// Returns server runtime information: CLR version, OS, machine name, CPU count, and bitness. Useful for support diagnostics.
		/// </summary>
		/// <param name="ssRuntimeInfo">Server runtime details</param>
		public void MssGetRuntimeInfo(out RCRuntimeInfoRecord ssRuntimeInfo) {
			ssRuntimeInfo = new RCRuntimeInfoRecord(null);

			ssRuntimeInfo.ssSTRuntimeInfo.ssCLRVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
			ssRuntimeInfo.ssSTRuntimeInfo.ssOSVersion = System.Environment.OSVersion.ToString();
			ssRuntimeInfo.ssSTRuntimeInfo.ssMachineName = System.Environment.MachineName;
			ssRuntimeInfo.ssSTRuntimeInfo.ssProcessorCount = System.Environment.ProcessorCount;
			ssRuntimeInfo.ssSTRuntimeInfo.ssIs64BitOS = System.Environment.Is64BitOperatingSystem;
			ssRuntimeInfo.ssSTRuntimeInfo.ssIs64BitProcess = System.Environment.Is64BitProcess;
		} // MssGetRuntimeInfo

		/// <summary>
		/// Retrieves the network name or identifier of the specific Front-End server where the current process is being executed.
		/// 
		/// This action is primarily used for diagnostics, technical logging, or auditing purposes, allowing developers to identify exactly which Front-End processed a specific request.
		/// </summary>
		/// <param name="ssFrontEndName">Name of the Front-End server.</param>
		public void MssGetFrontEndName(out string ssFrontEndName) {
            ssFrontEndName = AppInfo.GetAppInfo().FrontendName;
        } // MssGetFrontEndName

		/// <summary>
		/// Retrieves the key of the current running environment.
		/// </summary>
		/// <param name="ssEnvironmentKey">Key of the environment.</param>
		public void MssGetEnvironmentKey(out string ssEnvironmentKey) {
			ssEnvironmentKey = AppInfo.GetAppInfo().EnvironmentKey;
		} // MssGetEnvironmentKey


		/// <summary>
		/// Retrieves the name of the current running environment.
		/// </summary>
		/// <param name="ssEnvironmentName">Name of the environment.</param>
		public void MssGetEnvironmentName(out string ssEnvironmentName) {
			ssEnvironmentName = AppInfo.GetAppInfo().EnvironmentName;
		} // MssGetEnvironmentName


		/// <summary>
		/// Retrieves a list of all supported Server Mode definitions. Unlike the singular &quot;GetEnvironmentServerMode&quot; (which gets the current mode) this action returns a static list of all possible modes (e.g., Development, Production, Disaster Recovery) with their corresponding IDs.
		/// </summary>
		/// <param name="ssServerModes">A list containing all valid server mode records (ID and Name).</param>
		public void MssGetEnvironmentServerModes(out RLServerModeRecordList ssServerModes) {
            ssServerModes = new RLServerModeRecordList();

            foreach (ServerModes mode in Enum.GetValues(typeof(ServerModes)))
            {
                RCServerModeRecord rec = new RCServerModeRecord();
                rec.ssSTServerMode.ssId = (int)mode;
                rec.ssSTServerMode.ssName = mode.ToString();
                ssServerModes.Add(rec);
            }
        } // MssGetEnvironmentServerModes


		/// <summary>
		/// Checks whether the current running environment is configured as a &quot;Production&quot; environment. This action returns a boolean value, making it ideal for use directly in If widgets or conditional logic.
		/// </summary>
		/// <param name="ssIsProductionEnvironment">Returns True if the server mode is Production (ID 2). Returns False otherwise.</param>
		public void MssIsProductionEnvironment(out bool ssIsProductionEnvironment) {
			ssIsProductionEnvironment = AppInfo.GetAppInfo().ServerMode == ServerModes.Production;
		} // MssIsProductionEnvironment


		/// <summary>
		/// Retrieves the running environment&apos;s current Server Mode configuration. It provides both the internal identifier and a human-readable label indicating the type of environment (e.g., Development, Production).
		/// </summary>
		/// <param name="ssServerMode">Contains the details of the current environment&apos;s mode.</param>
		public void MssGetEnvironmentServerMode(out RCServerModeRecord ssServerMode) {
            ssServerMode = new RCServerModeRecord();

            var mode = AppInfo.GetAppInfo().ServerMode;
            ssServerMode.ssSTServerMode.ssId = (int)mode;
            ssServerMode.ssSTServerMode.ssName = mode.ToString();
        } // MssGetEnvironmentServerMode


		/// <summary>
		/// Returns the hostname for the current environment (e.g. env-dev.outsystemsenterprise.com).
		/// 
		/// Note: In background jobs (timers, BPTs) or non-HTTP contexts, this value will be the same.
		/// </summary>
		/// <param name="ssHostname">The resolved hostname of the server.</param>
		public void MssGetEnvironmentHostname(out string ssHostname) {
            var espaceProperties = new EspaceProperties();
            ssHostname = espaceProperties.DefaultDnsName?.ToString() ?? "";
        } // MssGetEnvironmentHostname


	} // CssEnvironmentInfo_Ext

} // OutSystems.NssEnvironmentInfo_Ext
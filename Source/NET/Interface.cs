using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.NssEnvironmentInfo_Ext {

	public interface IssEnvironmentInfo_Ext {

		/// <summary>
		/// Returns the environment&apos;s default DNS name as configured in the platform (for example env-dev.outsystemsenterprise.com). It&apos;s read from configuration, not from the HTTP request, so Timers and BPTs get the same value. Returns an empty string if no default DNS name is configured.
		/// </summary>
		/// <param name="ssHostname">The environment&apos;s default DNS name, or empty if none is configured.</param>
		void MssGetEnvironmentHostname(out string ssHostname);

		/// <summary>
		/// Returns the current environment&apos;s server mode: the platform&apos;s ServerModes value (Id) and enum name (Name). Ids: 0 Development, 1 NonProduction, 2 DisasterRecovery, 3 Management, 4 Production. If the platform can&apos;t read the server mode, it reports Development. Name is empty if the platform context is unavailable.
		/// </summary>
		/// <param name="ssServerMode">The current server mode.</param>
		void MssGetEnvironmentServerMode(out RCServerModeRecord ssServerMode);

		/// <summary>
		/// Checks whether the current environment&apos;s server mode is Production. Returns False in every other mode, including Disaster Recovery, so don&apos;t use &quot;not production&quot; to mean &quot;development&quot;. Ideal for If widgets and conditions.
		/// </summary>
		/// <param name="ssIsProductionEnvironment">True if the server mode is Production (Id 4). False otherwise, or if the platform context is unavailable.</param>
		void MssIsProductionEnvironment(out bool ssIsProductionEnvironment);

		/// <summary>
		/// Lists every value of the platform&apos;s ServerModes enum (Id and Name): 0 Development, 1 NonProduction, 2 DisasterRecovery, 3 Management, 4 Production. Unlike GetEnvironmentServerMode, which returns the current mode, this is a fixed list and doesn&apos;t query the environment.
		/// </summary>
		/// <param name="ssServerModes">Every server mode value (Id and Name).</param>
		void MssGetEnvironmentServerModes(out RLServerModeRecordList ssServerModes);

		/// <summary>
		/// Returns the name of the current environment. Empty if the platform context is unavailable.
		/// </summary>
		/// <param name="ssEnvironmentName">Name of the environment.</param>
		void MssGetEnvironmentName(out string ssEnvironmentName);

		/// <summary>
		/// Returns the key of the current environment. Keep it server-side: don&apos;t expose it to anonymous users or public APIs. Empty if the platform context is unavailable.
		/// </summary>
		/// <param name="ssEnvironmentKey">Key of the environment.</param>
		void MssGetEnvironmentKey(out string ssEnvironmentKey);

		/// <summary>
		/// Returns the name of the Front-End server running the current process: in a request, the Front-End that handled it; in a Timer or BPT, the one that ran the job. Use it for diagnostics, technical logging and auditing. Empty if the platform context is unavailable.
		/// </summary>
		/// <param name="ssFrontEndName">Name of the Front-End server.</param>
		void MssGetFrontEndName(out string ssFrontEndName);

		/// <summary>
		/// Returns the IP address of the client making the current HTTP request. When the platform&apos;s trusted proxies are enabled (as on OutSystems Cloud), X-Forwarded-For is read from the right through trusted proxies and CloudFront, so forged entries are ignored. Otherwise the first X-Forwarded-For entry is used, which the client can forge. Ports are stripped and invalid values fall back to the connection address. Returns an empty string when there is no HTTP request.
		/// </summary>
		/// <param name="ssIPAddress">Client IP address, or empty when there is no HTTP request.</param>
		void MssGetClientIPAddress(out string ssIPAddress);

		/// <summary>
		/// Returns server runtime information: .NET Framework description, OS version, machine name, CPU count and bitness. Useful for support diagnostics. Keep it server-side: it describes your infrastructure. If the server can&apos;t read the framework description, OS version or machine name, that field is returned empty.
		/// </summary>
		/// <param name="ssRuntimeInfo">Server runtime details.</param>
		void MssGetRuntimeInfo(out RCRuntimeInfoRecord ssRuntimeInfo);

		/// <summary>
		/// Checks whether the current environment&apos;s server mode is Development. Unlike &quot;not IsProductionEnvironment&quot;, it stays False in Disaster Recovery. Ideal for If widgets and conditions. If the platform can&apos;t read the server mode, it reports Development, so this also returns True then: don&apos;t let it alone expose sensitive debug features.
		/// </summary>
		/// <param name="ssIsDevelopmentEnvironment">True if the server mode is Development (Id 0), including when the platform can&apos;t read the server mode and reports Development. False otherwise, or if the platform context is unavailable.</param>
		void MssIsDevelopmentEnvironment(out bool ssIsDevelopmentEnvironment);

		/// <summary>
		/// Checks whether the current environment&apos;s server mode is NonProduction, the mode usually used for QA and test environments. Ideal for If widgets and conditions.
		/// </summary>
		/// <param name="ssIsNonProductionEnvironment">True if the server mode is NonProduction (Id 1). False otherwise, or if the platform context is unavailable.</param>
		void MssIsNonProductionEnvironment(out bool ssIsNonProductionEnvironment);

		/// <summary>
		/// Checks whether the current environment&apos;s server mode is DisasterRecovery. Use it to pause Timers or integrations that must only run in the primary Production environment. Ideal for If widgets and conditions.
		/// </summary>
		/// <param name="ssIsDisasterRecoveryEnvironment">True if the server mode is DisasterRecovery (Id 2). False otherwise, or if the platform context is unavailable.</param>
		void MssIsDisasterRecoveryEnvironment(out bool ssIsDisasterRecoveryEnvironment);

		/// <summary>
		/// Returns the current environment&apos;s name, key, hostname, Front-End name and server mode in one call, reading the server mode only once. Works the same in screens, Timers and BPTs. Keep it server-side: it describes your infrastructure. If the platform can&apos;t read the server mode, it reports Development.
		/// </summary>
		/// <param name="ssEnvironmentInfo">The environment&apos;s details. Values the platform can&apos;t provide are empty, 0 or False.</param>
		void MssGetEnvironmentInfo(out RCEnvironmentInfoRecord ssEnvironmentInfo);

		/// <summary>
		/// Returns the name, key and version of the module running the current request or Timer, and its application. Logic in a library runs inside the module that calls it, so a library gets its consumer&apos;s details. Useful for logs and audits.
		/// </summary>
		/// <param name="ssModuleInfo">The module and application details. Values the platform can&apos;t provide are empty or 0.</param>
		void MssGetCurrentModuleInfo(out RCModuleInfoRecord ssModuleInfo);

		/// <summary>
		/// Returns details of the current HTTP request: method, scheme, host, port, path, query string, full URL, user agent, referrer and whether the connection used HTTPS. Outside a request (Timers, BPTs), IsHttpRequest is False and the rest is empty. Behind a load balancer, the scheme, host and port can be the internal ones, so don&apos;t use them to build links for emails: use GetEnvironmentHostname.
		/// </summary>
		/// <param name="ssRequestInfo">Details of the current request. Empty when there is no HTTP request.</param>
		void MssGetRequestInfo(out RCRequestInfoRecord ssRequestInfo);

	} // IssEnvironmentInfo_Ext

} // OutSystems.NssEnvironmentInfo_Ext

using System;
using System.Collections;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform;

namespace OutSystems.NssEnvironmentInfo_Ext {

	public interface IssEnvironmentInfo_Ext {

		/// <summary>
		/// Returns the hostname for the current environment (e.g. env-dev.outsystemsenterprise.com).
		/// 
		/// Note: In background jobs (timers, BPTs) or non-HTTP contexts, this value will be the same.
		/// </summary>
		/// <param name="ssHostname">The resolved hostname of the server.</param>
		void MssGetEnvironmentHostname(out string ssHostname);

		/// <summary>
		/// Retrieves the running environment&apos;s current Server Mode configuration. It provides both the internal identifier and a human-readable label indicating the type of environment (e.g., Development, Production).
		/// </summary>
		/// <param name="ssServerMode">Contains the details of the current environment&apos;s mode.</param>
		void MssGetEnvironmentServerMode(out RCServerModeRecord ssServerMode);

		/// <summary>
		/// Checks whether the current running environment is configured as a &quot;Production&quot; environment. This action returns a boolean value, making it ideal for use directly in If widgets or conditional logic.
		/// </summary>
		/// <param name="ssIsProductionEnvironment">Returns True if the server mode is Production (ID 2). Returns False otherwise.</param>
		void MssIsProductionEnvironment(out bool ssIsProductionEnvironment);

		/// <summary>
		/// Retrieves a list of all supported Server Mode definitions. Unlike the singular &quot;GetEnvironmentServerMode&quot; (which gets the current mode) this action returns a static list of all possible modes (e.g., Development, Production, Disaster Recovery) with their corresponding IDs.
		/// </summary>
		/// <param name="ssServerModes">A list containing all valid server mode records (ID and Name).</param>
		void MssGetEnvironmentServerModes(out RLServerModeRecordList ssServerModes);

		/// <summary>
		/// Retrieves the name of the current running environment.
		/// </summary>
		/// <param name="ssEnvironmentName">Name of the environment.</param>
		void MssGetEnvironmentName(out string ssEnvironmentName);

		/// <summary>
		/// Retrieves the key of the current running environment.
		/// </summary>
		/// <param name="ssEnvironmentKey">Key of the environment.</param>
		void MssGetEnvironmentKey(out string ssEnvironmentKey);

		/// <summary>
		/// Retrieves the network name or identifier of the specific Front-End server where the current process is being executed.
		/// 
		/// This action is primarily used for diagnostics, technical logging, or auditing purposes, allowing developers to identify exactly which Front-End processed a specific request.
		/// </summary>
		/// <param name="ssFrontEndName">Name of the Front-End server.</param>
		void MssGetFrontEndName(out string ssFrontEndName);

		/// <summary>
		/// Returns the IP address of the client making the current HTTP request. Returns empty string in non-HTTP contexts (Timers, BPT).
		/// </summary>
		/// <param name="ssIPAddress">Client IP address</param>
		void MssGetClientIPAddress(out string ssIPAddress);

		/// <summary>
		/// Returns server runtime information: CLR version, OS, machine name, CPU count, and bitness. Useful for support diagnostics.
		/// </summary>
		/// <param name="ssRuntimeInfo">Server runtime details</param>
		void MssGetRuntimeInfo(out RCRuntimeInfoRecord ssRuntimeInfo);

	} // IssEnvironmentInfo_Ext

} // OutSystems.NssEnvironmentInfo_Ext

using System;
using System.Collections;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;

namespace OutSystems.NssEnvironmentInfo_Ext {

	/// <summary>
	/// Structure <code>STServerModeStructure</code> that represents the Service Studio structure
	///  <code>ServerMode</code> <p> Description: A platform server mode: the ServerModes enum value (Id
	/// ) and name (Name).</p>
	/// </summary>
	[Serializable()]
	public partial struct STServerModeStructure: ISerializable, ITypedRecord<STServerModeStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdId = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*Z2BdDt0eIU2P4U6PLIRkpg");
		internal static readonly GlobalObjectKey IdName = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*tDarf4fZQ0WjXXtxUeWFtQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Id")]
		public int ssId;

		[System.Xml.Serialization.XmlElement("Name")]
		public string ssName;


		public BitArray OptimizedAttributes;

		public STServerModeStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssId = 0;
			ssName = "";
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssId = r.ReadInteger(index++, "ServerMode.Id", 0);
			ssName = r.ReadText(index++, "ServerMode.Name", "");
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(STServerModeStructure r) {
			this = r;
		}


		public static bool operator == (STServerModeStructure a, STServerModeStructure b) {
			if (a.ssId != b.ssId) return false;
			if (a.ssName != b.ssName) return false;
			return true;
		}

		public static bool operator != (STServerModeStructure a, STServerModeStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STServerModeStructure)) return false;
			return (this == (STServerModeStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssId.GetHashCode()
				^ ssName.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public STServerModeStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssId = 0;
			ssName = "";
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssId", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssId' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssId = (int) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STServerModeStructure Duplicate() {
			STServerModeStructure t;
			t.ssId = this.ssId;
			t.ssName = this.ssName;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Id")) VarValue.AppendAttribute(recordElem, "Id", ssId, detailLevel, TypeKind.Integer); else VarValue.AppendOptimizedAttribute(recordElem, "Id");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Name")) VarValue.AppendAttribute(recordElem, "Name", ssName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Name");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "id") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Id")) variable.Value = ssId; else variable.Optimized = true;
			} else if (head == "name") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Name")) variable.Value = ssName; else variable.Optimized = true;
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdId) {
				return ssId;
			} else if (key == IdName) {
				return ssName;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssId = (int) other.AttributeGet(IdId);
			ssName = (string) other.AttributeGet(IdName);
		}
		public bool IsDefault() {
			STServerModeStructure defaultStruct = new STServerModeStructure(null);
			if (this.ssId != defaultStruct.ssId) return false;
			if (this.ssName != defaultStruct.ssName) return false;
			return true;
		}
	} // STServerModeStructure

	/// <summary>
	/// Structure <code>STRuntimeInfoStructure</code> that represents the Service Studio structure
	///  <code>RuntimeInfo</code> <p> Description: Runtime details of the server that ran the action.</p>
	/// </summary>
	[Serializable()]
	public partial struct STRuntimeInfoStructure: ISerializable, ITypedRecord<STRuntimeInfoStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdCLRVersion = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*g5UNWtWRokeX9_QwxZG7yg");
		internal static readonly GlobalObjectKey IdOSVersion = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*dBqSH8CFAEe+2pLxLqz7yw");
		internal static readonly GlobalObjectKey IdMachineName = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*1wtwORQTGkqqCK+e4noqTg");
		internal static readonly GlobalObjectKey IdProcessorCount = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*3KrS_tt04EOL7VXWGpeH+A");
		internal static readonly GlobalObjectKey IdIs64BitOS = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*j7ni49yAwkWe7NMtI8Y2lg");
		internal static readonly GlobalObjectKey IdIs64BitProcess = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*f9PqTrQoEEm851ugEN01uw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("CLRVersion")]
		public string ssCLRVersion;

		[System.Xml.Serialization.XmlElement("OSVersion")]
		public string ssOSVersion;

		[System.Xml.Serialization.XmlElement("MachineName")]
		public string ssMachineName;

		[System.Xml.Serialization.XmlElement("ProcessorCount")]
		public int ssProcessorCount;

		[System.Xml.Serialization.XmlElement("Is64BitOS")]
		public bool ssIs64BitOS;

		[System.Xml.Serialization.XmlElement("Is64BitProcess")]
		public bool ssIs64BitProcess;


		public BitArray OptimizedAttributes;

		public STRuntimeInfoStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssCLRVersion = "";
			ssOSVersion = "";
			ssMachineName = "";
			ssProcessorCount = 0;
			ssIs64BitOS = false;
			ssIs64BitProcess = false;
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssCLRVersion = r.ReadText(index++, "RuntimeInfo.CLRVersion", "");
			ssOSVersion = r.ReadText(index++, "RuntimeInfo.OSVersion", "");
			ssMachineName = r.ReadText(index++, "RuntimeInfo.MachineName", "");
			ssProcessorCount = r.ReadInteger(index++, "RuntimeInfo.ProcessorCount", 0);
			ssIs64BitOS = r.ReadBoolean(index++, "RuntimeInfo.Is64BitOS", false);
			ssIs64BitProcess = r.ReadBoolean(index++, "RuntimeInfo.Is64BitProcess", false);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(STRuntimeInfoStructure r) {
			this = r;
		}


		public static bool operator == (STRuntimeInfoStructure a, STRuntimeInfoStructure b) {
			if (a.ssCLRVersion != b.ssCLRVersion) return false;
			if (a.ssOSVersion != b.ssOSVersion) return false;
			if (a.ssMachineName != b.ssMachineName) return false;
			if (a.ssProcessorCount != b.ssProcessorCount) return false;
			if (a.ssIs64BitOS != b.ssIs64BitOS) return false;
			if (a.ssIs64BitProcess != b.ssIs64BitProcess) return false;
			return true;
		}

		public static bool operator != (STRuntimeInfoStructure a, STRuntimeInfoStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STRuntimeInfoStructure)) return false;
			return (this == (STRuntimeInfoStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssCLRVersion.GetHashCode()
				^ ssOSVersion.GetHashCode()
				^ ssMachineName.GetHashCode()
				^ ssProcessorCount.GetHashCode()
				^ ssIs64BitOS.GetHashCode()
				^ ssIs64BitProcess.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public STRuntimeInfoStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssCLRVersion = "";
			ssOSVersion = "";
			ssMachineName = "";
			ssProcessorCount = 0;
			ssIs64BitOS = false;
			ssIs64BitProcess = false;
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssCLRVersion", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssCLRVersion' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssCLRVersion = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssOSVersion", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssOSVersion' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssOSVersion = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssMachineName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssMachineName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssMachineName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssProcessorCount", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssProcessorCount' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssProcessorCount = (int) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIs64BitOS", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIs64BitOS' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIs64BitOS = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIs64BitProcess", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIs64BitProcess' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIs64BitProcess = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STRuntimeInfoStructure Duplicate() {
			STRuntimeInfoStructure t;
			t.ssCLRVersion = this.ssCLRVersion;
			t.ssOSVersion = this.ssOSVersion;
			t.ssMachineName = this.ssMachineName;
			t.ssProcessorCount = this.ssProcessorCount;
			t.ssIs64BitOS = this.ssIs64BitOS;
			t.ssIs64BitProcess = this.ssIs64BitProcess;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".CLRVersion")) VarValue.AppendAttribute(recordElem, "CLRVersion", ssCLRVersion, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "CLRVersion");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".OSVersion")) VarValue.AppendAttribute(recordElem, "OSVersion", ssOSVersion, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "OSVersion");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".MachineName")) VarValue.AppendAttribute(recordElem, "MachineName", ssMachineName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "MachineName");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ProcessorCount")) VarValue.AppendAttribute(recordElem, "ProcessorCount", ssProcessorCount, detailLevel, TypeKind.Integer); else VarValue.AppendOptimizedAttribute(recordElem, "ProcessorCount");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Is64BitOS")) VarValue.AppendAttribute(recordElem, "Is64BitOS", ssIs64BitOS, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "Is64BitOS");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Is64BitProcess")) VarValue.AppendAttribute(recordElem, "Is64BitProcess", ssIs64BitProcess, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "Is64BitProcess");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "clrversion") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".CLRVersion")) variable.Value = ssCLRVersion; else variable.Optimized = true;
			} else if (head == "osversion") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".OSVersion")) variable.Value = ssOSVersion; else variable.Optimized = true;
			} else if (head == "machinename") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".MachineName")) variable.Value = ssMachineName; else variable.Optimized = true;
			} else if (head == "processorcount") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ProcessorCount")) variable.Value = ssProcessorCount; else variable.Optimized = true;
			} else if (head == "is64bitos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Is64BitOS")) variable.Value = ssIs64BitOS; else variable.Optimized = true;
			} else if (head == "is64bitprocess") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Is64BitProcess")) variable.Value = ssIs64BitProcess; else variable.Optimized = true;
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdCLRVersion) {
				return ssCLRVersion;
			} else if (key == IdOSVersion) {
				return ssOSVersion;
			} else if (key == IdMachineName) {
				return ssMachineName;
			} else if (key == IdProcessorCount) {
				return ssProcessorCount;
			} else if (key == IdIs64BitOS) {
				return ssIs64BitOS;
			} else if (key == IdIs64BitProcess) {
				return ssIs64BitProcess;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssCLRVersion = (string) other.AttributeGet(IdCLRVersion);
			ssOSVersion = (string) other.AttributeGet(IdOSVersion);
			ssMachineName = (string) other.AttributeGet(IdMachineName);
			ssProcessorCount = (int) other.AttributeGet(IdProcessorCount);
			ssIs64BitOS = (bool) other.AttributeGet(IdIs64BitOS);
			ssIs64BitProcess = (bool) other.AttributeGet(IdIs64BitProcess);
		}
		public bool IsDefault() {
			STRuntimeInfoStructure defaultStruct = new STRuntimeInfoStructure(null);
			if (this.ssCLRVersion != defaultStruct.ssCLRVersion) return false;
			if (this.ssOSVersion != defaultStruct.ssOSVersion) return false;
			if (this.ssMachineName != defaultStruct.ssMachineName) return false;
			if (this.ssProcessorCount != defaultStruct.ssProcessorCount) return false;
			if (this.ssIs64BitOS != defaultStruct.ssIs64BitOS) return false;
			if (this.ssIs64BitProcess != defaultStruct.ssIs64BitProcess) return false;
			return true;
		}
	} // STRuntimeInfoStructure

	/// <summary>
	/// Structure <code>STEnvironmentInfoStructure</code> that represents the Service Studio structure
	///  <code>EnvironmentInfo</code> <p> Description: The current environment's details, read in one call
	/// . Contains no request data, so it works the same in screens, Timers and BPTs.</p>
	/// </summary>
	[Serializable()]
	public partial struct STEnvironmentInfoStructure: ISerializable, ITypedRecord<STEnvironmentInfoStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdEnvironmentName = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*msjPXcHZwkaLhuT_aSLrwQ");
		internal static readonly GlobalObjectKey IdEnvironmentKey = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*Y1PE28KFH0uuXmRaFhBoOA");
		internal static readonly GlobalObjectKey IdHostname = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*XYiIlqiokEudF0MTo+1eBQ");
		internal static readonly GlobalObjectKey IdFrontEndName = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*MGPHDrHy3UyGTqkaAOngOg");
		internal static readonly GlobalObjectKey IdServerModeId = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*bgmvrPRzCUGp9RNmIRpptQ");
		internal static readonly GlobalObjectKey IdServerModeName = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*CqtLz8EkfU6vx5kIFGqw9g");
		internal static readonly GlobalObjectKey IdIsProduction = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*NJe7UQCKOUO+Xe2KdwtWBg");
		internal static readonly GlobalObjectKey IdIsDevelopment = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*eSOR5I6fhUq+2_FavweT5Q");
		internal static readonly GlobalObjectKey IdIsNonProduction = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*2kiUuELsmkOH4JRD2m0DPw");
		internal static readonly GlobalObjectKey IdIsDisasterRecovery = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*AekZcut46k6vkTJbMh90bA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("EnvironmentName")]
		public string ssEnvironmentName;

		[System.Xml.Serialization.XmlElement("EnvironmentKey")]
		public string ssEnvironmentKey;

		[System.Xml.Serialization.XmlElement("Hostname")]
		public string ssHostname;

		[System.Xml.Serialization.XmlElement("FrontEndName")]
		public string ssFrontEndName;

		[System.Xml.Serialization.XmlElement("ServerModeId")]
		public int ssServerModeId;

		[System.Xml.Serialization.XmlElement("ServerModeName")]
		public string ssServerModeName;

		[System.Xml.Serialization.XmlElement("IsProduction")]
		public bool ssIsProduction;

		[System.Xml.Serialization.XmlElement("IsDevelopment")]
		public bool ssIsDevelopment;

		[System.Xml.Serialization.XmlElement("IsNonProduction")]
		public bool ssIsNonProduction;

		[System.Xml.Serialization.XmlElement("IsDisasterRecovery")]
		public bool ssIsDisasterRecovery;


		public BitArray OptimizedAttributes;

		public STEnvironmentInfoStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssEnvironmentName = "";
			ssEnvironmentKey = "";
			ssHostname = "";
			ssFrontEndName = "";
			ssServerModeId = 0;
			ssServerModeName = "";
			ssIsProduction = false;
			ssIsDevelopment = false;
			ssIsNonProduction = false;
			ssIsDisasterRecovery = false;
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssEnvironmentName = r.ReadText(index++, "EnvironmentInfo.EnvironmentName", "");
			ssEnvironmentKey = r.ReadText(index++, "EnvironmentInfo.EnvironmentKey", "");
			ssHostname = r.ReadText(index++, "EnvironmentInfo.Hostname", "");
			ssFrontEndName = r.ReadText(index++, "EnvironmentInfo.FrontEndName", "");
			ssServerModeId = r.ReadInteger(index++, "EnvironmentInfo.ServerModeId", 0);
			ssServerModeName = r.ReadText(index++, "EnvironmentInfo.ServerModeName", "");
			ssIsProduction = r.ReadBoolean(index++, "EnvironmentInfo.IsProduction", false);
			ssIsDevelopment = r.ReadBoolean(index++, "EnvironmentInfo.IsDevelopment", false);
			ssIsNonProduction = r.ReadBoolean(index++, "EnvironmentInfo.IsNonProduction", false);
			ssIsDisasterRecovery = r.ReadBoolean(index++, "EnvironmentInfo.IsDisasterRecovery", false);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(STEnvironmentInfoStructure r) {
			this = r;
		}


		public static bool operator == (STEnvironmentInfoStructure a, STEnvironmentInfoStructure b) {
			if (a.ssEnvironmentName != b.ssEnvironmentName) return false;
			if (a.ssEnvironmentKey != b.ssEnvironmentKey) return false;
			if (a.ssHostname != b.ssHostname) return false;
			if (a.ssFrontEndName != b.ssFrontEndName) return false;
			if (a.ssServerModeId != b.ssServerModeId) return false;
			if (a.ssServerModeName != b.ssServerModeName) return false;
			if (a.ssIsProduction != b.ssIsProduction) return false;
			if (a.ssIsDevelopment != b.ssIsDevelopment) return false;
			if (a.ssIsNonProduction != b.ssIsNonProduction) return false;
			if (a.ssIsDisasterRecovery != b.ssIsDisasterRecovery) return false;
			return true;
		}

		public static bool operator != (STEnvironmentInfoStructure a, STEnvironmentInfoStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STEnvironmentInfoStructure)) return false;
			return (this == (STEnvironmentInfoStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssEnvironmentName.GetHashCode()
				^ ssEnvironmentKey.GetHashCode()
				^ ssHostname.GetHashCode()
				^ ssFrontEndName.GetHashCode()
				^ ssServerModeId.GetHashCode()
				^ ssServerModeName.GetHashCode()
				^ ssIsProduction.GetHashCode()
				^ ssIsDevelopment.GetHashCode()
				^ ssIsNonProduction.GetHashCode()
				^ ssIsDisasterRecovery.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public STEnvironmentInfoStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssEnvironmentName = "";
			ssEnvironmentKey = "";
			ssHostname = "";
			ssFrontEndName = "";
			ssServerModeId = 0;
			ssServerModeName = "";
			ssIsProduction = false;
			ssIsDevelopment = false;
			ssIsNonProduction = false;
			ssIsDisasterRecovery = false;
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssEnvironmentName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssEnvironmentName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssEnvironmentName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssEnvironmentKey", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssEnvironmentKey' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssEnvironmentKey = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssHostname", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssHostname' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssHostname = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssFrontEndName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssFrontEndName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssFrontEndName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssServerModeId", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssServerModeId' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssServerModeId = (int) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssServerModeName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssServerModeName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssServerModeName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIsProduction", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIsProduction' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIsProduction = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIsDevelopment", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIsDevelopment' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIsDevelopment = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIsNonProduction", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIsNonProduction' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIsNonProduction = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIsDisasterRecovery", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIsDisasterRecovery' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIsDisasterRecovery = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STEnvironmentInfoStructure Duplicate() {
			STEnvironmentInfoStructure t;
			t.ssEnvironmentName = this.ssEnvironmentName;
			t.ssEnvironmentKey = this.ssEnvironmentKey;
			t.ssHostname = this.ssHostname;
			t.ssFrontEndName = this.ssFrontEndName;
			t.ssServerModeId = this.ssServerModeId;
			t.ssServerModeName = this.ssServerModeName;
			t.ssIsProduction = this.ssIsProduction;
			t.ssIsDevelopment = this.ssIsDevelopment;
			t.ssIsNonProduction = this.ssIsNonProduction;
			t.ssIsDisasterRecovery = this.ssIsDisasterRecovery;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".EnvironmentName")) VarValue.AppendAttribute(recordElem, "EnvironmentName", ssEnvironmentName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "EnvironmentName");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".EnvironmentKey")) VarValue.AppendAttribute(recordElem, "EnvironmentKey", ssEnvironmentKey, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "EnvironmentKey");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Hostname")) VarValue.AppendAttribute(recordElem, "Hostname", ssHostname, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Hostname");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".FrontEndName")) VarValue.AppendAttribute(recordElem, "FrontEndName", ssFrontEndName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "FrontEndName");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ServerModeId")) VarValue.AppendAttribute(recordElem, "ServerModeId", ssServerModeId, detailLevel, TypeKind.Integer); else VarValue.AppendOptimizedAttribute(recordElem, "ServerModeId");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ServerModeName")) VarValue.AppendAttribute(recordElem, "ServerModeName", ssServerModeName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "ServerModeName");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".IsProduction")) VarValue.AppendAttribute(recordElem, "IsProduction", ssIsProduction, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "IsProduction");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".IsDevelopment")) VarValue.AppendAttribute(recordElem, "IsDevelopment", ssIsDevelopment, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "IsDevelopment");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".IsNonProduction")) VarValue.AppendAttribute(recordElem, "IsNonProduction", ssIsNonProduction, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "IsNonProduction");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".IsDisasterRecovery")) VarValue.AppendAttribute(recordElem, "IsDisasterRecovery", ssIsDisasterRecovery, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "IsDisasterRecovery");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "environmentname") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".EnvironmentName")) variable.Value = ssEnvironmentName; else variable.Optimized = true;
			} else if (head == "environmentkey") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".EnvironmentKey")) variable.Value = ssEnvironmentKey; else variable.Optimized = true;
			} else if (head == "hostname") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Hostname")) variable.Value = ssHostname; else variable.Optimized = true;
			} else if (head == "frontendname") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".FrontEndName")) variable.Value = ssFrontEndName; else variable.Optimized = true;
			} else if (head == "servermodeid") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ServerModeId")) variable.Value = ssServerModeId; else variable.Optimized = true;
			} else if (head == "servermodename") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ServerModeName")) variable.Value = ssServerModeName; else variable.Optimized = true;
			} else if (head == "isproduction") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".IsProduction")) variable.Value = ssIsProduction; else variable.Optimized = true;
			} else if (head == "isdevelopment") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".IsDevelopment")) variable.Value = ssIsDevelopment; else variable.Optimized = true;
			} else if (head == "isnonproduction") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".IsNonProduction")) variable.Value = ssIsNonProduction; else variable.Optimized = true;
			} else if (head == "isdisasterrecovery") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".IsDisasterRecovery")) variable.Value = ssIsDisasterRecovery; else variable.Optimized = true;
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdEnvironmentName) {
				return ssEnvironmentName;
			} else if (key == IdEnvironmentKey) {
				return ssEnvironmentKey;
			} else if (key == IdHostname) {
				return ssHostname;
			} else if (key == IdFrontEndName) {
				return ssFrontEndName;
			} else if (key == IdServerModeId) {
				return ssServerModeId;
			} else if (key == IdServerModeName) {
				return ssServerModeName;
			} else if (key == IdIsProduction) {
				return ssIsProduction;
			} else if (key == IdIsDevelopment) {
				return ssIsDevelopment;
			} else if (key == IdIsNonProduction) {
				return ssIsNonProduction;
			} else if (key == IdIsDisasterRecovery) {
				return ssIsDisasterRecovery;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssEnvironmentName = (string) other.AttributeGet(IdEnvironmentName);
			ssEnvironmentKey = (string) other.AttributeGet(IdEnvironmentKey);
			ssHostname = (string) other.AttributeGet(IdHostname);
			ssFrontEndName = (string) other.AttributeGet(IdFrontEndName);
			ssServerModeId = (int) other.AttributeGet(IdServerModeId);
			ssServerModeName = (string) other.AttributeGet(IdServerModeName);
			ssIsProduction = (bool) other.AttributeGet(IdIsProduction);
			ssIsDevelopment = (bool) other.AttributeGet(IdIsDevelopment);
			ssIsNonProduction = (bool) other.AttributeGet(IdIsNonProduction);
			ssIsDisasterRecovery = (bool) other.AttributeGet(IdIsDisasterRecovery);
		}
		public bool IsDefault() {
			STEnvironmentInfoStructure defaultStruct = new STEnvironmentInfoStructure(null);
			if (this.ssEnvironmentName != defaultStruct.ssEnvironmentName) return false;
			if (this.ssEnvironmentKey != defaultStruct.ssEnvironmentKey) return false;
			if (this.ssHostname != defaultStruct.ssHostname) return false;
			if (this.ssFrontEndName != defaultStruct.ssFrontEndName) return false;
			if (this.ssServerModeId != defaultStruct.ssServerModeId) return false;
			if (this.ssServerModeName != defaultStruct.ssServerModeName) return false;
			if (this.ssIsProduction != defaultStruct.ssIsProduction) return false;
			if (this.ssIsDevelopment != defaultStruct.ssIsDevelopment) return false;
			if (this.ssIsNonProduction != defaultStruct.ssIsNonProduction) return false;
			if (this.ssIsDisasterRecovery != defaultStruct.ssIsDisasterRecovery) return false;
			return true;
		}
	} // STEnvironmentInfoStructure

	/// <summary>
	/// Structure <code>STModuleInfoStructure</code> that represents the Service Studio structure
	///  <code>ModuleInfo</code> <p> Description: The module and application running the current request o
	/// r Timer. Logic in a library runs inside the consumer, so these are the consumer's details.</p>
	/// </summary>
	[Serializable()]
	public partial struct STModuleInfoStructure: ISerializable, ITypedRecord<STModuleInfoStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdModuleName = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*eADlbdxxPU+31Xuuk_ErWg");
		internal static readonly GlobalObjectKey IdModuleKey = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*2doxrV2YI0mqnTNrAjaprA");
		internal static readonly GlobalObjectKey IdModuleId = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*i6lJZCDqS0WQPqfLSHfTPw");
		internal static readonly GlobalObjectKey IdModuleVersionId = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*HUR4C3UYY0qiSQyW0GBLbQ");
		internal static readonly GlobalObjectKey IdApplicationName = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*Rm4MRLbEnkaej5cnF+C+Tw");
		internal static readonly GlobalObjectKey IdApplicationKey = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*T8O15XhAT0+5reWvL31K8g");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ModuleName")]
		public string ssModuleName;

		[System.Xml.Serialization.XmlElement("ModuleKey")]
		public string ssModuleKey;

		[System.Xml.Serialization.XmlElement("ModuleId")]
		public int ssModuleId;

		[System.Xml.Serialization.XmlElement("ModuleVersionId")]
		public int ssModuleVersionId;

		[System.Xml.Serialization.XmlElement("ApplicationName")]
		public string ssApplicationName;

		[System.Xml.Serialization.XmlElement("ApplicationKey")]
		public string ssApplicationKey;


		public BitArray OptimizedAttributes;

		public STModuleInfoStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssModuleName = "";
			ssModuleKey = "";
			ssModuleId = 0;
			ssModuleVersionId = 0;
			ssApplicationName = "";
			ssApplicationKey = "";
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssModuleName = r.ReadText(index++, "ModuleInfo.ModuleName", "");
			ssModuleKey = r.ReadText(index++, "ModuleInfo.ModuleKey", "");
			ssModuleId = r.ReadInteger(index++, "ModuleInfo.ModuleId", 0);
			ssModuleVersionId = r.ReadInteger(index++, "ModuleInfo.ModuleVersionId", 0);
			ssApplicationName = r.ReadText(index++, "ModuleInfo.ApplicationName", "");
			ssApplicationKey = r.ReadText(index++, "ModuleInfo.ApplicationKey", "");
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(STModuleInfoStructure r) {
			this = r;
		}


		public static bool operator == (STModuleInfoStructure a, STModuleInfoStructure b) {
			if (a.ssModuleName != b.ssModuleName) return false;
			if (a.ssModuleKey != b.ssModuleKey) return false;
			if (a.ssModuleId != b.ssModuleId) return false;
			if (a.ssModuleVersionId != b.ssModuleVersionId) return false;
			if (a.ssApplicationName != b.ssApplicationName) return false;
			if (a.ssApplicationKey != b.ssApplicationKey) return false;
			return true;
		}

		public static bool operator != (STModuleInfoStructure a, STModuleInfoStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STModuleInfoStructure)) return false;
			return (this == (STModuleInfoStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssModuleName.GetHashCode()
				^ ssModuleKey.GetHashCode()
				^ ssModuleId.GetHashCode()
				^ ssModuleVersionId.GetHashCode()
				^ ssApplicationName.GetHashCode()
				^ ssApplicationKey.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public STModuleInfoStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssModuleName = "";
			ssModuleKey = "";
			ssModuleId = 0;
			ssModuleVersionId = 0;
			ssApplicationName = "";
			ssApplicationKey = "";
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssModuleName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssModuleName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssModuleName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssModuleKey", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssModuleKey' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssModuleKey = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssModuleId", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssModuleId' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssModuleId = (int) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssModuleVersionId", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssModuleVersionId' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssModuleVersionId = (int) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssApplicationName", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssApplicationName' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssApplicationName = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssApplicationKey", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssApplicationKey' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssApplicationKey = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STModuleInfoStructure Duplicate() {
			STModuleInfoStructure t;
			t.ssModuleName = this.ssModuleName;
			t.ssModuleKey = this.ssModuleKey;
			t.ssModuleId = this.ssModuleId;
			t.ssModuleVersionId = this.ssModuleVersionId;
			t.ssApplicationName = this.ssApplicationName;
			t.ssApplicationKey = this.ssApplicationKey;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ModuleName")) VarValue.AppendAttribute(recordElem, "ModuleName", ssModuleName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "ModuleName");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ModuleKey")) VarValue.AppendAttribute(recordElem, "ModuleKey", ssModuleKey, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "ModuleKey");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ModuleId")) VarValue.AppendAttribute(recordElem, "ModuleId", ssModuleId, detailLevel, TypeKind.Integer); else VarValue.AppendOptimizedAttribute(recordElem, "ModuleId");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ModuleVersionId")) VarValue.AppendAttribute(recordElem, "ModuleVersionId", ssModuleVersionId, detailLevel, TypeKind.Integer); else VarValue.AppendOptimizedAttribute(recordElem, "ModuleVersionId");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ApplicationName")) VarValue.AppendAttribute(recordElem, "ApplicationName", ssApplicationName, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "ApplicationName");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".ApplicationKey")) VarValue.AppendAttribute(recordElem, "ApplicationKey", ssApplicationKey, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "ApplicationKey");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "modulename") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ModuleName")) variable.Value = ssModuleName; else variable.Optimized = true;
			} else if (head == "modulekey") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ModuleKey")) variable.Value = ssModuleKey; else variable.Optimized = true;
			} else if (head == "moduleid") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ModuleId")) variable.Value = ssModuleId; else variable.Optimized = true;
			} else if (head == "moduleversionid") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ModuleVersionId")) variable.Value = ssModuleVersionId; else variable.Optimized = true;
			} else if (head == "applicationname") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ApplicationName")) variable.Value = ssApplicationName; else variable.Optimized = true;
			} else if (head == "applicationkey") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ApplicationKey")) variable.Value = ssApplicationKey; else variable.Optimized = true;
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdModuleName) {
				return ssModuleName;
			} else if (key == IdModuleKey) {
				return ssModuleKey;
			} else if (key == IdModuleId) {
				return ssModuleId;
			} else if (key == IdModuleVersionId) {
				return ssModuleVersionId;
			} else if (key == IdApplicationName) {
				return ssApplicationName;
			} else if (key == IdApplicationKey) {
				return ssApplicationKey;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssModuleName = (string) other.AttributeGet(IdModuleName);
			ssModuleKey = (string) other.AttributeGet(IdModuleKey);
			ssModuleId = (int) other.AttributeGet(IdModuleId);
			ssModuleVersionId = (int) other.AttributeGet(IdModuleVersionId);
			ssApplicationName = (string) other.AttributeGet(IdApplicationName);
			ssApplicationKey = (string) other.AttributeGet(IdApplicationKey);
		}
		public bool IsDefault() {
			STModuleInfoStructure defaultStruct = new STModuleInfoStructure(null);
			if (this.ssModuleName != defaultStruct.ssModuleName) return false;
			if (this.ssModuleKey != defaultStruct.ssModuleKey) return false;
			if (this.ssModuleId != defaultStruct.ssModuleId) return false;
			if (this.ssModuleVersionId != defaultStruct.ssModuleVersionId) return false;
			if (this.ssApplicationName != defaultStruct.ssApplicationName) return false;
			if (this.ssApplicationKey != defaultStruct.ssApplicationKey) return false;
			return true;
		}
	} // STModuleInfoStructure

	/// <summary>
	/// Structure <code>STRequestInfoStructure</code> that represents the Service Studio structure
	///  <code>RequestInfo</code> <p> Description: Details of the current HTTP request, as the Front-En
	/// d received it. Behind a load balancer, the scheme, host and port can be the internal ones. Empty
	///  outside a request.</p>
	/// </summary>
	[Serializable()]
	public partial struct STRequestInfoStructure: ISerializable, ITypedRecord<STRequestInfoStructure>, ISimpleRecord {
		internal static readonly GlobalObjectKey IdIsHttpRequest = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*HWAg0G5c2kSqF3qE9G2o3Q");
		internal static readonly GlobalObjectKey IdMethod = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*vtm8yaLW9ESwvC4hU4v7iw");
		internal static readonly GlobalObjectKey IdScheme = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*+UuHKo0p+0+OgALDVawiVg");
		internal static readonly GlobalObjectKey IdHost = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*eUSg83YCJ0u4+iRfDXhY7A");
		internal static readonly GlobalObjectKey IdPort = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*FS5dnsQEMkKUoelDmTL0aw");
		internal static readonly GlobalObjectKey IdPath = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*8m319lbJ70io9QGxoCgD+A");
		internal static readonly GlobalObjectKey IdQueryString = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*S+YsCLeE_keR8RnLp7adPg");
		internal static readonly GlobalObjectKey IdUrl = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*lRljnl4ZmUuKruRTH1gX5A");
		internal static readonly GlobalObjectKey IdUserAgent = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*QhJFHL0uDUeXd20MNWnfKA");
		internal static readonly GlobalObjectKey IdReferrer = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*h_ay5NdIzE+sH2HXwDN6zg");
		internal static readonly GlobalObjectKey IdIsSecureConnection = GlobalObjectKey.Parse("+5MgcGVYykaq2P9qp0CZPQ*hZLx3OSRC0KnHSCbIosR0w");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("IsHttpRequest")]
		public bool ssIsHttpRequest;

		[System.Xml.Serialization.XmlElement("Method")]
		public string ssMethod;

		[System.Xml.Serialization.XmlElement("Scheme")]
		public string ssScheme;

		[System.Xml.Serialization.XmlElement("Host")]
		public string ssHost;

		[System.Xml.Serialization.XmlElement("Port")]
		public int ssPort;

		[System.Xml.Serialization.XmlElement("Path")]
		public string ssPath;

		[System.Xml.Serialization.XmlElement("QueryString")]
		public string ssQueryString;

		[System.Xml.Serialization.XmlElement("Url")]
		public string ssUrl;

		[System.Xml.Serialization.XmlElement("UserAgent")]
		public string ssUserAgent;

		[System.Xml.Serialization.XmlElement("Referrer")]
		public string ssReferrer;

		[System.Xml.Serialization.XmlElement("IsSecureConnection")]
		public bool ssIsSecureConnection;


		public BitArray OptimizedAttributes;

		public STRequestInfoStructure(params string[] dummy) {
			OptimizedAttributes = null;
			ssIsHttpRequest = false;
			ssMethod = "";
			ssScheme = "";
			ssHost = "";
			ssPort = 0;
			ssPath = "";
			ssQueryString = "";
			ssUrl = "";
			ssUserAgent = "";
			ssReferrer = "";
			ssIsSecureConnection = false;
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[0];
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
				}
			}
			get {
				BitArray[] all = new BitArray[0];
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssIsHttpRequest = r.ReadBoolean(index++, "RequestInfo.IsHttpRequest", false);
			ssMethod = r.ReadText(index++, "RequestInfo.Method", "");
			ssScheme = r.ReadText(index++, "RequestInfo.Scheme", "");
			ssHost = r.ReadText(index++, "RequestInfo.Host", "");
			ssPort = r.ReadInteger(index++, "RequestInfo.Port", 0);
			ssPath = r.ReadText(index++, "RequestInfo.Path", "");
			ssQueryString = r.ReadText(index++, "RequestInfo.QueryString", "");
			ssUrl = r.ReadText(index++, "RequestInfo.Url", "");
			ssUserAgent = r.ReadText(index++, "RequestInfo.UserAgent", "");
			ssReferrer = r.ReadText(index++, "RequestInfo.Referrer", "");
			ssIsSecureConnection = r.ReadBoolean(index++, "RequestInfo.IsSecureConnection", false);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(STRequestInfoStructure r) {
			this = r;
		}


		public static bool operator == (STRequestInfoStructure a, STRequestInfoStructure b) {
			if (a.ssIsHttpRequest != b.ssIsHttpRequest) return false;
			if (a.ssMethod != b.ssMethod) return false;
			if (a.ssScheme != b.ssScheme) return false;
			if (a.ssHost != b.ssHost) return false;
			if (a.ssPort != b.ssPort) return false;
			if (a.ssPath != b.ssPath) return false;
			if (a.ssQueryString != b.ssQueryString) return false;
			if (a.ssUrl != b.ssUrl) return false;
			if (a.ssUserAgent != b.ssUserAgent) return false;
			if (a.ssReferrer != b.ssReferrer) return false;
			if (a.ssIsSecureConnection != b.ssIsSecureConnection) return false;
			return true;
		}

		public static bool operator != (STRequestInfoStructure a, STRequestInfoStructure b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(STRequestInfoStructure)) return false;
			return (this == (STRequestInfoStructure) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssIsHttpRequest.GetHashCode()
				^ ssMethod.GetHashCode()
				^ ssScheme.GetHashCode()
				^ ssHost.GetHashCode()
				^ ssPort.GetHashCode()
				^ ssPath.GetHashCode()
				^ ssQueryString.GetHashCode()
				^ ssUrl.GetHashCode()
				^ ssUserAgent.GetHashCode()
				^ ssReferrer.GetHashCode()
				^ ssIsSecureConnection.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public STRequestInfoStructure(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssIsHttpRequest = false;
			ssMethod = "";
			ssScheme = "";
			ssHost = "";
			ssPort = 0;
			ssPath = "";
			ssQueryString = "";
			ssUrl = "";
			ssUserAgent = "";
			ssReferrer = "";
			ssIsSecureConnection = false;
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssIsHttpRequest", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIsHttpRequest' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIsHttpRequest = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssMethod", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssMethod' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssMethod = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssScheme", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssScheme' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssScheme = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssHost", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssHost' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssHost = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssPort", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssPort' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssPort = (int) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssPath", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssPath' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssPath = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssQueryString", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssQueryString' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssQueryString = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssUrl", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssUrl' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssUrl = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssUserAgent", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssUserAgent' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssUserAgent = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssReferrer", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssReferrer' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssReferrer = (string) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
			fieldInfo = objInfo.GetField("ssIsSecureConnection", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssIsSecureConnection' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssIsSecureConnection = (bool) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
		}

		public void InternalRecursiveSave() {
		}


		public STRequestInfoStructure Duplicate() {
			STRequestInfoStructure t;
			t.ssIsHttpRequest = this.ssIsHttpRequest;
			t.ssMethod = this.ssMethod;
			t.ssScheme = this.ssScheme;
			t.ssHost = this.ssHost;
			t.ssPort = this.ssPort;
			t.ssPath = this.ssPath;
			t.ssQueryString = this.ssQueryString;
			t.ssUrl = this.ssUrl;
			t.ssUserAgent = this.ssUserAgent;
			t.ssReferrer = this.ssReferrer;
			t.ssIsSecureConnection = this.ssIsSecureConnection;
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Structure");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
				fieldName = fieldName.ToLowerInvariant();
			}
			if (detailLevel > 0) {
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".IsHttpRequest")) VarValue.AppendAttribute(recordElem, "IsHttpRequest", ssIsHttpRequest, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "IsHttpRequest");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Method")) VarValue.AppendAttribute(recordElem, "Method", ssMethod, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Method");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Scheme")) VarValue.AppendAttribute(recordElem, "Scheme", ssScheme, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Scheme");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Host")) VarValue.AppendAttribute(recordElem, "Host", ssHost, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Host");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Port")) VarValue.AppendAttribute(recordElem, "Port", ssPort, detailLevel, TypeKind.Integer); else VarValue.AppendOptimizedAttribute(recordElem, "Port");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Path")) VarValue.AppendAttribute(recordElem, "Path", ssPath, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Path");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".QueryString")) VarValue.AppendAttribute(recordElem, "QueryString", ssQueryString, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "QueryString");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Url")) VarValue.AppendAttribute(recordElem, "Url", ssUrl, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Url");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".UserAgent")) VarValue.AppendAttribute(recordElem, "UserAgent", ssUserAgent, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "UserAgent");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".Referrer")) VarValue.AppendAttribute(recordElem, "Referrer", ssReferrer, detailLevel, TypeKind.Text); else VarValue.AppendOptimizedAttribute(recordElem, "Referrer");
				if (!VarValue.FieldIsOptimized(parent, fieldName + ".IsSecureConnection")) VarValue.AppendAttribute(recordElem, "IsSecureConnection", ssIsSecureConnection, detailLevel, TypeKind.Boolean); else VarValue.AppendOptimizedAttribute(recordElem, "IsSecureConnection");
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "ishttprequest") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".IsHttpRequest")) variable.Value = ssIsHttpRequest; else variable.Optimized = true;
			} else if (head == "method") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Method")) variable.Value = ssMethod; else variable.Optimized = true;
			} else if (head == "scheme") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Scheme")) variable.Value = ssScheme; else variable.Optimized = true;
			} else if (head == "host") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Host")) variable.Value = ssHost; else variable.Optimized = true;
			} else if (head == "port") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Port")) variable.Value = ssPort; else variable.Optimized = true;
			} else if (head == "path") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Path")) variable.Value = ssPath; else variable.Optimized = true;
			} else if (head == "querystring") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".QueryString")) variable.Value = ssQueryString; else variable.Optimized = true;
			} else if (head == "url") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Url")) variable.Value = ssUrl; else variable.Optimized = true;
			} else if (head == "useragent") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UserAgent")) variable.Value = ssUserAgent; else variable.Optimized = true;
			} else if (head == "referrer") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Referrer")) variable.Value = ssReferrer; else variable.Optimized = true;
			} else if (head == "issecureconnection") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".IsSecureConnection")) variable.Value = ssIsSecureConnection; else variable.Optimized = true;
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			throw new Exception("Method not Supported");
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdIsHttpRequest) {
				return ssIsHttpRequest;
			} else if (key == IdMethod) {
				return ssMethod;
			} else if (key == IdScheme) {
				return ssScheme;
			} else if (key == IdHost) {
				return ssHost;
			} else if (key == IdPort) {
				return ssPort;
			} else if (key == IdPath) {
				return ssPath;
			} else if (key == IdQueryString) {
				return ssQueryString;
			} else if (key == IdUrl) {
				return ssUrl;
			} else if (key == IdUserAgent) {
				return ssUserAgent;
			} else if (key == IdReferrer) {
				return ssReferrer;
			} else if (key == IdIsSecureConnection) {
				return ssIsSecureConnection;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssIsHttpRequest = (bool) other.AttributeGet(IdIsHttpRequest);
			ssMethod = (string) other.AttributeGet(IdMethod);
			ssScheme = (string) other.AttributeGet(IdScheme);
			ssHost = (string) other.AttributeGet(IdHost);
			ssPort = (int) other.AttributeGet(IdPort);
			ssPath = (string) other.AttributeGet(IdPath);
			ssQueryString = (string) other.AttributeGet(IdQueryString);
			ssUrl = (string) other.AttributeGet(IdUrl);
			ssUserAgent = (string) other.AttributeGet(IdUserAgent);
			ssReferrer = (string) other.AttributeGet(IdReferrer);
			ssIsSecureConnection = (bool) other.AttributeGet(IdIsSecureConnection);
		}
		public bool IsDefault() {
			STRequestInfoStructure defaultStruct = new STRequestInfoStructure(null);
			if (this.ssIsHttpRequest != defaultStruct.ssIsHttpRequest) return false;
			if (this.ssMethod != defaultStruct.ssMethod) return false;
			if (this.ssScheme != defaultStruct.ssScheme) return false;
			if (this.ssHost != defaultStruct.ssHost) return false;
			if (this.ssPort != defaultStruct.ssPort) return false;
			if (this.ssPath != defaultStruct.ssPath) return false;
			if (this.ssQueryString != defaultStruct.ssQueryString) return false;
			if (this.ssUrl != defaultStruct.ssUrl) return false;
			if (this.ssUserAgent != defaultStruct.ssUserAgent) return false;
			if (this.ssReferrer != defaultStruct.ssReferrer) return false;
			if (this.ssIsSecureConnection != defaultStruct.ssIsSecureConnection) return false;
			return true;
		}
	} // STRequestInfoStructure

} // OutSystems.NssEnvironmentInfo_Ext

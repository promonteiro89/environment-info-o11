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

} // OutSystems.NssEnvironmentInfo_Ext

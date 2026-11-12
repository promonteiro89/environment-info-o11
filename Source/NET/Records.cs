using System;
using System.Collections;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;

namespace OutSystems.NssEnvironmentInfo_Ext {

	/// <summary>
	/// Structure <code>RCServerModeRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCServerModeRecord: ISerializable, ITypedRecord<RCServerModeRecord> {
		internal static readonly GlobalObjectKey IdServerMode = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*2du+NuohH+6EeIg8Q20DLg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ServerMode")]
		public STServerModeStructure ssSTServerMode;


		public static implicit operator STServerModeStructure(RCServerModeRecord r) {
			return r.ssSTServerMode;
		}

		public static implicit operator RCServerModeRecord(STServerModeStructure r) {
			RCServerModeRecord res = new RCServerModeRecord(null);
			res.ssSTServerMode = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCServerModeRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTServerMode = new STServerModeStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTServerMode.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTServerMode.Read(r, ref index);
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
		public void ReadIM(RCServerModeRecord r) {
			this = r;
		}


		public static bool operator == (RCServerModeRecord a, RCServerModeRecord b) {
			if (a.ssSTServerMode != b.ssSTServerMode) return false;
			return true;
		}

		public static bool operator != (RCServerModeRecord a, RCServerModeRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCServerModeRecord)) return false;
			return (this == (RCServerModeRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTServerMode.GetHashCode()
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

		public RCServerModeRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTServerMode = new STServerModeStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTServerMode", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTServerMode' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTServerMode = (STServerModeStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTServerMode.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTServerMode.InternalRecursiveSave();
		}


		public RCServerModeRecord Duplicate() {
			RCServerModeRecord t;
			t.ssSTServerMode = (STServerModeStructure) this.ssSTServerMode.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTServerMode.ToXml(this, recordElem, "ServerMode", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "servermode") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ServerMode")) variable.Value = ssSTServerMode; else variable.Optimized = true;
				variable.SetFieldName("servermode");
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
			if (key == IdServerMode) {
				return ssSTServerMode;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTServerMode.FillFromOther((IRecord) other.AttributeGet(IdServerMode));
		}
		public bool IsDefault() {
			RCServerModeRecord defaultStruct = new RCServerModeRecord(null);
			if (this.ssSTServerMode != defaultStruct.ssSTServerMode) return false;
			return true;
		}
	} // RCServerModeRecord

	/// <summary>
	/// Structure <code>RCRuntimeInfoRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCRuntimeInfoRecord: ISerializable, ITypedRecord<RCRuntimeInfoRecord> {
		internal static readonly GlobalObjectKey IdRuntimeInfo = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*mKba1jA+bMNwX1QJt5Hfgg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("RuntimeInfo")]
		public STRuntimeInfoStructure ssSTRuntimeInfo;


		public static implicit operator STRuntimeInfoStructure(RCRuntimeInfoRecord r) {
			return r.ssSTRuntimeInfo;
		}

		public static implicit operator RCRuntimeInfoRecord(STRuntimeInfoStructure r) {
			RCRuntimeInfoRecord res = new RCRuntimeInfoRecord(null);
			res.ssSTRuntimeInfo = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCRuntimeInfoRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTRuntimeInfo = new STRuntimeInfoStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTRuntimeInfo.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTRuntimeInfo.Read(r, ref index);
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
		public void ReadIM(RCRuntimeInfoRecord r) {
			this = r;
		}


		public static bool operator == (RCRuntimeInfoRecord a, RCRuntimeInfoRecord b) {
			if (a.ssSTRuntimeInfo != b.ssSTRuntimeInfo) return false;
			return true;
		}

		public static bool operator != (RCRuntimeInfoRecord a, RCRuntimeInfoRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCRuntimeInfoRecord)) return false;
			return (this == (RCRuntimeInfoRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTRuntimeInfo.GetHashCode()
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

		public RCRuntimeInfoRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTRuntimeInfo = new STRuntimeInfoStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTRuntimeInfo", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTRuntimeInfo' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTRuntimeInfo = (STRuntimeInfoStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTRuntimeInfo.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTRuntimeInfo.InternalRecursiveSave();
		}


		public RCRuntimeInfoRecord Duplicate() {
			RCRuntimeInfoRecord t;
			t.ssSTRuntimeInfo = (STRuntimeInfoStructure) this.ssSTRuntimeInfo.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTRuntimeInfo.ToXml(this, recordElem, "RuntimeInfo", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "runtimeinfo") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".RuntimeInfo")) variable.Value = ssSTRuntimeInfo; else variable.Optimized = true;
				variable.SetFieldName("runtimeinfo");
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
			if (key == IdRuntimeInfo) {
				return ssSTRuntimeInfo;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTRuntimeInfo.FillFromOther((IRecord) other.AttributeGet(IdRuntimeInfo));
		}
		public bool IsDefault() {
			RCRuntimeInfoRecord defaultStruct = new RCRuntimeInfoRecord(null);
			if (this.ssSTRuntimeInfo != defaultStruct.ssSTRuntimeInfo) return false;
			return true;
		}
	} // RCRuntimeInfoRecord

	/// <summary>
	/// Structure <code>RCEnvironmentInfoRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCEnvironmentInfoRecord: ISerializable, ITypedRecord<RCEnvironmentInfoRecord> {
		internal static readonly GlobalObjectKey IdEnvironmentInfo = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*AzM0_NWU63mYX1HRJJQTHQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("EnvironmentInfo")]
		public STEnvironmentInfoStructure ssSTEnvironmentInfo;


		public static implicit operator STEnvironmentInfoStructure(RCEnvironmentInfoRecord r) {
			return r.ssSTEnvironmentInfo;
		}

		public static implicit operator RCEnvironmentInfoRecord(STEnvironmentInfoStructure r) {
			RCEnvironmentInfoRecord res = new RCEnvironmentInfoRecord(null);
			res.ssSTEnvironmentInfo = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCEnvironmentInfoRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTEnvironmentInfo = new STEnvironmentInfoStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTEnvironmentInfo.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTEnvironmentInfo.Read(r, ref index);
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
		public void ReadIM(RCEnvironmentInfoRecord r) {
			this = r;
		}


		public static bool operator == (RCEnvironmentInfoRecord a, RCEnvironmentInfoRecord b) {
			if (a.ssSTEnvironmentInfo != b.ssSTEnvironmentInfo) return false;
			return true;
		}

		public static bool operator != (RCEnvironmentInfoRecord a, RCEnvironmentInfoRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCEnvironmentInfoRecord)) return false;
			return (this == (RCEnvironmentInfoRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTEnvironmentInfo.GetHashCode()
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

		public RCEnvironmentInfoRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTEnvironmentInfo = new STEnvironmentInfoStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTEnvironmentInfo", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTEnvironmentInfo' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTEnvironmentInfo = (STEnvironmentInfoStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTEnvironmentInfo.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTEnvironmentInfo.InternalRecursiveSave();
		}


		public RCEnvironmentInfoRecord Duplicate() {
			RCEnvironmentInfoRecord t;
			t.ssSTEnvironmentInfo = (STEnvironmentInfoStructure) this.ssSTEnvironmentInfo.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTEnvironmentInfo.ToXml(this, recordElem, "EnvironmentInfo", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "environmentinfo") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".EnvironmentInfo")) variable.Value = ssSTEnvironmentInfo; else variable.Optimized = true;
				variable.SetFieldName("environmentinfo");
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
			if (key == IdEnvironmentInfo) {
				return ssSTEnvironmentInfo;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTEnvironmentInfo.FillFromOther((IRecord) other.AttributeGet(IdEnvironmentInfo));
		}
		public bool IsDefault() {
			RCEnvironmentInfoRecord defaultStruct = new RCEnvironmentInfoRecord(null);
			if (this.ssSTEnvironmentInfo != defaultStruct.ssSTEnvironmentInfo) return false;
			return true;
		}
	} // RCEnvironmentInfoRecord

	/// <summary>
	/// Structure <code>RCModuleInfoRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCModuleInfoRecord: ISerializable, ITypedRecord<RCModuleInfoRecord> {
		internal static readonly GlobalObjectKey IdModuleInfo = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*77cw434hU5Cbi4rRajODUA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ModuleInfo")]
		public STModuleInfoStructure ssSTModuleInfo;


		public static implicit operator STModuleInfoStructure(RCModuleInfoRecord r) {
			return r.ssSTModuleInfo;
		}

		public static implicit operator RCModuleInfoRecord(STModuleInfoStructure r) {
			RCModuleInfoRecord res = new RCModuleInfoRecord(null);
			res.ssSTModuleInfo = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCModuleInfoRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTModuleInfo = new STModuleInfoStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTModuleInfo.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTModuleInfo.Read(r, ref index);
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
		public void ReadIM(RCModuleInfoRecord r) {
			this = r;
		}


		public static bool operator == (RCModuleInfoRecord a, RCModuleInfoRecord b) {
			if (a.ssSTModuleInfo != b.ssSTModuleInfo) return false;
			return true;
		}

		public static bool operator != (RCModuleInfoRecord a, RCModuleInfoRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCModuleInfoRecord)) return false;
			return (this == (RCModuleInfoRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTModuleInfo.GetHashCode()
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

		public RCModuleInfoRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTModuleInfo = new STModuleInfoStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTModuleInfo", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTModuleInfo' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTModuleInfo = (STModuleInfoStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTModuleInfo.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTModuleInfo.InternalRecursiveSave();
		}


		public RCModuleInfoRecord Duplicate() {
			RCModuleInfoRecord t;
			t.ssSTModuleInfo = (STModuleInfoStructure) this.ssSTModuleInfo.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTModuleInfo.ToXml(this, recordElem, "ModuleInfo", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "moduleinfo") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ModuleInfo")) variable.Value = ssSTModuleInfo; else variable.Optimized = true;
				variable.SetFieldName("moduleinfo");
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
			if (key == IdModuleInfo) {
				return ssSTModuleInfo;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTModuleInfo.FillFromOther((IRecord) other.AttributeGet(IdModuleInfo));
		}
		public bool IsDefault() {
			RCModuleInfoRecord defaultStruct = new RCModuleInfoRecord(null);
			if (this.ssSTModuleInfo != defaultStruct.ssSTModuleInfo) return false;
			return true;
		}
	} // RCModuleInfoRecord

	/// <summary>
	/// Structure <code>RCRequestInfoRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCRequestInfoRecord: ISerializable, ITypedRecord<RCRequestInfoRecord> {
		internal static readonly GlobalObjectKey IdRequestInfo = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*RxdMmfjtmTzwJEBiySNI7w");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("RequestInfo")]
		public STRequestInfoStructure ssSTRequestInfo;


		public static implicit operator STRequestInfoStructure(RCRequestInfoRecord r) {
			return r.ssSTRequestInfo;
		}

		public static implicit operator RCRequestInfoRecord(STRequestInfoStructure r) {
			RCRequestInfoRecord res = new RCRequestInfoRecord(null);
			res.ssSTRequestInfo = r;
			return res;
		}

		public BitArray OptimizedAttributes;

		public RCRequestInfoRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssSTRequestInfo = new STRequestInfoStructure(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = null;
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
				} else {
					ssSTRequestInfo.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = null;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssSTRequestInfo.Read(r, ref index);
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
		public void ReadIM(RCRequestInfoRecord r) {
			this = r;
		}


		public static bool operator == (RCRequestInfoRecord a, RCRequestInfoRecord b) {
			if (a.ssSTRequestInfo != b.ssSTRequestInfo) return false;
			return true;
		}

		public static bool operator != (RCRequestInfoRecord a, RCRequestInfoRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCRequestInfoRecord)) return false;
			return (this == (RCRequestInfoRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssSTRequestInfo.GetHashCode()
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

		public RCRequestInfoRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssSTRequestInfo = new STRequestInfoStructure(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssSTRequestInfo", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssSTRequestInfo' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssSTRequestInfo = (STRequestInfoStructure) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssSTRequestInfo.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssSTRequestInfo.InternalRecursiveSave();
		}


		public RCRequestInfoRecord Duplicate() {
			RCRequestInfoRecord t;
			t.ssSTRequestInfo = (STRequestInfoStructure) this.ssSTRequestInfo.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssSTRequestInfo.ToXml(this, recordElem, "RequestInfo", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "requestinfo") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".RequestInfo")) variable.Value = ssSTRequestInfo; else variable.Optimized = true;
				variable.SetFieldName("requestinfo");
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
			if (key == IdRequestInfo) {
				return ssSTRequestInfo;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssSTRequestInfo.FillFromOther((IRecord) other.AttributeGet(IdRequestInfo));
		}
		public bool IsDefault() {
			RCRequestInfoRecord defaultStruct = new RCRequestInfoRecord(null);
			if (this.ssSTRequestInfo != defaultStruct.ssSTRequestInfo) return false;
			return true;
		}
	} // RCRequestInfoRecord
}

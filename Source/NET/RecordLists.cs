using System;
using System.Data;
using System.Collections;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;

namespace OutSystems.NssEnvironmentInfo_Ext {

	/// <summary>
	/// RecordList type <code>RLServerModeRecordList</code> that represents a record list of
	///  <code>ServerMode</code>
	/// </summary>
	[Serializable()]
	public partial class RLServerModeRecordList: GenericRecordList<RCServerModeRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCServerModeRecord GetElementDefaultValue() {
			return new RCServerModeRecord("");
		}

		public T[] ToArray<T>(Func<RCServerModeRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLServerModeRecordList recordlist, Func<RCServerModeRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLServerModeRecordList(RCServerModeRecord[] array) {
			RLServerModeRecordList result = new RLServerModeRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLServerModeRecordList ToList<T>(T[] array, Func <T, RCServerModeRecord> converter) {
			RLServerModeRecordList result = new RLServerModeRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLServerModeRecordList FromRestList<T>(RestList<T> restList, Func <T, RCServerModeRecord> converter) {
			RLServerModeRecordList result = new RLServerModeRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLServerModeRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLServerModeRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLServerModeRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLServerModeRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCServerModeRecord> NewList() {
			return new RLServerModeRecordList();
		}


	} // RLServerModeRecordList

	/// <summary>
	/// RecordList type <code>RLRuntimeInfoRecordList</code> that represents a record list of
	///  <code>RuntimeInfo</code>
	/// </summary>
	[Serializable()]
	public partial class RLRuntimeInfoRecordList: GenericRecordList<RCRuntimeInfoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCRuntimeInfoRecord GetElementDefaultValue() {
			return new RCRuntimeInfoRecord("");
		}

		public T[] ToArray<T>(Func<RCRuntimeInfoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLRuntimeInfoRecordList recordlist, Func<RCRuntimeInfoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLRuntimeInfoRecordList(RCRuntimeInfoRecord[] array) {
			RLRuntimeInfoRecordList result = new RLRuntimeInfoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLRuntimeInfoRecordList ToList<T>(T[] array, Func <T, RCRuntimeInfoRecord> converter) {
			RLRuntimeInfoRecordList result = new RLRuntimeInfoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLRuntimeInfoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCRuntimeInfoRecord> converter) {
			RLRuntimeInfoRecordList result = new RLRuntimeInfoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLRuntimeInfoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLRuntimeInfoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLRuntimeInfoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLRuntimeInfoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCRuntimeInfoRecord> NewList() {
			return new RLRuntimeInfoRecordList();
		}


	} // RLRuntimeInfoRecordList

	/// <summary>
	/// RecordList type <code>RLEnvironmentInfoRecordList</code> that represents a record list of
	///  <code>EnvironmentInfo</code>
	/// </summary>
	[Serializable()]
	public partial class RLEnvironmentInfoRecordList: GenericRecordList<RCEnvironmentInfoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCEnvironmentInfoRecord GetElementDefaultValue() {
			return new RCEnvironmentInfoRecord("");
		}

		public T[] ToArray<T>(Func<RCEnvironmentInfoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLEnvironmentInfoRecordList recordlist, Func<RCEnvironmentInfoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLEnvironmentInfoRecordList(RCEnvironmentInfoRecord[] array) {
			RLEnvironmentInfoRecordList result = new RLEnvironmentInfoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLEnvironmentInfoRecordList ToList<T>(T[] array, Func <T, RCEnvironmentInfoRecord> converter) {
			RLEnvironmentInfoRecordList result = new RLEnvironmentInfoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLEnvironmentInfoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCEnvironmentInfoRecord> converter) {
			RLEnvironmentInfoRecordList result = new RLEnvironmentInfoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLEnvironmentInfoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEnvironmentInfoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEnvironmentInfoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLEnvironmentInfoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCEnvironmentInfoRecord> NewList() {
			return new RLEnvironmentInfoRecordList();
		}


	} // RLEnvironmentInfoRecordList

	/// <summary>
	/// RecordList type <code>RLModuleInfoRecordList</code> that represents a record list of
	///  <code>ModuleInfo</code>
	/// </summary>
	[Serializable()]
	public partial class RLModuleInfoRecordList: GenericRecordList<RCModuleInfoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCModuleInfoRecord GetElementDefaultValue() {
			return new RCModuleInfoRecord("");
		}

		public T[] ToArray<T>(Func<RCModuleInfoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLModuleInfoRecordList recordlist, Func<RCModuleInfoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLModuleInfoRecordList(RCModuleInfoRecord[] array) {
			RLModuleInfoRecordList result = new RLModuleInfoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLModuleInfoRecordList ToList<T>(T[] array, Func <T, RCModuleInfoRecord> converter) {
			RLModuleInfoRecordList result = new RLModuleInfoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLModuleInfoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCModuleInfoRecord> converter) {
			RLModuleInfoRecordList result = new RLModuleInfoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLModuleInfoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLModuleInfoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLModuleInfoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLModuleInfoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCModuleInfoRecord> NewList() {
			return new RLModuleInfoRecordList();
		}


	} // RLModuleInfoRecordList

	/// <summary>
	/// RecordList type <code>RLRequestInfoRecordList</code> that represents a record list of
	///  <code>RequestInfo</code>
	/// </summary>
	[Serializable()]
	public partial class RLRequestInfoRecordList: GenericRecordList<RCRequestInfoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCRequestInfoRecord GetElementDefaultValue() {
			return new RCRequestInfoRecord("");
		}

		public T[] ToArray<T>(Func<RCRequestInfoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLRequestInfoRecordList recordlist, Func<RCRequestInfoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLRequestInfoRecordList(RCRequestInfoRecord[] array) {
			RLRequestInfoRecordList result = new RLRequestInfoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLRequestInfoRecordList ToList<T>(T[] array, Func <T, RCRequestInfoRecord> converter) {
			RLRequestInfoRecordList result = new RLRequestInfoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLRequestInfoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCRequestInfoRecord> converter) {
			RLRequestInfoRecordList result = new RLRequestInfoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLRequestInfoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLRequestInfoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLRequestInfoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLRequestInfoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = null;
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCRequestInfoRecord> NewList() {
			return new RLRequestInfoRecordList();
		}


	} // RLRequestInfoRecordList
}

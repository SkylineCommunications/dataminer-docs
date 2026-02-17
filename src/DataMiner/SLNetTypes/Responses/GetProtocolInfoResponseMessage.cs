using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;

using Skyline.DataMiner.Net.Parser.ProtocolParsers;
using Skyline.DataMiner.Net.Topology;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Represents information for a single protocol
	/// </summary>
	public class GetProtocolInfoResponseMessage : ResponseMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetProtocolInfoResponseMessage"/> class.
		/// </summary>
		public GetProtocolInfoResponseMessage() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="GetProtocolInfoResponseMessage"/> class.
		/// </summary>
		/// <exception cref="ArgumentNullException"><paramref name="protocolInfo"/> is <see langword="null"/>.</exception>
		protected GetProtocolInfoResponseMessage(GetProtocolInfoResponseMessage protocolInfo)
		{
			if (protocolInfo == null)
				throw new ArgumentNullException("protocolInfo");
		}

		/// <summary>
		/// Links all of the child parameter info objects to this object.
		/// </summary>
		public void LinkParametersToProtocol()
		{
		}

		#region HasCharacteristics code

		/// <summary>
		/// Checks whether this protocol has the specified characteristic.
		/// </summary>
		/// <param name="c">The characteristic to check.</param>
		/// <returns><c>true</c> if this protocol has the specified characteristic; otherwise, <c>false</c>.</returns>
		private bool HasCharacteristic(Characteristics c)
		{
			return false;
		}

		/// <summary>
		/// Updates a certain characteristic of the protocol.
		/// </summary>
		/// <param name="c">The characteristic to update.</param>
		/// <param name="newVal">The new value.</param>
		private void UpdateCharacteristic(Characteristics c, bool newVal)
		{
		}

		/// <summary>
		/// Represents a characteristic of the protocol.
		/// </summary>
		[Flags]
		private enum Characteristics : int
		{
			None = 0x0000,
			HasInformationTemplateApplied = 0x0001,
			DisableViewRefresh = 0x0002,
			IsUnicodeType = 0x0004,
			IsDveMainElement = 0x0008,
			IsSigned = 0x0010,
			IsBaseProtocol = 0x0020,
			HasHelp = 0x0040,
			HasVdx = 0x0080,
			HasVsdx = 0x0100,
			IsMatrixElement = 0x0200,
			HasConnectivityInterfaces = 0x0400,
			HasNoElementPrefix = 0x0800
		}

		#endregion

		/// <summary>
		/// Gets or sets a value indicating whether this protocol has no element prefix.
		/// </summary>
		/// <value><c>true</c> if the protocol has no element prefix; otherwise, <c>false</c>.</value>
		public bool HasNoElementPrefix
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this protocol has connectivity interfaces.
		/// </summary>
		/// <value><c>true</c> if the protocol has connectivity interfaces; otherwise, <c>false</c>.</value>
		public bool HasConnectivityInterfaces
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the function GUID.
		/// </summary>
		/// <value>The function GUID.</value>
		public string FunctionGUID
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the parameter groups.
		/// </summary>
		/// <value>The parameter groups.</value>
		public ParameterGroupInfo[] ParameterGroups
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this protocol object has the information.xml template information applied to it.
		/// </summary>
		/// <value><c>true</c> if this protocol object has the information.xml template information applied to it.</value>
		public bool HasInformationTemplateApplied
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether "view" type tables in this protocol cannot be automatically refreshed by the client.
		/// </summary>
		/// <value><c>true</c> if "view" type tables in this protocol cannot be automatically refreshed by the client.</value>
		public bool DisableViewRefresh
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the protocol table keys are in Unicode.
		/// </summary>
		/// <value><c>true</c> if the protocol table keys are in Unicode.</value>
		public bool IsUnicodeType
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the protocol defines exported protocols, making it a main element for DVE children.
		/// </summary>
		/// <value><c>true</c> if the protocol defines exported protocols, making it a main element for DVE children.</value>
		public bool IsDveMainElement
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the protocol defines matrix parameters.
		/// </summary>
		/// <value><c>true</c> if the protocol defines matrix parameters.</value>
		public bool IsMatrixElement
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the protocol is a base protocol.
		/// </summary>
		/// <value><c>true</c> if the protocol is a base protocol.</value>
		public bool IsBaseProtocol
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this protocol object has help available.
		/// </summary>
		/// <value><c>true</c> if this protocol object has help available.</value>
		public bool HasHelp
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this protocol object has a VDX available.
		/// </summary>
		/// <value><c>true</c> if this protocol object has a VDX available.</value>
		public bool HasVdx
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this protocol object has a VSDX available.
		/// </summary>
		/// <value><c>true</c> if this protocol object has a VSDX available.</value>
		public bool HasVsdx
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this protocol object has a VDX or VSDX available.
		/// </summary>
		/// <value><c>true</c> if this protocol object has a VDX or VSDX available.</value>
		public bool HasVisio
		{
			get { return HasVdx || HasVsdx; }
		}

		/// <summary>
		/// Gets or sets the name of the element type for which this protocol is a base protocol, if this protocol is a base protocol.
		/// </summary>
		/// <value>If this protocol is a base protocol, contains the name of the element type for which this protocol is a base protocol.</value>
		public string BaseProtocolType
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this protocol has a signature.
		/// </summary>
		/// <value><c>true</c> if this protocol has a signature.</value>
		public bool IsSigned
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the vendor that signed this protocol.
		/// </summary>
		/// <value>The vendor who signed the protocol or <see langword="null"/> if not signed.</value>
		public string SignVendor
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this protocol is exported.
		/// </summary>
		/// <value><c>true</c> if this protocol is exported.</value>
		public bool IsExportedProtocol
		{
			get;
		}

		/// <summary>
		/// Returns a value indication of whether this protocol is a virtual function.
		/// </summary>
		/// <returns><c>true</c> if this protocol is a virtual function; otherwise, <c>false</c>.</returns>
		public bool IsVirtualFunction()
		{
			return !string.IsNullOrEmpty(FunctionGUID);
		}

		/// <summary>
		/// Gets or sets the topologies.
		/// </summary>
		/// <value>The topologies.</value>
		public ProtocolTopology[] Topologies { get; set; }

		/// <summary>
		/// Gets or sets the topology chains.
		/// </summary>
		/// <value>The topology chains.</value>
		public ProtocolTopologyChain[] TopologyChains { get; set; }

		/// <summary>
		/// Gets or sets the topology chains filter.
		/// </summary>
		/// <value>The topology chains filter.</value>
		public TopologyChainsFilterType TopologyChainsFilter { get; set; }

		/// <summary>
		/// Gets or sets the search chains that have been defined.
		/// </summary>
		/// <value>The search chains that have been defined.</value>
		public SearchChain[] TopologySearchChains { get; set; }

		/// <summary>
		/// Gets all topology chains (combination of TopologyChains and SearchChains) in the order defined in the protocol.xml.
		/// </summary>
		/// <value>All topology chains.</value>
		public IEnumerable<IProtocolTopologyChain> TopologyAllChains
		{
			get;
		}

		/// <summary>
		/// Gets or sets the table relations specified in the protocol.
		/// </summary>
		/// <value>The table relations specified in the protocol.</value>
		public ProtocolRelation[] Relations { get; set; }

		/// <summary>
		/// The tree control definitions.
		/// </summary>
		public TreeControl[] TreeControls;

		/// <summary>
		/// Gets or sets the search control definitions.
		/// </summary>
		/// <value>The search control definitions.</value>
		public SearchControl[] SearchControls { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this protocol contains at least one active parameter that will be indexed as DynamicData.
		/// </summary>
		/// <value><c>true</c> if this protocol contains at least one active parameter that will be indexed as DynamicData.</value>
		public bool IsIndexing { get; set; }

		/// <summary>
		/// The protocol description.
		/// </summary>
		public String Description;

		/// <summary>
		/// The protocol name.
		/// </summary>
		public String Name;

		/// <summary>
		/// Gets or sets the provider.
		/// </summary>
		/// <value>The provider.</value>
		public String Provider { get; set; }

		/// <summary>
		/// Gets or sets the advanced security.
		/// </summary>
		/// <value>The advanced security.</value>
		public String AdvancedSecurity { get; set; }

		/// <summary>
		/// Gets or sets the name of the parent protocol for which the protocol was exported. (For exported protocols.)
		/// </summary>
		/// <value>For exported protocols, the name of the parent protocol for which the protocol was exported.</value>
		public string ParentProtocolName { get; set; }

		/// <summary>
		/// The protocol version.
		/// </summary>
		public String Version;

		/// <summary>
		/// Gets or sets the protocol version history.
		/// </summary>
		/// <value>The protocol version history.</value>
		public VersionHistory VersionHistory { get; set; }

		/// <summary>
		/// Gets or sets the Process Automation info.
		/// </summary>
		/// <value>The Process Automation info.</value>
		public ProcessAutomationInfo ProcessAutomationInfo { get; set; }

		/// <summary>
		/// The vendor.
		/// </summary>
		public String Vendor;

		/// <summary>
		/// The list of available protocol functions.
		/// </summary>
		public List<FunctionDefinition> ProtocolFunctions { get; set; }

		/// <summary>
		/// The protocol type.
		/// </summary>
		public String Type;

		/// <summary>
		/// Gets or sets the protocol type.
		/// </summary>
		/// <value>The protocol type.</value>
		public ProtocolType ProtocolType
		{
			get; set;
		}

		/// <summary>
		/// Gets the protocol types.
		/// </summary>
		/// <value>The protocol types.</value>
		public ProtocolType[] ProtocolTypes
		{
			get;
		}

		/// <summary>
		/// Checks the main type and advanced types if it matches the specified value.
		/// </summary>
		/// <param name="typeToCheck">The type to check (e.g. serial).</param>
		/// <returns><c>true</c> if the main type or one of the advanced types matches the specified value.</returns>
		public bool IsProtocolType(ProtocolType typeToCheck)
		{
			return ProtocolTypes.Contains(typeToCheck);
		}

		/// <summary>
		/// The main connection name.
		/// </summary>
		public String MainConnectionName;

		/// <summary>
		/// Converts the specified type to <see cref="ProtocolType"/>.
		/// </summary>
		/// <param name="unparsed">The protocol type.</param>
		/// <returns>The corresponding <see cref="ProtocolType"/>.</returns>
		public static ProtocolType ToProtocolType(string unparsed)
		{
			return ProtocolType.Unknown;
		}

		/// <summary>
		/// Converts the <see cref="ProtocolType"/> enum to its string representation. 
		/// </summary>
		/// <param name="type">The protocol type to convert.</param>
		/// <returns>The string representation of the protocol type. Empty string when the type is not known.</returns>
		public static string ProtocolTypeToString(ProtocolType type)
		{
			return String.Empty;
		}

		/// <summary>
		/// The extra port types/names "type1:name1;type2:name2".
		/// </summary>
		public String AdvancedTypes;

		/// <summary>
		/// The default page.
		/// </summary>
		public String DefaultPage;

		/// <summary>
		/// Name of the information template to use. 
		/// </summary>
		public String Information;

		/// <summary>
		/// The page order.
		/// </summary>
		public String PageOrder;

		/// <summary>
		/// The page options.
		/// </summary>
		public String PageOptions;

		/// <summary>
		/// The display type.
		/// </summary>
		public String DisplayType;

		/// <summary>
		/// The wide column pages.
		/// </summary>
		public String DisplayWideColumnPages;

		/// <summary>
		/// Page information.
		/// </summary>
		public PageInfo[] Pages { get; set; }

		/// <summary>
		/// The element type.
		/// </summary>
		public String ElementType;

		/// <summary>
		/// Gets the list of exported tables.
		/// </summary>
		/// <value>The list of exported tables.</value>
		/// <remarks>Only applicable for a DVE main protocol; <see langword="null"/> if this protocol is not a DVE main protocol.</remarks>
		public ExportedTableInfo[] ExportedTables { get; }

		/// <summary>
		/// Gets or sets the raw version of the data exposed by <see cref="GetProtocolInfoResponseMessage.ExportedTables"/>.
		/// </summary>
		/// <value>The raw version of the data exposed by <see cref="GetProtocolInfoResponseMessage.ExportedTables"/>.</value>
		public string ExportedTableRawInfo { get; set; }

		/// <summary>
		/// Gets a value indicating whether this protocol is an aggregator protocol.
		/// </summary>
		/// <value><c>true</c> if this protocol is an aggregator protocol.</value>
		public bool IsAggregatorProtocol { get; }

		/// <summary>
		/// Gets or sets the application type.
		/// </summary>
		/// <value>The application type.</value>
		/// <remarks>When an application type is specified, the elements using this protocol will be displayed as Application items in DataMiner Cube.</remarks>
		public string AppType { get; set; }

		/// <summary>
		/// Gets a value indicating whether this protocol is an application.
		/// </summary>
		/// <value><c>true</c> if this protocol is an application; otherwise, <c>false</c>.</value>
		public bool IsApp { get { return !String.IsNullOrEmpty(AppType); } }

		/// <summary>
		/// The configuration options.
		/// </summary>
		public PortSettingsOptions ConfigurationOptions;

		/// <summary>
		/// The extra port config options.
		/// </summary>
		public PortSettingsOptions[] ExtraPortsConfigOptions;

		/// <summary>
		/// Gets or sets a value indicating whether this protocol needs to enable partitioning on the trend tables.
		/// </summary>
		/// <value><c>true</c> if this protocol needs to enable partitioning on the trend tables; otherwise, <c>false</c>.</value>
		public bool IsPartitionedTrendingEnabled { get; set; }

		/// <summary>
		/// The protocol parameters.
		/// </summary>
		public ParameterInfo[] Parameters;

		/// <summary>
		/// Gets or sets all parameters.
		/// </summary>
		/// <value>All parameters.</value>
		public ParameterInfo[] AllParameters
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets all base protocol parameters.
		/// </summary>
		/// <value>All base protocol parameters.</value>
		public ParameterInfo[] BaseParameters { get; set; }

		/// <summary>
		/// Applies the specified user level.
		/// </summary>
		/// <param name="level">The user level to apply.</param>
		public void ApplyUserLevel(int level)
		{
		}

		/// <summary>
		/// Retrieves a value that indicates whether the specified parameter is visible for the specified user level.
		/// </summary>
		/// <param name="parameter">The parameter.</param>
		/// <param name="level">The level.</param>
		/// <returns><c>true</c> if the specified parameter is visible for the specified user level; otherwise, <c>false</c>.</returns>
		private Boolean ParameterVisibleForUserLevel(ParameterInfo parameter, int level)
		{
			return false;
		}

		/// <summary>
		/// The trending.
		/// </summary>
		public bool Trending;

		/// <summary>
		/// Gets or sets a value indicating whether this protocol is a production protocol.
		/// </summary>
		/// <value><c>true</c> if this protocol is a production protocol; otherwise, <c>false</c>.</value>
		public bool IsProduction { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this protocol defines RCA.
		/// </summary>
		/// <value><c>true</c> if this protocol defines RCA; otherwise, <c>false</c>.</value>
		public bool DefinesRCA { get; set; }

		/// <summary>
		/// Gets or sets the icon info (XAML code).
		/// </summary>
		/// <value>The icon code.</value>
		public string Icon { get; set; }

		/// <summary>
		/// If the protocol defines internal RCA chains (RCA/Protocol/Link), the maximum depth. Otherwise, -1.
		/// </summary>
		/// <value>The maximum depth.</value>
		public int MaxProtocolRCA { get; set; }

		/// <summary>
		/// Gets a value indicating whether the forceDefaultAlarming option is used.
		/// </summary>
		/// <value><c>true</c> if the forceDefaultAlarming option is used; otherwise, <c>false</c>.</value>
		public bool ForceDefaultAlarming { get; set; }

		/// <summary>
		/// Returns the name of a specified parameter.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <returns>The parameter name.</returns>
		public string GetParameterName(int parameterID)
		{
			return String.Empty;
		}

		/// <summary>
		/// Gets all parameters.
		/// </summary>
		/// <returns>All parameters.</returns>
		public IEnumerable<ParameterInfo> GetAllParameters()
		{
			var result = new List<ParameterInfo>();

			return result;
		}

		/// <summary>
		/// Gets the name of the specified parameter.
		/// </summary>
		/// <param name="parameterID">The ID of the parameter.</param>
		/// <param name="idx">The index.</param>
		/// <returns>The parameter name.</returns>
		public string GetParameterName(int parameterID, string idx)
		{
			if (String.IsNullOrEmpty(idx))
				return GetParameterName(parameterID);
			return String.Format(CultureInfo.InvariantCulture, "{0} ({1})", GetParameterName(parameterID), idx);
		}

		/// <summary>
		/// Converts the given raw value into a format ready for display in the UI, with number group separator.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="rawValue">The raw value.</param>
		/// <param name="isFromRawString">Whether the origin of the value is raw-based. Default is <c>true</c>.</param>
		/// <param name="includeUnits">Whether units should be included in the value. Default is <c>true</c>.</param>
		/// <returns>The parameter display value.</returns>
		public string GetUIParameterDisplayValue(int parameterID, string rawValue, bool isFromRawString = true, bool includeUnits = true)
		{
			return String.Empty;
		}


		/// <summary>
		/// Converts the given raw value into a format ready for display.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="rawValue">The raw value.</param>
		/// <param name="isFromRawString">Whether the origin of the value is raw-based. Default is true.</param>
		/// <param name="includeUnits">Whether units should be included in the value. Default is true.</param>
		/// <returns></returns>
		public string GetParameterDisplayValue(int parameterID, string rawValue, bool isFromRawString = true, bool includeUnits = true)
		{
			return GetParameterDisplayValue(parameterID, rawValue, null, false, isFromRawString, includeUnits);
		}

		/// <summary>
		/// Converts the given raw value into a format ready for display.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="rawValue">The raw value.</param>
		/// <param name="isFromRawString">Whether the origin of the value is raw-based. Default is true.</param>
		/// <param name="includeUnits">Whether units should be included in the value. Default is true.</param>
		/// <param name="culture">Overrides the default culture (InvariantCulture). Use ParameterInfo.DataMinerNumberCulture if you want to use the default DataMiner number grouping separator.</param>
		/// <param name="displayNumberGroupSeparator">If <c>true</c>, the digits will be grouped using the number group separator of the culture.</param>
		/// <returns>The parameter display value.</returns>
		public string GetParameterDisplayValue(int parameterID, string rawValue, CultureInfo culture, bool displayNumberGroupSeparator, bool isFromRawString = true, bool includeUnits = true)
		{
			return String.Empty;
		}

		/// <summary>
		/// Converts the given parameter value into a format that is ready for display.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="value">The value.</param>
		/// <param name="culture">Overrides the default culture (InvariantCulture). Use ParameterInfo.DataMinerNumberCulture if you want to use the default DataMiner number grouping separator.</param>
		/// <param name="displayNumberGroupSeparator">If true, the digits will be grouped using the number group separator of the culture.</param>
		/// <returns>The display value.</returns>
		public string GetParameterDisplayValue(int parameterID, ParameterValue value, CultureInfo culture, bool displayNumberGroupSeparator)
		{
			return String.Empty;
		}

		/// <summary>
		/// Converts the given parameter value into a format that is ready for display.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="value">The value.</param>
		/// <returns>The display value.</returns>
		public string GetParameterDisplayValue(int parameterID, ParameterValue value)
		{
			return String.Empty;
		}

		/// <summary>
		/// Gets the string that should be used to display the value in the UI.
		/// This will enable number grouping, using the DataMinerNumberCulture.
		/// This will group digits per 3 with a short space.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <param name="value">The value.</param>
		/// <returns>The parameter UI display value.</returns>
		public string GetParameterUIDisplayValue(int parameterID, ParameterValue value)
		{
			return String.Empty;
		}

		/// <summary>
		/// Returns the <see cref="ParameterInfo"/> object for the parameter with the given ID. When no parameter is found, returns <see langword="null"/>.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <returns>The parameter info.</returns>
		public ParameterInfo FindParameter(int parameterID)
		{
			return null;
		}

		/// <summary>
		/// Returns a value that indicates whether the specified parameter is a base protocol parameter.
		/// </summary>
		/// <param name="parameterID">The parameter ID.</param>
		/// <returns><c>true</c> if the specified parameter is a base protocol parameter.</returns>
		public static bool IsBaseProtocolParameter(int parameterID)
		{
			return true;
		}

		/// <summary>
		/// Returns the <see cref="ParameterInfo"/> object for the parameter with the given description. When no parameter is found, returns <see langword="null"/>.
		/// </summary>
		/// <param name="parameterDescription">Description of the parameter to look for.</param>
		/// <returns>The parameter info.</returns>
		public ParameterInfo FindParameter(string parameterDescription)
		{
			return null;
		}

		/// <summary>
		/// Finds the specified parameter.
		/// </summary>
		/// <param name="parameterDescription">The parameter description.</param>
		/// <param name="writeParameter">If <c>true</c>, specifically looks for a write parameter.</param>
		/// <returns>The parameter info.</returns>
		public ParameterInfo FindParameter(string parameterDescription, bool writeParameter)
		{
			return null;
		}

		/// <summary>
		/// Finds the parameter by the specified mask.
		/// </summary>
		/// <param name="parameterDescriptionMask">Mask with wildcards '*' and '?'.</param>
		public ParameterInfo[] FindParametersByMask(string parameterDescriptionMask)
		{
			return null;
		}

		/// <summary>
		/// Finds the parameter by the specified mask.
		/// </summary>
		/// <param name="parameterDescriptionMask">Mask with wildcards '*' and '?'.</param>
		/// <param name="writeParameter">If <c>true</c>, specifically looks for a write parameter.</param>
		/// <returns>The parameter info or <see langword="null"/> or empty if nothing was found.</returns>
		public ParameterInfo[] FindParametersByMask(string parameterDescriptionMask, bool writeParameter)
		{
			return null;
		}

		/// <summary>
		/// Finds the write parameter that is associated with the specified read parameter. If no such parameter is found, returns <see langword="null"/>.
		/// </summary>
		/// <param name="readParameter">The read parameter.</param>
		/// <returns>The write parameter that is associated with the specified read parameter or <see langword="null"/> if no such parameter is found.</returns>
		public ParameterInfo FindAssociatedWriteParameter(ParameterInfo readParameter)
		{
			return null;
		}

		/// <summary>
		/// Finds the read parameter that is associated with the specified write parameter. If no such parameter is found, returns <see langword="null"/>.
		/// </summary>
		/// <param name="writeParameter"></param>
		/// <returns>The read parameter that is associated with the specified write parameter or <see langword="null"/> if no such parameter is found.</returns>
		public ParameterInfo FindAssociatedReadParameter(ParameterInfo writeParameter)
		{
			return null;
		}

		/// <summary>
		/// Finds the associated table parameter ID for the specified column parameter.
		/// </summary>
		/// <param name="columnParameterID">The column parameter ID.</param>
		/// <returns>The table parameter ID for the specified column parameter.</returns>
		public int FindAssociatedTableParameterID(int columnParameterID)
		{
			return -1;
		}

		/// <summary>
		/// Retrieves the associated table parameter info for the specified column parameter.
		/// </summary>
		/// <param name="columnParameterID">The column parameter ID.</param>
		/// <returns>The table parameter info for the specified column parameter.</returns>
		public ParameterInfo FindAssociatedTableParameter(int columnParameterID)
		{
			return FindAssociatedTableParameter(FindParameter(columnParameterID));
		}

		/// <summary>
		/// Finds the associated column parameter info for the specified column parameter.
		/// </summary>
		/// <param name="tableParameterID">The table parameter ID.</param>
		/// <param name="indexInDataArray">The column index.</param>
		/// <returns>The column parameter info for the specified column parameter.</returns>
		public ParameterInfo FindAssociatedColumnParameter(int tableParameterID, int indexInDataArray)
		{
			return FindAssociatedColumnParameter(FindParameter(tableParameterID), indexInDataArray);

		}

		/// <summary>
		/// Finds the associated column parameter info for the specified column parameter.
		/// </summary>
		/// <param name="tableParameter">The table parameter.</param>
		/// <param name="indexInDataArray">The column index.</param>
		/// <returns>The column parameter info for the specified column parameter.</returns>
		public ParameterInfo FindAssociatedColumnParameter(ParameterInfo tableParameter, int indexInDataArray)
		{
			return null;
		}

		/// <summary>
		/// Finds the table parameter that is associated with the specified column parameter.
		/// </summary>
		/// <param name="columnParameter">The column parameter.</param>
		/// <returns>The table parameter that is associated with the specified column parameter or <c>null</c> if no such parameter is found.</returns>
		public ParameterInfo FindAssociatedTableParameter(ParameterInfo columnParameter)
		{
			return null;
		}

		/// <summary>
		/// Finds the associated primary key column parameter for the specified table parameter.
		/// </summary>
		/// <param name="tableParam">The table parameter.</param>
		/// <returns>The associated primary key column parameter for the specified table parameter.</returns>
		public ParameterInfo FindAssociatedPrimaryKeyColumn(ParameterInfo tableParam)
		{
			return null;
		}
	
		/// <summary>
		/// Finds the associated display key column parameter for the specified table parameter.
		/// </summary>
		/// <param name="tableParam">The table parameter.</param>
		/// <returns>The associated display key column parameter for the specified table parameter.</returns>
		public ParameterInfo FindAssociatedDisplayKeyColumn(ParameterInfo tableParam)
		{
			return null;
		}

		/// <summary>
		/// Finds the topology cell for the specified name and table ID.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="tablePid">The table ID.</param>
		/// <returns>The topology cell.</returns>
		public ProtocolTopologyCell FindTopologyCell(string name, int tablePid)
		{
			return null;
		}

		/// <summary>
		/// Finds the child tables for the specified cell.
		/// </summary>
		/// <param name="cell">The cell.</param>
		/// <returns>The child tables.</returns>
		public IEnumerable<ProtocolTopologyCell> FindChildTables(ProtocolTopologyCell cell)
		{
			return FindChildTables(String.Empty, cell);
		}

		/// <summary>
		/// Finds the child tables for the specified cell.
		/// </summary>
		/// <param name="topologyname">The topology name.</param>
		/// <param name="cell">The cell.</param>
		/// <returns>The child tables.</returns>
		public IEnumerable<ProtocolTopologyCell> FindChildTables(string topologyname, ProtocolTopologyCell cell)
		{
			if (cell == null)
				yield break;
		}

		/// <summary>
		/// Finds the child tables for the specified cell.
		/// </summary>
		/// <param name="topologyname">The topology name.</param>
		/// <param name="tablePid">The table ID.</param>
		/// <returns>The child tables.</returns>
		public IEnumerable<ProtocolTopologyCell> FindChildTables(string topologyname, int tablePid)
		{
			if (Topologies == null)
				yield break;
		}

		/// <summary>
		/// Finds the parent tables for the specified cell.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="cell">The cell.</param>
		/// <returns>The parent tables.</returns>
		public IEnumerable<ProtocolTopologyCell> FindParentTables(string name, ProtocolTopologyCell cell)
		{
			if (cell == null)
				yield break;
		}

		/// <summary>
		/// Finds the parent tables for the specified cell.
		/// </summary>
		/// <param name="topologyname">The topology name.</param>
		/// <param name="tablePid">The table ID.</param>
		/// <returns>The parent tables.</returns>
		public IEnumerable<ProtocolTopologyCell> FindParentTables(string topologyname, int tablePid)
		{
			if (Topologies == null)
				yield break;
		}

		/// <summary>
		/// Returns all page names that are used by parameters in the protocol.
		/// </summary>
		/// <returns>All page names that are used by parameters in the protocol.</returns>
		public string[] FindPageNames()
		{
			List<string> names = new List<string>();
			return names.ToArray();
		}

		/// <summary>
		/// Gets a value indicating whether the protocol has at least one parameter that can be used as a virtual source or destination (element connections).
		/// </summary>
		/// <value><c>true</c> if the protocol has at least one parameter that can be used as a virtual source or destination (element connections).</value>
		public bool HasParametersForElementConnections
		{
			get;
		}

		/// <summary>
		/// Returns information about which pages have been defined in the protocol, and which parameters are on each of these pages.
		/// </summary>
		/// <returns>Information about which pages have been defined in the protocol, and which parameters are on each of these pages.</returns>
		/// <remarks>Only considers the actual device protocol. Does not return page info for the parameters of the base protocol.</remarks>
		public PageInfo[] FindPages()
		{
			return null;
		}

		/// <summary>
		/// Filters and/or sorts a collection of parameters, given a combination of selection options. For example, returns a collection with only the analog parameters if <paramref name="options"/> is set to <see cref="ParameterFilterOptions.AnalogOnly"/>.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <returns>The filtered parameters.</returns>
		public List<ParameterInfo> FilterParameters(ParameterFilterOptions options)
		{
			return FilterParameters(options, null);
		}

		/// <summary>
		/// Filters and/or sorts a collection of parameters, given a combination of selection options. For example, returns a collection with only the analog parameters if <paramref name="options"/> is set to <see cref="ParameterFilterOptions.AnalogOnly"/>.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <param name="extraFilter">Callback function to extra filter. Function should return <c>true</c> only when the object needs to be included.</param>.
		/// <returns>The filtered parameters.</returns>
		public List<ParameterInfo> FilterParameters(ParameterFilterOptions options, Predicate<ParameterInfo> extraFilter)
		{
			List<ParameterInfo> filteredParams = new List<ParameterInfo>();
			return filteredParams;
		}

		/// <summary>
		/// Gets or sets the unique cache ID.
		/// </summary>
		/// <value>The unique cache key.</value>
		public Guid UniqueCacheKey { get; set; }

		/// <summary>
		/// Retrieves a CSV for the protocol parameters.
		/// </summary>
		/// <returns>A CSV for the protocol parameters.</returns>
		public string GetExportProtocolCsv()
		{
			return String.Empty;
		}

		#region Compliancies

		/// <summary>
		/// Gets or sets the compliancies.
		/// </summary>
		/// <value>The compliancies.</value>
		public List<CompliancyPair> Compliancies { get; set; }

		/// <summary>
		/// Adds the specified compliancy pair.
		/// </summary>
		/// <param name="key">The compliancy key.</param>
		/// <param name="value">The compliancy value.</param>
		public void AddCompliancyPair(string key, string value)
		{
		}

		/// <summary>
		/// Retrieves the compliancy pair for the specified key.
		/// </summary>
		/// <param name="key">The compliancy key.</param>
		/// <returns>The compliancy pair for the specified key</returns>
		public CompliancyPair GetCompliancy(CompliancyKey key)
		{
			return null;
		}

		#endregion
		/// <summary>
		/// Gets or sets a value indicating whether this protocol has a view impact column.
		/// </summary>
		/// <value><c>true</c> if this protocol has a view impact column; otherwise, <c>false</c>.</value>
		public bool HasViewImpactColumn { get; set; } = false;

		/// <summary>
		/// Gets or sets a value indicating whether this protocol has exposers.
		/// </summary>
		/// <value><c>true</c> if this protocol has exposers; otherwise, <c>false</c>.</value>
		public bool HasExposers { get; set; } = false;

		/// <summary>
		/// Determines whether this protocol has an exposer for the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns><c>true</c> if this protocol has an exposer for the specified name; otherwise, <c>false</c>.</returns>
		public bool HasExposerFor(string name)
		{
			return false;
		}

		/// <summary>
		/// Gets the topology data for the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>The topology data.</returns>
		public TopologyExposerData GetTopologyDataFor(string name)
		{
			return null;
		}

		/// <summary>
		/// Gets the internal licenses this protocol has.
		/// </summary>
		/// <value>The internal licenses this protocol has.</value>
		public List<InternalLicense> InternalLicenses { get; } = new List<InternalLicense>();

		/// <summary>
		/// Adds the internal license for the specified license type.
		/// </summary>
		/// <param name="type">The license type.</param>
		public void AddInternalLicense(InternalLicenseType type)
		{
		}

		/// <summary>
		/// Retrieves the internal license for the specified license type.
		/// </summary>
		/// <param name="type">The license type.</param>
		/// <returns>The internal license.</returns>
		public InternalLicense GetInternalLicense(InternalLicenseType type)
		{
			return null;
		}
	}

	public enum TopologyChainsFilterType
	{
		Horizontal,
		Vertical
	}

	/// <summary>
	/// Contains information about exported DVE tables.
	/// </summary>
	public class ExportedTableInfo
	{
	}

	/// <summary>
	/// Different types of compliancy keys.
	/// </summary>
	public enum CompliancyKey
	{
		CassandraReady,
		CassandraRequired,
		MinimumRequiredVersion
	}

	[Serializable]
	public class CompliancyPair
	{
	}

	/// <summary>
	/// Enumeration of the type values for the different types of internal licenses.
	/// This should match the enumeration in SLGlobal.
	/// </summary>
	public enum InternalLicenseType
	{
		Solution
	}

	[Serializable]
	public class InternalLicense
	{
	}
}

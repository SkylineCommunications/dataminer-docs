namespace Skyline.DataMiner.Library.Common
{
	using Properties;

	using System;
	using System.Collections.Generic;

	using Templates;

	/// <summary>
	/// DataMiner element interface.
	/// </summary>
	public interface IDmsElement : IDmsObject, IUpdateable
	{
		/// <summary>
		/// Gets the advanced settings of this element.
		/// </summary>
		/// <value>The advanced settings of this element.</value>
		IAdvancedSettings AdvancedSettings { get; }

		/// <summary>
		/// Gets the DataMiner Agent ID.
		/// </summary>
		/// <value>The DataMiner Agent ID.</value>
		int AgentId { get; }

		/// <summary>
		/// Gets or sets the alarm template assigned to this element.
		/// </summary>
		/// <value>The alarm template assigned to this element.</value>
		/// <exception cref="ArgumentException">The specified alarm template is not compatible with the protocol this element executes.</exception>
		IDmsAlarmTemplate AlarmTemplate { get; set; }

		/// <summary>
		/// Gets or Sets the collection of IElementConnection objects.
		/// </summary>
		IElementConnectionCollection Connections { get; set; }

		/// <summary>
		/// Gets or sets the element description.
		/// </summary>
		/// <value>The element description.</value>
		string Description { get; set; }

		/// <summary>
		/// Gets the system-wide element ID of the element.
		/// </summary>
		/// <value>The system-wide element ID of the element.</value>
		DmsElementId DmsElementId { get; }

		/// <summary>
		/// Gets the DVE settings of this element.
		/// </summary>
		/// <value>The DVE settings of this element.</value>
		IDveSettings DveSettings { get; }

		/// <summary>
		/// Gets the DataMiner Agent that hosts this element.
		/// </summary>
		/// <value>The DataMiner Agent that hosts this element.</value>
		IDma Host { get; }

		///// <summary>
		///// Gets the failover settings of this element.
		///// </summary>
		///// <value>The failover settings of this element.</value>
		//IFailoverSettings FailoverSettings { get; }
		/// <summary>
		/// Gets the element ID.
		/// </summary>
		/// <value>The element ID.</value>
		int Id { get; }

		/// <summary>
		/// Gets or sets the element name.
		/// </summary>
		/// <value>The element name.</value>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">The value of a set operation is empty or white space.</exception>
		/// <exception cref="ArgumentException">The value of a set operation exceeds 200 characters.</exception>
		/// <exception cref="ArgumentException">The value of a set operation contains a forbidden character.</exception>
		/// <exception cref="ArgumentException">The value of a set operation contains more than one '%' character.</exception>
		/// <exception cref="NotSupportedException">A set operation is not supported on a DVE child or a derived element.</exception>
		/// <remarks>
		/// <para>The following restrictions apply to element names:</para>
		/// <list type="bullet">
		///		<item><para>Names may not start or end with the following characters: '.' (dot), ' ' (space).</para></item>
		///		<item><para>Names may not contain the following characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|', '°', ';'.</para></item>
		///		<item><para>The following characters may not occur more than once within a name: '%' (percentage).</para></item>
		/// </list>
		/// </remarks>
		string Name { get; set; }

		/// <summary>
		/// Gets the properties of this element.
		/// </summary>
		/// <value>The element properties.</value>
		IPropertyCollection<IDmsElementProperty, IDmsElementPropertyDefinition> Properties { get; }

		/// <summary>
		/// Gets the protocol executed by this element.
		/// </summary>
		/// <value>The protocol executed by this element.</value>
		IDmsProtocol Protocol { get; }

		/// <summary>
		/// Gets the redundancy settings.
		/// </summary>
		/// <value>The redundancy settings.</value>
		IRedundancySettings RedundancySettings { get; }

		/// <summary>
		/// Gets the replication settings.
		/// </summary>
		/// <value>The replication settings.</value>
		IReplicationSettings ReplicationSettings { get; }

		/// <summary>
		/// Gets the spectrum analyzer component of this element.
		/// </summary>
		/// <value>The spectrum analyzer component.</value>
		/// <remarks>This is only applicable for spectrum analyzer elements.</remarks>
		IDmsSpectrumAnalyzer SpectrumAnalyzer { get; }

		/// <summary>
		/// Gets the element state.
		/// </summary>
		/// <value>The element state.</value>
		ElementState State { get; }

		/// <summary>
		/// Gets or sets the trend template that is assigned to this element.
		/// </summary>
		/// <value>The trend template that is assigned to this element.</value>
		/// <exception cref="ArgumentException">The specified trend template is not compatible with the protocol this element executes.</exception>
		IDmsTrendTemplate TrendTemplate { get; set; }

		/// <summary>
		/// Gets the type of the element.
		/// </summary>
		/// <value>The element type.</value>
		string Type { get; }

		/// <summary>
		/// Gets the views the element is part of.
		/// </summary>
		/// <value>The views the element is part of.</value>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword = "null" />.</exception>
		/// <exception cref="ArgumentException">The value of a set operation is an empty collection.</exception>
		ISet<IDmsView> Views { get; }

		/// <summary>
		/// Deletes the element.
		/// </summary>
		/// <exception cref="NotSupportedException">The element is a DVE child or a derived element.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		void Delete();

		/// <summary>
		/// Duplicates the element.
		/// </summary>
		/// <param name="newElementName">The name to assign to the duplicated element.</param>
		/// <param name="agent">The target DataMiner Agent where the duplicated element should be created.</param>
		/// <exception cref = "ArgumentNullException"><paramref name="newElementName"/> is <see langword = "null" />.</exception>
		/// <exception cref="ArgumentException"><paramref name="newElementName"/> is invalid.</exception>
		/// <exception cref="NotSupportedException">The element is a DVE child or a derived element.</exception>
		/// <exception cref="AgentNotFoundException">The specified DataMiner Agent was not found in the DataMiner System.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="IncorrectDataException">Invalid data.</exception>
		/// <returns>The duplicated element.</returns>
		IDmsElement Duplicate(string newElementName, IDma agent = null);

		/// <summary>
		/// Gets the number of active alarms.
		/// </summary>
		/// <exception cref="ElementStoppedException">The element is not active.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The number of active alarms.</returns>
		int GetActiveAlarmCount();

		/// <summary>
		/// Gets the number of critical alarms.
		/// </summary>
		/// <exception cref="ElementStoppedException">The element is not active.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The number of critical alarms.</returns>
		int GetActiveCriticalAlarmCount();

		/// <summary>
		/// Gets the number of major alarms.
		/// </summary>
		/// <exception cref="ElementStoppedException">The element is not active.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The number of major alarms.</returns>
		int GetActiveMajorAlarmCount();

		/// <summary>
		/// Gets the number of minor alarms.
		/// </summary>
		/// <exception cref="ElementStoppedException">The element is not active.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The number of minor alarms.</returns>
		int GetActiveMinorAlarmCount();

		/// <summary>
		/// Gets the number of warnings.
		/// </summary>
		/// <exception cref="ElementStoppedException">The element is not active.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <returns>The number of warnings.</returns>
		int GetActiveWarningAlarmCount();

		/// <summary>
		/// Gets the alarm level of the element.
		/// </summary>
		/// <returns>The element alarm level.</returns>
		/// <exception cref="ElementStoppedException">The element is not active.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		AlarmLevel GetAlarmLevel();

		/// <summary>
		/// Gets the specified standalone parameter.
		/// </summary>
		/// <typeparam name="T">The type of the parameter. Currently supported types: int?, double?, DateTime? and string.</typeparam>
		/// <param name="parameterId">The parameter ID.</param>
		/// <exception cref="ArgumentException"><paramref name="parameterId"/> is invalid.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is not active.</exception>
		/// <exception cref="NotSupportedException">A type other than string, int?, double? or DateTime? was provided.</exception>
		/// <returns>The standalone parameter that corresponds with the specified ID.</returns>
		IDmsStandaloneParameter<T> GetStandaloneParameter<T>(int parameterId);

		/// <summary>
		/// Gets the specified table.
		/// </summary>
		/// <param name="tableId">The table parameter ID.</param>
		/// <exception cref="ArgumentException"><paramref name="tableId"/> is invalid.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		/// <exception cref="ElementStoppedException">The element is not active.</exception>
		/// <returns>The table that corresponds with the specified ID.</returns>
		IDmsTable GetTable(int tableId);

		/// <summary>
		/// Determines whether the element has been started up completely.
		/// </summary>
		/// <returns><c>true</c> if the element is started up; otherwise, <c>false</c>.</returns>
		/// <exception cref="ElementNotFoundException">The element was not found.</exception>
		bool IsStartupComplete();

		/// <summary>
		/// Pauses the element.
		/// </summary>
		/// <exception cref="NotSupportedException">The element is a DVE child or derived element.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		void Pause();

		/// <summary>
		/// Restarts the element.
		/// </summary>
		/// <exception cref="NotSupportedException">The element is a DVE child or derived element.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		void Restart();

		/// <summary>
		/// Starts the element.
		/// </summary>
		/// <exception cref="NotSupportedException">The element is a DVE child or derived element.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		void Start();

		/// <summary>
		/// Stops the element.
		/// </summary>
		/// <exception cref="NotSupportedException">The element is a DVE child or derived element.</exception>
		/// <exception cref="ElementNotFoundException">The element was not found in the DataMiner System.</exception>
		void Stop();
	}
}
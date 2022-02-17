using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Represents a message to request trend data from a DataMiner Agent.
	/// </summary>
	/// <remarks>Use this message to execute queries on the trend data tables for a certain element. Results in a <see cref="GetTrendDataResponseMessage"/> response.</remarks>
	[Serializable]
    public class GetTrendDataMessage : TargetedClientRequestMessage, ICloneable
    {
		/// <summary>
		/// Initializes a new instance of the GetTrendDataMessage class representing a message to request trend data from a DataMiner Agent.
		/// </summary>
		public GetTrendDataMessage() : this(-1, -1, -1, null, false, false)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="GetTrendDataMessage"/> class representing a message to request trend data from a DataMiner Agent.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID.</param>
		/// <param name="eid">The element ID.</param>
		/// <param name="pid">The parameter ID.</param>
		public GetTrendDataMessage(int dmaid, int eid, int pid) : this(dmaid, eid, pid, null, false, false) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="GetTrendDataMessage"/> class representing a message to request trend data from a DataMiner Agent.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID.</param>
		/// <param name="eid">The element ID.</param>
		/// <param name="pid">The parameter ID.</param>
		/// <param name="key">The key of the row.</param>
		public GetTrendDataMessage(int dmaid, int eid, int pid, string key) : this(dmaid, eid, pid, key, false, false) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="GetTrendDataMessage"/> class representing a message to request trend data from a DataMiner Agent.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID.</param>
		/// <param name="eid">The element ID.</param>
		/// <param name="pid">The parameter ID.</param>
		/// <param name="key">The key of the row.</param>
		/// <param name="raw">Indicates whether raw data should be returned.</param>
		public GetTrendDataMessage(int dmaid, int eid, int pid, string key, Boolean raw) : this(dmaid, eid, pid, key, raw, false) { }


		/// <summary>
		/// Initializes a new instance of the <see cref="GetTrendDataMessage"/> class representing a message to request trend data from a DataMiner Agent.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID.</param>
		/// <param name="eid">The element ID.</param>
		/// <param name="pid">The parameter ID.</param>
		/// <param name="key">The key of the row.</param>
		/// <param name="raw">Indicates whether raw data should be returned.</param>
		/// <param name="dateTimeUTC">Indicates whether UTC timestamps are used.</param>
		public GetTrendDataMessage(int dmaid, int eid, int pid, string key, Boolean raw, Boolean dateTimeUTC) //: base(dmaid)
        {
        }

		/// <summary>
		/// Gets or sets the ID of the element for which you want to request trend data.
		/// </summary>
		/// <value>The element ID</value>
		public int ElementID { get; set; }

		/// <summary>
		/// Retrieves the element ID for messages that are about an element.
		/// </summary>
		/// <returns>The ID of the element this message is about.</returns>
		/// <remarks>
		/// <para>Together with TargetedClientRequestMessage.DataMinerID, this info is used to auto fill out the HostingDataMinerID.</para>
		/// </remarks>
		public  int GetElementID() //override
		{
            return 1;
        }

		/// <summary>
		/// Gets or sets the parameter ID.
		/// </summary>
		/// <value>Parameter ID.</value>
		[Obsolete("Use Parameters property instead [7.0.1+]", false)]
        public int ParameterID 
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the primary key.
		/// </summary>
		/// <value>The primary key.</value>
		[Obsolete("Use Parameters property instead [7.0.1+]", false)]
        public string TableIndex 
        {
			get; set;
        }
        
        /// <summary>
        /// List of table columns (fields) to get. To include a count, add a "COUNT(*)" field.
        /// </summary>
        public string[] Fields { get; set; }

		/// <summary>
		/// Gets or sets the optional extra SQL where clause to further limit the trend data.
		/// </summary>
		/// <value>Optional extra SQL where clause to further limit the trend data.</value>
		[Obsolete("Only queries limited by datetime can be done, use StartTime and EndTime for it.")]
        public string WhereClause { get; set; }

		/// <summary>
		/// Gets or sets an optional SQL order clause.
		/// </summary>
		/// <value>Optional SQL order clause.</value>
		[Obsolete("Result will always come back descending ordered on timestamp", false)]
        public string OrderClause { get; set; }

		/// <summary>
		/// Gets or sets a clause which can be used to select an alternative PID next to the one selected by ParameterID/TableIndex(e.g. "iPid = -1").
		/// </summary>
		/// <value>Alternative clause to select another PID next to the one selected by ParameterID/TableIndex.</value>
		[Obsolete("Result will always contain data for requested parameter(s) and general element data", false)]
        public string AlternativePidClause { get; set; }

        /// <summary>
        /// List of parameters to include [7.0.1+]
        /// </summary>
        public ParameterIndexPair[] Parameters { get; set; }

		/// <summary>
		/// Gets or sets the type of trending data that is requested.
		/// </summary>
		/// <value>The requested type of trend data.</value>
		public TrendingType TrendingType { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether trend data should be filled up.
		/// </summary>
		/// <value>Whether trending data should be filled up.</value>
		[Obsolete("Result will only contain changes", false)]
        public TrendOptions TrendOption { get; set; }

        /// <summary>
        /// When <c>true</c>, data will never be resolved from the trendcache.
        /// </summary>
        public bool SkipCache { get; set; }

		/// <summary>
		/// Gets or sets the type of average trend interval that is requested.
		/// </summary>
		/// <value>The type of average trend interval that is requested.</value>
		public AverageTrendIntervalType AverageTrendIntervalType { get; set; }

        /// <summary>
        /// Start time of trending
        /// </summary>
        public DateTime StartTime 
        {
			get; set;
        }

        /// <summary>
        /// End time of trending
        /// </summary>
        public DateTime EndTime
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets a value indicating whether to return the raw data.
		/// </summary>
		/// <value><c>true</c> if raw data must be returned; otherwise, <c>false</c>.</value>
		public Boolean Raw { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the timestamps returned will be in UTC. StartTime and EndTime will be interpreted as UTC.
		/// </summary>
		/// <value>If set to true, all DateTime values in the Ge tTrendDataMessage have to be specified in UTC format. Also, in the response, all DateTime values will be in UTC format.</value>
		/// <remarks>The default value is false (i.e. local time).</remarks>
		public Boolean DateTimeUTC
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the maximum number of rows to return.
		/// </summary>
		/// <value>Maximum number of rows to return.</value>
		[Obsolete("Result will contain full dataset", false)]
        public int Limit 
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets a flag to set when you want bigger data like hour records and day records to be flattened.
		/// </summary>
		/// <value>Flag to set when you want bigger data like hour records and day records to be flattened.</value>
		[Obsolete("Result will always contain the most precise data that it has available")]
        public bool Flatten
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets a value indicating whether the Values or Records property in the corresponding GetTrendDataResponseMessage will be set.
		/// </summary>
		/// <value>When set to true, the Records property of the corresponding GetTrendDataResponseMessage will be set, otherwise the Values property will be set.</value>
		public bool ReturnAsObjects
        {
			get; set;
        }

        /// <summary>
        /// RetrievalWithPrimaryKey is true when the ParameterIndexPair (in Parameters) contains the primary key (even in the case of a display column)
        /// </summary>
        public bool RetrievalWithPrimaryKey { get; set; } = false;

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
			return "";
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public virtual object Clone()
        {
			return null;
		}
    }
}

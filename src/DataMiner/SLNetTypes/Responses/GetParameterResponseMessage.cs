using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Represents a response to a <see cref="GetParameterMessage"/>.
	/// </summary>
	[Serializable]
	public class GetParameterResponseMessage : ResponseMessage
	{
		///// <summary>
		///// Initializes a new instance of the <see cref="GetParameterResponseMessage"/> class.
		///// </summary>
		//public GetParameterResponseMessage()
		//{
		//}

		///// <summary>
		///// Initializes a new instance of the <see cref="GetParameterResponseMessage"/> class.
		///// </summary>
		///// <param name="dmaId">The Agent ID.</param>
		///// <param name="elId">The element ID.</param>
		///// <param name="parameterId">The parameter ID.</param>
		///// <param name="index">The index.</param>
		///// <param name="value">The value.</param>
		//public GetParameterResponseMessage(int dmaId, int elId, int parameterId, string index, ParameterValue value)
		//{
		//	ParameterId	= parameterId;
		//	ElId		= elId;
		//	Value		= value;
		//	DataMinerID	= dmaId;
		//	TableIndex	= index;
		//}

		///// <summary>
		///// Initializes a new instance of the <see cref="GetParameterResponseMessage"/> class.
		///// </summary>
		///// <param name="dmaId">The Agent ID.</param>
		///// <param name="elId">The element ID.</param>
		///// <param name="parameterId">The parameter ID.</param>
		///// <param name="index">The index.</param>
		///// <param name="value">The value.</param>
		///// <param name="strValue">The value as a string.</param>
		///// <param name="valueType">The value type.</param>
		//public GetParameterResponseMessage(int dmaId, int elId, int parameterId, string index, double value, String strValue, ParameterValueType valueType)
		//	: this(dmaId, elId, parameterId, index, ParameterValue.Compose(value, strValue, valueType))
		//{
		//}

		/// <summary>
		/// The current parameter Value (raw).
		/// </summary>
		public ParameterValue Value;
	
		/// <summary>
		/// The DataMiner Agent ID.
		/// </summary>
		public int DataMinerID;

		/// <summary>
		/// The element ID.
		/// </summary>
		public int ElId;

		/// <summary>
		/// The parameter ID.
		/// </summary>
		public int ParameterId;

		/// <summary>
		/// Gets or sets the table index.
		/// </summary>
		/// <value>The table index.</value>
		/// <remarks>For table column parameters, the row index about which this object contains data.</remarks>
		public string TableIndex
		{
			get; set;
		}


		/// <summary>
		/// The parameter display type.
		/// </summary>
		public ParameterDisplayType DisplayType;

		/// <summary>
		/// The display value.
		/// </summary>
		public String DisplayValue;

		/// <summary>
		/// The time of last change.
		/// </summary>
		public DateTime LastChange;

        /// <summary>
        /// The time of last poll.
        /// </summary>
        public DateTime LastPoll;

		/// <summary>
		/// The name of the user or process that caused the last change of the parameter.
		/// </summary>
		public String UserName;

		/// <summary>
		/// The alarm level for the parameter.
		/// </summary>
		/// <remarks>
		/// If the parameter is masked, AlarmLevel.Masked is returned.
		/// </remarks>
		public AlarmLevel AlarmLevel;

		/// <summary>
		/// Gets or sets the actual alarm level, even if the parameter is masked.
		/// </summary>
		/// <value>The actual alarm level, even if the parameter is masked.</value>
		public AlarmLevel ActualAlarmLevel
        {
            get;
            set;
        }

		/// <summary>
		/// Gets or sets the latch alarm level.
		/// </summary>
		/// <value>The latch alarm level.</value>
		public AlarmLevel LatchLevel { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether average trending is enabled.
		/// </summary>
		/// <value><c>true</c> if average trending is enabled; otherwise, <c>false</c>.</value>
        public bool IsAverageTrended
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets a value indicating whether real-time trending is enabled.
		/// </summary>
		/// <value><c>true</c> if real-time trending is enabled; otherwise, <c>false</c>.</value>
		public bool IsRealTimeTrended
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets a value indicating whether this parameter is masked.
		/// </summary>
		/// <value><c>true</c> if masked; otherwise, <c>false</c>.</value>
		public bool IsMasked
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets a value indicating whether this is a valid value (i.e. last poll for this parameter succeeded).
		/// </summary>
		/// <value><c>true</c> if valid; otherwise, <c>false</c>.</value>
		public bool IsValidValue
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets a value indicating whether this parameter is trended.
		/// </summary>
		/// <value><c>true</c> if trended; otherwise, <c>false</c>.</value>
		public bool IsTrended { get; }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return "";
		}
	}
}
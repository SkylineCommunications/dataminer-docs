using System;
using System.Globalization;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Represents a message to request a parameter value.
	/// </summary>
	/// <remarks>
	/// The response message is a <see cref="GetParameterResponseMessage"/> containing the value of the requested parameter.
	/// </remarks>
	[Serializable]
    //[DataMinerSecurity(PermissionFlags.AccessElement)]
	public class GetParameterMessage //: TargetedClientRequestMessage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetParameterMessage"/> class.
		/// </summary>
		public GetParameterMessage()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GetParameterMessage"/> class using the Agent ID, element ID and parameter ID.
		/// </summary>
		/// <param name="dmaId">The Agent ID of the element.</param>
		/// <param name="elId">The element ID.</param>
		/// <param name="parameterId">The parameter ID.</param>
		public GetParameterMessage(int dmaId, int elId, int parameterId)
			: this(dmaId, elId, parameterId, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="GetParameterMessage"/> class using the Agent ID, element ID, parameter ID and the display key.
		/// </summary>
		/// <param name="dmaId">The Agent ID of the element.</param>
		/// <param name="elId">The element ID.</param>
		/// <param name="parameterId">The parameter ID.</param>
		/// <param name="displayKey">The display key.</param>
		public GetParameterMessage(int dmaId, int elId, int parameterId, string displayKey)
			: this(dmaId, elId, parameterId, displayKey, false)
		{
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="GetParameterMessage"/> class using the Agent ID, element ID, parameter ID and the display key.
		/// </summary>
		/// <param name="dmaId">The Agent ID of the element.</param>
		/// <param name="elId">The element ID.</param>
		/// <param name="parameterId">The parameter ID.</param>
		/// <param name="key">The display key or primary key.</param>
		/// <param name="usePrimaryKey"><c>true</c> if <paramref name="key"/> denotes the primary key; otherwise <c>false</c>.</param>
		public GetParameterMessage(int dmaId, int elId, int parameterId, string key, bool usePrimaryKey)
		    //: base(dmaId)
        {
        }

		/// <summary>
		/// Gets or sets a value indicating whether the key to be used is the primary key.
		/// </summary>
		/// <value>If <c>true</c>, the primary key will be used for retrieving the data, otherwise the display key will be used.</value>
		/// <remarks>
		/// <para> Default: <c>false</c>.</para>
		/// <para>Feature introduced in DataMiner 10.1.11 (RN 30694).</para>
		/// </remarks>
		public bool UsePrimaryKey { get; set; }

        /// <summary>
        /// ID of the element for which to receive the current parameter value.
        /// </summary>
        public int ElId;

		/// <summary>
		/// Retrieves the element ID.
		/// </summary>
		/// <returns>The element ID.</returns>
        public int GetElementID()
        {
            return 0;
        }

        /// <summary>
        /// ID of the parameter for which to receive the current value.
        /// </summary>
        public int ParameterId;

		/// <summary>
		/// If the <see cref="ParameterId"/> references a dynamic table column,
		/// a primary or display key specifying the row needs to be specified.
		/// Which type of key depends on the <see cref="UsePrimaryKey"/> property.
		/// </summary>
        public string TableIndex
        {
			get; set;
        }


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
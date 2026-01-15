using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Skyline.DataMiner.Net.Ticketing.Helpers.Visualization
{
	/// <summary>
	/// Represents Ticketing visualization hints. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	/// </summary>
	[Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class TicketingVisualizationHints
    {
		#region Properties
		/// <summary>
		/// Gets or sets the field order.
		/// </summary>
		/// <value>The field order.</value>
		[JsonProperty]
        public Dictionary<string, int> FieldOrder { get; set; }

		/// <summary>
		/// Contains all the visual data linked with the values of certain enum field values.
		/// </summary>
		/// <remarks>
		/// <para>For every color linked to a selection box value, a <see cref="VisualFieldEnum"/> should be added with the following properties:</para>
		/// <para>Feature introduced in DataMiner 10.0.5 (RN 25175).</para>
		/// </remarks>
		public List<VisualFieldEnum> VisualFieldEnums
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets the search display field.
		/// </summary>
		/// <value>The search display field.</value>
        [JsonProperty]
        public string SearchDisplayField { get; set; }
		#endregion

		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="TicketingVisualizationHints"/> class.
		/// </summary>
		public TicketingVisualizationHints()
        {
        }
        #endregion

        #region Methods

        #endregion
    }
}

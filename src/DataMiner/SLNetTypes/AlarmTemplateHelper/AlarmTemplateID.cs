using System;

namespace Skyline.DataMiner.Net.AlarmTemplateHelper
{
	/// <summary>
	/// Identifies an alarm template.
	/// </summary>
	[Serializable]
    public class AlarmTemplateID
    {
		/// <summary>
		/// Gets or sets the alarm template name.
		/// </summary>
		/// <value>The alarm template name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the protocol name.
		/// </summary>
		/// <value>The protocol name.</value>
		public string ProtocolName { get; set; }

		/// <summary>
		/// Gets or sets the protocol version.
		/// </summary>
		/// <value>The protocol version.</value>
		public string ProtocolVersion { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmTemplateID"/> class.
		/// </summary>
		public AlarmTemplateID()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="AlarmTemplateID"/> class using the specified template name, protocol name and protocol version.
		/// </summary>
		/// <param name="name">The template name.</param>
		/// <param name="protocolName">The protocol name.</param>
		/// <param name="protocolVersion">The protocol version.</param>
		/// <example>
		/// <code>
		/// var id = new AlarmTemplateID("AlarmTemplate", "Protocol", "1.0.0.0");
		/// </code>
		/// </example>
		public AlarmTemplateID(string name, string protocolName, string protocolVersion)
        {
        }
    }
}

namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Globalization;
	using System.Text;

	using Templates;

	/// <summary>
	/// Represents a service configuration.
	/// </summary>
	public class AdvancedServiceConfiguration
	{
		/// <summary>
		/// Instance of the protocol for enhanced services.
		/// </summary>
		private IDmsProtocol protocol;

		/// <summary>
		/// The alarm template assigned to the element for enhanced services.
		/// </summary>
		private IDmsAlarmTemplate alarmTemplate;

		/// <summary>
		/// The trend template assigned to the element for enhanced services.
		/// </summary>
		private IDmsTrendTemplate trendTemplate;

		/// <summary>
		/// Gets or sets the protocol for enhanced services.
		/// </summary>
		public IDmsProtocol Protocol
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the timeouts of the linked element will be included in the service.
		/// </summary>
		public bool IgnoreTimeouts
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the alarm template for enhanced service.
		/// </summary>
		/// <exception cref="ArgumentException">The value of a set operation is an alarm template that is not compatible with the protocol of the enhanced service.</exception>
		public IDmsAlarmTemplate AlarmTemplate
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the trend template for the enhanced service.
		/// </summary>
		/// <exception cref="ArgumentException">The value of a set operation is a trend template that is not compatible with the protocol of the enhanced service.</exception>
		public IDmsTrendTemplate TrendTemplate
		{
			get; set;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(CultureInfo.InvariantCulture, "IncludesTimeout: {0}{1}", IgnoreTimeouts, Environment.NewLine);
			sb.AppendFormat(CultureInfo.InvariantCulture, "Protocol: {0}{1}", protocol == null ? "<<NULL>>" : protocol.Name, Environment.NewLine);
			sb.AppendFormat(CultureInfo.InvariantCulture, "Version: {0}{1}", protocol == null ? "<<NULL>>" : protocol.Version, Environment.NewLine);
			sb.AppendFormat(CultureInfo.InvariantCulture, "AlarmTemplate: {0}{1}", alarmTemplate == null ? "<<NULL>>" : alarmTemplate.Name, Environment.NewLine);
			sb.AppendFormat(CultureInfo.InvariantCulture, "TrendTemplate: {0}{1}", trendTemplate == null ? "<<NULL>>" : trendTemplate.Name, Environment.NewLine);

			return sb.ToString();
		}
	}
}
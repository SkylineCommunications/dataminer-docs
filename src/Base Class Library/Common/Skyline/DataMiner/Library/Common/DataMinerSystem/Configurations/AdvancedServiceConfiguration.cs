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
			get
			{
				return this.protocol;
			}

			set
			{
				if (alarmTemplate != null && !InputValidator.IsCompatibleTemplate(alarmTemplate,value))
				{
					alarmTemplate = null;
				}

				if (trendTemplate != null && !InputValidator.IsCompatibleTemplate(trendTemplate, value))
				{
					trendTemplate = null;
				}

				if (value.Type != ProtocolType.Service)
				{
					throw new ArgumentException("The specified protocol is not compatible with services.", "value");
				}

				this.protocol = value;
			}
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
			get
			{
				return alarmTemplate;
			}

			set
			{
				if (!InputValidator.IsCompatibleTemplate(value, this.Protocol))
				{
					throw new ArgumentException("The specified alarm template is not compatible with the protocol this enhnaced service executes.", "value");
				}
				else
				{
					this.alarmTemplate = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the trend template for the enhanced service.
		/// </summary>
		/// <exception cref="ArgumentException">The value of a set operation is a trend template that is not compatible with the protocol of the enhanced service.</exception>
		public IDmsTrendTemplate TrendTemplate
		{
			get
			{
				return trendTemplate;
			}

			set
			{
				if (!InputValidator.IsCompatibleTemplate(value, this.Protocol))
				{
					throw new ArgumentException("The specified trend template is not compatible with the protocol this enhanced service executes.", "value");
				}
				else
				{
					trendTemplate = value;
				}
			}
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
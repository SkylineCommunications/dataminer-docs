namespace Skyline.DataMiner.Library.Common
{
	using Templates;

	/// <summary>
	/// DataMiner service advanced settings interface.
	/// </summary>
	public interface IAdvancedServiceSettings
	{
		/// <summary>
		/// Gets a value indicating whether the service is a service template.
		/// </summary>
		/// <value><c>true</c> if the service is a service template; otherwise, <c>false</c>.</value>
		bool IsTemplate { get; }

		/// <summary>
		/// Gets the service template from which the service is generated in case the service is generated through a service template.
		/// </summary>
		DmsServiceId? ParentTemplate { get; }

		/// <summary>
		/// Gets the element that is linked to this service in case of an enhanced service.
		/// </summary>
		DmsElementId? ServiceElement { get; }

		/// <summary>
		/// Gets or sets the alarm template of the service element (enhanced service).
		/// </summary>
		IDmsAlarmTemplate ServiceElementAlarmTemplate { get; set; }

		/// <summary>
		/// Gets or sets the trend template of the service element (enhanced service).
		/// </summary>
		IDmsTrendTemplate ServiceElementTrendTemplate { get; set; }

		/// <summary>
		/// Gets or sets the protocol applied to the service element (enhanced service).
		/// </summary>
		IDmsProtocol ServiceElementProtocol { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether timeouts are being included in the service.
		/// </summary>
		bool IgnoreTimeouts { get; set; }
	}
}
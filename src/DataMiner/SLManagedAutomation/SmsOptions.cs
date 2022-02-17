namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents the SMS options.
	/// </summary>
	public class SmsOptions : NotificationOptions
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SmsOptions"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="to">The recipient.</param>
		/// <example>
		/// <code>
		/// var options = new SmsOptions("message", "recipient");
		/// </code>
		/// </example>
		public SmsOptions(string message, string to) : base((NotificationType)2) { }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the recipient.
		/// </summary>
		/// <value>The recipient.</value>
		public string TO { get; set; }
	}
}
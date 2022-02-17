namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents pager options.
	/// </summary>
	public class PagerOptions: NotificationOptions
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PagerOptions"/> class.
		/// </summary>
		/// <param name="message">The message to be sent.</param>
		/// <param name="to">The recipient to which the message has to be sent.</param>
		/// <example>
		/// <code>
		/// PagerOptions options = new PagerOptions("message", "recipient");
		/// </code>
		/// </example>
		public PagerOptions(string message, string to) : base((NotificationType)3) { }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <example>
		/// <code>
		/// PagerOptions options = new PagerOptions("message", "recipient");
		/// string message = options.Message;
		/// </code>
		/// </example>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the recipient.
		/// </summary>
		/// PagerOptions options = new PagerOptions("message", "recipient");
		/// string recipient = options.TO;
		public string TO { get; set; }
	}
}
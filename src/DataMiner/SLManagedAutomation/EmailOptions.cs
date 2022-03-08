namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents the email options.
	/// </summary>
	public class EmailOptions : NotificationOptions
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EmailOptions"/> class.
		/// </summary>
		/// <example>
		/// <code>
		/// EmailOptions options = new EmailOptions();
		/// </code>
		/// </example>
		public EmailOptions() :base((NotificationType)1)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailOptions"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="title">The title.</param>
		/// <param name="to">The recipient.</param>
		/// <example>
		/// <code>
		/// EmailOptions options = new EmailOptions("message", "title", "recipient");
		/// </code>
		/// </example>
		public EmailOptions(string message, string title, string to) : base((NotificationType)1)
		{
		}

		/// <summary>
		/// Gets or sets the blank carbon copy (BCC) recipients.
		/// </summary>
		/// <value>The blank carbon copy (BCC) recipients.</value>
		public string BCC { get; set; }

		/// <summary>
		/// Gets or sets the carbon copy (CC) recipients.
		/// </summary>
		/// <value>The carbon copy (CC) recipients.</value>
		public string CC { get; set; }

		/// <summary>
		/// Gets or sets the sender.
		/// </summary>
		/// <value>The sender.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.13 (RN 23563).</remarks>
		public string FROM { get; set; }

		/// <summary>
		/// Gets or set the message.
		/// </summary>
		/// <value>The message.</value>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the email should be sent as plain text.
		/// </summary>
		/// <value><c>true</c> to send as plain text; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>If set to <c>true</c>, and a report is included in the email, it will be attached to the email instead.</para>
		/// </remarks>
		public bool SendAsPlainText { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the recipients.
		/// </summary>
		/// <value>The recipients.</value>
		public string TO { get; set; }
	}
}
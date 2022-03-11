namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Serves as a base class for <see cref="EmailOptions"/>, <see cref="PagerOptions"/> and <see cref="SmsOptions"/>.
	/// </summary>
	public class NotificationOptions
	{
		internal NotificationType _type;
		internal string _message;
		internal string _title;
		internal string _to;
		internal string _cc;
		internal string _bcc;
		internal bool _asPlainText;

		/// <summary>
		/// Initializes a new instance of the <see cref="NotificationOptions"/> class.
		/// </summary>
		/// <param name="type">The type of notification.</param>
		internal NotificationOptions(NotificationType type)
		{
			this._type = type;
		}
	}
}
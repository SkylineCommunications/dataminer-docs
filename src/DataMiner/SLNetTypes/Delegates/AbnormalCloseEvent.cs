using System;

namespace Skyline.DataMiner.Net
{
	/// <summary>
	/// Delegate used for the <see cref="IConnection.OnAbnormalClose"/> event of the <see cref="IConnection"/> interface.
	/// </summary>
	public delegate void AbnormalCloseEventHandler(Object sender, AbnormalCloseEventArgs e); 

	/// <summary>
	/// Event arguments for use with <see cref="AbnormalCloseEventHandler"/>.
	/// </summary>
	/// <remarks>
	/// <seealso cref="IConnection.OnAbnormalClose"/>
	/// </remarks>
    [Serializable]
	public class AbnormalCloseEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AbnormalCloseEventArgs"/> class.
		/// </summary>
		public AbnormalCloseEventArgs() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="AbnormalCloseEventArgs"/> class.
		/// </summary>
		/// <param name="reason">Reason why the connection was destroyed.</param>
		public AbnormalCloseEventArgs(String reason)
		{
			_reason = reason;
		}

		/// <summary>
		/// Gets the reason why the connection was destroyed.
		/// </summary>
		/// <value>The reason why the connection was destroyed.</value>
		public string Reason
		{
			get
			{
				return _reason;
			}
		}

		private string _reason;
	}

}
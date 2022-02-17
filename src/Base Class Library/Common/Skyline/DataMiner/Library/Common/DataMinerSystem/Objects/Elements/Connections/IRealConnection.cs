namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// Defines a non-virtual interface.
	/// </summary>
	public interface IRealConnection : IElementConnection
	{
		// The following properties are added to each connection although it only works for the main connection.
		// The reason for this is that it could be supported in the future, and it's also designed like this in the web api: http://localhost/API/v1/soap.asmx?op=CreateElement

		/// <summary>
		/// Gets or sets the timeout of a single command or request.
		/// </summary>
		/// <value>The timeout of a single command or request.</value>
		TimeSpan Timeout { get; set; }

		/// <summary>
		/// Gets or sets the number of retries.
		/// </summary>
		/// <value>The number of retries.</value>
		int Retries { get; set; }

		///<summary>
		/// Gets or sets a value indicating after how long the element will go into timeout when it is not responding for.
		///</summary>
		/// <value>The timespan to be set, when set to <see langword="null"/>, the connection does not have an impact on the element timeout./></value>
		TimeSpan? ElementTimeout { get; set; }
	}
}

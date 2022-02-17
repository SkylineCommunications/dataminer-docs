using Skyline.DataMiner.Net.Exceptions;
using System;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents mail report options.
	/// </summary>
	public class MailReportOptions
	{
		/// <summary>
		/// Gets the email options.
		/// </summary>
		/// <value>The email options.</value>
		public EmailOptions MailOptions { get; }

		/// <summary>
		/// Gets or sets the name of the report template to be used.
		/// </summary>
		/// <value>The name of the report template to be used.</value>
		public string ReportName { get; set; }

		/// <summary>
		/// Adds the specified reservation properties.
		/// </summary>
		/// <param name="params">The reservation properties to be added.</param>
		public void AddReservationProperties(params string[] @params) { }

		/// <summary>
		/// Adds the specified parameters of the specified dummy element to this report.
		/// </summary>
		/// <param name="dummy">The element from which the specified parameters should be included.</param>
		/// <param name="params">The parameters to be included in the mail report.</param>
		/// <remarks>
		/// <para>Allows including table cells.</para>
		/// </remarks>
		public void IncludeElement(IActionableElement dummy, params MailReportParameter[] @params) { }

		/// <summary>
		/// Adds the specified parameters of the specified dummy element to this report.
		/// </summary>
		/// <param name="dummy">The element from which the specified parameters should be included.</param>
		/// <param name="params">The names of the standalone parameters to be included in the mail report.</param>
		public void IncludeElement(IActionableElement dummy, params string[] @params) { }

		/// <summary>
		/// Adds the specified parameters of the specified element to this report.
		/// </summary>
		/// <param name="dmaid">The DataMiner Agent ID of the element from which the specified parameters should be included.</param>
		/// <param name="eid">The element ID of the element from which the specified parameters should be included.</param>
		/// <param name="params">The parameters to be included in the mail report.</param>
		public void IncludeElement(int dmaid, int eid, params MailReportParameter[] @params) { }

		/// <summary>
		/// Adds the specified parameters of all elements of a given protocol from the specified view to this mail report.
		/// </summary>
		/// <param name="viewName">The name of the view.</param>
		/// <param name="protocolName">The name of the protocol.</param>
		/// <param name="protocolVersion">The version of the protocol.</param>
		/// <param name="params">The parameters to be included in the mail report.</param>
		public void IncludeFilteredView(string viewName, string protocolName, string protocolVersion, params MailReportParameter[] @params) { }

		/// <summary>
		/// Adds the specified parameters of all elements of a given protocol from the specified view to this mail report.
		/// </summary>
		/// <param name="viewName">The name of the view.</param>
		/// <param name="protocolName">The name of the protocol.</param>
		/// <param name="protocolVersion">The version of the protocol.</param>
		/// <param name="params">The parameters to be included in the mail report.</param>
		/// <exception cref="DataMinerException">
		/// Cannot load protocol (no SLNet connection)<br />
		/// -or-
		/// Could not load protocol (no data returned)
		/// -or-
		/// Could not load protocol (no object returned)
		/// </exception>
		public void IncludeFilteredView(string viewName, string protocolName, string protocolVersion, params string[] @params) { }

		
		public void IncludeReservationGuid(ValueType reservationGuid) { }

		/// <summary>
		/// Adds a view to be included in the report.
		/// </summary>
		/// <param name="viewName">The name of the view.</param>
		public void IncludeView(string viewName) { }

		/// <summary>
		/// Adds the specified parameters of the elements in the specified view to the mail report.
		/// </summary>
		/// <param name="viewName">The name of the view.</param>
		/// <param name="params">The parameters to be included in the mail report.</param>
		public void IncludeView(string viewName, params MailReportParameter[] @params) { }

		/// <summary>
		/// Sets the mail options.
		/// </summary>
		/// <param name="mailOptions">The mail options.</param>
		public void SetMailOptions(EmailOptions mailOptions) { }

		/// <summary>
		/// Sets the mail options.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="title">The title.</param>
		/// <param name="to">The recipients.</param>
		public void SetMailOptions(string message, string title, string to) { }
	}
}
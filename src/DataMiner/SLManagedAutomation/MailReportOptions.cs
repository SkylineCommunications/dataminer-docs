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
		/// <value>The full name of the dashboard (including all parent folders separated with '/') or the name of the report template (legacy Reporter) to be used.</value>
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
		/// <example>
		/// <para>For an example showing how to pass single-value parameters as well as table cells to a report, see below:</para>
		/// <code>
		/// Element dummy1 = engine.FindElement("My Element");
		/// MailReportOptions reportOptions = engine.PrepareMailReport("Report Name");
		/// // Add single-value parameter
		/// reportOptions.IncludeElement(dummy1, new MailReportParameter(dummy1, "Total Processor Load");
		/// // Add table cell
		/// reportOptions.IncludeElement(dummy1, new MailReportParameter(dummy1, "Bandwidth", "Eth0");
		/// </code>
		/// <note type="note">
		/// <para>In the example above, the index argument has to contain the display key. If necessary, use the FindDisplayKey method on the element or the dummy to retrieve that key. See <see cref="Element.FindDisplayKey(int, String)"/>.</para>
		/// </note>
		/// </example>
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

		/// <summary>
		/// Adds the specified reservation GUID.
		/// </summary>
		/// <param name="reservationGuid">The reservation GUID.</param>
		/// <example>
		/// <code>
		/// MailReportOptions reportOptions = engine.PrepareMailReport("myTemplate");
		/// 
		/// reportOptions.IncludeReservationGuid(new Guid("{12776948-CF8E-4A5D-AC2B-A9D1AB0D8A68}"));
		/// </code>
		/// </example>
		public void IncludeReservationGuid(ValueType reservationGuid) { }

		/// <summary>
		/// Adds a view to be included in the report.
		/// </summary>
		/// <param name="viewName">The name of the view.</param>
		/// <example>
		/// <code>
		/// MailReportOptions reportOptions = engine.PrepareMailReport("myTemplate");
		/// 
		/// reportOptions.IncludeView("myView");
		/// </code>
		/// </example>
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
		/// <example>
		/// <code>
		/// MailReportOptions reportOptions = engine.PrepareMailReport("myTemplate");
		///
		/// string title = "Load Overview";
		/// string message = "Information about last day's load";
		///
		/// EmailOptions emailOptions = new EmailOptions();
		/// emailOptions.Title = title;
		/// emailOptions.Message = message;
		/// emailOptions.TO = "user.demuynck@domain.com";
		/// emailOptions.SendAsPlainText = true;
		/// 
		/// reportOptions.SetMailOptions(emailOptions);
		/// </code>
		/// </example>
		public void SetMailOptions(EmailOptions mailOptions) { }

		/// <summary>
		/// Sets the mail options.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="title">The title.</param>
		/// <param name="to">The recipients.</param>
		/// <example>
		/// <code>
		/// MailReportOptions reportOptions = engine.PrepareMailReport("myTemplate");
		/// 
		/// string title = "Load Overview";
		/// string message = "Information about last day's load";
		/// string to = "user@domain.com";
		/// reportOptions.SetMailOptions(message, title, to);
		/// </code>
		/// </example>
		public void SetMailOptions(string message, string title, string to) { }
	}
}

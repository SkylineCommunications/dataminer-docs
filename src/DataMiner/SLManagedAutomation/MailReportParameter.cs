using System.Collections.Generic;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a mail report parameter.
	/// </summary>
	public class MailReportParameter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MailReportOptions"/> class using the specified parameter ID.
		/// </summary>
		/// <param name="pid">The ID of the parameter.</param>
		public MailReportParameter(int pid) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MailReportOptions"/> class using the specified dummy and parameter name.
		/// </summary>
		/// <param name="dummy">The element dummy.</param>
		/// <param name="name">The name of the parameter.</param>
		public MailReportParameter(IActionableElement dummy, string name) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MailReportOptions"/> class using the specified parameter ID and index.
		/// </summary>
		/// <param name="pid">The ID of the parameter.</param>
		/// <param name="index">The display key.</param>
		public MailReportParameter(int pid, string index) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MailReportOptions"/> class using the specified dummy, parameter name and index.
		/// </summary>
		/// <param name="dummy">The element dummy.</param>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="index">The display key.</param>
		public MailReportParameter(IActionableElement dummy, string name, string index) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MailReportOptions"/> class using the specified parameter ID, index and mail report parameter options.
		/// </summary>
		/// <param name="pid">The ID of the parameter.</param>
		/// <param name="index">The display key.</param>
		/// <param name="options">The mail report parameter options.</param>
		public MailReportParameter(int pid, string index, MailReportParameterFlags options) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MailReportOptions"/> class using the specified dummy, name and mail report parameter options.
		/// </summary>
		/// <param name="dummy">The element dummy.</param>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="index">The display key.</param>
		/// <param name="options">The mail report parameter options.</param>
		public MailReportParameter(IActionableElement dummy, string name, string index, MailReportParameterFlags options) { }

		/// <summary>
		/// Gets or sets the mail report parameter options.
		/// </summary>
		public MailReportParameterFlags Options { get; set; }

		/// <summary>
		/// Gets or sets the parameter ID.
		/// </summary>
		/// <value>The parameter ID.</value>
		public int ParameterID { get; set; }

		/// <summary>
		/// Gets or sets the row filter.
		/// </summary>
		/// <value>The row filter.</value>
		public string RowFilter { get; set; }

		/// <summary>
		/// Converts the provided mail report parameter list to a string representation.
		/// </summary>
		/// <param name="params">The parameters to include in the string representation.</param>
		/// <returns>The string representation of the provided mail report parameter list.</returns>
		public static string ToIncludedParametersString(List<MailReportParameter> @params) { return ""; }

		/// <summary>
		/// Converts the provided mail report parameters to a string representation.
		/// </summary>
		/// <param name="params">The parameters to include in the string representation.</param>
		/// <returns>The string representation of the provided mail report parameters.</returns>
		public static string ToIncludedParametersString(params MailReportParameter[] @params) { return ""; }
	}
}
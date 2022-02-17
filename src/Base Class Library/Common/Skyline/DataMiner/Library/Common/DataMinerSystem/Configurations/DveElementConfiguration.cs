namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Globalization;
	using System.Text;

	/// <summary>
	/// Represents an element configuration.
	/// </summary>
	public class DveElementConfiguration
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="DveElementConfiguration"/> class.
		/// </summary>
		public DveElementConfiguration()
		{
			IsDveCreationEnabled = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the creation of DVEs is enabled.
		/// </summary>
		public bool IsDveCreationEnabled { get; set; }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(CultureInfo.InvariantCulture, "IsDveCreationEnabled: {0}{1}", IsDveCreationEnabled, Environment.NewLine);

			return sb.ToString();
		}
	}
}
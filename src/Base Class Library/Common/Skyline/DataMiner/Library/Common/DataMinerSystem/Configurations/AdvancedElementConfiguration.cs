namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Globalization;
	using System.Text;

	/// <summary>
	/// Represents an element configuration.
	/// </summary>
	public class AdvancedElementConfiguration
    {
        /// <summary>
        /// The default timeout time of an element.
        /// </summary>
        private TimeSpan timespan = new TimeSpan(0, 0, 30);

        /// <summary>
        /// Gets or sets a value indicating whether the element is hidden.
        /// </summary>
        public bool IsHidden
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the element is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get;
            set;
        }

		/// <summary>
		/// Gets or sets the timeout.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">The value of a set operation is not within the range of [0,120] s.</exception>
		public TimeSpan Timeout
        {
            get
            {
                return timespan;
            }

            set
            {
				int timeoutInSeconds = (int)value.TotalSeconds;

				if (timeoutInSeconds < 0 || timeoutInSeconds > 120)
				{
					throw new ArgumentOutOfRangeException("value", "The timeout value must be in the range of [0,120] s.");
				}

				timespan = value;
            }
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(CultureInfo.InvariantCulture, "IsHidden: {0}{1}", IsHidden, Environment.NewLine);
			sb.AppendFormat(CultureInfo.InvariantCulture, "IsReadOnly: {0}{1}", IsReadOnly, Environment.NewLine);
			sb.AppendFormat(CultureInfo.InvariantCulture, "Timeout: {0}{1}", Timeout, Environment.NewLine);

			return sb.ToString();
		}
	}
}
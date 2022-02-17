namespace Skyline.DataMiner.Library.Common
{
	using System;

	/// <summary>
	/// DataMiner element advanced settings interface.
	/// </summary>
	public interface IAdvancedSettings
	{
		/// <summary>
		/// Gets or sets a value indicating whether the element is hidden.
		/// </summary>
		/// <value><c>true</c> if the element is hidden; otherwise, <c>false</c>.</value>
		/// <exception cref="NotSupportedException">A set operation is not supported on a derived element.</exception>
		bool IsHidden { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the element is read-only.
		/// </summary>
		/// <value><c>true</c> if the element is read-only; otherwise, <c>false</c>.</value>
		/// <exception cref="NotSupportedException">A set operation is not supported on a DVE or derived element.</exception>
		bool IsReadOnly { get; set; }

		/// <summary>
		/// Gets a value indicating whether the element is running a simulation.
		/// </summary>
		/// <value><c>true</c> if the element is running a simulation; otherwise, <c>false</c>.</value>
		bool IsSimulation { get; }

		/// <summary>
		/// Gets or sets the element timeout value.
		/// </summary>
		/// <value>The timeout value.</value>
		/// <exception cref="NotSupportedException">A set operation is not supported on a DVE or derived element.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified for a set operation is not in the range of [0,120] s.</exception>
		/// <remarks>Fractional seconds are ignored. For example, setting the timeout to a value of 3.5s results in setting it to 3s.</remarks>
		TimeSpan Timeout { get; set; }
	}
}
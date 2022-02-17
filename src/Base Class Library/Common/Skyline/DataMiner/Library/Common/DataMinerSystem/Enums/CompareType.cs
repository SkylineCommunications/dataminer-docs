namespace Skyline.DataMiner.Library.Common
{
	/// <summary>
	/// Specifies the state of the element.
	/// </summary>
	public enum ComparisonOperator
	{
		/// <summary>
		/// Specifies to compare if both values are equal.
		/// </summary>
		Equal = 0,

		/// <summary>
		/// Specifies to compare if both values are not equal.
		/// </summary>
		NotEqual = 1,

		/// <summary>
		/// Specifies to compare if one value is greater than the other value.
		/// </summary>
		GreaterThan = 2,

		/// <summary>
		/// Specifies to compare if one value is greater than or equal to the other value.
		/// </summary>
		GreaterThanOrEqual = 3,

		/// <summary>
		/// Specifies to compare if one value is less than the other value.
		/// </summary>
		LessThan = 4,

		/// <summary>
		/// Specifies to compare if one value is less than or equal to the other value.
		/// </summary>
		LessThanOrEqual = 6
	}
}

using System;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a capacity.
	/// </summary>
	/// <remarks>Feature introduced in DataMiner 9.6.5 (RN 20996).</remarks>
	/// <remarks>
	/// Defines the value of a capacity parameter. This is a <see cref="Parameter"/> of the ProfileManager with category Capacity.
	/// The units are part of the parameter definition, and not the value.
	/// </remarks>
	[Serializable]
    //[DataContract]
    public sealed class CapacityUsageParameterValue : IEquatable<CapacityUsageParameterValue>, ICloneable
    {
		/// <summary>
		/// Gets or sets the quantity.
		/// </summary>
		/// <value>The quantity.</value>
		[Obsolete("Please use the DecimalQuantity property instead")]
        public long Quantity {
			get; set;
        }

		/// <summary>
		/// Gets or sets the decimal quantity.
		/// </summary>
		/// <value>The decimal quantity.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.8 (RN 22022).
		/// Setting the long capacity value will also update its decimal capacity value and vice versa. If the decimal value is too large to fit in a long, getting the corresponding long value will return 0. Getting the long capacity while the corresponding decimal capacity is set to a non-integer value will return the decimal capacity rounded down to the nearest integer (i.e if the decimal capacity is set to 125.8, the long capacity will be 125).
		/// A system that uses decimal capacities should no longer use the obsolete long capacities. Since it is not always possible to correctly convert the decimal capacity to a long capacity, the returned value when requesting the long capacity may no longer be correct.
		/// </remarks>
		//[DataMember(Name = "Quantity")]
        public decimal DecimalQuantity { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CapacityUsageParameterValue"/> class.
		/// </summary>
		public CapacityUsageParameterValue()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="CapacityUsageParameterValue"/> class using the specified quantity.
		/// </summary>
		/// <param name="quantity">The quantity.</param>
		public CapacityUsageParameterValue(long quantity)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="CapacityUsageParameterValue"/> class using the specified quantity.
		/// </summary>
		/// <param name="quantity">The quantity.</param>
		public CapacityUsageParameterValue(decimal quantity)
        {
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
			return true;
        }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(CapacityUsageParameterValue other)
        {
			return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
			return 1;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
			return null;
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}
    }
}

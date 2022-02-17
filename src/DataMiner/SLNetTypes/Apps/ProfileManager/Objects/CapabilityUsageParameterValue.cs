using System;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a capability usage parameter value.
	/// </summary>
	/// <remarks>Feature introduced in DataMiner 9.6.4 (RN 20891, 21178).</remarks>
	[Serializable]
    //[DataContract]
    public sealed class CapabilityUsageParameterValue : ICloneable, IEquatable<CapabilityUsageParameterValue>
    {
		/// <summary>
		/// Gets or sets the required discrete value.
		/// </summary>
		/// <value>The required discrete value.</value>
		/// <remarks>
		/// Will be used if <see cref="RequiredRangePoint"/> is NaN.
		/// </remarks>
		//[DataMember(Name = "RequiredDiscreet")]
        public string RequiredDiscreet { get; set; }

		/// <summary>
		/// Gets or sets the required range point.
		/// </summary>
		/// <value>The required range point.</value>
		/// <remarks>
		/// If this is NaN then the <see cref="RequiredDiscreet"/> or <see cref="RequiredString"/> value will be used instead, depending on which one is filled in.
		/// </remarks>
		//[DataMember(Name = "RequiredRangePoint")]
        public double RequiredRangePoint { get; set; }

		/// <summary>
		/// Gets or sets the required string.
		/// </summary>
		/// <value>The required string.</value>
		/// <remarks>
		/// Will be used if <see cref="RequiredRangePoint"/> is NaN and <see cref="RequiredDiscreet"/> is null or an empty string.
		/// </remarks>
		//[DataMember(Name = "RequiredString")]
        public string RequiredString { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CapabilityUsageParameterValue"/> class.
		/// </summary>
		public CapabilityUsageParameterValue()
        {
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
			return null;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(CapabilityUsageParameterValue other)
        {
            return true;
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
    }
}

using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a capability parameter value.
	/// </summary>
	/// <remarks>Feature introduced in DataMiner 9.6.4 (RN 20891, 21178).</remarks>
	[Serializable]
    //[DataContract]
    public class CapabilityParameterValue : IEquatable<CapabilityParameterValue>, ICloneable
    {
		/// <summary>
		/// Gets or sets the discrete entries.
		/// </summary>
		/// <value>The discrete entries.</value>
		//[DataMember(Name = "DiscreetValues")]
        public List<string> Discreets { get; set; }

		/// <summary>
		/// Gets or sets the minimum value of the range.
		/// </summary>
		/// <value>The minimum value of the range.</value>
		//[DataMember(Name = "MinRange")]
        public double MinRange { get; set; }

		/// <summary>
		/// Gets or sets the maximum value of the range.
		/// </summary>
		/// <value>The maximum value of the range.</value>
		//[DataMember(Name = "MaxRange")]
        public double MaxRange { get; set; }

		/// <summary>
		/// Gets or sets the provider string.
		/// </summary>
		/// <value>The provider string.</value>
        //[DataMember(Name = "ProvidedString")]
        public string ProvidedString { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CapabilityParameterValue"/> class.
		/// </summary>
		public CapabilityParameterValue()
            : this(new List<string>(), double.NaN, double.NaN, String.Empty)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="CapabilityParameterValue"/> class using the specified minimum and maximum range values.
		/// </summary>
		/// <param name="minRange">The minimum value of the range.</param>
		/// <param name="maxRange">The maximum value of the range.</param>
		public CapabilityParameterValue(double minRange, double maxRange)
            : this(new List<string>(), minRange, maxRange, string.Empty)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="CapabilityParameterValue"/> class using the specified list of discrete entries.
		/// </summary>
		/// <param name="discreets">The discrete entries.</param>
		public CapabilityParameterValue(List<string> discreets)
            : this(discreets, double.NaN, double.NaN, string.Empty)
        {
        }

        public CapabilityParameterValue(string providedString) : this(new List<string>(), double.NaN, double.NaN, providedString)
        {
        }

        private CapabilityParameterValue(List<string> discreets, double minRange, double maxRange) : this(discreets, minRange, maxRange, string.Empty)
        {
        }

        private CapabilityParameterValue(List<string> discreets, double minRange, double maxRange, string providedString)
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
		public bool Equals(CapabilityParameterValue other)
        {
            return true;
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
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
			return 0;
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
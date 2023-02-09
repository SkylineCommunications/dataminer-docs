using System;
#if NETFRAMEWORK
using System.ComponentModel;
using System.Drawing.Design;
#endif

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a Profile Manager parameter value.
	/// </summary>
	[Serializable]
//#if NETFRAMEWORK
//    [Editor(typeof(ObjectEditor<ParameterValue>), typeof(UITypeEditor))]
//#endif
    //[DataContract(Name = "ParameterValue")]
    public class ParameterValue : IEquatable<ParameterValue>, IProfileParameterValue
    {
		/// <summary>
		/// Specifies the type of the parameter value.
		/// </summary>
		[Serializable]
        public enum ValueType
        {
			/// <summary>
			/// Undefined.
			/// </summary>
			Undefined,
			/// <summary>
			/// Double.
			/// </summary>
			Double,
			/// <summary>
			/// String.
			/// </summary>
			String,
			/// <summary>
			/// Discrete.
			/// </summary>
			/// <remarks>
			/// Do not use this, always store the raw values of a discrete, either a double or string.
			/// </remarks>
			[Obsolete("Do not use this, always store the raw values of a discreet, either a double or string.")]
            Discreet
            // Integer,
            // DateTime
        }

		/// <summary>
		/// Gets or sets the type of the parameter value.
		/// </summary>
		//[DataMember(Name = "Type")]
        public ValueType Type { get; set; }

		/// <summary>
		/// Gets or sets the parameter value in case the type is <see cref="ValueType.String"/>.
		/// </summary>
		/// <value>The parameter value in case the type is <see cref="ValueType.String"/>.</value>
		//[DataMember(Name = "StringValue")]
        public string StringValue { get; set; }

		/// <summary>
		/// Gets or sets the parameter value in case the type is <see cref="ValueType.Double"/>.
		/// </summary>
		/// <value>The parameter value in case the type is <see cref="ValueType.Double"/>.</value>
		//[DataMember(Name = "DoubleValue")]
        public double DoubleValue { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValue"/> class.
		/// </summary>
		public ParameterValue()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterValue"/> class using the specified parameter value.
		/// </summary>
		/// <param name="pv">The parameter value.</param>
		public ParameterValue(ParameterValue pv)
        {
        }

        public bool ShouldSerializeDoubleValue()
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
		///  Determines whether the specified <see cref="ParameterValue"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public bool Equals(ParameterValue other)
        {
            return true;
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
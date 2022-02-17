using System;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents parameter settings.
	/// </summary>
	/// <remarks>Available from DataMiner 10.1.4 (RN 28792) onwards.</remarks>
	[Serializable]
    //[DataContract(Name = "ParameterSettings")]
    public class ParameterSettings : IEquatable<ParameterSettings>
    {
		/// <summary>
		/// Gets or sets a value indicating whether this parameter is hidden. Default: false.
		/// </summary>
		/// <value><c>true</c> if hidden; otherwise <c>false</c>.</value>
		//[DataMember(Name = "IsHidden")]
        public bool IsHidden { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterSettings"/> class.
		/// </summary>
		public ParameterSettings()
        {
        }

		/// <summary>
		///  Determines whether the specified <see cref="ParameterSettings"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public bool Equals(ParameterSettings other)
        {
            return false;
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
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override int GetHashCode()
        {
            return 1;
        }
    }
}

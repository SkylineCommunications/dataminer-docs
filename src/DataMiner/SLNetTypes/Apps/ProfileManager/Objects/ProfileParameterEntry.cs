using System;
using System.Xml.Serialization;

using Skyline.DataMiner.Net.IManager.Helper;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a profile parameter entry in a profile instance.
	/// </summary>
	[Serializable]
    //[DataContract(Name ="ProfileParameterEntry")]
    public class ProfileParameterEntry : IEquatable<ProfileParameterEntry>
    {
        #region Properties & fields
		/// <summary>
		/// Gets or sets the profile parameter this entry relates to.
		/// </summary>
		/// <value>The profile parameter this entry relates to.</value>
		[XmlIgnore] // don't serialize this Parameter property as an object...
        public Parameter Parameter
        {
			get; set;
        }

		/// <summary>
		/// Gets the ID of the profile parameter this entry relates to.
		/// </summary>
		/// <value>The ID of the profile parameter this entry relates to.</value>
		//[DataMember(Name = "Parameter")] // ...instead serialize its GUID field only
        public Guid ParameterID
        {
			get; private set;
        }

		/// <summary>
		/// Gets or sets the value of this profile parameter entry.
		/// </summary>
		/// <value>The value of this profile parameter entry.</value>
		//[DataMember(Name = "Value")]
        public ParameterValue Value { get; set; }

		/// <summary>
		/// Gets or sets the capability usage value.
		/// </summary>
		/// <value>The capability usage value.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.4 (RN 20891, 21178).</remarks>
		//[DataMember(Name = "CapabilityUsageValue")]
        public CapabilityUsageParameterValue CapabilityUsageValue { get; set; }

		/// <summary>
		/// Gets or sets the capacity usage value.
		/// </summary>
		/// <value>The capacity usage value.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.5 (RN 21194).</remarks>
		//[DataMember(Name = "CapacityUsageValue")]
        public CapacityUsageParameterValue CapacityUsageValue { get; set; }

		/// <summary>
		/// Gets or sets remarks related to this profile parameter entry.
		/// </summary>
		/// <value>Remarks related to this profile parameter entry.</value>
		//[DataMember(Name = "Remarks")]
        public string Remarks { get; set; } // add some details why a certain value is used?

		/// <summary>
		/// Gets or sets a value indicating whether this parameter is disabled.
		/// </summary>
		/// <value><c>true</c> if disabled; otherwise, <c>false</c>.</value>
		/// <remarks>This is used to disable a parameter that should not be inherited from a parent profile instance.
		/// Feature introduced in DataMiner 9.6.8 (RN 21808).</remarks>
		//[DataMember(Name = "Disabled")]
        public bool Disabled { get; set; }

		/// <summary>
		/// Gets or sets the parameter settings.
		/// </summary>
		/// <value>The parameter settings.</value>
		//[DataMember(Name = "ParameterSettings")]
        public ParameterSettings ParameterSettings { get; set; }

        [field: NonSerialized]
        public event EventHandler<IManagerRequestResponseEventArgs> RequestResponseEvent;

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileParameterEntry"/> class.
		/// </summary>
		public ProfileParameterEntry()
        {
        }

		/// <summary>
		/// Determines whether this parameter entry matches the specified filter.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns><c>true</c> if this parameter entry matches the specified filter; otherwise, <c>false</c>.</returns>
		public bool FiltersTo(ProfileParameterEntry filter)
        {
            return true;
        }

        internal ProfileParameterEntry ShallowCopy()
        {
            return null;
        }

		/// <summary>
		///  Determines whether the specified <see cref="ProfileParameterEntry"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>Two <see cref="ProfileParameterEntry"/> instances are considered equal by this method if the <see cref="ParameterID"/> and <see cref="Value"/> property values are equal.</remarks>
		public bool Equals(ProfileParameterEntry other)
        {
            return true;
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>Two <see cref="ProfileParameterEntry"/> instances are considered equal by this method if the <see cref="ParameterID"/> and <see cref="Value"/> property values are equal.</remarks>
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

        public void SetParameterRetrievalFunc(Func<Guid, Parameter> retrieveFunc)
        {
        }
    }
}

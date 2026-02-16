using System;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>Represents a script entry.</summary>
	/// <remarks>Used by <see cref="ProfileDefinition"/>.</remarks>
	// also used in ServiceDefinition.
	[Serializable]
    //[DataContract(Name = "ScriptEntry")]
    public class ScriptEntry: IEquatable<ScriptEntry>
    {
		/// <summary>
		/// Gets or sets the name of the automation script.
		/// </summary>
		/// <value>The name of the automation script.</value>
		//[DataMember(Name = "Name")]
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of the script.
		/// </summary>
		/// <value>The description of the script.</value>
		//[DataMember(Name = "Description")]
        public string Description { get; set; }


		/// <summary>
		/// Gets or sets the script.
		/// </summary>
		/// <remarks>Same syntax as used in Visio "Execute" shape data, e.g. "MyScript|Dummy 1=MyElement|MyParameter=12|MyMemory=abc|MyTooltip|NoConfirmation,NoSetCheck".</remarks>
		//[DataMember(Name = "Script")]
        public string Script { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptEntry"/> class.
		/// </summary>
		public ScriptEntry()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptEntry"/> class using the specified script entry.
		/// </summary>
		/// <param name="entry">The entry to base this new <see cref="ScriptEntry"/> instance on.</param>
		public ScriptEntry(ScriptEntry entry)
        {
        }

        /// <summary>
        /// Checks if this object qualifies for the specified filter.
        /// </summary>
        /// <param name="filter">Object used as filter</param>
        /// <returns>True if we pass the filter, false if we don't pass</returns>
        public bool FiltersTo(ScriptEntry filter)
        {
            return true;
        }

		/// <summary>
		///  Determines whether the specified <see cref="ScriptEntry"/> object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		public bool Equals(ScriptEntry other)
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
			return false;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
			return 1;
        }
    }
}

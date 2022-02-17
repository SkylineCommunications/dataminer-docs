using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.DataMiner.Net.Messages
{
    /// <summary>
    /// Represents the combination of a parameter and display index (for dynamic table columns).
    /// </summary>
    [Serializable]
    public class ParameterIndexPair : ICloneable
    {
		/// <summary>
		/// Initializes an instance of the <see cref="ParameterIndexPair"/> class.
		/// </summary>
		public ParameterIndexPair() { }

		/// <summary>
		/// Initializes an instance of the <see cref="ParameterIndexPair"/> class using the specified parameter ID.
		/// </summary>
		/// <param name="pid">The parameter ID.</param>
		public ParameterIndexPair(int pid) : this(pid, null) { }

		/// <summary>
		/// Initializes an instance of the <see cref="ParameterIndexPair"/> class using the specified parameter ID and index.
		/// </summary>
		/// <param name="pid">The parameter ID.</param>
		/// <param name="index">The index.</param>
		public ParameterIndexPair(int pid, string index)
        {
            this.ID = pid;
            this.Index = index;
        }

		/// <summary>
		/// Gets or sets the parameter ID.
		/// </summary>
		/// <value>The parameter ID.</value>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the index.
		/// </summary>
		/// <value>The index.</value>
        public string Index { get; set; }

		/// <summary>
		/// Gets the key.
		/// </summary>
		/// <value>The key.</value>
		public string Key { get { return ToKey(ID, Index); } }

		/// <summary>
		/// Returns a string representation of the specified parameter ID and index.
		/// </summary>
		/// <param name="pid">The parameter ID.</param>
		/// <param name="idx">The index.</param>
		/// <returns></returns>
        public static string ToKey(int pid, string idx)
        {
			return null;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
			if (String.IsNullOrEmpty(Index))
				return this.ID.ToString();
			else
				return null;
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

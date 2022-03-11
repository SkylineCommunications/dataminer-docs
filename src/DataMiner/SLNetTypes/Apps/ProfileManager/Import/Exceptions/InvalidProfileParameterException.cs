using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net.Profiles;

namespace Skyline.DataMiner.Net.ProfileManager.Import.Exceptions
{
	/// <summary>
	/// Thrown by the ProfileParameterImporter when a <see cref="Parameter"/> could not be imported.
	/// </summary>
	[Serializable]
    public class InvalidProfileParameterException : Exception
    {
		/// <summary>
		/// Gets the ID of the <see cref="Parameter"/> that could not be imported.
		/// </summary>
		/// <value>The ID of the <see cref="Parameter"/> that could not be imported. Empty GUID if the ID was not recoverable from the import package.</value>
		public Guid ProfileParameterId { get; private set; }

		/// <summary>
		/// Gets or sets the path to the invalid Entry within the upgrade package.
		/// </summary>
		/// <value>The path to the invalid Entry within the upgrade package.</value>
		public string EntryPath { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidProfileParameterException"/> class using the specified profile parameter ID and entry path.
		/// </summary>
		/// <param name="profileParameterId">The profile parameter ID</param>
		/// <param name="entryPath">The entry path.</param>
		public InvalidProfileParameterException(Guid profileParameterId, string entryPath)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidProfileParameterException"/> class using the specified message, profile parameter ID and entry path.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="profileParameterId">The profile parameter ID</param>
		/// <param name="entryPath">The entry path.</param>
		public InvalidProfileParameterException(string message, Guid profileParameterId, string entryPath) : base(message)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidProfileParameterException"/> class using the specified message, inner exception, profile parameter ID and entry path.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner exception.</param>
		/// <param name="profileParameterId">The profile parameter ID</param>
		/// <param name="entryPath">The entry path.</param>
		public InvalidProfileParameterException(string message, Exception inner, Guid profileParameterId, string entryPath) : base(message, inner)
        {
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
			return null;
		}

        #region Serialization
        protected InvalidProfileParameterException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

		/// <summary>
		/// Populates a <see cref="SerializationInfo"/> with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
        #endregion
    }
}

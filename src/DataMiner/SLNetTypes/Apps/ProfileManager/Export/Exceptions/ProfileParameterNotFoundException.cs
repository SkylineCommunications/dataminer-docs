using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.ProfileManager.Export.Exceptions
{
	/// <summary>
	/// Thrown when a profile parameter passed to the ProfileParameterExporter cannot be found.
	/// </summary>
	[Serializable]
    public class ProfileParameterNotFoundException : Exception
    {
		/// <summary>
		/// Gets the profile parameter ID.
		/// </summary>
		/// <value>The profile parameter ID.</value>
		public Guid ProfileParameterId { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileParameterNotFoundException"/> class using the specified profile parameter ID.
		/// </summary>
		/// <param name="profileParameterId">The profile parameter ID.</param>
		public ProfileParameterNotFoundException(Guid profileParameterId)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileParameterNotFoundException"/> class using the specified message and profile parameter ID.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="profileParameterId">The profile parameter ID.</param>
		public ProfileParameterNotFoundException(string message, Guid profileParameterId) : base(message)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileParameterNotFoundException"/> class using the specified message and profile parameter ID.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner exception.</param>
		/// <param name="profileParameterId">The profile parameter ID.</param>
		public ProfileParameterNotFoundException(string message, Exception inner, Guid profileParameterId) : base(message, inner)
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
        protected ProfileParameterNotFoundException(
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net.Profiles;

namespace Skyline.DataMiner.Net.ProfileManager.Export.Exceptions
{
	/// <summary>
	/// Thrown when a <see cref="Parameter"/> with a <see cref="ProtocolParameterReference"/> with an invalid link to a MediationSnippet is exported.
	/// </summary>
	[Serializable]
    public class MediationSnippetNotFoundException : Exception
    {
		/// <summary>
		/// Gets the mediation snippet ID.
		/// </summary>
		/// <value>The mediation snippet ID.</value>
		public Guid MediationSnippetId { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="MediationSnippetNotFoundException"/> class using the specified snippet GUID.
		/// </summary>
		/// <param name="mediationSnippetGuid">The snippet GUID.</param>
		public MediationSnippetNotFoundException(Guid mediationSnippetGuid)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="MediationSnippetNotFoundException"/> class using the specified message and snippet GUID.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="mediationSnippetGuid">The snippet GUID.</param>
		public MediationSnippetNotFoundException(string message, Guid mediationSnippetGuid) : base(message)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="MediationSnippetNotFoundException"/> class using the specified message, inner exception and snippet GUID.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="inner">The inner exception.</param>
		/// <param name="mediationSnippetGuid">The snippet GUID.</param>
		public MediationSnippetNotFoundException(string message, Exception inner, Guid mediationSnippetGuid) : base(message, inner)
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
        protected MediationSnippetNotFoundException(
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

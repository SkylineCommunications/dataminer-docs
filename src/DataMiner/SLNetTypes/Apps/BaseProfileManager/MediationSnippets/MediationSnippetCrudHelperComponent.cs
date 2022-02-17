using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net.MediationSnippets
{
	/// <summary>
	/// Mediation snippet CRUD helper component.
	/// </summary>
	/// <remarks>
	/// <para>Available from DataMiner 10.0.8 (RN 25515) onwards.</para>
	/// </remarks>
	public class MediationSnippetCrudHelperComponent : CrudHelperComponent<MediationSnippet>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="MediationSnippetCrudHelperComponent"/> class.
		/// </summary>
		/// <param name="messageHandler">The message handler.</param>
		public MediationSnippetCrudHelperComponent(Func<DMSMessage[], DMSMessage[]> messageHandler)
            //: base(messageHandler, true)
        {
        }

    }
}
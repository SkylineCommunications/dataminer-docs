using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net.MediationSnippets;
using Skyline.DataMiner.Net.Profiles;

namespace Skyline.DataMiner.Net.ProfileManager.Import
{
	/// <summary>
	/// Returned by the ProfileParameterImporter when importing <see cref="Parameter"/>s
	/// </summary>
	[Serializable]
    public class ProfileParameterImportResult
    {
		/// <summary>
		/// Gets the list of <see cref="Parameter"/>s that was imported.
		/// </summary>
		/// <value>The list of <see cref="Parameter"/>s that was imported.</value>
		public List<Profiles.Parameter> ImportedParameters{ get; private set; }

		/// <summary>
		/// Gets the list of <see cref="MediationSnippet"/>s that was imported.
		/// </summary>
		/// <value>The list of <see cref="MediationSnippet"/>s that was imported. One or more of the imported parameters will have a link to one of these snippets.</value>
		public List<MediationSnippet> ImportedMediationSnippets{ get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileParameterImportResult"/> class using the specified imported parameters and mediation snippets.
		/// </summary>
		/// <param name="importedParameters">The imported parameters.</param>
		/// <param name="importedMediationSnippets">The imported mediation snippets.</param>
		public ProfileParameterImportResult(List<Parameter> importedParameters, List<MediationSnippet> importedMediationSnippets)
        {
        }
    }
}

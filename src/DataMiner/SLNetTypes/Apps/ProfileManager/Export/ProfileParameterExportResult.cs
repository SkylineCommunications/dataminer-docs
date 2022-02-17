using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net.MediationSnippets;
using Skyline.DataMiner.Net.ProfileManager.Import;

namespace Skyline.DataMiner.Net.ProfileManager.Export
{
    /// <summary>
    /// Returned when exporting <see cref="Skyline.DataMiner.Net.Profiles.Parameter"/> using the <c>ProfileParameterExporter</c>
    /// </summary>
    [Serializable]
    public class ProfileParameterExportResult
    {
		/// <summary>
		/// The file containing the exported <see cref="Skyline.DataMiner.Net.Profiles.Parameter"/> and <see cref="MediationSnippet"/>.
		/// </summary>
		/// <remarks>
		/// This can be passed to an instance of a ProfileParameterImporter to import the parameters.
		/// </remarks>
		public byte[] FileBytes { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProfileParameterExportResult"/> using the specified file bytes.
		/// </summary>
		/// <param name="fileBytes">The file bytes.</param>
		public ProfileParameterExportResult(byte[] fileBytes)
        {
        }

    }
}

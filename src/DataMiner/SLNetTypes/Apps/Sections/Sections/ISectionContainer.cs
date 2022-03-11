using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Represents a container for sections.
	/// </summary>
	public interface ISectionContainer
    {
		/// <summary>
		/// Retrieves the sections.
		/// </summary>
		/// <returns>The sections.</returns>
		IReadOnlyList<Section> GetSections();

		/// <summary>
		/// Sets the sections.
		/// </summary>
		/// <param name="sections">The sections.</param>
		void SetSections(IEnumerable<Section> sections);
    }
}

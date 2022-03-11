using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Sections
{
	/// <summary>
	/// Section validator interface.
	/// </summary>
	public interface ISectionValidator
    {
		/// <summary>
		/// Validates the specified section.
		/// </summary>
		/// <param name="section">The section to validate.</param>
		/// <returns><c>true</c> if the specified section validates against this validator; otherwise, <c>false</c>.</returns>
		bool Validate(Section section);
    }
}

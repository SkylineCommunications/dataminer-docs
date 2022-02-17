using Skyline.DataMiner.Net.Sections;
using System;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Represents a job suggestion.
	/// </summary>
	[Serializable]
    public class JobSuggestion
    {
		/// <summary>
		/// Gets or sets the matched field.
		/// </summary>
		/// <value>The matched field.</value>
		[Obsolete("Suggestions no longer include the field for the suggestion. This property is no longer filled in and does not have an alternative.")]
        public FieldDescriptorID MatchedField { get; set; }

		/// <summary>
		/// Gets or sets the matched value.
		/// </summary>
		/// <value>The matched value.</value>
		public string MatchedValue { get; set; }

		/// <summary>
		/// Gets or sets the score.
		/// </summary>
		/// <value>The score.</value>
		[Obsolete("Suggestions no longer include the score for the suggestion. This property is no longer filled in and does not have an alternative.")]
        public double Score { get; set; }
    }
}

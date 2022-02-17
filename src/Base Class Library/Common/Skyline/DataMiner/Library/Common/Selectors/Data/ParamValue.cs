namespace Skyline.DataMiner.Library.Common.Selectors.Data
{
	/// <summary>
	/// Represents a parameter value.
	/// </summary>
	public class ParamValue
	{
		private readonly Param param;
		private readonly object value;

		/// <summary>
		/// Initializes a new instance of the <see cref="ParamValue"/> class.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="elementId">The element ID.</param>
		/// <param name="parameterId">The parameter ID.</param>
		/// <param name="value">The parameter value.</param>
		public ParamValue(int agentId, int elementId, int parameterId, object value)
		{
			param = new Param(agentId, elementId, parameterId);
			this.value = value;
		}

		/// <summary>
		/// Gets the parameter.
		/// </summary>
		/// <value>The parameter.</value>
		public Param Param { get { return param; } }

		/// <summary>
		/// Gets the value of the parameter.
		/// </summary>
		/// <value>The parameter value.</value>
		public object Value { get { return value; } }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var data = obj as ParamValue;
			return data != null && data.ToString() == this.ToString();
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		/// <summary>
		/// A textual representation in the format: DmaId/ElementId/ParameterId/Value.
		/// </summary>
		/// <returns>The textual representation.</returns>
		public override string ToString()
		{
			return param.AgentId + "/" + param.ElementId + "/" + param.ParameterId + "/" + Value;
		}
	}
}
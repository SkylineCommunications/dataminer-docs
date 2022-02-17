namespace Skyline.DataMiner.Library.Common.Selectors
{
	/// <summary>
	/// Represents a parameter selection.
	/// </summary>
	public class Param : Element
	{
		private readonly int parameterId;

		/// <summary>
		/// Initializes a new instance of the <see cref="Param"/> class.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="elementId">The element ID.</param>
		/// <param name="parameterId">The parameter ID.</param>
		public Param(int agentId, int elementId, int parameterId) : base(agentId, elementId)
		{
			this.parameterId = parameterId;
		}

		/// <summary>
		/// Gets the parameter ID.
		/// </summary>
		/// <value>The parameter ID.</value>
		public int ParameterId { get { return parameterId; } }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var data = obj as Param;
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
		/// A textual representation of format: DmaId/ElementId/ParameterId.
		/// </summary>
		/// <returns>A textual representation of this object.</returns>
		public override string ToString()
		{
			return AgentId + "/" + ElementId + "/" + ParameterId;
		}
	}
}
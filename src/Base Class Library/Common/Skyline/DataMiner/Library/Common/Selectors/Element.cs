namespace Skyline.DataMiner.Library.Common.Selectors
{
	/// <summary>
	/// Represents an element selection.
	/// </summary>
	public class Element : Agent
	{
		private readonly int elementId;

		/// <summary>
		/// Initializes a new instance of the <see cref="Element"/> class.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="elementId">The element ID.</param>
		public Element(int agentId, int elementId) : base(agentId)
		{
			this.elementId = elementId;
		}

		/// <summary>
		/// Gets the element ID.
		/// </summary>
		/// <value>The element ID.</value>
		public int ElementId { get { return elementId; } }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var data = obj as Element;
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
		/// A textual representation of format: DmaId/ElementId.
		/// </summary>
		/// <returns>A textual representation of this object.</returns>
		public override string ToString()
		{
			return AgentId + "/" + ElementId;
		}
	}
}
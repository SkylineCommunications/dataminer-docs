namespace Skyline.DataMiner.Library.Common.Selectors
{
	using System.Globalization;

	/// <summary>
	/// Represents a DataMiner Agent selection.
	/// </summary>
	public class Agent
	{
		private readonly int agentId;

		/// <summary>
		/// Initializes a new instance of the <see cref="Agent"/> class.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		public Agent(int agentId)
		{
			this.agentId = agentId;
		}

		/// <summary>
		/// Gets the DataMiner Agent ID.
		/// </summary>
		/// <value>The DataMiner Agent ID.</value>
		public int AgentId { get { return agentId; } }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			var data = obj as Agent;
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
		/// A textual representation of format: DmaId.
		/// </summary>
		/// <returns>A textual representation of this object.</returns>
		public override string ToString()
		{
			return AgentId.ToString(CultureInfo.InvariantCulture);
		}
	}
}
namespace Skyline.DataMiner.Library.Common.Selectors
{
	/// <summary>
	/// Represents a service selection.
	/// </summary>
	public class Service : Agent
	{
		private readonly int serviceId;

		/// <summary>
		/// Initializes a new instance of the <see cref="Service"/> class.
		/// </summary>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="serviceId">The service ID.</param>
		public Service(int agentId, int serviceId) : base(agentId)
		{
			this.serviceId = serviceId;
		}

		/// <summary>
		/// Gets the service ID.
		/// </summary>
		/// <value>The service ID.</value>
		public int ServiceId
		{
			get
			{
				return serviceId;
			}
		}

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
		/// A textual representation of format: DmaId/ServiceId.
		/// </summary>
		/// <returns>A textual representation of this object.</returns>
		public override string ToString()
		{
			return AgentId + "/" + ServiceId;
		}
	}
}
using System;

namespace Skyline.DataMiner.Library.Common.InterAppCalls.Shared
{
	/// <summary>
	/// Represents the source of the inter-app call. This can include an element ID or just a string variable.
	/// </summary>
	public class Source
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="Source"/> class.
		/// </summary>
		public Source()
		{
			// Empty constructor necessary for Serialization.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Source"/> class using the specified name.
		/// </summary>
		/// <param name="name">A textual representation of the source.</param>
		/// <exception cref="ArgumentNullException">Name is <see langword="null"/> empty or white space.</exception>
		public Source(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
			Name = name;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Source"/> class using the specified name, DataMiner Agent ID and element ID.
		/// </summary>
		/// <param name="name">A textual representation of the source.</param>
		/// <param name="agentId">The DataMiner Agent ID.</param>
		/// <param name="elementId">The element ID.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name" /> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException"><paramref name="agentId"/> or <paramref name="elementId"/> is negative.</exception>
		public Source(string name, int agentId, int elementId)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
			if (agentId < 0) throw new ArgumentException("DataMiner Agent ID should not be negative.", "agentId");
			if (elementId < 0) throw new ArgumentException("Element Identifier should not be negative.", "elementId");

			Name = name;
			AgentId = agentId;
			ElementId = elementId;
		}

		/// <summary>
		/// Gets or sets the DataMiner Agent ID.
		/// </summary>
		/// <value>The DataMiner Agent ID.</value>
		public int AgentId { get; set; }

		/// <summary>
		/// Gets or sets the element ID.
		/// </summary>
		/// <value>The element ID.</value>
		public int ElementId { get; set; }

		/// <summary>
		/// Gets or sets the textual representation of the source.
		/// </summary>
		/// <value>The textual representation of the source.</value>
		public string Name { get; set; }
	}
}
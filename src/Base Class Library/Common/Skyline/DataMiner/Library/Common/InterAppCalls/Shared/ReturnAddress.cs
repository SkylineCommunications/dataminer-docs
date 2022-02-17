using System;

namespace Skyline.DataMiner.Library.Common.InterAppCalls.Shared
{
    /// <summary>
    /// Represents the location of a parameter that will hold the return message.
    /// </summary>
    public class ReturnAddress
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="ReturnAddress"/> class.
        /// </summary>
        public ReturnAddress()
        {
            // Empty constructor necessary for serialization.
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="ReturnAddress"/> class.
        /// </summary>
        /// <param name="agentId">The DataMiner Agent ID.</param>
        /// <param name="elementId">The element ID.</param>
        /// <param name="pid">The parameter ID.</param>
        /// <exception cref="ArgumentException">Agent, element and parameter IDs cannot be negative.</exception>
        public ReturnAddress(int agentId, int elementId, int pid)
        {
            if (agentId < 0) throw new ArgumentException("Agent Id cannot be a negative value.", "agentId");
            if (elementId < 0) throw new ArgumentException("Element Id cannot be a negative value.", "elementId");
            if (pid < 0) throw new ArgumentException("Parameter Id cannot be a negative value.", "pid");
            ParameterId = pid;
            AgentId = agentId;
            ElementId = elementId;
        }

        /// <summary>
        /// Gets or sets the DataMiner Agent ID.
        /// </summary>
        /// <value>The DataMiner Agent ID.</value>
        public int AgentId { get; private set; }

        /// <summary>
        /// Gets or sets the element ID.
        /// </summary>
        /// <value>The element ID.</value>
        public int ElementId { get; private set; }

        /// <summary>
        /// Gets or sets the parameter ID.
        /// </summary>
        /// <value>The parameter ID.</value>
        public int ParameterId { get; private set; }
    }
}
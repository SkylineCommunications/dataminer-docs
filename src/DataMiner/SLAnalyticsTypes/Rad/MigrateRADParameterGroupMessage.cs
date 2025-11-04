using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    [Serializable]
    public class MigrateRADParameterGroupMessage : Communication.GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// The name of the group to move.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// The ID of the new hosting Agent for the group.
        /// </summary>
        public int NewHostingAgentId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrateRADParameterGroupMessage"/> class.
        /// </summary>
        public MigrateRADParameterGroupMessage() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrateRADParameterGroupMessage"/> class.
        /// </summary>
        /// <param name="groupName">The name of the group to move to a new Agent.</param>
        /// <param name="newHostingAgentId">The ID of the new hosting Agent for the group.</param>
        public MigrateRADParameterGroupMessage(string groupName, int newHostingAgentId) { }

        /// <summary>
        /// Returns a string that represents the current message.
        /// </summary>
        public override string ToString()
        {
            return $"MigrateRADParameterGroupMessage: GroupName='{GroupName}', NewHostingAgentId={NewHostingAgentId}, SessionID={SessionID}";
        }


    }
}
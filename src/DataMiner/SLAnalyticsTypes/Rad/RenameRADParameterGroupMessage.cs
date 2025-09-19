using System;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Message to rename an existing Relational Anomaly Detection parameter group.
    /// Results in a <see cref="RenameRADParameterGroupResponseMessage"/>.
    /// </summary>
    [Serializable]
    public class RenameRADParameterGroupMessage : Communication.GetSessionedAnalyticsMessage
    {
        /// <summary>
        /// Gets or sets the old group name.
        /// </summary>
        public string OldGroupName { get; set; }
        /// <summary>
        /// Gets or sets the new group name.
        /// </summary>
        public string NewGroupName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenameRADParameterGroupMessage"/> class.
        /// </summary>
        public RenameRADParameterGroupMessage() : this(string.Empty, string.Empty) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenameRADParameterGroupMessage"/> class.
        /// </summary>
        /// <param name="oldGroupName">The old group name.</param>
        /// <param name="newGroupName">The new group name.</param>
        public RenameRADParameterGroupMessage(string oldGroupName, string newGroupName) { }
    }
}

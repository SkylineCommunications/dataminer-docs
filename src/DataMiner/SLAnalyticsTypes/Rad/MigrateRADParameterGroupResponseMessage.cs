using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Analytics.Rad
{
    /// <summary>
    /// Response message for <see cref="MigrateRADParameterGroupMessage"/>
    /// </summary>
    [Serializable]
    public class MigrateRADParameterGroupResponseMessage : ResponseMessage
    {
        public MigrateRADParameterGroupResponseMessage() { }

        /// <summary>
        /// Returns a string that represents the current message.
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(MigrateRADParameterGroupResponseMessage)}.";
        }
    }
}

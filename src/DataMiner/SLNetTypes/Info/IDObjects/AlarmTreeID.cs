using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using System;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Represents a reference to one specific alarm tree.
    /// </summary>
    [Serializable]
    public sealed class AlarmTreeID //: DMAObjectRef, IEquatable<AlarmTreeID>
    {
        // Default constructor is required for protobuf.
        public AlarmTreeID() { }

        /// <summary>
        /// Element on which the alarm tree lives or lived. 
        /// Guaranteed non-null.
        /// </summary>
        public ElementID ElementID { get; }

        /// <summary>
        /// Identifier for the alarm tree. Guaranteed to be unique within the element context.
        /// Always positive.
        /// </summary>
        public int RootAlarmID { get; }

        public AlarmTreeID(ElementID elementId, int rootAlarmId)
        {

        }

        public AlarmTreeID(AlarmEventMessage alarm)
        {
        }

        public AlarmTreeID(AlarmTreeID other)
        {
        }

        public AlarmTreeID(int dmaid, int eid, int rootAlarmId) : this(new ElementID(dmaid, eid), rootAlarmId) { }
    }
}

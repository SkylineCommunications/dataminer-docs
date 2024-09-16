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
        // default ctor is required for protobuf
        public AlarmTreeID() { }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Messages.SLDataGateway
{
    [Serializable]
	public class AlarmID //: DMAObjectRef, DataTypeID<Alarm>, IMaskable, IEquatable<AlarmID>, IComparable<AlarmID>, IComparable
    {
        /// <summary>
        /// The tree of this alarm event
        /// </summary>
        public AlarmTreeID TreeID { get; set; }

        /// <summary>
        /// The alarm ID of this event in the tree
        /// </summary>
        public int EventID { get; set; }

        /// <summary>
        /// Is this the root event in the tree
        /// </summary>
        public bool IsTreeRoot => TreeID.RootAlarmID == EventID;

        /// <summary>
        /// Builds an AlarmID reference for a given tree ID and event ID within that tree
        /// </summary>
        public AlarmID(AlarmTreeID tree, int eventId)
        {
            TreeID = tree;
            EventID = eventId;
        }

        /// <summary>
        /// Builds an AlarmID reference for a specific alarm event
        /// </summary>
        public AlarmID(AlarmEventMessage alarmEvent)
        {
        }

        [Obsolete("Use version which takes AlarmTreeID (still supported in <= 10.6)")]
        public AlarmID(int dataMinerId, long alarmId, long rootId)
        {
        }
    }
}

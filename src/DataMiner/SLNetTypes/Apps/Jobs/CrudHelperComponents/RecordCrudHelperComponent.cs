using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Records;
using System;

namespace Skyline.DataMiner.Net.Jobs
{
	/// <summary>
	/// Represents a record CRUD helper component.
	/// </summary>
	public class RecordCrudHelperComponent : CrudHelperComponent<Record>
    {
        internal RecordCrudHelperComponent(Func<DMSMessage[], DMSMessage[]> messageHandler) 
            //: base(messageHandler)
        {
        }
    }
}

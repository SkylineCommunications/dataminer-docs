using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

namespace Skyline.DataMiner.Net.Messages
{
	public class ManagerStorePagingResponse<T> : ManagerStoreCrudResponse<T>
		where T : DataType
	{
	}
}
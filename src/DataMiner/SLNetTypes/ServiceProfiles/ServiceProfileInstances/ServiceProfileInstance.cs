using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

namespace Skyline.DataMiner.Net.ServiceProfiles
{
	[Serializable]
	public class ServiceProfileInstance : CustomDataType
	{
		public bool FromMigration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public string DataTypeID => throw new NotImplementedException();

		public FilterElement<T> ToFilter<T>()
		{
			throw new NotImplementedException();
		}

		public object[] ToInterOp()
		{
			throw new NotImplementedException();
		}

		public string[] ToStringArray()
		{
			throw new NotImplementedException();
		}

		public DataType toType(string[] data)
		{
			throw new NotImplementedException();
		}
	}
}

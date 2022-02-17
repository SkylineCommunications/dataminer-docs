using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Messages
{
	public enum AutomationCheckType
	{
		LessThan,
		GreaterThan,
		Equal,
		NotEqual,
		LessThanOrEqual,
		GreaterThanOrEqual
	}

	public enum ParameterVirtualAttribute
	{
		SourceProtocol,
		SourceParameterDescription,
		DestinationProtocol,
		DestinationParameterDescription
	}
}

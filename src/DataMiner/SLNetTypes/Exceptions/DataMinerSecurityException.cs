using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Exceptions
{
	/// <summary>
	/// The exception that is thrown when the user that is attempting to authenticate does not have sufficient rights to access the DataMiner Agent.
	/// </summary>
	public class DataMinerSecurityException : DataMinerException
	{
	}
}

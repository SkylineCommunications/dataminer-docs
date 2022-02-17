using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyline.DataMiner.Net;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Scripting
{
	public interface ISLNetConnection
	{
		void TryOpenConnection();

		void OpenConnection();

		void CloseConnection();

		Connection RawConnection { get; }

		bool IsAlive { get; }

		DMSMessage[] SendMessage(DMSMessage message);

		DMSMessage[] SendMessages(params DMSMessage[] messages);

		DMSMessage SendSingleResponseMessage(DMSMessage message);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Skyline.DataMiner.Net.IManager.Messages;

namespace Skyline.DataMiner.Net.IManager.Helper
{
	public interface IManagerHelper<T> : ISerializable where T : IEquatable<T>
	{
		void OnEventReceived(IManagerEventMessage message);

		bool IsInitialized();
	}
}

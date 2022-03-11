using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Net.Ownership
{
	public sealed class SimpleByteWriter : IDisposable
	{

		public SimpleByteWriter()
		{
		}

		public byte[] ToByteArray()
		{
			return null;
		}

		public void WriteInt(int value)
		{
		}

		public void WriteByte(byte value)
		{
		}

		public void WriteGuid(Guid guid)
		{
		}

		public void Dispose()
		{
		}
	}

	public sealed class SimpleByteReader : IDisposable
	{
		public SimpleByteReader(byte[] byteArray)
		{
		}

		public int ReadInt()
		{
			return 0;
		}

		public byte ReadByte()
		{
			return default(byte);
		}
		public Guid ReadGuid()
		{
			return default(Guid);
		}

		public string ReadString()
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}

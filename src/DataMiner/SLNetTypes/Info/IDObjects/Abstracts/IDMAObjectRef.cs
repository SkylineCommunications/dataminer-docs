using Skyline.DataMiner.Net.Info.IDObjects.Abstracts;
using Skyline.DataMiner.Net.Ownership;

namespace Skyline.DataMiner.Net
{
	public interface IDMAObjectRef
	{
		void Write(SimpleByteWriter writer);

		bool Equals(object obj);

		int GetHashCode();

		string ToFileFriendlyString();

		string ToAttachmentString();

		string Parse(IDMAObjectRefToStringParser toStringParser);

		string ToString();
	}
}

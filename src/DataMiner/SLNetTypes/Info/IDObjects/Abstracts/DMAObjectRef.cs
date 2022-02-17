using Skyline.DataMiner.Net.APIDeployment.Url.Blocks;
using Skyline.DataMiner.Net.Info.IDObjects.Abstracts;
using Skyline.DataMiner.Net.Ownership;
using System;

namespace Skyline.DataMiner.Net
{
	[Serializable]
	public abstract class DMAObjectRef : IDMAObjectRef
	{

		public override abstract int GetHashCode();

		public override abstract bool Equals(object obj);

		public override abstract string ToString();

		public abstract string ToFileFriendlyString();

		public virtual string ToAttachmentString()
		{
			return ToFileFriendlyString();
		}

		public virtual void Write(SimpleByteWriter writer)
		{
			
		}

		public static IDMAObjectRef Build(SimpleByteReader reader)
		{
			return null;
		}

		public string Parse(IDMAObjectRefToStringParser toStringParser)
		{
			return null;
		}

		public void Accept(IDMAObjectRefVisitor visitor)
		{
		}

		public virtual SelectorBlock ToSelectorBlock()
		{
			throw new NotImplementedException();
		}
	}

}

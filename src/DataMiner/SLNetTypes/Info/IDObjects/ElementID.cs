using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Skyline.DataMiner.Net.APIDeployment.Url.Blocks;
using Skyline.DataMiner.Net.Ownership;

namespace Skyline.DataMiner.Net
{
	[Serializable]
	public class ElementID : DMAObjectRef, ICloneable, IEquatable<ElementID>, IComparable<ElementID>, IComparable, ISerializable//, IMaskable
	{
		protected const char ItemSeparator = '/';

		public int DataMinerID { get; set; }

		public int EID { get; set; }

		public ElementID()
			: base()
		{
			DataMinerID = EID = -1;
		}

		public ElementID(int DataMinerID, int EID)
		{
			this.DataMinerID = DataMinerID;
			this.EID = EID;
		}

		public static ElementID FromString(string strElementID)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;

			return Equals(obj as ElementID);
		}

		public override int GetHashCode()
		{
			return 1;
		}

		public override string ToString()
		{
			return GetKey();
		}

		public string GetKey()
		{
			return GetKey(DataMinerID, EID);
		}

		public static string GetKey(int dataminerId, int elementId)
		{
			return dataminerId.ToString() + ItemSeparator + elementId.ToString();
		}


		#region IEquatable
		public bool Equals(ElementID other)
		{
			if (other is null)
				return false;

			return ((DataMinerID == other.DataMinerID) && (EID == other.EID));
		}
		#endregion

		#region ICloneable
		public object Clone()
		{
			return MemberwiseClone();
		}
		#endregion

		#region IComparable
		public int CompareTo(ElementID other)
		{
			return 1;
		}

		public int CompareTo(object obj)
		{
			return CompareTo(obj as ElementID);
		}
		#endregion

		#region ISerializable
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}

		public ElementID(SerializationInfo info, StreamingContext context)
		{
		}
		#endregion

		#region IDMAObject Write&Build

		public override void Write(SimpleByteWriter writer)
		{
		}

		public new static IDMAObjectRef Build(SimpleByteReader reader)
		{
			return new ElementID(reader.ReadInt(), reader.ReadInt());
		}

		public override string ToFileFriendlyString()
		{
			return string.Format("ElementID_{0}_{1}", DataMinerID, EID);
		}
		#endregion

		public override SelectorBlock ToSelectorBlock()
		{
			return null;
		}
	}

	#region DerivedElementID
	[Serializable]
	public class DerivedElementID : ElementID
	{
		public DerivedElementID() : base()
		{
			DerivedDMAID = DerivedEID = -1;
		}

		public DerivedElementID(int DataMinerID, int EID, int derivedDMAID, int derivedEID) : base(DataMinerID, EID)
		{
			this.DerivedDMAID = derivedDMAID;
			this.DerivedEID = derivedEID;
		}

		public int DerivedDMAID { get; set; }

		public int DerivedEID { get; set; }
	}
	#endregion
}

namespace Skyline.DataMiner.Automation
{

	internal class DcfConnection
	{
		public int ConnectionId { get; }
		public int DestinationDmaId { get; }
		public int DestinationEId { get; }
		public int DestinationInterface { get; }
		public int DmaId { get; }
		public int EId { get; }
		public string Filter { get; }
		public bool IsInternal { get; }
		public string Name { get; }
		public int SourceInterface { get; }

		public virtual string GetPropertyValue(string propertyName) { return ""; }
		public virtual bool HasProperty(string propertyName) { return false; }
		public virtual void SetPropertyValue(string propertyName, string propertyValue) { }
	}
}
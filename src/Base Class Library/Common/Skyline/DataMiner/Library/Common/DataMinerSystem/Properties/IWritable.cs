using System.ComponentModel;

namespace Skyline.DataMiner.Library.Common.Properties
{
	/// <summary>
	/// DataMiner writable property interface.
	/// </summary>
	public interface IWritableProperty : INotifyPropertyChanged
	{
		/// <summary>
		/// Gets or sets the property value.
		/// </summary>
		string Value { get; set; }
	}
}
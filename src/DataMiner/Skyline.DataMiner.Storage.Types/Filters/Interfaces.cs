using System;

namespace Skyline.DataMiner.Net.Messages.SLDataGateway
{
	/// <summary>
	/// Field exposer interface.
	/// </summary>
	public interface FieldExposer : IEquatable<FieldExposer>
	{
		/// <summary>
		/// Gets or sets the field name.
		/// </summary>
		/// <value>The field name.</value>
		string fieldName { get; set; }

		/// <summary>
		/// Executes the exposer function.
		/// </summary>
		/// <param name="source">The object on which to execute the function to extract the field.</param>
		/// <returns>The resulting field.</returns>
		object execute(object source);
	}

	public interface DataType
	{
		bool FromMigration { get; set; }
		string DataTypeID { get; }

		FilterElement<T> ToFilter<T>();
		string[] ToStringArray();
		object[] ToInterOp();
		DataType toType(string[] data);
	}
}
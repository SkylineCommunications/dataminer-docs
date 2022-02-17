
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyline.DataMiner.Net.Messages.SLDataGateway
{
	/// <summary>
	/// Represents a custom data type.
	/// </summary>
	/// <remarks>
	/// <para>The supported data types for CustomDataType are:</para>
	/// <list type="bullet">
	/// <item><description>string</description></item>
	/// <item><description>int</description></item>
	/// <item><description>long</description></item>
	/// <item><description>double</description></item>
	/// <item><description>GUID</description></item>
	/// <item><description>DateTime</description></item>
	/// <item><description>boolean</description></item>
	/// <item><description>Any type implementing IDictionary</description></item>
	/// <item><description>Any type implementing ICollection</description></item>
	/// <item><description>Arrays</description></item>
	/// <item><description>Queues</description></item>
	/// </list>
	/// <note type="note">Important: the collections may only have type parameters string, int, long, double, GUID, boolean and DateTime.
	/// The collections must also have a default constructor.</note>
	/// </remarks>
	public interface CustomDataType : DataType { }
}

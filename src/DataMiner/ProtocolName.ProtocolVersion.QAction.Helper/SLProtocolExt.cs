using Skyline.DataMiner.Scripting;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Extension of the <see cref="SLProtocol"/> interface.
	/// </summary>
	/// <remarks>
	///		<para>The SLProtocolExt interface is an extension of the SLProtocol interface (hence the name "SLProtocolExt") and is automatically generated (along with the Parameter class, see <see cref="Parameter"/> class). This interface can be found in the [Protocol Name].[Protocol Version].QAction.Helper.dll DLL located in the folder C:\Skyline DataMiner\ProtocolScripts.</para>
	///		<para>For every standalone parameter of type "read" or "dummy", two properties are defined in the SLProtocolExt interface: one using the name of the parameter (Pascal cased and removing special characters) and one with an additional suffix consisting of an underscore and the parameter ID (e.g. "_108").</para>
	///		<para>For example, suppose a protocol defines a parameter of type “read" with ID 108 and name "Status Code", then the Parameter class will define the following two fields:</para>
	///		<code language="c#">
	///	public interface SLProtocolExt : SLProtocol
	///	{
	///	    object StatusCode { get; set; }
	///	    object StatusCode_108 { get; set; }
	///	}
	///	</code>
	///	<para>For write parameters, a property "Write” of type “WriteParameters" is defined in the ProtocolExt interface. The “WriteParameters" class then defines a property for each parameter of type "write". For example, suppose there is a parameter of type "write" with ID 158 and name "Status Code", then the WriteParameters class will define the following property for this write parameter:</para>
	///	<code language="c#">
	///	public interface SLProtocolExt : SLProtocol
	///	{
	///		...
	///		WriteParameters Write { get; set; }
	///	}
	///	public class WriteParameters
	///	{
	///		public System.Object StatusCode { get { return Protocol.GetParameter(158); } set { Protocol.SetParameter(158, value); } }
	///		...
	///	}
	///	</code>
	///	<para>The QAction_Helper.cs file also contains automatically generated subclasses of the QActionTable and QActionTableRow class for each table defined in the protocol. The ProtocolExt interface then defines a property for each table type.</para>
	///	<para>For example, suppose a protocol defines a table with name "Overview", then the ProtocolExt interface will contain the following property:</para>
	///	<code language="c#">
	///	public interface SLProtocolExt : SLProtocol
	/// {
	///		public OverviewQActionTable overview {get; set; };
	///
	///	}
	///	</code>
	///	<para>The ProtocolExt interface allows you to work with parameters and tables on a higher level, abstracting away from the low-level details. This allows you to produce more readable and maintainable code.</para>
	///	<code language="c#">
	///	protocol.RequestCounter = 1; // Sets the value of the read parameter with name “Request Counter”.
	///	OverviewQActionRow row = protocol.overview["Main"]; // Retrieve the row with primary key “Main” from the overview table.
	/// </code>
	/// <note type="note">SLProtocolExt is an interface from DataMiner 10.0.1 onwards (RN 23787). In earlier DataMiner versions, it is a concrete class.</note>
	/// </remarks>
	public interface SLProtocolExt : SLProtocol
	{
	}
}
using Skyline.DataMiner.Scripting;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Holds an overview of the protocol parameters.
	/// </summary>
	/// <remarks><list type="bullet">
	///		<item><description>The Parameter class is an auto-generated static class. It allows you to improve readability and maintainability of QAction code. This class can be found in the [Protocol Name].[Protocol Version].QAction.Helper.dll DLL located in the folder C:\Skyline DataMiner\ProtocolScripts.</description></item>
	///		<item><description>For every standalone read parameter, the class defines two public constant fields, one using the name of the parameter (lower cased and removing special characters) and one with an additional suffix consisting of an underscore and the parameter ID (e.g. "_108").</description></item>
	///		<item><description>For example, suppose a protocol defines a parameter of type "read" with ID 108 and name "Status Code", then the Parameter class will define the following two fields:</description></item>
	///		</list>
	///		<code language="c#">
	///	public static class Parameter
	///	{
	///		public const int statusCode_108 = 108;
	///		public const int statusCode = 108;
	/// }
	/// </code> 
	/// <para>For write parameters, a public inner Write class is defined in the Parameter class. This class then defines two fields for each parameter of type "write", just like for parameters of type read. Suppose there is a parameter of type "write" with ID 158 and name "Status Code", then the Write class will define the following two fields for the write parameter:</para>
	/// <code language="c#">
	/// public static class Parameter
	/// {
	///		...
	///		public class Write
	///		{
	///			public const int statusCode_158 = 158;
	///			public const int statusCode = 158;
	///			...
	///		}
	///	}
	/// </code>
	/// <para>Additionally, the Parameter class defines a class for every table defined in the protocol. The table class takes the name of the table parameter (parameter of type array) and defines three constant fields:</para>
	/// <list type="bullet">
	///		<item><description><para>tablePid: The parameter ID of the table parameter.</para></description></item>
	///		<item><description><para>indexColumn: The index of the column that holds the primary keys.</para></description></item>
	///		<item><description><para>indexColumnPid: The ID of the column parameter that holds the primary keys.</para></description></item>
	/// </list>
	/// <para>The table class also defines two inner classes named “Pid” and “Idx” which hold the parameter IDs and indexes of the columns defined in the table respectively. The Pid class additionally defines an inner class “Write”, defining the IDs of the write parameters (if any).</para>
	/// <para>For example, consider a parameter of type “array” with name “Master Table” and ID 2000. The table has two columns: a column named “Master Index” (ID 2001) and a column named “Master Description” (ID 2002). Then the Parameter class will define a class MasterTable as follows:</para>
	/// <code language="c#">
	/// public static class Parameter
	/// {
	///		public class MasterTable
	///		{
	///			public const int tablePid = 2000;
	///			public const int indexColumn = 0;
	///			public const int indexColumnPid = 2001;
	///
	///			public class Pid
	///			{
	///				public const int masterIndex_2001 = 2001;
	///				public const int masterIndex = 2001;
	///				public const int masterDescription_2002 = 2002;
	///				public const int masterDescription = 2002;
	///				public class Write
	///				{
	///				}
	///			}
	///
	///			public class Idx
	///			{
	///				public const int masterIndex_2001 = 0;
	///				public const int masterIndex = 0;
	///				public const int masterDescription_2002 = 1;
	///				public const int masterDescription = 1;
	///			}
	///		}
	///	}
	/// </code>
	/// <para>The parameter class allows to produce more readable code. For example, parameter ID or index positions often need to be provided in a method call of the SLProtocol class as in the examples below:</para>
	/// <code language="c#">
	/// protocol.SetParameter(Parameter.requestCounter, 1);
	/// protocol.SetParameterIndexByKey(Parameter.MasterTable.tablePid, "1", Parameter.MasterTable.Idx.masterDescription + 1, "Main");
	/// </code>
	/// <para>It is clear that the above lines of code result in code that is easer to interpret than the following lines:</para>
	/// <code language="c#">
	/// protocol.SetParameter(120, 1);
	/// protocol.SetParameterIndexByKey(4000, "1", 6, "Main");
	/// </code>
	/// </remarks>
	public static class Parameter
	{
		/// <summary>
		/// Holds an overview of the protocol write parameters.
		/// </summary>
		/// <remarks>
		/// <para>This class defines for each parameter of type “write” two fields, just like for parameters of type read in the <see cref="Parameter"/> class. Suppose there is a parameter of type “write” with ID 158 and name “Status Code”, then the Write class will define the following two fields for the write parameter:</para>
		///	<code language="c#">
		///	public class Write
		/// {
		///		public const int statusCode_158 = 158;
		///		public const int statusCode = 158;
		/// }
		/// </code> 
		/// </remarks>
		public class Write
		{
			
		}
	}
}
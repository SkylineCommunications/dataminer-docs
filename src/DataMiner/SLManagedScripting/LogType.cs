using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Defines the logging type.
	/// </summary>
	/// <remarks>
	/// <para>This enum is used as argument in the <see cref="SLProtocol.Log(string, LogType)"/> and <see cref="SLProtocol.Log(string, LogType, LogLevel)"/> methods.</para>
	/// <para>Prior to DataMiner 10.1.1 (RN 27995), this type was defined in the QActionHelperBaseClasses assembly.</para>
	/// </remarks>
	public enum LogType
	{
		/// <summary>
		/// Informational message.
		/// </summary>
		Information = 1,
		/// <summary>
		/// Error.
		/// </summary>
		Error = 2,
		/// <summary>
		/// Debugging information.
		/// </summary>
		DebugInfo = 4,
		/// <summary>
		/// Always.
		/// </summary>
		Allways = 8
	}
}

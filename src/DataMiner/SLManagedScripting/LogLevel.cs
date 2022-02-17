using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Defines the logging level.
	/// </summary>
	/// <remarks>
	/// <para>This enum is used as argument in the <see cref="SLProtocol.Log(string, LogLevel)"/> and <see cref="SLProtocol.Log(string, LogType, LogLevel)"/> methods.</para>
	/// <para>Prior to DataMiner 10.1.1 (RN 27995), this type was defined in the QActionHelperBaseClasses assembly.</para>
	/// </remarks>
	public enum LogLevel
	{
		/// <summary>
		/// Development logging.
		/// </summary>
		DevelopmentLogging = -1,
		/// <summary>
		/// No logging.
		/// </summary>
		NoLogging = 0,
		/// <summary>
		/// Level 1 logging.
		/// </summary>
		Level1 = 1,
		/// <summary>
		/// Level 2 logging.
		/// </summary>
		Level2 = 2,
		/// <summary>
		/// Level 3 logging.
		/// </summary>
		Level3 = 3,
		/// <summary>
		/// Level 4 logging.
		/// </summary>
		Level4 = 4,
		/// <summary>
		/// Log everything.
		/// </summary>
		LogEverything = 5
	}
}

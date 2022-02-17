using System;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// The alarm level of an element, parameter or alarm.
	/// </summary>
	public enum AlarmLevel
	{
		Undefined = 0,
		Normal = 1,
		Warning = 2,
		Minor = 3,
		Major = 4,
		Critical = 5,
		Information = 6,
		Timeout = 7,
		Initial = 8,
		Masked = 9,
		Error = 10,
		Notice = 11,
		Suggestion = 12
	}
}
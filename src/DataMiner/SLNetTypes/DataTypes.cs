using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
#if NETFRAMEWORK
using System.ComponentModel;
using System.Drawing.Design;
#endif

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// String array wrapper class.
	/// </summary>
	public class SA
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SA"/> class.
		/// </summary>
		public SA() : this(null) {}

		/// <summary>
		/// Returns <see cref="Sa"/> or an empty array if <see cref="Sa"/> is <see langword="null" />.
		/// </summary>
		/// <returns><see cref="Sa"/> or an empty array if <see cref="Sa"/> is <see langword="null" /></returns>
		public static String[] ToArray(Array info)
		{
			return null;
		}

		/// <summary>
		/// Converts the array to an array that can be marshaled for
		/// COM interop
		/// </summary>
		/// <returns></returns>
		public static object[] ToInteropArray(SA sa)
		{
			return null;
		}

		/// <summary>
		/// Converts the specified array to an array that can be marshaled for COM Interop.
		/// </summary>
		/// <param name="sa">The <see cref="SA"/> instance to convert.</param>
		/// <returns>The array that can be marshaled for COM Interop.</returns>
		public static object[] ToInteropArray(string[] sa)
        {
			return null;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SA"/> class using the specified string array.
		/// </summary>
		/// <param name="sa">The string array to wrap.</param>
		/// <remarks>If <paramref name="sa"/> is <see langword="null"/>, <see cref="Sa"/> is set to an empty array.</remarks>
		public SA(String[] sa)
		{
		}

		/// <summary>
		/// The wrapped string array.
		/// </summary>
		public String [] Sa;

		/// <summary>
		/// Converts this object to a string array.
		/// </summary>
		/// <returns>The resulting string array.</returns>
		public String[] ToArray()
		{
			return null;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return null;
		}

		/// <summary>
		/// Searches for the specified string and returns the index of its first occurrence in the string array.
		/// </summary>
		/// <param name="needle">The string to locate in the string array.</param>
		/// <returns>The zero-based index of the first occurrence of <paramref name="needle"/>, if found; otherwise, -1.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="needle"/> is <see langword="null"/>.</exception>
		public int IndexOf(string needle)
        {
			return 0;
		}

		/// <summary>
		/// Searches for the specified string and returns the index of its first occurrence in the string array.
		/// </summary>
		/// <param name="needle">The string to locate in the string array.</param>
		/// <param name="comparisonType">One of the enumeration values that specifies the rules for the comparison.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, -1.</returns>
		/// <remarks>If <paramref name="needle"/> is <see langword="null"/>, -1 is returned.</remarks>
		public int IndexOf(string needle, StringComparison comparisonType) // [DCP44724]
        {
			return 0;
		}
	}

	[Serializable]
//#if NETFRAMEWORK
//    [Editor(typeof(PSAEditor), typeof(UITypeEditor))]
//#endif
	public class PSA
	{
		public PSA() : this (null) {}

		/// <summary>
		/// Converts the PSA to a jagged array of String
		/// </summary>
		/// <returns></returns>
		public static String[][] ToArray(Array info)
		{
			return null;
		}	
	
		public PSA(Array info)
		{
		}

		public SA [] Psa;

		/// <summary>
		/// Converts the PSA to a jagged array of String
		/// </summary>
		/// <returns></returns>
		public String[][] ToArray()
		{
			return null;
		}

		/// <summary>
		/// Converts the array to an array that can be marshaled for
		/// COM interop
		/// </summary>
		/// <returns></returns>
		public static object[] ToInteropArray(PSA psa)
		{
			return null;
		}

        public static object[] ToInteropArray(string[][] psa)
        {
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}

	[Serializable]
	public class PPSA
	{
		public PPSA() : this(null) {}

		public static String[][][] ToArray(Array info)
		{
			return null;
		}

		public PPSA(Array info)
		{
		}

		public String[][][] ToArray()
		{
			return null;
		}

		public static object[] ToInteropArray(PPSA ppsa)
		{
			return null;
		}

        public static object[] ToInteropArray(string[][][] ppsa)
        {
			return null;
		}

		public PSA[] Ppsa;
	
	}

    [Serializable]
    public class PPPSA
    {
        public PPPSA() : this(null) { }

        public PPPSA(Array info)
        {
		}

        public static object[] ToInteropArray(PPPSA pppsa)
        {
			return null;
		}

        public static object[] ToInteropArray(string[][][][] pppsa)
        {
			return null;
		}

        public PPSA[] Pppsa;
    }

    [Serializable]
    public class PPPPSA
    {
        public PPPPSA() : this(null) { }

        public PPPPSA(Array info)
        {
        }

        public static object[] ToInteropArray(PPPPSA ppppsa)
        {
			return null;
		}

		public static object[] ToInteropArray(string[][][][][] ppppsa)
        {
			return null;
		}

        public PPPSA[] Ppppsa;
    }
	
	[Serializable]
//#if NETFRAMEWORK
//    [Editor(typeof(UIAEditor), typeof(UITypeEditor))]
//#endif
	public class UIA
	{
		public UIA() : this(new UInt32[0]) {}
		public UIA(UInt32[] uia)
		{
		}

		public UIA(Int32[] ia)
		{
		}

		public uint [] Uia;

		public UInt32[] ToArray()
		{
			return null;
		}

		public static UInt32[] ToInteropArray(UIA uia)
		{
			return null;
		}
	}

	[Serializable]
//#if NETFRAMEWORK
//    [Editor(typeof(PUIAEditor), typeof(UITypeEditor))]
//#endif
	public class PUIA
	{
		public PUIA() 
		{
			
		}
		public UIA[] Puia;

		public UInt32[][] ToArray()
		{
			return null;
		}

		public static object[] ToInteropArray(PUIA puia)
		{
			return null;
		}
	}

	[Serializable]
    [XmlRoot("Position")]
	public class AutomationMemoryInfoPosition : ICloneable
	{
        [XmlText]
        public int Position;

        [XmlAttribute("savefrom")]
        public string SaveFrom;

        [XmlAttribute("loadto")]
        public string LoadTo;

        public AutomationMemoryInfoPosition() { }

        public object Clone()
        {
			return null;
		}
	}

    [Serializable]
    [Flags]
    public enum AutomationScriptOptions
    {
		/// <summary>
		/// None.
		/// </summary>
        None = 0x0000,

        /// <summary>
        /// Lock elements used by script.
        /// </summary>
        Lock = 0x0001,

        /// <summary>
        /// When a lock is held by another user/process, take it away by force (in combination with AUTOMATION_LOCK)
        /// </summary>
        ForceLock = 0x0002,

        /// <summary>
        /// Instead of waiting when an element is in use by another script or locked, fail immediately.
        /// </summary>
        NoWait = 0x0004
    }

	[Serializable]
	public class AutomationCheck : ICloneable
	{
		public AutomationCheck() {}
		public AutomationCheckType Type;
		public int Ref;
		public String Value;

        public object Clone()
        {
			return null;
		}
	}

    /// <summary>
	/// This represents a parameter set action
	/// </summary>
	[Serializable]
	public class Parameter
	{
		public Parameter() {}
		public Parameter(uint dataMinerId, uint elementId, uint parameterId)
			: this(dataMinerId, elementId, parameterId, null)
		{
		}
		public Parameter(uint dataMinerId, uint elementId, uint parameterId, string idx)
		{
		}

		public uint DataMinerId;
		public uint ElementId;
		public uint ParameterId;
		public string RowIdx;

        public SetParameterTableIndexPreference TableIndexPreference { get; set; }

		public ParameterValue Value;

		public override string ToString()
		{
			return null;
		}
	}
}
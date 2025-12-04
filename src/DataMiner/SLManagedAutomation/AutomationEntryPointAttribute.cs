using System;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Indicates that a method can be used as an Automation script entry point.
	/// </summary>
	/// <remarks>
	/// <para>The entry points must be public, and may be static or non-static.</para>
	/// <para>The method names and parameter names can be chosen at will.</para>
	/// <para>Restrictions: </para>
	/// <list type="bullet">
	/// <item>
	/// <description>An Automation script using custom entry points can have only one executable action, which must be a C# code block.</description>
	/// </item>
	/// <item>
	/// <description>If, in a C# code block, you have defined multiple entry points, you must make sure they are of different types. Multiple entry points of the same type are not allowed.</description>
	/// </item>
	/// <item>
	/// <description>For reasons of backward compatibility, it is recommended to use the Script class as the entry point class for a script. Although this is no longer strictly required, it is good practice to add a Script class to a C# code block, even if it is empty.</description>
	/// </item>
	/// </list>
	/// </remarks>
	/// <example>
	/// <para>Defining a custom entry point:</para>
	/// <code>
	/// [AutomationEntryPoint(AutomationEntryPointType.Types.Default)]
	/// public void Default(Engine engine)
	/// {
	///	 engine.GenerateInformation(""Default"");
	/// }
	/// </code>
	/// <para>For testing purposes, you can use <see cref="AutomationEntryPointType.Types.AutomationEntryPointTest"/>:</para>
	/// <code>
	/// [AutomationEntryPoint(AutomationEntryPointType.Types.AutomationEntryPointTest)]
	/// public void AutomationEntryPointTest(Engine engine, string testMessage, List&lt;int&gt; testIntList)
	/// {
	/// 	engine.GenerateInformation(""AutomationEntryPointTest: "" + testMessage + "" "" + string.Join("", "", testIntList.ToArray()));
	/// }
	/// </code>
	/// </example>
	[AttributeUsage(AttributeTargets.Method)]
	public class AutomationEntryPointAttribute : Attribute
	{
		private AutomationEntryPointType _type;

		/// <summary>
		/// Gets the Automation entry point type.
		/// </summary>
		/// <value>The Automation entry point type.</value>
		public AutomationEntryPointType Type
		{
			get
			{
				return this._type;
			}
			private set
			{
				this._type = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AutomationEntryPointAttribute"/> class.
		/// </summary>
		/// <param name="type">The Automation entry point type.</param>
		public AutomationEntryPointAttribute(AutomationEntryPointType.Types type)
		{
			this.Type = AutomationEntryPointType.GetEntryPointTypeByID(type);
		}
	}
}
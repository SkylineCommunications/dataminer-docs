namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a script parameter.
	/// </summary>
	/// <remarks>
	/// Script parameters are supplied by DataMiner through <see cref="IEngine.GetScriptParam(string)"/> or
	/// <see cref="IEngine.GetScriptParam(int)"/>. Their values are strings. Do not construct a
	/// <see cref="ScriptParam"/> in script code to represent input.
	/// </remarks>
	public class ScriptParam
	{
		/// <summary>
		/// Gets the ID of the script parameter.
		/// </summary>
		/// <value>The ID of the script parameter.</value>
		public int Id { get; }

		/// <summary>
		/// Gets the name of the script parameter.
		/// </summary>
		/// <value>The name of the script parameter.</value>
		public string Name { get; }

		/// <summary>
		/// Gets the value of the script parameter.
		/// </summary>
		/// <value>The value of the script parameter.</value>
		/// <remarks>The value is supplied as a string from the script input.</remarks>
		/// <example>
		/// <code>
		/// // Retrieving the value by using the parameter ID.
		/// ScriptParam paramUser = engine.GetScriptParam(65000);
		/// string userDescription = paramUser.Value;
		/// </code>
		/// </example>
		public string Value { get; }

		/// <summary>
		/// Sets the specified value to this script parameter.
		/// </summary>
		/// <param name="val">The value to set.</param>
		/// <example>
		/// <code>
		/// ScriptParam myScriptParam = engine.GetScriptParam("param1");
		/// myScriptParam.SetParamValue("myValue");
		/// </code>
		/// </example>
		public void SetParamValue(string val) { }

		///// <summary>
		///// Sets the specified value to this script parameter.
		///// </summary>
		///// <param name="val">The value to set.</param>
		//public void SetScriptParam(string val)
		//{
		//	this.SetParamValue(val);
		//}
	}
}
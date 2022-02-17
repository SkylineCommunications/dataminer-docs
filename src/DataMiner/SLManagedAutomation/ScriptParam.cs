namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents a script parameter.
	/// </summary>
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
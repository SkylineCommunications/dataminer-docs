namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Specifies the layout used to render the dialog box for an interactive automation script in DataMiner web apps.
	/// </summary>
	/// <remarks>
	/// <para>See <see href="xref:Building_interactive_Automation_scripts_with_CSharp#using-the-grid-layout-in-web-apps-to-control-the-tab-behavior">Using the grid layout in web apps</see> for more information.</para>
	/// <para>Feature introduced in DataMiner 10.6.12/10.7.0 (RN 46602 / RN 46716).</para>
	/// </remarks>
	public enum WebUILayout
	{
		/// <summary>
		/// The default layout, which currently behaves like <see cref="Table"/>. (Default option)
		/// </summary>
		Default = 0,

		/// <summary>
		/// The table layout. Components are arranged in a table, and TAB navigation moves from left to right across each row before moving to the next row.
		/// </summary>
		Table = 1,

		/// <summary>
		/// Components are positioned in the rows and columns defined in the script, while TAB navigation follows the order in which the blocks are appended to the <see cref="UIBuilder"/>.
		/// </summary>
		Grid = 2,
	}
}

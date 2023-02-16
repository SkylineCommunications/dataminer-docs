using System;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents the builder of a dialog box of an interactive automation script.
	/// </summary>
	/// <remarks>
	/// <note type="note">
	/// If you want to use IntelliSense in DataMiner Cube, the name of the dialog box has to start with “uib”.
	/// </note>
	/// <note type="note">
	/// Interactive Automation scripts resize their width and height depending on which properties of the script are filled in (UIBuilder.Height, .Width, .MinHeight, .MinWidth). If nothing is defined in the script, a default width and height of 650px by 650px will be applied.
	/// </note>
	/// </remarks>
	public class UIBuilder
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UIBuilder"/> class.
		/// </summary>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox1 = new UIBuilder();
		/// uibDialogBox1.ColumnDefs = "100;100;100";
		/// uibDialogBox1.RowDefs = "100;100;100";
		/// uibDialogBox1.Height = 300;
		/// uibDialogBox1.Width = 300;
		/// // uibDialogBox1.MinHeight = 100;
		/// // uibDialogBox1.MinWidth = 100;
		/// // uibDialogBox1.MaxHeight = 500;
		/// // uibDialogBox1.MaxWidth = 500;
		/// uibDialogBox1.RequireResponse = true;
		/// ...
		/// </code>
		/// </example>
		public UIBuilder() { }

		/// <summary>
		/// Gets or sets the width (in pixels) of all columns of the dialog box grid, separated by semicolons.
		/// </summary>
		/// <value>The width (in pixels) of all columns of the dialog box grid, separated by semicolons.</value>
		/// <remarks>
		/// <para>Instead of a pixel value, you can also specify the following values:</para>
		/// <list type="bullet">
		/// <item><description>"auto" or "a": The width of the column will be automatically adapted to the widest dialog box item in that column.</description></item>
		/// <item><description>*: The column will have the largest possible width, depending on the width of the other columns.</description></item>
		/// </list>
		/// <note type="note">If automatic ColumnDefs are specified, e.g. "a;a;a;a", and you want to show a UIBlockDefinition with a columnspan, then the space for each column will be equal, so other blocks will also move. To avoid this, you can change the ColumnDefs to "a;a;a;a;*". The extra '*' column will use all extra available space. Then change the columnspan so the block uses that new '*' column.</note>
		/// <para>Example:</para>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// uib.ColumnDefs = "a;a;a;a;*"; // 4 columns + extra space column.
		/// UIBlockDefinition uibd = new UIBlockDefinition();
		/// uibd.Column = 0; // On column 0 (0-based).
		/// uibd.ColumnSpan = 5; // if column pos=1, columnspan = 4
		/// </code>
		/// </example>
		/// </remarks>
		public string ColumnDefs { get; set; }

		/// <summary>
		/// Gets or sets the fixed height (in pixels) of the dialog box.
		/// </summary>
		/// <value>The fixed height (in pixels) of the dialog box.</value>
		/// <remarks>
		/// <note type="note">Interactive Automation scripts resize their width and height depending on which properties of the script are filled in (UIBuilder.Height, .Width, .MinHeight, .MinWidth). If nothing is defined in the script, a default width and height of 650px by 650px will be applied.</note>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// uib.Height = 200;
		/// </code>
		/// </example>
		public int Height { get; set; }

		/// <summary>
		/// Gets or sets the maximum height (in pixels) of the dialog box.
		/// </summary>
		/// <value>The minimum height (in pixels) of the dialog box.</value>
		/// <remarks>
		/// <note type="note">Interactive Automation scripts resize their width and height depending on which properties of the script are filled in (UIBuilder.Height, .Width, .MinHeight, .MinWidth). If nothing is defined in the script, a default width and height of 650px by 650px will be applied.</note>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// uib.MaxHeight = 400;
		/// </code>
		/// </example>
		public int MaxHeight { get; set; }

		/// <summary>
		/// Gets or sets the maximum width (in pixels) of the dialog box.
		/// </summary>
		/// <value>The maximum width (in pixels) of the dialog box.</value>
		/// <remarks>
		/// <note type="note" >Interactive Automation scripts resize their width and height depending on which properties of the script are filled in (UIBuilder.Height, .Width, .MinHeight, .MinWidth). If nothing is defined in the script, a default width and height of 650px by 650px will be applied.</note>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// uib.MaxWidth = 500;
		/// </code>
		/// </example>
		public int MaxWidth { get; set; }

		/// <summary>
		/// Gets or sets the minimum height (in pixels) of the dialog box.
		/// </summary>
		/// <value>The minimum height (in pixels) of the dialog box.</value>
		/// <remarks>
		/// <note type="note">Interactive Automation scripts resize their width and height depending on which properties of the script are filled in (UIBuilder.Height, .Width, .MinHeight, .MinWidth). If nothing is defined in the script, a default width and height of 650px by 650px will be applied.</note>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// uib.MinHeight = 200;
		/// </code>
		/// </example>
		public int MinHeight { get; set; }

		/// <summary>
		/// Gets or sets the minimum width (in pixels) of the dialog box.
		/// </summary>
		/// <value>The minimum width (in pixels) of the dialog box.</value>
		/// <remarks>
		/// <note type="note">Interactive Automation scripts resize their width and height depending on which properties of the script are filled in (UIBuilder.Height, .Width, .MinHeight, .MinWidth). If nothing is defined in the script, a default width and height of 650px by 650px will be applied.</note>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// uib.MinWidth = 500;
		/// </code>
		/// </example>
		public int MinWidth { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the dialog box expects some action from the user (e.g. clicking a button, selecting a checkbox, selecting an entry in a selection box, etc.).
		/// </summary>
		/// <value><c>true</c> if the dialog box expects some action from the user; otherwise, <c>false</c>.</value>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// // ...
		/// uib.RequireResponse = true;
		/// </code>
		/// </example>
		public bool RequireResponse { get; set; }

		/// <summary>
		/// Gets or sets the height (in pixels) of all rows of the dialog box grid, separated by semicolons.
		/// </summary>
		/// <value>The height (in pixels) of all rows of the dialog box grid, separated by semicolons.</value>
		/// <remarks>
		/// <para>Instead of a pixel value, you can also specify the following values:</para>
		/// <list type="bullet">
		/// <item><description>auto: The height of the row will be automatically adapted to the highest dialog box item in that row.</description></item>
		/// <item><description>*: The row will have the largest possible height, depending on the height of the other rows.</description></item>
		/// </list>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox1 = new UIBuilder();
		/// uibDialogBox1.ColumnDefs = "100;100;100";
		/// uibDialogBox1.RowDefs = "100;100;100";
		/// uibDialogBox1.Height = 300;
		/// uibDialogBox1.Width = 300;
		/// // uibDialogBox1.MinHeight = 100;
		/// // uibDialogBox1.MinWidth = 100;
		/// // uibDialogBox1.MaxHeight = 500;
		/// // uibDialogBox1.MaxWidth = 500;
		/// 
		/// uibDialogBox1.RequireResponse = true;
		/// </code>
		/// </example>
		public string RowDefs { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title</value>
		/// <remarks>
		/// <para>In case no title is specified, the name of the Automation script is used as title.</para>
		/// <para>Feature introduced in DataMiner 9.6.6 (RN 21552).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// uibDialogBox.Title = “My dialog box title”;
		/// </code>
		/// </example>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the fixed width (in pixels) of the dialog box.
		/// </summary>
		/// <value>The fixed width (in pixels) of the dialog box.</value>
		/// <remarks>
		/// <para>Note: Interactive Automation scripts resize their width and height depending on which properties of the script are filled in (UIBuilder.Height, .Width, .MinHeight, .MinWidth). If nothing is defined in the script, a default width and height of 650px by 650px will be applied.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// uib.Width = 500;
		/// </code>
		/// </example>
		public int Width { get; set; }

		/// <summary>
		/// Adds the specified text to this dialog box.
		/// </summary>
		/// <param name="text"></param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.Append("Select a ticket:");
		/// </code>
		/// </example>
		public UIBuilder Append(string text) { return null; }

		/// <summary>
		/// Adds the specified composite format string to this dialog box.
		/// </summary>
		/// <param name="text">A composite format string that should be appended.</param>
		/// <param name="args">An object array that contains zero or more objects to format in the appended text.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <remarks>This is a convenience method that calls String.Format(System.String, System.Object[]).</remarks>
		/// <exception cref="ArgumentNullException"><c>format</c> or <c>args</c> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><c>format</c> is invalid.<br />
		/// -or-<br />
		/// The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.
		/// </exception>
		/// <example>
		/// <code>
		/// int selectedTicketId = 1;
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.Append("The ID of the selected ticket is {0}", selectedTicketId);
		/// </code>
		/// </example>
		public UIBuilder Append(string text, params object[] args) { return null; }

		/// <summary>
		/// Adds the specified <see cref="UIBlockDefinition"/> instance to this dialog box.
		/// </summary>
		/// <param name="block">The <see cref="UIBlockDefinition"/> instance to add.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// UIBlockDefinition blockTextBox = new UIBlockDefinition();
		/// // ...
		/// uibDialogBox.AppendBlock(blockTextBox);
		/// </code>
		/// </example>
		public UIBuilder AppendBlock(UIBlockDefinition block) { return null; }

		/// <summary>
		/// Adds a button to this dialog box with the specified destination variable name and button text.
		/// </summary>
		/// <param name="destVar">The name of the destination variable.</param>
		/// <param name="displayText">The button text.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <remarks>
		/// <para>When the button is pressed, the destination variable is filled with its own name.</para>
		/// <para>This is a convenience method that will create a new instance of <see cref="UIBlockDefinition"/> of type Button and sets <see cref="RequireResponse"/> to <c>true</c>.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendButton("applyButtonDestVar", "Apply");
		/// // ...
		/// var uir = engine.ShowUI(uibDialogBox);
		/// string value = uir.GetString("applyButtonDestVar"); // If the button was pressed, the value will be "applyButtonDestVar"; otherwise, null.
		/// </code>
		/// </example>
		public UIBuilder AppendButton(string destVar, string displayText) { return null; }


		/// <summary>
		/// <para>Adds a button to this dialog box with the specified destination variable name, button text, and style.<br/>
		/// The supported button styles can be accessed through const strings on the Style.Button class.</para>
		/// <para>This is supported from DataMiner 10.3.1/10.4.0 onwards.</para>
		/// </summary>
		/// <param name="destVar">The name of the destination variable.</param>
		/// <param name="displayText">The button text.</param>
		/// <param name="style">The button style (see Style.Button for supported styles).</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <remarks>
		/// <para>When the button is pressed, the destination variable is filled in with its own name.</para>
		/// <para>This is a convenience method that will create a new instance of <see cref="UIBlockDefinition"/> of type Button and set <see cref="RequireResponse"/> to <c>true</c>.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendButton("applyButtonDestVar", "Apply", Style.Button.CallToAction);
		/// // ...
		/// var uir = engine.ShowUI(uibDialogBox);
		/// string value = uir.GetString("applyButtonDestVar"); // If the button was pressed, the value will be "applyButtonDestVar"; otherwise, null.
		/// </code>
		/// </example>
		public UIBuilder AppendButton(string destVar, string displayText, string style) { return null; }

		/// <summary>
		/// Adds a drop-down box to this dialog box.
		/// </summary>
		/// <param name="destVar">The name of the destination variable.</param>
		/// <param name="options">The items in the drop-down list. The format of a drop-down entry must be as follows: value|displayValue</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <remarks>
		/// <para>This is a convenience method that will create a new instance of <see cref="UIBlockDefinition"/> of type DropDown and sets <see cref="RequireResponse"/> to <c>true</c>.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// 
		/// uibDialogBox.AppendDropDown("selectionVar", "1|Automatic", "2|Semi-automatic", "3|Manual");
		/// 
		/// var uir = engine.ShowUI(uibDialogBox);
		/// string result = uir.GetString("selectionVar");
		/// engine.GenerateInformation("selectionVar: " + result);	// In case "Semi-automatic" was selected, selectionVar will contain "2".
		/// </code>
		/// </example>
		public UIBuilder AppendDropDown(string destVar, params string[] options) { return null; }

		/// <summary>
		/// Adds a new line to this dialog box.
		/// </summary>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendLine();
		/// // ...
		/// </code>
		/// </example>
		public UIBuilder AppendLine() { return null; }

		/// <summary>
		/// Adds the specified line of text to this dialog box.
		/// </summary>
		/// <param name="text">The line of text to add to this dialog box.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendLine("Select a ticket:");
		/// </code>
		/// </example>
		public UIBuilder AppendLine(string text) { return null; }

		/// <summary>
		/// Adds the specified composite format string to this dialog box.
		/// </summary>
		/// <param name="text">A composite format string that should be appended.</param>
		/// <param name="args">An object array that contains zero or more objects to format in the appended text.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <remarks>This is a convenience method that calls String.Format(System.String, System.Object[]).</remarks>
		/// <exception cref="ArgumentNullException"><c>format</c> or <c>args</c> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><c>format</c> is invalid.<br />
		/// -or-<br />
		/// The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.
		/// </exception>
		/// <example>
		/// <code>
		/// int selectedTicketId = 1;
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendLine("The ID of the selected ticket is {0}", selectedTicketId);
		/// </code>
		/// </example>
		public UIBuilder AppendLine(string text, params object[] args) { return null; }

		/// <summary>
		/// Adds the display value of the specified (standalone or table) parameter to this dialog box.
		/// </summary>
		/// <param name="element">The element the parameter is part of.</param>
		/// <param name="pid">The ID of the parameter.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// Element element = engine.FindElement(200, 4000);
		/// 
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendParameter(element, 1000);
		/// </code>
		/// </example>
		public UIBuilder AppendParameter(IActionableElement element, int pid) { return null; }

		/// <summary>
		/// Adds the display value of the specified (standalone or table) parameter to this dialog box.
		/// </summary>
		/// <param name="dma">The DataMiner Agent ID.</param>
		/// <param name="eid">The element ID.</param>
		/// <param name="pid">The parameter ID.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendParameter(200, 4000, 1000);
		/// </code>
		/// </example>
		public UIBuilder AppendParameter(int dma, int eid, int pid) { return null; }

		/// <summary>
		/// Adds the display value of the specified table cell to this dialog box.
		/// </summary>
		/// <param name="element">The element the parameter is part of.</param>
		/// <param name="pid">The ID of the column parameter.</param>
		/// <param name="idx">The display key of the row.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// Element element = engine.FindElement(200, 4000);
		/// 
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendParameter(element, 1002, "Row 1");
		/// </code>
		/// </example>
		public UIBuilder AppendParameter(IActionableElement element, int pid, string idx) { return null; }

		/// <summary>
		/// Adds the display value of the specified table cell to this dialog box.
		/// </summary>
		/// <param name="dma">The DataMiner Agent ID.</param>
		/// <param name="eid">The element ID.</param>
		/// <param name="pid">The ID of the column parameter.</param>
		/// <param name="idx">The row index.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendParameter(200, 4000, 1002, "Row 1");
		/// </code>
		/// </example>
		public UIBuilder AppendParameter(int dma, int eid, int pid, string idx) { return null; }

		/// <summary>
		/// Adds a textbox to this dialog box.
		/// </summary>
		/// <param name="destVar">The name of the destination variable.</param>
		/// <returns>This <see cref="UIBuilder"/> instance.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// // ...
		/// uibDialogBox.AppendTextBox("input");
		/// </code>
		/// </example>
		public UIBuilder AppendTextBox(string destVar) { return null; }

		/// <summary>
		/// Gets a string representation of this dialog box.
		/// </summary>
		/// <returns>A string representation of this dialog box.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uibDialogBox = new UIBuilder();
		/// uibDialogBox.MinHeight = 450;
		/// uibDialogBox.MinWidth = 400;
		/// uibDialogBox.RequireResponse = true;
		/// uibDialogBox.ColumnDefs = "a;";
		/// 
		/// uibDialogBox.Append("Input: ");
		/// uibDialogBox.AppendTextBox("input");
		/// 
		/// string result = uibDialogBox.ToString();
		/// // result:
		/// // [UI]
		/// // type=global
		/// // min-width=400
		/// // min-height=450
		/// // grid-column-defs=a;
		/// // [/UI][UI]
		/// // type=static
		/// // range-low=NaN
		/// // range-high=NaN
		/// // range-step=NaN
		/// // text = Input: 
		/// // [/UI][UI]
		/// // type=textbox
		/// // range-low=NaN
		/// // range-high=NaN
		/// // range-step=NaN
		/// // destvar = input
		/// // [/ UI]
		/// </code>
		/// </example>
		public override string ToString() { return ""; }
	}
}
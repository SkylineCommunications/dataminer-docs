using System;
using System.Collections.Generic;

using Skyline.DataMiner.Net.AutomationUI.Objects;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents an item in a dialog box of an interactive Automation script.
	/// </summary>
	public class UIBlockDefinition
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UIBlockDefinition"/> class.
		/// </summary>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// </code>
		/// </example>
		/// <remarks>
		/// <note type="note">
		/// If you want to have IntelliSense in DataMiner Cube, the name of the dialog box has to start with “block”.
		/// </note>
		/// </remarks>
		public UIBlockDefinition() { }

		/// <summary>
		/// Gets or sets the allowed file name extensions.
		/// </summary>
		/// <value>The allowed file name extensions.</value>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <description>In Automation scripts launched from web apps, the MaxFileSizeInBytes and AllowedFileNameExtensions properties of UIBlockDefinitions of type FileSelector are taken into account from DataMiner 10.1.12 onwards.
		/// 
		/// An error will be thrown when you try to add a file that is larger than the allowed file size or that
		/// does not have an allowed file name extension. Also, the “Choose file” pop-up window will
		/// only list files with an allowed extension and dragging an item other than a file or a folder onto
		/// the script’s drop zone will no longer be possible.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Available from DataMiner 10.1.12 (RN 31212) onwards.</description>
		/// </item>
		/// </list>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition uibDef = new UIBlockDefinition();
		/// uibDef.Type = UIBlockType.FileSelector;
		/// uibDef.AllowedFileNameExtensions = new List&lt;string&gt;() { ".txt", ".csv" };
		/// </code>
		/// </example>
		public List<string> AllowedFileNameExtensions { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether multiple files can be uploaded.
		/// </summary>
		/// <value><c>true</c> if multiple files can be uploaded; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>In an interactive Automation script that is used in the DataMiner web apps, you can use this property to configure a file selector component that allows the user to upload multiple files. To do so, set the property AllowMultipleFiles to <c>true</c>.</para>
		/// <para>With this configuration, users will be able to add files one by one, but they will not be able to add the same file twice. They will also be able to add a file by dragging it to the file selector.</para>
		/// <para>Available from DataMiner 10.1.8/10.2.0 onwards.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition uibDef = new UIBlockDefinition();
		/// uibDef.Type = UIBlockType.FileSelector;
		/// uibDef.DestVar = destvar;
		/// uibDef.InitialValue = initialValue;
		/// uibDef.Row = (int)row;
		/// uibDef.RowSpan = (int)rowSpan;
		/// uibDef.Column = (int)column;
		/// uibDef.ColumnSpan = (int)columnSpan;
		/// uibDef.HorizontalAlignment = GetHorizontalAlignment(horizontalAlignment);
		/// uibDef.VerticalAlignment = GetVerticalAlignment(verticalAlignment);
		/// uibDef.AllowMultipleFiles = true;
		/// </code>
		/// </example>
		public bool AllowMultipleFiles { get; set; }

		/// <summary>
		/// Gets or sets the zero-based index of the column in which the dialog box item has to be placed.
		/// </summary>
		/// <value>The zero-based index of the column in which the dialog box item has to be placed.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.Column = 1; // Text box positioned in second column from the left.
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int Column { get; set; }

		/// <summary>
		/// Gets or sets the number of joining columns the dialog box item is allowed to occupy.
		/// </summary>
		/// <value>The number of joining columns the dialog box item is allowed to occupy.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.Column = 1;
		/// blockItem.ColumnSpan = 2;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int ColumnSpan { get; set; }

		/// <summary>
		/// Gets or sets the configuration options.
		/// </summary>
		/// <value>The configuration options.</value>
		/// <remarks>Only intended to be used when <see cref="Type"/> is set to <see cref="E:UIBlockType.Time"/>.</remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition uibDef = new UIBlockDefinition();
		/// uibDef.Type = UIBlockType.Time;
		/// uibDef.InitialValue = DateTime.Now.ToString("G");
		/// 
		/// var config = new AutomationDateTimePickerOptions();
		/// config.Format = DateTimeFormat.ShortDate;
		/// 
		/// uibDef.ConfigOptions = config;
		/// </code>
		/// </example>
		public AutomationConfigOptions ConfigOptions { get; set; }

		/// <summary>
		/// Gets or sets the number of decimals to show.
		/// </summary>
		/// <value>The number of decimals to show.</value>
		/// <remarks>
		/// <para>Applicable only in case <see cref="Type"/> is set to Numeric.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition numericBlock = new UIBlockDefinition();
		/// 
		/// numericBlock.Type = UIBlockType.Numeric;
		/// numericBlock.InitialValue = "10;true;Discreet 2";
		/// numericBlock.DestVar = "num";
		/// numericBlock.WantsOnChange = true;
		/// numericBlock.Row = 0;
		/// numericBlock.Column = 1;
		/// numericBlock.HorizontalAlignment = "Center";
		/// numericBlock.VerticalAlignment = "Top";
		/// numericBlock.RangeHigh = 300;
		/// numericBlock.RangeLow = 5;
		/// numericBlock.RangeStep = 5;
		/// numericBlock.Decimals = 6;
		/// numericBlock.Extra = "Discreet 1;Discreet 2;Discreet 3";
		/// 
		/// uib.AppendBlock(numericBlock);
		/// </code>
		/// </example>
		public int Decimals { get; set; }

		/// <summary>
		/// Gets or sets the alias that will be used to retrieve the value entered or selected by the user from the <see cref="UIResults"/> object.
		/// </summary>
		/// <value>The alias that will be used to retrieve the value entered or selected by the user from the <see cref="UIResults"/> object.</value>
		/// <remarks>
		/// <para>Applicable only when <see cref="Type"/> is set to either Button, Calendar, CheckBox, CheckBoxList, DropDown, TextBox, Time or TreeView.</para>
		/// <para>Note: Unlike a variable, a DestVar alias does not have to be declared.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIResults uir = null;
		/// string enteredText = "";
		/// 
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// 
		/// blockItem.DestVar = "myText";
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// 
		/// uir = engine.ShowUI(uibDialogBox1);
		/// enteredText = uir.GetString("myText");
		/// </code>
		/// </example>
		public string DestVar { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether a filter box is available for the control.
		/// </summary>
		/// <value><c>true</c> if a filter box is available for the control; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: <c>false</c>.</para>
		/// <para>Available from DataMiner 9.5.6 onwards.</para>
		/// <para>Applicable only when <see cref="Type"/> is set to DropDown.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.DropDown;
		/// blockItem.DisplayFilter = true;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public bool DisplayFilter { get; set; }

		/// <summary>
		/// Gets or sets the ID of the parameter that has to be displayed in the dialog box item.
		/// </summary>
		/// <value>The ID of the parameter that has to be displayed in the dialog box item.</value>
		/// <remarks>
		/// <para>Applicable only when <see cref="Type"/> is set to Parameter or Numeric.</para>
		/// <para>For a dialog box item of type Numeric, this property allows to have a checkbox with multiple discrete values. In case multiple discrete values are defined, separate these with a semicolon (';'). If you do not want any checkbox, but only the numeric box, then leave this property empty.</para>
		/// <para>For a dialog box item of type Parameter, the ID syntax is as follows: DmaID/ElementID:ParamID[:index]</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.Parameter;
		/// blockItem.Extra = "7/253:83";
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public string Extra { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the password box shows an icon that, when clicked, allows displaying the value inside the password box.
		/// </summary>
		/// <value><c>true</c> if the peek icon is shown; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <list type="bullet">
		/// <item><description>Only applicable for password boxes.</description></item>
		/// <item><description>Feature introduced in DataMiner 9.6.6 (RN 21518).</description></item>
		/// </list>
		/// </remarks>
		/// <example>
		/// <code>blockPasswordBox.HasPeekIcon = allowPeek;</code>
		/// </example>
		public bool HasPeekIcon { get; set; }

		/// <summary>
		/// Gets or sets the fixed height (in pixels) of the dialog box item.
		/// </summary>
		/// <value>The fixed height (in pixels) of the dialog box item.</value>
		/// <remarks>
		/// <para>To make sure the dialog box can be displayed optimally, we advise to use a minimum and maximum height instead of a fixed height (see MaxHeight and MinHeight).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.Height = 100;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int Height { get; set; }

		/// <summary>
		/// Gets or sets the horizontal alignment of the dialog box item.
		/// </summary>
		/// <value>The horizontal alignment of the dialog box item: “Center”, “Left”, “Right” or “Stretch”.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.HorizontalAlignment = "Left";
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public string HorizontalAlignment { get; set; }

		/// <summary>
		/// Gets or sets the value that will be assigned to the dialog box item the moment the dialog box opens.
		/// </summary>
		/// <value>The value that will be assigned to the dialog box item the moment the dialog box opens.</value>
		/// <remarks>
		/// <para>For a dialog box item of type CheckBoxList, you can specify several values separated by semicolons.</para>
		/// <para>For a dialog box item of type Numeric, the initial value has to be of format "DoubleValue;Boolean;SelectedDiscreetString". The DoubleValue contains the value of the numeric box. The Boolean ("true" or "false") determines whether the discreet checkbox is selected (true) or not (false). The SelectedDiscreetString selects the discreet with that exact name in case multiple discrete values are defined. If case you only want to visualize the numeric box, it is sufficient to only specify the DoubleValue (RN 6825).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockCalendar = new UIBlockDefinition();
		/// blockCalendar.Type = UIBlockType.Calendar;
		/// DateTime saveNow = DateTime.Now;
		/// blockCalendar.InitialValue = saveNow.ToString("dd/MM/yyyy HH:mm:ss");
		/// 
		/// uib.AppendBlock(blockCalendar);
		/// </code>
		/// </example>
		public string InitialValue { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the control is enabled in the UI.
		/// </summary>
		/// <value><c>true</c> if the control is enabled in the UI; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: true.</para>
		/// <para>Available from DataMiner 9.5.3 onwards.</para>
		/// </remarks>
		public bool IsEnabled { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether users are able to enter multiple lines of text.
		/// </summary>
		/// <value><c>true</c> if users are able to enter multiple lines of text; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Applicable only when <see cref="Type"/> is set to TextBox.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.IsMultiline = true;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public bool IsMultiline { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this input control requires a value.
		/// </summary>
		/// <value><c>true</c> if this input control requires a valued; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>If <c>true</c>, the control will be marked “Invalid” when empty.</para>
		/// <para>Refer to <see cref="UIBlockDefinition.ValidationState"/> for an overview of the types that support this property.</para>
		/// <para>Feature introduced in DataMiner 10.0.5 (RN 25183, RN 25253).</para>
		/// </remarks>
		public bool IsRequired { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether items in the control are sorted naturally.
		/// </summary>
		/// <value><c>true</c> if the items are sorted naturally; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Applicable only when <see cref="Type"/> is set to CheckBoxList or DropDown.</para>
		/// <para>Default: false</para>
		/// <para>Available from DataMiner 9.5.6 onwards.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.DropDown;
		/// blockItem.IsSorted = true;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public bool IsSorted { get; set; }

		/// <summary>
		/// Gets or sets the margin (in pixels) around the dialog box item.
		/// </summary>
		/// <value>The margin (in pixels) around the dialog box item.</value>
		/// <remarks>
		/// <para>Default: no margin.</para>
		/// <para>Syntax: "Left;Top;Right;Bottom"</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.Margin = "5;5;5;5";
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public string Margin { get; set; }

		/// <summary>
		/// Gets or sets the maximum allowed file size.
		/// </summary>
		/// <value>The maximum allowed file size.</value>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <description>In Automation scripts launched from web apps, the MaxFileSizeInBytes and AllowedFileNameExtensions properties of UIBlockDefinitions of type FileSelector are taken into account from DataMiner 10.1.12 onwards.
		/// 
		/// An error will be thrown when you try to add a file that is larger than the allowed file size or
		/// that does not have an allowed file name extension. Also, the “Choose file” pop-up window will
		/// only list files with an allowed extension and dragging an item other than a file or a folder onto
		/// the script’s drop zone will no longer be possible.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Available from DataMiner 10.1.12 (RN 31212) onwards.</description>
		/// </item>
		/// </list>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition uibDef = new UIBlockDefinition();
		/// uibDef.Type = UIBlockType.FileSelector;
		/// uibDef.MaxFileSizeInBytes = 100000;
		/// </code>
		/// </example>
		public long MaxFileSizeInBytes { get; set; }


		/// <summary>
		/// Gets or sets the maximum height (in pixels) of the dialog box item.
		/// </summary>
		/// <value>The maximum height (in pixels) of the dialog box item.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.MaxHeight = 100;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int MaxHeight { get; set; }

		/// <summary>
		/// Gets or sets the maximum width (in pixels) of the dialog box item.
		/// </summary>
		/// <value>The maximum width (in pixels) of the dialog box item.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.MaxWidth = 100;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int MaxWidth { get; set; }

		/// <summary>
		/// Gets or sets the minimum height (in pixels) of the dialog box item.
		/// </summary>
		/// <value>The minimum height (in pixels) of the dialog box item.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.MinHeight = 100;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int MinHeight { get; set; }

		/// <summary>
		/// Gets or sets the minimum width (in pixels) of the dialog box item.
		/// </summary>
		/// <value>The minimum width (in pixels) of the dialog box item.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.MinWidth = 100;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int MinWidth { get; set; }

		/// <summary>
		/// Gets or sets the placeholder text.
		/// </summary>
		/// <value>Text that will be displayed as long as the control is empty (e.g. “In this box, enter...”).</value>
		/// <remarks>
		/// <para>Refer to <see cref="UIBlockDefinition.ValidationState"/> for an overview of the types that support this property.</para>
		/// <para>Feature introduced in DataMiner 10.0.5 (RN 25183, RN 25253).</para>
		/// </remarks>
		public string PlaceholderText { get; set; }


		/// <summary>
		/// Gets or sets the maximum value of the range.
		/// </summary>
		/// <value>The maximum value of the range.</value>
		/// <remarks>
		/// <para>Applicable only in case <see cref="Type"/> is set to Numeric.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition numericBlock = new UIBlockDefinition();
		/// 
		/// numericBlock.Type = UIBlockType.Numeric;
		/// numericBlock.InitialValue = "10;true;Discreet 2";
		/// numericBlock.DestVar = "num";
		/// numericBlock.WantsOnChange = true;
		/// numericBlock.Row = 0;
		/// numericBlock.Column = 1;
		/// numericBlock.HorizontalAlignment = "Center";
		/// numericBlock.VerticalAlignment = "Top";
		/// numericBlock.RangeHigh = 300;
		/// numericBlock.RangeLow = 5;
		/// numericBlock.RangeStep = 5;
		/// numericBlock.Decimals = 6;
		/// numericBlock.Extra = "Discreet 1;Discreet 2;Discreet 3";
		/// 
		/// uib.AppendBlock(numericBlock);
		/// </code>
		/// </example>
		public double RangeHigh { get; set; }

		/// <summary>
		/// Gets or sets the minimum value of the range.
		/// </summary>
		/// <value>The minimum value of the range.</value>
		/// <remarks>
		/// <para>Applicable only in case <see cref="Type"/> is set to Numeric.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition numericBlock = new UIBlockDefinition();
		/// 
		/// numericBlock.Type = UIBlockType.Numeric;
		/// numericBlock.InitialValue = "10;true;Discreet 2";
		/// numericBlock.DestVar = "num";
		/// numericBlock.WantsOnChange = true;
		/// numericBlock.Row = 0;
		/// numericBlock.Column = 1;
		/// numericBlock.HorizontalAlignment = "Center";
		/// numericBlock.VerticalAlignment = "Top";
		/// numericBlock.RangeHigh = 300;
		/// numericBlock.RangeLow = 5;
		/// numericBlock.RangeStep = 5;
		/// numericBlock.Decimals = 6;
		/// numericBlock.Extra = "Discreet 1;Discreet 2;Discreet 3";
		/// 
		/// uib.AppendBlock(numericBlock);
		/// </code>
		/// </example>
		public double RangeLow { get; set; }

		/// <summary>
		/// Gets or sets the step size.
		/// </summary>
		/// <value>The step size.</value>
		/// <remarks>
		/// <para>Applicable only in case <see cref="Type"/> is set to Numeric.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition numericBlock = new UIBlockDefinition();
		/// 
		/// numericBlock.Type = UIBlockType.Numeric;
		/// numericBlock.InitialValue = "10;true;Discreet 2";
		/// numericBlock.DestVar = "num";
		/// numericBlock.WantsOnChange = true;
		/// numericBlock.Row = 0;
		/// numericBlock.Column = 1;
		/// numericBlock.HorizontalAlignment = "Center";
		/// numericBlock.VerticalAlignment = "Top";
		/// numericBlock.RangeHigh = 300;
		/// numericBlock.RangeLow = 5;
		/// numericBlock.RangeStep = 5;
		/// numericBlock.Decimals = 6;
		/// numericBlock.Extra = "Discreet 1;Discreet 2;Discreet 3";
		/// 
		/// uib.AppendBlock(numericBlock);
		/// </code>
		/// </example>
		public double RangeStep { get; set; }

		/// <summary>
		/// Gets or sets the zero-based index of the row in which the dialog box item has to be positioned.
		/// </summary>
		/// <value>The zero-based index of the row in which the dialog box item has to be positioned.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.Row = 2; // Text box situated in third row from the top.
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int Row { get; set; }

		/// <summary>
		/// Gets or sets the number of joining rows the dialog box item is allowed to occupy.
		/// </summary>
		/// <value>The number of joining rows the dialog box item is allowed to occupy.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.Row = 2; blockItem.RowSpan = 2;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int RowSpan { get; set; }

		/// <summary>
		/// Gets or sets the style of the dialog box item.
		/// </summary>
		/// <value>The style of the dialog box item.</value>
		/// <remarks>
		/// <para>It is possible to set a style on some dialog box items.</para>
		/// <para>The supported styles can be accessed through const strings on the Style class, subdivided per control type (Button, Text, etc.).<br/>
		/// All Button styles can also be applied to a DownloadButton.<br/>
		/// The Style class is available from DataMiner 10.3.1/10.4.0 onwards. For older DataMiner versions, you can use the StaticText styles 'Title1', 'Title2', and 'Title3'.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition propertiesTitle = new UIBlockDefinition();
		/// propertiesTitle.Type = UIBlockType.StaticText;
		/// propertiesTitle.Style = Style.Text.Title2;
		/// </code>
		/// </example>
		public string Style { get; set; }

		/// <summary>
		/// Gets or sets the text that has to appear in the dialog box item.
		/// </summary>
		/// <value>The text that has to appear in the dialog box item.</value>
		/// <example>
		/// <remarks>
		/// <para>Applicable only when <see cref="Type"/> is set to Button or StaticText.</para>
		/// </remarks>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.Button;
		/// blockItem.Row = 2; blockItem.Text = "OK";
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets the text of the tooltip for a component of an interactive Automation script.
		/// </summary>
		/// <value>The text of the tooltip for a component of an interactive Automation script.</value>
		/// <remarks>
		/// <para>This tooltip is only displayed if the script is run within one of the DataMiner web apps, for example the Jobs app.</para>
		/// <para>Available from DataMiner 10.0.8 onwards.</para>
		/// <example>
		/// <code>
		/// UIBlockDefinition label3 = new UIBlockDefinition();
		/// label3.Type = UIBlockType.StaticText;
		/// label3.Text = "Drop-down no filter";
		/// label3.Row = 2;
		/// label3.Column = 0;
		/// uib.AppendBlock(label3);
		/// UIBlockDefinition input3 = new UIBlockDefinition();
		/// input3.Type = UIBlockType.DropDown;
		/// input3.AddDropDownOption("1|Option 1");
		/// input3.AddDropDownOption("2|Option 2");
		/// input3.AddDropDownOption("3|Option 3");
		/// input3.ValidationState = UIValidationState.Invalid;
		/// input3.ValidationText = "Validation message...";
		/// input3.IsRequired = true;
		/// input3.Height = 400;
		/// input3.PlaceholderText = "Placeholder message...";
		/// input3.InitialValue = "2";
		/// input3.Row = 2;
		/// input3.Column = 1;
		/// input3.TooltipText = "drop-down no filter - tooltip text";
		/// uib.AppendBlock(input3);
		/// </code>
		/// </example>
		/// </remarks>
		public string TooltipText { get; set; }

		/// <summary>
		/// Gets or sets the type of the dialog box item.
		/// </summary>
		/// <value>The type of the dialog box item.</value>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public UIBlockType Type { get; set; }

		/// <summary>
		/// Contains each item of the tree view as a TreeViewItem.
		/// </summary>
		/// <value>The items of the tree view as a TreeViewItem.</value>
		/// <remarks>
		/// <para>Only applicable if UIBlockType is set to TreeView.</para>
		/// <para>Available from DataMiner 10.0.10 onwards.</para>
		/// </remarks>
		/// <seealso cref="TreeViewItem"/>
		public List<TreeViewItem> TreeViewItems { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		/// <remarks><para>This property is obsolete. Use the <see cref="UIBuilder.Title"/> property instead.</para></remarks>
		[Obsolete("Use UIBuilder.Title instead.")]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets a value indicating the validation state.
		/// </summary>
		/// <value><c>Valid</c> if the state is valid; <c>Invalid</c> if the state is invalid; otherwise <c>NotValidated</c>.</value>
		/// <remarks>
		/// <para>The ValidationState and ValidationText properties should be used in combination with the  <see cref="WantsOnChange"/> property. If <see cref="WantsOnChange"/> is <c>true</c>, the interactive Automation script will have its <see cref="Engine.ShowUI"/> method return each time the user input changes. This will also be indicated by the _ONCHANGE key, which is returned in the <see cref="UIResults"/>. This functionality will allow you to offer clear feedback on user input.</para>
		/// <para>The following table gives an overview of which input controls support which properties:</para>
		/// <list type="table">
		/// <listheader>
		/// <term></term>
		/// <term>IsRequired</term>
		/// <term>PlaceholderText</term>
		/// <term>ValidationText</term>
		/// </listheader>
		/// <item>
		/// <term>TextBox</term>
		/// <term>X</term>
		/// <term>X</term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>PasswordBox</term>
		/// <term>X</term>
		/// <term>X</term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>DropDown</term>
		/// <term>X</term>
		/// <term>X</term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>Numeric</term>
		/// <term>X</term>
		/// <term>X</term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>Calendar (both Date and Time)</term>
		/// <term>X</term>
		/// <term></term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>FileSelector</term>
		/// <term></term>
		/// <term></term>
		/// <term>X</term>
		/// </item>
		/// </list>
		/// <para>Feature introduced in DataMiner 10.0.5 (RN 25183, RN 25253).</para>
		/// </remarks>
		public UIValidationState ValidationState
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the validation text.
		/// </summary>
		/// <value>Text that will be displayed when ValidationState is “Invalid”.</value>
		/// <remarks>
		/// <para>The ValidationState and ValidationText properties should be used in combination with the  <see cref="WantsOnChange"/> property. If <see cref="WantsOnChange"/> is <c>true</c>, the interactive Automation script will have its <see cref="Engine.ShowUI"/> method return each time the user input changes. This will also be indicated by the _ONCHANGE key, which is returned in the <see cref="UIResults"/>. This functionality will allow you to offer clear feedback on user input.</para>
		/// <para>The following table gives an overview of which input controls support which properties:</para>
		/// <list type="table">
		/// <listheader>
		/// <term></term>
		/// <term>IsRequired</term>
		/// <term>Placeholder</term>
		/// <term>ValidationText</term>
		/// </listheader>
		/// <item>
		/// <term>TextBox</term>
		/// <term>X</term>
		/// <term>X</term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>PasswordBox</term>
		/// <term>X</term>
		/// <term>X</term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>DropDown</term>
		/// <term>X</term>
		/// <term>X</term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>Numeric</term>
		/// <term>X</term>
		/// <term>X</term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>Calendar (both Date and Time)</term>
		/// <term>X</term>
		/// <term></term>
		/// <term>X</term>
		/// </item>
		/// <item>
		/// <term>FileUpload</term>
		/// <term></term>
		/// <term></term>
		/// <term>X</term>
		/// </item>
		/// </list>
		/// <para>Feature introduced in DataMiner 10.0.5 (RN 25183, RN 25253).</para>
		/// </remarks>
		public string ValidationText
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the vertical alignment of the dialog box item.
		/// </summary>
		/// <value>The vertical alignment of the dialog box item: “Center”, “Top”, “Bottom” or “Stretch”.</value>
		/// <remarks>
		/// <para>Note: If no vertical alignment option is set, by default “Top” alignment is applied.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.VerticalAlignment = "Top";
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public string VerticalAlignment { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether an update of the current value of the dialog box item will trigger an OnChange event.
		/// </summary>
		/// <value><c>true</c> if an update of the current value of the dialog box item will trigger an OnChange event; otherwise, <c>false</c>.</value>
		/// <example>
		/// <remarks>
		/// <para>Applicable only when <see cref="Type"/> is set to either Button, Calendar, Checkbox, CheckBoxList, DropDown, Numeric, PasswordBox (from DataMiner 9.6.6 onwards), RadioButtonList (from DataMiner 9.6.6 onwards), TextBox (from DataMiner 9.5.3 onwards), Time or TreeView (from DataMiner 10.0.10 onwards).</para>
		/// <para>Note: A button will always trigger an OnChange event, regardless of what you specify for the WantsOnChange attribute.</para>
		/// </remarks>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.CheckBox;
		/// blockItem.WantsOnChange = true;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public bool WantsOnChange { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether an OnChange event will be triggered when the component loses focus.
		/// </summary>
		/// <value><c>true</c> to let an OnChange event be triggered when the component loses focus; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Applicable only in case <see cref="Type"/> is set to Calendar, CheckBox, CheckBoxList, DropDown, Numeric, PasswordBox, RadioButtonList, TextBox, Time.</para>
		/// <para>Feature introduced in DataMiner 10.1.10 (RN 30638).</para>
		/// </remarks>
		public bool WantsOnFocusLost { get; set; }

		/// <summary>
		/// Gets or sets the fixed width (in pixels) of the dialog box item.
		/// </summary>
		/// <value>The fixed width (in pixels) of the dialog box item.</value>
		/// <remarks>
		/// <para>Note: To make sure the dialog box can be displayed optimally, we advise to use a minimum and maximum width instead of a fixed width (see MaxWidth and MinWidth).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox; 
		/// blockItem.Width = 100;
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public int Width { get; set; }

		/// <summary>
		/// Adds an entry to a checkbox list.
		/// </summary>
		/// <param name="option"></param>
		/// <remarks>
		/// <para>Only intended to be used when <see cref="Type"/> is set to <see cref="E:UIBlockType.CheckBoxList"/>.</para>
		/// <para>Available from DataMiner 9.6.6 onwards.</para>
		/// </remarks>
		public void AddCheckBoxListOption(string option) { }

		/// <summary>
		/// Adds an entry to a checkbox list.
		/// </summary>
		/// <param name="rawValue">The raw value.</param>
		/// <param name="displayValue">The display value.</param>
		/// <remarks>
		/// <para>Only intended to be used when <see cref="Type"/> is set to <see cref="E:UIBlockType.CheckBoxList"/>.</para>
		/// <para>Available from DataMiner 9.6.6 onwards.</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// 
		/// blockItem.Type = UIBlockType.CheckBoxList;
		/// 
		/// blockItem.AddCheckBoxListOption("1","First option");
		/// blockItem.AddCheckBoxListOption("2","Second option");
		/// 
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public void AddCheckBoxListOption(string rawValue, string displayValue) { }

		/// <summary>
		/// Adds an entry to a drop-down list.
		/// </summary>
		/// <param name="option">The entry to add.</param>
		/// <remarks>Only intended to be used when <see cref="Type"/> is set to <see cref="E:UIBlockType.DropDown"/>.</remarks>
		public void AddDropDownOption(string option) { }

		/// <summary>
		/// Adds an entry to a drop-down list.
		/// </summary>
		/// <param name="rawValue">The raw value.</param>
		/// <param name="displayValue">The display value.</param>
		/// <remarks>Only intended to be used when <see cref="Type"/> is set to <see cref="E:UIBlockType.DropDown"/>.</remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// 
		/// blockItem.Type = UIBlockType.DropDown;
		/// 
		/// blockItem.AddDropDownOption("option_a","First option");
		/// blockItem.AddDropDownOption("option_b","Second option");
		///
		/// uibDialogBox1.AppendBlock(blockItem);
		/// </code>
		/// </example>
		public void AddDropDownOption(string rawValue, string displayValue) { }

		/// <summary>
		/// Adds an entry to the radio button list.
		/// </summary>
		/// <param name="rawValue">The raw value.</param>
		/// <param name="displayValue">The display value.</param>
		/// <remarks>
		/// <note type="note">
		/// When no initial value is passed to this list, no radio button will be selected by default.
		/// </note>
		/// <para>Only intended to be used when <see cref="Type"/> is set to <see cref="E:UIBlockType.RadioButtonList"/>.</para>
		/// <para>Feature introduced in DataMiner 9.6.6 (RN 21475).</para>
		/// </remarks>
		public void AddRadioButtonListOption(string rawValue, string displayValue)
		{
			//this.AddDropDownOption(Tools.Format("{0}|{1}", (object)rawValue, (object)displayValue));
		}

		/// <summary>
		/// Adds an entry to the radio button list.
		/// </summary>
		/// <param name="option">The entry to add.</param>
		/// <remarks>
		/// <note type="note">
		/// When no initial value is passed to this list, no radio button will be selected by default.
		/// </note>
		/// <para>Only intended to be used when <see cref="Type"/> is set to <see cref="E:UIBlockType.RadioButtonList"/>.</para>
		/// <para>Feature introduced in DataMiner 9.6.6 (RN 21475).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition blockRadioButtonList = new UIBlockDefinition();
		/// blockRadioButtonList.Type = UIBlockType.RadioButtonList;
		/// ...
		/// foreach (string sOption in dropDownOptions)
		/// {
		///		uibDef.AddRadioButtonListOption(sOption);
		///	}
		/// </code>
		/// </example>
		public void AddRadioButtonListOption(string option)
		{
			this.AddDropDownOption(option);
		}

		/// <summary>
		/// Returns a string representation of this dialog box item.
		/// </summary>
		/// <returns>A string representation of this dialog box item.</returns>
		/// <example>
		/// <code>
		/// UIBlockDefinition numericBlock = new UIBlockDefinition();
		/// numericBlock.Type = UIBlockType.Numeric;
		/// numericBlock.InitialValue = "5";
		/// numericBlock.DestVar = "num";
		/// numericBlock.WantsOnChange = true;
		/// numericBlock.Row = 0;
		/// numericBlock.Column = 1;
		/// numericBlock.HorizontalAlignment = "Center";
		/// numericBlock.VerticalAlignment = "Top";
		/// numericBlock.RangeHigh = 300;
		/// numericBlock.RangeLow = 5;
		/// numericBlock.RangeStep = 5;
		/// numericBlock.Decimals = 6;
		/// numericBlock.Extra = "Discreet 1;Discreet 2;Discreet 3";
		/// 
		/// string result = numericBlock.ToCode();
		/// 
		/// // result:
		/// // [UI]
		/// // type=numeric
		/// // column = 1
		/// // row=0
		/// // range-low=5
		/// // range-high=300
		/// // range-step=5
		/// // decimals=6
		/// // align-hor=Center
		/// // align-ver=Top
		/// // initial = 5
		/// // destvar=num
		/// // extra = Discreet 1; Discreet 2;Discreet 3
		/// // onchange=true
		/// // [/UI]
		/// </code>
		/// </example>
		public string ToCode() { return ""; }

		/// <summary>
		/// Returns a string representation of the specified block type.
		/// </summary>
		/// <param name="blockType">The block type.</param>
		/// <returns>The string representation.</returns>
		/// <example>
		/// <code>
		/// string type = UIBlockDefinition.ToString(UIBlockType.Parameter); // type = "parameter".
		/// </code>
		/// </example>
		public static string ToString(UIBlockType blockType) { return ""; }
	}
}

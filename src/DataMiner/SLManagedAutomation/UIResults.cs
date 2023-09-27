using System;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents the information a user has entered or selected in a dialog box of an interactive Automation script.
	/// </summary>
	/// <example>
	/// <code>
	/// UIResults uir = engine.ShowUI(uibDialogBox1);
	/// </code>
	/// </example>
	/// <remarks>
	/// <note type="note">If you want to use IntelliSense, the name of a UIResults object has to start with “uir”.</note>
	/// </remarks>
	public class UIResults
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UIResults"/> class.
		/// </summary>
		public UIResults() { }

		/// <summary>
		/// Gets a value indicating whether the specified destination variable that is linked to a checkbox was selected.
		/// </summary>
		/// <param name="key">The destination variable name.</param>
		/// <returns><c>true</c> if the specified checkbox is selected; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// UIResults uir = null;
		/// bool isSelected;
		/// UIBlockDefinition blockCheckBox = new UIBlockDefinition();
		/// blockCheckBox.Type = UIBlockType.CheckBox;
		/// blockCheckBox.DestVar = "checkbox";
		/// ...
		/// uib.AppendBlock(blockCheckBox);
		/// ...
		/// uir = engine.ShowUI(uib);
		/// isSelected = uir.GetChecked("checkbox");
		/// </code>
		/// </example>
		public bool GetChecked(string key) { return false; }

		/// <summary>
		/// Gets a value indicating whether the specified checkbox list item of the specified destination variable that is linked to a checkbox list was selected.
		/// </summary>
		/// <param name="key">The value of the checkbox.</param>
		/// <param name="value"><c>true</c> if the specified checkbox list item is selected; otherwise, <c>false</c>.</param>
		/// <returns><c>true</c> if the specified checkbox list item is selected; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// UIBuilder uiBuilder = new UIBuilder();
		/// ...
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.CheckBoxList;
		/// blockItem.AddCheckBoxListOption("1","First option");
		/// blockItem.AddCheckBoxListOption("2","Second option");
		/// blockItem.DestVar = "chekBoxList";
		/// uiBuilder.AppendBlock(blockItem);
		/// ...
		/// var uir = engine.ShowUI(uiBuilder);
		/// 
		/// bool selected = uir.GetChecked("chekBoxList", "2");
		/// </code>
		/// </example>
		public bool GetChecked(string key, string value) { return false; }

		/// <summary>
		/// Gets the date/time that was selected in the specified destination variable that is linked to a Calendar item.
		/// </summary>
		/// <param name="key">The name of the destination variable.</param>
		/// <returns>The date/time that was selected in the specified destination variable that is linked to a Calendar item.</returns>
		/// <example>
		/// <code>
		/// UIResults uir = null;
		/// DateTime selection = DateTime.Now;
		/// ...
		/// UIBlockDefinition blockCalendar = new UIBlockDefinition();
		/// blockCalendar.Type = UIBlockType.Calendar;
		/// blockCalendar.InitialValue = selection.ToString("dd/MM/yyyy HH:mm:ss");
		/// blockCalendar.DestVar = "calendar";
		/// blockCalendar.WantsOnChange = true;
		/// ...
		/// uib.AppendBlock(blockCalendar);
		/// ...
		/// uir = engine.ShowUI(uib);
		/// selection = uir.GetDateTime("calendar");
		/// </code>
		/// </example>
		/// <remarks>
		/// <note type="note">Prior to DataMiner 10.0.12, this method only supports the parsing of datetimes in the format dd/MM/yyyy HH:mm:ss. From DataMiner 10.0.12 onwards, ISO format is supported.</note>
		/// </remarks>
		public DateTime GetDateTime(string key) { return DateTime.Now; }

		/// <summary>
		/// Gets the key values of the tree view items that are expanded for the specified key.
		/// </summary>
		/// <param name="key">The name of the destination variable.</param>
		/// <returns>The keys of all expanded tree view items which have the SupportsLazyLoading property enabled.</returns>
		/// <remarks>
		/// <para>This method can be used to check whether a tree view node is collapsed or expanded.</para>
		/// <para>Feature introduced in DataMiner 10.1.2 (RN 28132).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// if (_treeResults?.GetExpanded("treevar").Contains(treeViewItem.KeyValue) == true)
		/// {
		/// 	treeViewItem.ChildItems = new List&lt;TreeViewItem&gt;
		/// 	{
		/// 		// add child items
		/// 	};
		/// }
		/// </code>
		/// </example>
		public string[] GetExpanded(string key)
		{
			return new string[0];
		}

		/// <summary>
		/// Gets the string value from the specified destination variable that is linked to a dialog box item (typically a text box).
		/// </summary>
		/// <param name="key">The name of the destination variable.</param>
		/// <returns>The string value from the specified destination variable that is linked to a dialog box item.</returns>
		/// <example>
		/// <code>
		/// UIResults uir = null;
		/// ...
		/// UIBlockDefinition blockItem = new UIBlockDefinition();
		/// blockItem.Type = UIBlockType.TextBox;
		/// blockItem.DestVar = "myText";
		/// ...
		/// uibDialogBox1.AppendBlock(blockItem);
		/// ...
		/// uir = engine.ShowUI(uibDialogBox1);
		/// string enteredText = uir.GetString("myText");
		/// </code>
		/// </example>
		public string GetString(string key) { return ""; }

		/// <summary>
		/// Retrieves the selected upload file path.
		/// </summary>
		/// <param name="key">The key of the file selection UI component to retrieve the selected upload file paht from.</param>
		/// <returns>The selected upload file path. If the specified key was not found, <see langword="null"/> is returned.</returns>
		/// <remarks>
		/// <para>When you have selected a file, the actual upload will only start after you click a button to 		make the script continue (e.g.Close, Next, etc.). Once the upload has started, a Cancel option will appear, allowing you to abort the upload operation.</para>
		/// <para>All files uploaded by users will by default be placed in the C:\Skyline DataMiner\TempDocuments folder, which is automatically cleared at every DataMiner startup.</para>
		/// <para>Feature introduced in DataMiner 10.0.2 (RN 23950).</para>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBlockDefinition uiBlock = new UIBlockDefinition();
		/// uiBlock.Type = UIBlockType.FileSelector;
		/// uiBlock.DestVar = "varUserUploadedFile";
		/// ...
		/// UIResults results = engine.ShowUI(uiBuilder);
		/// string uploadedFilePath = results.GetUploadedFilePath("varUserUploadedFile");
		/// </code>
		/// </example>
		/// <remarks>
		/// <note type="note">All files uploaded by users will by default be placed in the C:\Skyline DataMiner\TempDocuments folder, which is automatically cleared at every DataMiner startup.</note>
		/// <note type="tip">See also: <see cref="UIBlockType.FileSelector"/>.</note>
		/// </remarks>
		public string GetUploadedFilePath(string key)
		{
			return this.GetString(key);
		}

		/// <summary>
		/// Returns a value indicating whether the user clicked the <c>Back</c> button.
		/// </summary>
		/// <returns><c>true</c> if the user clicked the <c>Back</c> button; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Only applicable for scripts that support this feature.</para>
		/// <note type="note">To enable the Back and Forward buttons, from the General Page in the Automation App, expand Show Details and check the "Supports back/forward buttons in interactive mode" checkbox.</note>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// ...	
		/// UIResults uir = engine.ShowUI(uib);
		/// 
		/// if (uir.WasBack())
		/// {
		///		...
		///	}
		/// </code>
		/// </example>
		public bool WasBack() { return false; }

		/// <summary>
		/// Returns a value indicating whether a specific button was clicked.
		/// </summary>
		/// <param name="key">The destination variable that is linked to the button.</param>
		/// <returns><c>true</c> if the button was clicked; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// UIResults uir = null;
		/// do
		/// {
		///		UIBuilder uib = new UIBuilder();
		///		uib.RequireResponse = true;
		///		uib.Width = 800;
		///		uib.Height = 600;
		///		uib.RowDefs = "100;100;100";
		///		uib.ColumnDefs="100;100;100";
		///		
		///		UIBlockDefinition blockButton = new UIBlockDefinition();
		///		blockButton.Type = UIBlockType.Button;
		///		blockButton.Text = "Go";
		///		blockButton.DestVar = "buttonGo";
		///		blockButton.Row = 0;
		///		blockButton.Column = 0;
		///		
		///		uib.AppendBlock(blockButton);
		///		
		///		uir = engine.ShowUI(uib);
		///	} while (!uir.WasButtonPressed("buttonGo"));
		/// </code>
		/// </example>
		public bool WasButtonPressed(string key) { return false; }

		/// <summary>
		/// Returns a value indicating whether the user clicked the <c>Forward</c> button.
		/// </summary>
		/// <returns><c>true</c> if the user clicked the <c>Forward</c> button; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Only applicable for scripts that support this feature.</para>
		/// <note type="note">To enable the Back and Forward buttons, from the General Page in the Automation App, expand Show Details and check the "Supports back/forward buttons in interactive mode" checkbox.</note>
		/// </remarks>
		/// <example>
		/// <code>
		/// UIBuilder uib = new UIBuilder();
		/// ...	
		/// UIResults uir = engine.ShowUI(uib);
		/// 
		/// if (uir.WasForward())
		/// {
		///		...
		///	}
		/// </code>
		/// </example>
		public bool WasForward() { return false; }

		/// <summary>
		/// Returns a value indicating whether the user changed the value of a specific dialog box item.
		/// </summary>
		/// <param name="key">The destination variable that is linked to the specific dialog box item.</param>
		/// <returns><c>true</c> if the user changed the value; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// UIResults uir = null;
		/// do
		/// {
		///		UIBuilder uib = new UIBuilder();
		///		uib.RequireResponse = true;
		///		uib.Width = 800;
		///		uib.Height = 600;
		///		uib.RowDefs = "100;100;100";
		///		uib.ColumnDefs="100;100;100";
		///		
		///		UIBlockDefinition blockCheckBox = new UIBlockDefinition();
		///		blockCheckBox.Type = UIBlockType.CheckBox;
		///		blockCheckBox.WantsOnChange = true;
		///		blockCheckBox.DestVar = "myCheckBox";
		///		blockCheckBox.Row = 0;
		///		blockCheckBox.Column = 0;
		///		uib.AppendBlock(blockCheckBox);
		///		
		///		UIBlockDefinition blockButton = new UIBlockDefinition();
		///		blockButton.Type = UIBlockType.Button;  
		///		blockButton.Text = "Next";
		///		blockButton.DestVar = "buttonNext";
		///		blockButton.Row = 1;
		///		blockButton.Column = 0;	
		///		uib.AppendBlock(blockButton);  
		///		
		///		uir = engine.ShowUI(uib);
		///		} while (!uir.WasOnChange("myCheckBox"));
		/// </code>
		/// </example>
		/// <remarks>
		/// <para>Use this method to check whether or not the user changed the value of a particular dialog box item:</para>
		/// <list type="bullet">
		/// <item><description>Did the user enter text in a text box?</description></item>
		/// <item><description>Did the user select a value in a selection box?</description></item>
		/// <item><description>Did the user specify a date/time in a calendar item?</description></item>
		/// <item><description>...</description></item>
		/// </list>
		/// <note type="note">
		/// For a .WasOnChange to work, you have to put .WantsOnChange to true. See the example.
		/// </note>
		/// </remarks>
		public bool WasOnChange(string key) { return false; }
		
		/// <summary>
		/// Returns true if a dialog box item with the given destination variable and with the property WantsOnFocusLoss set to true has lost focus.
		/// </summary>
		/// <param name="key">The destination variable that is linked to the specific dialog box item.</param>
		/// <returns><c>true</c> if the dialog box item has lost focus; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <note type="note">
		/// For this method ever to return true, you have to set .WantsOnFocusLoss to true.
		/// </note>
		/// </remarks>
		public bool WasOnFocusLost(string key) { return false; }
		
		
		/// <summary>
		/// Returns true if a download button with the given destination variable and with the property ReturnWhenDownloadIsStarted on the AutomationDownloadButtonOptions set to true has started the file download.
		/// </summary>
		/// <param name="key">The destination variable that is linked to the specific download button.</param>
		/// <returns><c>true</c> if the download button has started the download; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <note type="note">
		/// For this method ever to return true, you have to set .ReturnWhenDownloadIsStarted to true on the AutomationDownloadButtonOptions, in the ConfigOptions of the UIBlockDefinition.
		/// </note>
		/// <note type="note">
		/// Once the download is started, the control is given to the browser, so there is no way to know when the download is finished.
		/// </note>
		/// </remarks>
		public bool WasOnDownloadStarted(string key) { return false; }
	}
}

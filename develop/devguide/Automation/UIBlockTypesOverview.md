---
uid: UIBlockTypesOverview
---

# UIBlockType overview

> [!TIP]
> We highly recommend that you use the [Interactive Automation Script Toolkit](xref:Interactive_Automation_Script_Toolkit).
> For more information, see [Getting started with the IAS Toolkit](xref:Getting_Started_with_the_IAS_Toolkit).

The [UIBlockType](xref:Skyline.DataMiner.Automation.UIBlockType) enum defines different types of UI components.

| Name | Description |
|---|---|
| [Button](#button) | Button. |
| [Calendar](#calendar) | Calendar control. |
| [CheckBox](#checkbox) | Checkbox. |
| [CheckBoxList](#checkboxlist) | Checkbox list. |
| [DownloadButton](#downloadbutton) | Download button. |
| [DropDown](#dropdown) | Dropdown list. |
| [Executable](#executable) | Executable. |
| [FileSelector](#fileselector) | File selector. |
| [Numeric](#numeric) | Numeric. |
| [Parameter](#parameter) | Text displaying the value of a parameter. |
| [PasswordBox](#passwordbox) | Password input box. |
| [RadioButtonList](#radiobuttonlist) | Radio button list. |
| [StaticText](#statictext) | Static text. |
| [TextBox](#textbox) | Text box. |
| [Time](#time) | Item that displays a time value. |
| [TreeView](#treeview) | Tree view control. |

## UIBuilder

To create these UI blocks, a UIBuilder should be defined with *Width*, *RowDefs*, and *ColumnDefs*.

```csharp
var uiBuilder = new UIBuilder() { Width = 800, RowDefs = "auto;auto", ColumnDefs = "auto;auto" };
uiBuilder.RequireResponse = true;

//Add UI blocks here

var results = engine.ShowUI(uiBuilder);
```

## Getting input

Some of these UI blocks use the [DestVar](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_DestVar) property to read out input. To get the input of that property, use *GetString()*.

```C#
var input = results.GetString("destVarName")
```

## Button

Allows you to define a button.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.Button,
  Text = "Enter",
  DestVar = "ButtonVar"
};
uiBuilder.AppendBlock(blockItem);

uiBuilder.RequireResponse = true;

var results = engine.ShowUI(uiBuilder);

if (results.WasButtonPressed("ButtonVar"))
{
  //Do something
}
```

## Calendar

Allows you to define a calendar control.

To have a certain initial value in the calendar, use the [InitialValue](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_InitialValue) property. In the *Calendar* UIBlockType, the value is expected to be a string in the "(dd/MM/yyyy HH:mm:ss)" format.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.Calendar,
  InitialValue = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
  DestVar = "InputCalendar",
  Row = 1,
  Column = 0,
};
uiBuilder.AppendBlock(blockItem);
```

## CheckBox

Allows you to define a checkbox.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.CheckBox,
  Text = "Option1",
  Row = 1,
  Column = 1
};
uiBuilder.AppendBlock(blockItem);
```

> [!NOTE]
> To check if the user selected the checkbox, use [GetChecked](xref:Skyline.DataMiner.Automation.UIResults#Skyline_DataMiner_Automation_UIResults_GetChecked_System_String_).

## CheckBoxList

Allows you to define a list of checkboxes.

It is possible to differentiate between the raw value and display value for the options. The display value is the text the UI will show for the option, and the raw value is the value used to set checkboxes as selected by default using [InitialValue](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_InitialValue).

Example:

```csharp
var checkBoxList = new UIBlockDefinition
{
  Type = UIBlockType.CheckBoxList,
  Row = 0,
  Column = 3,
  DestVar = "list"
};
checkBoxList.AddCheckBoxListOption("Option1");
checkBoxList.AddCheckBoxListOption("2", "Option2");  //(raw value, display value)
checkBoxList.AddCheckBoxListOption("3", "Option3"); 
checkBoxList.InitialValue = "2;3";
uiBuilder.AppendBlock(checkBoxList);
```

> [!NOTE]
> To read out which boxes are selected, use [GetChecked](xref:Skyline.DataMiner.Automation.UIResults#Skyline_DataMiner_Automation_UIResults_GetChecked_System_String_) with the *DestVar* of the *CheckBoxList* and the raw value of the option
>
> ```csharp
> var results = engine.ShowUI(uiBuilder);
> 
> bool ticked = results.GetChecked("list","2");
> ```

## DownloadButton

Allows you to define a download button. Available from DataMiner 10.3.7/10.4.0 onwards.<!-- RN 35869 -->

Example:

```csharp
var downloadButtonOptions = new AutomationDownloadButtonOptions()
{
   URL = @"/Documents/DMA_COMMON_DOCUMENTS/DailyReport.pdf", // The URL to the file, which can be an absolute URL or a relative URL to the DMA hostname.
   StartDownloadImmediately = false, // If set to true (the default is false), the download will start immediately when the component is displayed.
   ReturnWhenDownloadIsStarted = false, // If set to true (the default is false), the engine.ShowUI() method will return as soon as the download is started.
   FileNameToSave = "Report.PDF", // The file name that will be saved. By default, this is the same as the file name of the document.
};
UIBlockDefinition blockItem = new UIBlockDefinition
{
   Type = UIBlockType.DownloadButton,
   Width = 125,
   Text = "Get report of today",
   Style = Style.Button.CallToAction,
   ConfigOptions = downloadButtonOptions,
};
uiBuilder.AppendBlock(blockItem);
```

> [!NOTE]
>
> - This download button is currently only supported in Automation scripts used in the DataMiner web apps (e.g. Dashboards or Low-Code Apps).
> - The URL is used as the content of the `href` property in an A-HTML element (after sanitizing for security). For more information on how to build valid URLs, see <https://www.w3schools.com/html/html_filepaths>. The most common use cases are:
>   - An absolute URL to a file, for example: `https://dataminer.services/install/DataMinerCube.exe`
>   - A relative URL, relative to the DMA hostname, for example: `/Documents/General Documents/myfile.txt`

## DropDown

Allows you to define a selection box.

Example:

```csharp
var dropDownOptions = new List<string>{ "1", "2", "3", "4", "5" };
var initialValue = "--Select--";
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.DropDown,
  Text = "DropDown1",
  InitialValue = initialValue,
  Row = 1,
  Column = 1, 
  Width = 200
};

foreach (string dropDownOption in dropDownOptions)
{
  blockItem.AddDropDownOption(dropDownOption);
}

uiBuilder.AppendBlock(blockItem);
```

## Executable

Allows you to run a program execution. To do this, you must fill in the property *Extra* with the name of the program you want to execute.
You can also specify arguments when launching a program execution. To do so, call the method *AddDropDownOption* on the item with key *Arguments*, using the arguments you want to pass on as the value.

Examples:

- Open the program Notepad++ on the client device where the interactive script is running.

  ```csharp
  UIBlockDefinition blockItem = new UIBlockDefinition();
  blockItem.Type = UIBlockType.Executable;
  blockItem.Extra = "notepad++.exe";
  ...
  uiBuilder.AppendBlock(blockItem);
  ```

- Open a file with Notepad on the client device where the interactive script is running.

  ```csharp
  UIBlockDefinition blockItem = new UIBlockDefinition();
  blockItem.Type = UIBlockType.Executable;
  blockItem.Extra = "notepad.exe";
  blockItem.AddDropDownOption("Arguments", @"C:\Skyline DataMiner\Files\VersionCompatibility.txt");
  ...
  uiBuilder.AppendBlock(blockItem);
  ```

> [!NOTE]
> Automation scripts with an executable component are currently only supported in DataMiner Cube. These are not supported in DataMiner web apps.

## FileSelector

Allows you to define a file selector control.

Available from DataMiner 10.0.0/10.0.2 onwards.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.FileSelector,
  DestVar = "varUserUploadedFile",
  Row = 1,
  Column = 1
};
uiBuilder.AppendBlock(blockItem);
```

When the UI is then shown using *Engine#ShowUI(...)*, *UIResults* will contain the path to the file:

```csharp
UIResults results = engine.ShowUI(uiBuilder);
string uploadedFilePath = results.GetUploadedFilePath("varUserUploadedFile");
```

When you have selected a file, the actual upload will only start after you click a button to make the script continue (e.g. *Close*, *Next*, etc.). Once the upload has started, a *Cancel* option will be available.

All files uploaded by users will by default be placed in the *C:\\Skyline DataMiner\\TempDocuments* folder, which is automatically cleared at every DataMiner startup.

> [!TIP]
> See also: [GetUploadedFilePath](xref:Skyline.DataMiner.Automation.UIResults#Skyline_DataMiner_Automation_UIResults_GetUploadedFilePath_System_String_)

## Numeric

Allows you to define a numeric value.

Example of a number range between 0 and 100 with step size of 1 and an initial value of 5:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.Numeric,
  DestVar = "NumericVariable",
  InitialValue = "5",
  RangeHigh = 100,
  RangeLow = 0,
  RangeStep = 1,
  Row = 1,
  Column = 1
};
uiBuilder.AppendBlock(blockItem);
```

The initial value has to be a string of an integer or have the following format:

```csharp
[DoubleValue];[Boolean];[SelectedDiscreetString]
```

- DoubleValue: Value of the numeric box.
- Boolean: Indicates whether the discrete checkbox is selected (=true) or cleared (=false).
- SelectedDiscreetString: selects the discrete parameter with that exact name in case multiple discrete parameters are defined.

Example:

```csharp
string sel_numericValue = "23.567891;true;Discreet 2";
```

If you want a checkbox with one or more discrete values, then use the *Extra* property to specify a list of discrete values (separated by semicolons). If you only want a numeric box and no checkbox, then leave the *Extra* property empty. In that case, just set the initial value to the DoubleValue.

If you set the *WantsOnChange* property to "true", then both the checkbox and the discrete combo box will trigger a change.

Optionally you can provide a RangeHigh (maximum value), a RangeLow (minimum value), a RangeStep (increment or decrement steps) and the number of decimals.

Full example:

```csharp
string sel_numericValue = "23.567891;true;Discreet 2";
UIBlockDefinition numericBlock = new UIBlockDefinition();
numericBlock.Type = UIBlockType.Numeric;
numericBlock.InitialValue = sel_numericValue;
numericBlock.DestVar = "num";
numericBlock.WantsOnChange = true;
numericBlock.Row = 0;
numericBlock.Column = 1;
numericBlock.HorizontalAlignment = "Center";
numericBlock.VerticalAlignment = "Top";
numericBlock.RangeHigh = 300;
numericBlock.RangeLow = 5;
numericBlock.RangeStep = 5;
numericBlock.Decimals = 6;
numericBlock.Extra = "Discreet 1;Discreet 2;Discreet 3";
uiBuilder.AppendBlock(numericBlock);
```

> [!NOTE]
> From DataMiner 9.5.5 onwards, you can specify the WantsOnChange property to have a small delay before a change is triggered by the numeric box itself, in order to avoid updates being sent as soon as a single character is changed in the numeric box. See [WantsOnChange](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_WantsOnChange).

## Parameter

Allows you to define a text item displaying the value of a parameter.

In the [Extra](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_Extra) property, enter the information to find the parameter.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.Parameter,
  DestVar = "Input",
  InitialValue = initialValue,
  WantsOnChange = true,
  DisplayFilter = true,
  Extra = $"{dmaID}/{elementID}:{parameterID}"
};
uiBuilder.AppendBlock(blockItem);
```

## PasswordBox

Allows you to define a password box. Available from DataMiner 9.6.6 onwards.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.PasswordBox,
  DestVar = "Password",
  HasPeekIcon = true,
  Row = 1,
  Column = 1
};
uiBuilder.AppendBlock(blockItem);
```

Optionally, you can set the *HasPeekIcon* property to display an icon that, when clicked, will allow you to display the value inside the password box. See [HasPeekIcon](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_HasPeekIcon).

## RadioButtonList

Allows you to define a radio button list. Available from DataMiner 9.6.6 onwards.

It is possible to differentiate between the raw value and display value for the options. The display value is the text the UI will show for the option, and the raw value is the value used to have a radio button selected by default using [InitialValue](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_InitialValue).

Example:

```csharp
var radioButtonListItems = new List<string> { "Option 1", "Option 2", "Option 3" };

UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.RadioButtonList,
  DestVar = "ChoiceOption",
  Row = 1,
  Column = 1,
  WantsOnChange = true,
  DisplayFilter = true,
};

foreach (string item in radioButtonListItems)
{
  blockItem.AddRadioButtonListOption(item);
}

blockItem.AddRadioButtonListOption("4", "Option4"); //(raw value, display value)
blockItem.InitialValue = "4";

uiBuilder.AppendBlock(blockItem);
```

> [!NOTE]
>
> - To read out which option is selected, use [GetChecked](xref:Skyline.DataMiner.Automation.UIResults#Skyline_DataMiner_Automation_UIResults_GetChecked_System_String_) with the *DestVar* of the *RadioButtonList* and the raw value of the option.
>
>   ```csharp
>   var results = engine.ShowUI(uiBuilder);
>   
>   bool ticked = results.GetChecked("ChoiceOption","4");
>   ```
>
> - If no initial value is passed to this list, no radio button will be selected by default.

## StaticText

Allows you to define a text item displaying a piece of fixed text.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.StaticText,
  Text = "Static Text",
  Row = 1,
  Column = 1
};
uiBuilder.AppendBlock(blockItem);
```

## TextBox

Allows you to define a box into which a user can enter a piece of text.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.TextBox,
  DestVar = "InputText",
  InitialValue = "Default text",
  Row = 1,
  Column = 1
};
uiBuilder.AppendBlock(blockItem);
```

> [!NOTE]
> From DataMiner 9.5.3 onwards, this control can be used with a “WantsOnChange” property, which prevents updates being sent after a single character is changed in a text box. See [WantsOnChange](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_WantsOnChange).

## Time

Allows you to define an item displaying a time value.

In the [ConfigOptions](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_ConfigOptions), you can define the minimum and maximum time range.

In this example, a time span block is created with a minimum of 1 hour and a maximum of 2 days:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.Time,
  DestVar = "InputText",
  InitialValue = "12:25:30",
  Row = 1,
  Column = 1,
  ConfigOptions = new AutomationTimeUpDownOptions()
  {
    Minimum = TimeSpan.FromHours(1),
    Maximum = TimeSpan.FromDays(2)
  }
};
uiBuilder.AppendBlock(blockItem);
```

> [!NOTE]
>
> - From DataMiner 9.5.3 onwards, additional classes are available to define controls to select the date and/or time. See [AutomationConfigOptions class](xref:Skyline.DataMiner.Automation.AutomationConfigOptions).
> - When the initial value of the time span exceeds 24 hours, an extra digit will be displayed that represents the days. This digit is by default hidden. You can also make it show up by using the up button of the spinner or pressing the Up arrow key on your keyboard when the current time span is 23:59:59.
> - The `AutomationTimeUpDownOptions` property `AllowSpin` is not supported in the Low-Code Apps.
> - The `AutomationTimeUpDownOptions` property `UpdateValueOnEnter` is not supported in Cube.
> - The `AutomationTimeUpDownOptions` property `FractionalSecondsDigitsCount` is only supported in Cube and should be within a range of 0 to 3.
> - From DataMiner 10.3.0 [CU1]/10.3.4 onwards, the `ShowTimeUnits` property is available. When this property is set to *true*, the component will display labels indicating the days, hours, minutes and seconds. By default, this property is set to *false*. The `ShowTimeUnits` property is only supported in the DataMiner web apps and not in DataMiner Cube. <!-- RN 35435 -->
> - When the initial value is set to an empty string or null, a default value of one hour will be displayed in Cube. In the Low-Code Apps, zero (00:00:00) will be displayed.
> - The time span values are returned in the constant invariant format (e.g. "3.17:25:30.5569124").

## TreeView

Allows you to define a tree view. Available from DataMiner 10.0.10 onwards.

To define a tree view control, create a *UIBlockDefinition* of type *TreeView* and add each item of the tree view as a *TreeViewItem* to the *TreeViewItems* property. It is not required to fill in the *InitialValue* or *Value* of the *UIBlockDefinition*, as that value is determined based on the *TreeViewItem* collection.

Optionally, you can enable the *WantsOnChange* option for the tree view control, in which case it will send an update each time the selected state of a *TreeViewItem* changes. See [WantsOnChange](xref:Skyline.DataMiner.Automation.UIBlockDefinition#Skyline_DataMiner_Automation_UIBlockDefinition_WantsOnChange).

To retrieve the results:

- The *UIResult*, which can be returned using *engine.ShowUI()*, contains the *KeyValue* of the selected items.
- The *GetString(UIBlockDefinition destvar)* method to retrieve a semicolon-separated string of the *KeyValues*.
- The *GetChecked(UIBlockDefinition destvar, KeyValue value)* method can be used to check if a specific *KeyValue* was selected.

Make sure to add "using Skyline.DataMiner.Net.AutomationUI.Objects;" at the top of your script, it is required for *TreeViewItem*.

> [!NOTE]
> Automation scripts with tree view controls are currently only supported in the DataMiner web apps. These are not yet supported in DataMiner Cube.

Example:

```csharp
UIBlockDefinition blockItem = new UIBlockDefinition
{
  Type = UIBlockType.TreeView,
  DestVar = "TreeVar",
  Row = 1,
  Column = 1,
  TreeViewItems =
    new List<TreeViewItem>
    {
      new TreeViewItem("Core Teams", "1", new List<TreeViewItem>
      {
        new TreeViewItem("Team A", "1/1", new List<TreeViewItem>
        {
          new TreeViewItem("Brian", "1/1/1", true) { ItemType = TreeViewItem.TreeViewItemType.CheckBox },
          new TreeViewItem("John", "1/1/2"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
          new TreeViewItem("Kevin", "1/1/3", true){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
          new TreeViewItem("David", "1/1/4"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
          new TreeViewItem("Joe", "1/1/5", true){ ItemType = TreeViewItem.TreeViewItemType.CheckBox }
        }){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
        new TreeViewItem("Team B", "1/2", new List<TreeViewItem>
        {
          new TreeViewItem("Jane", "1/2/1"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
          new TreeViewItem("Sarah", "1/2/2"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
          new TreeViewItem("Emely", "1/2/3"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
          new TreeViewItem("Anne", "1/2/4"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
          new TreeViewItem("Florence", "1/2/5"){ ItemType = TreeViewItem.TreeViewItemType.CheckBox }
        }) { ItemType = TreeViewItem.TreeViewItemType.CheckBox }
      }){ ItemType = TreeViewItem.TreeViewItemType.CheckBox },
      new TreeViewItem("Team C", "2") { ItemType = TreeViewItem.TreeViewItemType.CheckBox }
    }
};
uiBuilder.AppendBlock(blockItem);
```

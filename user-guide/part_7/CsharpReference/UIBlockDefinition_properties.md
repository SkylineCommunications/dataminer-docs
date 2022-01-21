---
uid: UIBlockDefinition_properties
---

## UIBlockDefinition properties

- [AllowedFileNameExtensions](#allowedfilenameextensions)

- [AllowMultipleFiles](#allowmultiplefiles)

- [Column](#column)

- [ColumnSpan](#columnspan)

- [ConfigOptions](#configoptions)

- [Decimals](#decimals)

- [DestVar](#destvar)

- [DisplayFilter](#displayfilter)

- [Extra](#extra)

- [HasPeekIcon](#haspeekicon)

- [Height](#height)

- [HorizontalAlignment](#horizontalalignment)

- [InitialValue](#initialvalue)

- [IsEnabled](#isenabled)

- [IsMultiline](#ismultiline)

- [IsRequired](#isrequired)

- [IsSorted](#issorted)

- [Margin](#margin)

- [MaxFileSizeInBytes](#maxfilesizeinbytes)

- [MaxHeight](#maxheight)

- [MaxWidth](#maxwidth)

- [MinHeight](#minheight)

- [MinWidth](#minwidth)

- [PlaceholderText](#placeholdertext)

- [RangeHigh](#rangehigh)

- [RangeLow](#rangelow)

- [RangeStep](#rangestep)

- [Row](#row)

- [RowSpan](#rowspan)

- [Style](#style)

- [Text](#text)

- [Title](#title)

- [TooltipText](#tooltiptext)

- [Type](#type)

- [TreeViewItems](#treeviewitems)

- [ValidationState](#validationstate)

- [ValidationText](#validationtext)

- [VerticalAlignment](#verticalalignment)

- [WantsOnChange](#wantsonchange)

- [WantsOnFocusLost](#wantsonfocuslost)

- [Width](#width)

#### AllowedFileNameExtensions

Gets or sets the allowed file name extensions. Available from DataMiner 10.1.12 onwards.

```txt
List<string> AllowedFileNameExtensions
```

Example:

```txt
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
uibDef.AllowedFileNameExtensions = new List<string>() { ".txt", ".csv" };
```

> [!NOTE]
> In Automation scripts launched from web apps, the *MaxFileSizeInBytes* and *AllowedFileNameExtensions* properties of *UIBlockDefinitions* of type *FileSelector* are taken into account from DataMiner 10.1.12 onwards.
>
> An error will be thrown when you try to add a file that is larger than the allowed file size or that does not have an allowed file name extension. Also, the "Choose file" pop-up window will only list files with an allowed extension and dragging an item other than a file or a folder onto the script's drop zone will no longer be possible.

#### AllowMultipleFiles

Gets or sets a value indicating whether multiple files can be uploaded. Available from DataMiner 10.1.8/10.2.0 onwards.

In an interactive Automation script that is used in the DataMiner web apps, you can use this property to configure a file selector component that allows the user to upload multiple files. To do so, set the property *AllowMultipleFiles* to true.

With this configuration, users will be able to add files one by one, but they will not be able to add the same file twice. They will also be able to add a file by dragging it to the file selector.

UIBlockType: *FileSelector*

```txt
bool AllowMultipleFiles
```

Example:

```txt
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
uibDef.DestVar = destvar;
uibDef.InitialValue = initialValue;
uibDef.Row = (int)row;
uibDef.RowSpan = (int)rowSpan;
uibDef.Column = (int)column;
uibDef.ColumnSpan = (int)columnSpan;
uibDef.HorizontalAlignment = GetHorizontalAlignment(horizontalAlignment);
uibDef.VerticalAlignment = GetVerticalAlignment(verticalAlignment);
uibDef.AllowMultipleFiles = true;
```

#### Column

Gets or sets the zero-based index of the column in which the dialog box item has to be placed.

UIBlockType: *All*

```txt
int Column
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.Column = 1; //Text box situated in second column from the left

uibDialogBox1.AppendBlock(blockItem);
```

#### ColumnSpan

Gets or sets the number of joining columns the dialog box item is allowed to occupy.

UIBlockType: *All*

```txt
int ColumnSpan
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.Column = 1;
blockItem.ColumnSpan = 2;

uibDialogBox1.AppendBlock(blockItem);
```

#### ConfigOptions

Used with a UIBlockType Time to get or set the configuration options.

UIBlockType: *Time*

```txt
AutomationConfigOptions ConfigOptions
```

> [!TIP]
> See also:
> [AutomationConfigOptions class](AutomationConfigOptions_class.md)

Example:

```txt
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.Time;
uibDef.InitialValue = DateTime.Now.ToString("G");

var config = new AutomationDateTimePickerOptions();
config.Format = DateTimeFormat.ShortDate;

uibDef.ConfigOptions = config;
```

#### Decimals

Gets or sets the number of decimals to show.

UIBlockType: [Numeric](UIBlockType_enumeration.md#numeric)

```txt
int Decimals
```

Example:

```txt
UIBlockDefinition numericBlock = new UIBlockDefinition();

numericBlock.Type = UIBlockType.Numeric;
numericBlock.InitialValue = "10;true;Discreet 2";
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

uib.AppendBlock(numericBlock);
```

#### DestVar

Gets or sets the alias that will be used to retrieve the value entered or selected by the user from the *UIResults* object.

> [!NOTE]
> Unlike a variable, a *DestVar* alias does not have to be declared.

UIBlockType:

- [Button](UIBlockType_enumeration.md#button)

- [Calendar](UIBlockType_enumeration.md#calendar)

- [CheckBox](UIBlockType_enumeration.md#checkbox)

- [CheckBoxList](UIBlockType_enumeration.md#checkboxlist)

- [DropDown](UIBlockType_enumeration.md#dropdown)

- [TextBox](UIBlockType_enumeration.md#textbox)

- [Time](UIBlockType_enumeration.md#time)

- [TreeView](UIBlockType_enumeration.md#treeview)

```txt
string DestVar
```

Example:

```txt
UIResults uir = null;
string enteredText = "";

UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;

blockItem.DestVar = "myText";

uibDialogBox1.AppendBlock(blockItem);

uir = engine.ShowUI(uibDialogBox1);
enteredText = uir.GetString("myText");
```

#### DisplayFilter

Gets or sets a value indicating whether a filter box is available for the control.

Available from DataMiner 9.5.6 onwards.

Default: False.

UIBlockType: [DropDown](UIBlockType_enumeration.md#dropdown)

```txt
bool DisplayFilter
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.DropDown;
blockItem.DisplayFilter = true;

uibDialogBox1.AppendBlock(blockItem);
```

#### Extra

Gets or sets the ID of the parameter that has to be displayed in the dialog box item.

UIBlockType:

- [Numeric](UIBlockType_enumeration.md#numeric)

- [Parameter](UIBlockType_enumeration.md#parameter)

```txt
string Extra
```

> [!NOTE]
> - For a dialog box item of type *Numeric*, this property allows to have a checkbox with multiple discrete values. In case multiple discrete values are defined, separate these with a semicolon (';'). If you do not want any checkbox, but only the numeric box, then leave this property empty.
> - For a dialog box item of type *Parameter*, the ID syntax is as follows:<br>DmaID/ElementID:ParamID\[:index\]

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.Parameter;
blockItem.Extra = "7/253:83";

uibDialogBox1.AppendBlock(blockItem);
```

#### HasPeekIcon

Gets or sets a value indicating whether the password box shows an icon that, when clicked, will allow you to display the value inside the password box. Available from DataMiner 9.6.6 onwards.

*true* if the peek icon is displayed, otherwise *false*.

UIBlockType: [PasswordBox](UIBlockType_enumeration.md#passwordbox)

```txt
bool HasPeekIcon
```

Example:

```txt
blockPasswordBox.HasPeekIcon = allowPeek;
```

#### Height

Gets or sets the fixed height (in pixels) of the dialog box item.

> [!NOTE]
> To make sure the dialog box can be displayed optimally, we advise to use a minimum and maximum height instead of a fixed height (see [MaxHeight](#maxheight) and [MinHeight](#minheight)).

UIBlockType: *All*

```txt
int Height
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.Height = 100;

uibDialogBox1.AppendBlock(blockItem);
```

#### HorizontalAlignment

Gets or sets the horizontal alignment of the dialog box item: “Center”, “Left”, “Right” or “Stretch”

UIBlockType: *All*

```txt
string HorizontalAlignment
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.HorizontalAlignment = "Left";

uibDialogBox1.AppendBlock(blockItem);
```

#### InitialValue

Gets or sets the value that will be assigned to the dialog box item the moment the dialog box opens.

UIBlockType: *All*

```txt
string InitialValue
```

> [!NOTE]
> - For a dialog box item of type *CheckBoxList*, you can specify several values separated by semicolons.
> - For a dialog box item of type Numeric, the initial value has to be of format "*DoubleValue;Boolean;SelectedDiscreetString*". The DoubleValue contains the value of the numeric box. The Boolean ("true" or "false") determines whether the discreet checkbox is checked (true) or unchecked (false). The SelectedDiscreetString selects the discreet with that exact name in case multiple discrete values are defined. If case you only want to visualize the numeric box, it is sufficient to only specify the DoubleValue.

Example:

```txt
UIBlockDefinition blockCalendar = new UIBlockDefinition();
blockCalendar.Type = UIBlockType.Calendar;
DateTime saveNow = DateTime.Now;
blockCalendar.InitialValue = saveNow.ToString("dd/MM/yyyy HH:mm:ss");

uib.AppendBlock(blockCalendar);
```

#### IsEnabled

Gets or sets a value indicating whether the control is enabled in the UI. Default: true.

Available from DataMiner 9.5.3 onwards.

UIBlockType: *All*

```txt
bool IsEnabled
```

#### IsMultiline

Gets or sets a value indicating whether users are able to enter multiple lines of text.

UIBlockType: [TextBox](UIBlockType_enumeration.md#textbox)

```txt
bool IsMultiline
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.IsMultiline = true;

uibDialogBox1.AppendBlock(blockItem);
```

#### IsRequired

Gets or sets a value indicating whether this input control requires a value. Available from DataMiner 10.0.5 onwards. Returns true if a value is required; otherwise returns false.

If this is set to true, the control will be marked as invalid when it is empty.

UIBlockType:

- [Calendar](UIBlockType_enumeration.md#calendar)

- [DropDown](UIBlockType_enumeration.md#dropdown)

- [Numeric](UIBlockType_enumeration.md#numeric)

- [PasswordBox](UIBlockType_enumeration.md#passwordbox)

- [TextBox](UIBlockType_enumeration.md#textbox)

```txt
bool IsRequired
```

#### IsSorted

Gets or sets a value indicating whether items in the control are sorted naturally.

Available from DataMiner 9.5.6 onwards.

Default: False.

UIBlockType:

- [CheckBoxList](UIBlockType_enumeration.md#checkboxlist)

- [DropDown](UIBlockType_enumeration.md#dropdown)

```txt
bool IsSorted
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.DropDown;
blockItem.IsSorted = true;

uibDialogBox1.AppendBlock(blockItem);
```

#### Margin

Gets or sets the margin (in pixels) around the dialog box item.

Default: No margin

UIBlockType: *All*

```txt
string Margin
```

Syntax:

```txt
"Left;Top;Right;Bottom"
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.Margin = "5;5;5;5";

uibDialogBox1.AppendBlock(blockItem);
```

#### MaxFileSizeInBytes

Gets or sets the maximum allowed file size. Available from DataMiner 10.1.12 onwards.

```txt
long MaxFileSizeInBytes
```

Example:

```txt
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
uibDef.MaxFileSizeInBytes = 100000;
```

> [!NOTE]
> In Automation scripts launched from web apps, the *MaxFileSizeInBytes* and *AllowedFileNameExtensions* properties of *UIBlockDefinitions* of type *FileSelector* are taken into account from DataMiner 10.1.12 onwards.
>
> An error will be thrown when you try to add a file that is larger than the allowed file size or that does not have an allowed file name extension. Also, the "Choose file" pop-up window will only list files with an allowed extension and dragging an item other than a file or a folder onto the script's drop zone will no longer be possible.

#### MaxHeight

Gets or sets the maximum height (in pixels) of the dialog box item.

UIBlockType: *All*

```txt
int MaxHeight
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.MaxHeight = 100;

uibDialogBox1.AppendBlock(blockItem);
```

#### MaxWidth

Gets or sets the maximum width (in pixels) of the dialog box item.

UIBlockType: *All*

```txt
int MaxWidth
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.MaxWidth = 100;

uibDialogBox1.AppendBlock(blockItem);
```

#### MinHeight

Gets or sets the minimum height (in pixels) of the dialog box item.

UIBlockType: *All*

```txt
int MinHeight
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.MinHeight = 100;

uibDialogBox1.AppendBlock(blockItem);
```

#### MinWidth

Gets or sets the minimum width (in pixels) of the dialog box item.

UIBlockType: *All*

```txt
int MinWidth
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.MinWidth = 100;

uibDialogBox1.AppendBlock(blockItem);
```

#### PlaceholderText

Gets or sets the placeholder text, i.e. the text that should be displayed as long as the control is empty (e.g. “In this box, enter...”). Available from DataMiner 10.0.5 onwards.

UIBlockType:

- [DropDown](UIBlockType_enumeration.md#dropdown)

- [Numeric](UIBlockType_enumeration.md#numeric)

- [PasswordBox](UIBlockType_enumeration.md#passwordbox)

- [TextBox](UIBlockType_enumeration.md#textbox)

```txt
string PlaceholderText
```

#### RangeHigh

Gets or sets the maximum value of the range.

UIBlockType: [Numeric](UIBlockType_enumeration.md#numeric)

```txt
double RangeHigh
```

Example:

```txt
UIBlockDefinition numericBlock = new UIBlockDefinition();

numericBlock.Type = UIBlockType.Numeric;
numericBlock.InitialValue = "10;true;Discreet 2";
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

uib.AppendBlock(numericBlock);
```

#### RangeLow

Gets or sets the minimum value of the range.

UIBlockType: [Numeric](UIBlockType_enumeration.md#numeric)

```txt
double RangeLow
```

Example:

```txt
UIBlockDefinition numericBlock = new UIBlockDefinition();

numericBlock.Type = UIBlockType.Numeric;
numericBlock.InitialValue = "10;true;Discreet 2";
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

uib.AppendBlock(numericBlock);
```

#### RangeStep

Gets or sets the step size.

UIBlockType: [Numeric](UIBlockType_enumeration.md#numeric)

```txt
double RangeStep
```

Example:

```txt
UIBlockDefinition numericBlock = new UIBlockDefinition();

numericBlock.Type = UIBlockType.Numeric;
numericBlock.InitialValue = "10;true;Discreet 2";
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

uib.AppendBlock(numericBlock);
```

#### Row

Gets or sets the zero-based index of the row in which the dialog box item has to be placed.

UIBlockType: *All*

```txt
int Row
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.Row = 2; //Text box situated in third row from the top

uibDialogBox1.AppendBlock(blockItem);
```

#### RowSpan

Gets or sets the number of joining rows the dialog box item is allowed to occupy.

UIBlockType: *All*

```txt
int RowSpan
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.Row = 2; blockItem.RowSpan = 2;

uibDialogBox1.AppendBlock(blockItem);
```

#### Style

Gets or sets the style of the dialog box.

It is possible to add one of three title styles to a text block:

- “Title1” (highest level, all lower case)

- “Title2” (medium level, all upper case)

- “Title3” (lowest level, all upper case)

To set the style of a text block to regular text, leave the style property empty.

UIBlockType: *All*

```txt
UIBlockDefinition PropertiesTitle = new UIBlockDefinition();
PropertiesTitle.Type = UIBlockType.StaticText;
PropertiesTitle.Style = "Title2";
```

#### Text

Gets or sets the text that has to appear in the dialog box item.

UIBlockType:

- [Button](UIBlockType_enumeration.md#button)

- [StaticText](UIBlockType_enumeration.md#statictext)

```txt
string Text
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.Button;
blockItem.Row = 2; blockItem.Text = "OK";

uibDialogBox1.AppendBlock(blockItem);
```

#### Title

Gets or sets the title

```txt
string Title
```

#### TooltipText

Available from DataMiner 10.0.8 onwards. Gets or sets the text of the tooltip for a component of an interactive Automation script. This tooltip is only displayed if the script is run within one of the DataMiner web apps, for example the Jobs app.

UIBlockType: *All*

```txt
string TooltipText
```

Example:

```txt
UIBlockDefinition label3 = new UIBlockDefinition();
label3.Type = UIBlockType.StaticText;
label3.Text = "Drop-down no filter";
label3.Row = 2;
label3.Column = 0;
uib.AppendBlock(label3);
UIBlockDefinition input3 = new UIBlockDefinition();
input3.Type = UIBlockType.DropDown;
input3.AddDropDownOption("1|Option 1");
input3.AddDropDownOption("2|Option 2");
input3.AddDropDownOption("3|Option 3");
input3.ValidationState = UIValidationState.Invalid;
input3.ValidationText = "Validation message...";
input3.IsRequired = true;
input3.Height = 400;
input3.PlaceholderText = "Placeholder message...";
input3.InitialValue = "2";
input3.Row = 2;
input3.Column = 1;
input3.TooltipText = "drop-down no filter - tooltip text";
uib.AppendBlock(input3);
```

#### Type

Gets or sets the *UIBlockType* of the dialog box item. See [UIBlockType enumeration](UIBlockType_enumeration.md).

UIBlockType: *All*

```txt
UIBlockType Type
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;

uibDialogBox1.AppendBlock(blockItem);
```

#### TreeViewItems

Contains each item of the tree view as a TreeViewItem. Available from DataMiner 10.0.10 onwards.

UIBlockType: [TreeView](UIBlockType_enumeration.md#treeview).

```txt
TreeViewItem TreeViewItems
```

Note that a *TreeViewItem* is an object in the *Skyline.DataMiner.Net.AutomationUI.Objects* namespace, with the following properties:

- *ChildItems* (List\<TreeViewITem>): The child items of the tree view item, if any.

- *DisplayValue* (string): The display value of the tree view item.

- *IsChecked* (bool): Indicates whether the tree view item is selected.

- *IsCollapsed* (bool): Indicates whether the tree view item is collapsed. Supported from DataMiner 10.0.13 onwards.

- *ItemType* (TreeViewItemType): The type of tree view item.

- *KeyValue* (string): The key value of the tree view item.

- *SupportsLazyLoading* (bool): Indicates whether the tree view item will only be loaded when a user expands the item by clicking the arrow in front of it. Supported from DataMiner 10.1.2 onwards.

- *CheckingBehavior* (TreeViewItem.TreeViewItemCheckingBehavior): Available from DataMiner 10.1.10/10.2.0 onwards. Configures what happens when you select a tree view item in an interactive Automation script. This property can have one of the following values:

    - *FullRecursion*: All child items will automatically be selected when this item is selected, and vice versa.

    - *None*: Only this item will be selected. The selection state of child items will not change. In addition, if all child items are selected, this tree view item will not be automatically selected.

    Regardless of which type of behavior you choose, if one or more child items of a tree view item are selected, the checkbox of the tree view item will be colored.     Example:

```txt
var treeViewItem = new TreeViewItem("displayValue", "keyValue", false) { CheckingBehavior = TreeViewItem.TreeViewItemCheckingBehavior.None };
```

#### ValidationState

Gets or sets a value indicating the validation state. Available from DataMiner 10.0.5 onwards.

Returns true if the state is valid; otherwise returns false.

UIBlockType:

- [Calendar](UIBlockType_enumeration.md#calendar)

- [DropDown](UIBlockType_enumeration.md#dropdown)

- [FileSelector](UIBlockType_enumeration.md#fileselector)

- [Numeric](UIBlockType_enumeration.md#numeric)

- [PasswordBox](UIBlockType_enumeration.md#passwordbox)

- [TextBox](UIBlockType_enumeration.md#textbox)

```txt
string ValidationState
```

> [!NOTE]
> This property should be used in combination with the *WantsOnChange* property (see [WantsOnChange](#wantsonchange)). If *WantsOnChange* is true, the interactive Automation script will have its ShowUI(String) method return each time the user input changes. This will also be indicated by the \_ONCHANGE key, which is returned in the UIResults. This functionality will allow you to offer clear feedback on user input.

#### ValidationText

Gets or sets the text that will be displayed if *ValidationState* is false. Available from DataMiner 10.0.5 onwards.

UIBlockType:

- [Calendar](UIBlockType_enumeration.md#calendar)

- [DropDown](UIBlockType_enumeration.md#dropdown)

- [FileSelector](UIBlockType_enumeration.md#fileselector)

- [Numeric](UIBlockType_enumeration.md#numeric)

- [PasswordBox](UIBlockType_enumeration.md#passwordbox)

- [TextBox](UIBlockType_enumeration.md#textbox)

```txt
string ValidationText
```

> [!NOTE]
> This property should be used in combination with the *WantsOnChange* property (see [WantsOnChange](#wantsonchange)). If *WantsOnChange* is true, the interactive Automation script will have its ShowUI(String) method return each time the user input changes. This will also be indicated by the \_ONCHANGE key, which is returned in the UIResults. This functionality will allow you to offer clear feedback on user input.

#### VerticalAlignment

Gets or sets the vertical alignment of the dialog box item: “Center”, “Top”, “Bottom” or “Stretch”

UIBlockType: *All*

```txt
string VerticalAlignment
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;
blockItem.VerticalAlignment = "Top";

uibDialogBox1.AppendBlock(blockItem);
```

> [!NOTE]
> If no vertical alignment option is set, by default “Top” alignment is applied.

#### WantsOnChange

Gets or sets a value indicating whether an update of the current value of the dialog box item will trigger an OnChange event.

UIBlockType:

- [Button](UIBlockType_enumeration.md#button)

- [Calendar](UIBlockType_enumeration.md#calendar)

- [CheckBox](UIBlockType_enumeration.md#checkbox)

- [CheckBoxList](UIBlockType_enumeration.md#checkboxlist)

- [DropDown](UIBlockType_enumeration.md#dropdown)

- [Numeric](UIBlockType_enumeration.md#numeric) (from DataMiner 9.5.5 onwards)

- [PasswordBox](UIBlockType_enumeration.md#passwordbox) (from DataMiner 9.6.6 onwards)

- [RadioButtonList](UIBlockType_enumeration.md#radiobuttonlist) (from DataMiner 9.6.6 onwards)

- [TextBox](UIBlockType_enumeration.md#textbox) (from DataMiner 9.5.3 onwards)

- [Time](UIBlockType_enumeration.md#time)

- [TreeView](UIBlockType_enumeration.md#treeview) (from DataMiner 10.0.10 onwards)

> [!NOTE]
> A button will always trigger an OnChange event, regardless of what you specify for the WantsOnChange attribute.

```txt
bool WantsOnChange
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.CheckBox;
blockItem.WantsOnChange = true;

uibDialogBox1.AppendBlock(blockItem);
```

#### WantsOnFocusLost

Available from DataMiner 10.1.10/10.2.0 onwards. Gets or sets a value indicating whether an OnChange event will be triggered when the component loses focus.

```txt
bool WantsOnFocusLost
```

> [!NOTE]
> Applicable only in case *Type* is set to Calendar, CheckBox, CheckBoxList, DropDown, Numeric, PasswordBox, RadioButtonList, TextBox or Time.

#### Width

Gets or sets the fixed width (in pixels) of the dialog box item.

> [!NOTE]
> To make sure the dialog box can be displayed optimally, we advise to use a minimum and maximum width instead of a fixed width (see [MaxWidth](#maxwidth) and [MinWidth](#minwidth)).

UIBlockType: *All*

```txt
int Width
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox; b
lockItem.Width = 100;

uibDialogBox1.AppendBlock(blockItem);
```

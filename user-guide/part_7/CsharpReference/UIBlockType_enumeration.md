# UIBlockType enumeration

Below, you can find an overview of the members of the *UIBlockType* enumeration.

This enum allows you to specify the type of a dialog box item in an interactive Automation script.

| Member name     | Value | Description                                                                                                   |
|-----------------|-------|---------------------------------------------------------------------------------------------------------------|
| Undefined       | 0     | Undefined.                                                                                                    |
| StaticText      | 1     | Static text. See [StaticText](#statictext).                                                                   |
| TextBox         | 2     | Text box. See [TextBox](#textbox).                                                                            |
| DropDown        | 3     | Drop-down list. See [DropDown](#dropdown).                                                                    |
| Button          | 4     | Button. See [Button](#button).                                                                                |
| Variable        | 5     | Variable.                                                                                                     |
| Parameter       | 6     | Text displaying the value of a parameter. See [Parameter](#parameter).                                        |
| CheckBox        | 7     | Checkbox. See [CheckBox](#checkbox).                                                                          |
| Calendar        | 8     | Calender control. See [Calendar](#calendar).                                                                  |
| Time            | 9     | Item that displays a time value. See [Time](#time).                                                           |
| GlobalSettings  | 10    | Global settings.                                                                                              |
| CheckBoxList    | 11    | Checkbox list. See [CheckBoxList](#checkboxlist).                                                             |
| Numeric         | 12    | Numeric. See [Numeric](#numeric).                                                                             |
| Executable      | 13    | Executable.                                                                                                   |
| RadioButtonList | 14    | Available from DataMiner 9.6.6 onwards.<br> Radio button list. See [RadioButtonList](#radiobuttonlist).       |
| PasswordBox     | 15    | Available from DataMiner 9.6.6 onwards.<br> Password box. See [PasswordBox](#passwordbox).                    |
| FileSelector    | 16    | Available from DataMiner 10.0.0/10.0.2 onwards.<br> File selector control. See [FileSelector](#fileselector). |
| TreeView        | 17    | Available from DataMiner 10.0.10 onwards.<br> Tree view control. See [TreeView](#treeview).                   |

#### Button

Allows you to define a newly created dialog box item as a button.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.Button;                  
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

#### Calendar

Allows you to define a newly created dialog box item as a calendar control.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.Calendar;                
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

#### CheckBox

Allows you to define a newly created dialog box item as a checkbox.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.CheckBox;                
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

#### CheckBoxList

Allows you to define a newly created dialog box item as a list of checkboxes.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.CheckBoxList;            
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

#### DropDown

Allows you to define a newly created dialog box item as a selection box.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.DropDown;                
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

#### FileSelector

Allows you to define a newly created dialog box item as a file selector control. <br>Available from DataMiner 10.0.0/10.0.2 onwards.

Example:

```txt
UIBlockDefinition uiBlock = new UIBlockDefinition();
uiBlock.Type = UIBlockType.FileSelector;            
uiBlock.DestVar = "varUserUploadedFile";            
```

When the UI is then shown using *Engine#ShowUI(...)*, *UIResults* will contain the path to the file:

```txt
UIResults results = engine.ShowUI(uiBuilder);                                
string uploadedFilePath = results.GetUploadedFilePath("varUserUploadedFile");
```

When you have selected a file, the actual upload will only start after you click a button to make the script continue (e.g. *Close*, *Next*, etc.). Once the upload has started, a *Cancel* option will be available.

All files uploaded by users will by default be placed in the *C:\\Skyline DataMiner\\TempDocuments* folder, which is automatically cleared at every DataMiner startup.

> [!TIP]
> See also:
> [GetUploadedFilePath](UIResults_methods.md#getuploadedfilepath)

#### Numeric

Allows you to define a newly created dialog box item displaying a numeric value.

The initial value has to have the following format:

```txt
[DoubleValue];[Boolean];[SelectedDiscreetString]
```

- DoubleValue: Value of the numeric box.

- Boolean: Indicates whether the discrete checkbox is selected (=true) or cleared (=false).

- SelectedDiscreetString: selects the discrete parameter with that exact name in case multiple discrete parameters are defined.

Example:

```txt
string sel_numericValue = "23.567891;true;Discreet 2";
```

If you want a checkbox with one or more discrete values, then use the *Extra* property to specify a list of discrete values (separated by semicolons). If you only want a numeric box and no checkbox, then leave the *Extra* property empty. In that case, just set the initial value to the DoubleValue.

If you set the *WantsOnChange* property to “true”, then both the checkbox and the discrete combo box will trigger a change.

Optionally you can provide a RangeHigh (maximum value), a RangeLow (minimum value), a RangeStep (increment or decrement steps) and the number of decimals.

Full example:

```txt
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
uib.AppendBlock(numericBlock);                           
```

> [!NOTE]
> From DataMiner 9.5.5 onwards, you can specify the WantsOnChange property to have a small delay before a change is triggered by the numeric box itself, in order to avoid updates being sent as soon as a single character is changed in the numeric box. See [WantsOnChange](UIBlockDefinition_properties.md#wantsonchange).

#### Parameter

Allows you to define a newly created dialog box item as a text item displaying the value of a Parameter.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.Parameter;               
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

#### PasswordBox

Allows you to define a password box. Available from DataMiner 9.6.6 onwards.

Example:

```txt
UIBlockDefinition blockPasswordBox = new UIBlockDefinition();
blockPasswordBox.Type = UIBlockType.PasswordBox;             
```

Optionally, you can set the *HasPeekIcon* property to display an icon that, when clicked, will allow you to display the value inside the password box. See [HasPeekIcon](UIBlockDefinition_properties.md#haspeekicon).

#### RadioButtonList

Allows you to define a radio button list. Available from DataMiner 9.6.6 onwards.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.RadioButtonList;         
...                                                   
foreach (string item in radioButtonListItems)         
{                                                     
   blockItem.AddRadioButtonListOption(item);          
}                                                     
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

> [!NOTE]
> If no initial value is passed to this list, no radio button will be selected by default.

#### StaticText

Allows you to define a newly created dialog box item as a text item displaying a piece of fixed text.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.StaticText;              
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

#### TextBox

Allows you to define a newly created dialog box item as a box into which a user can enter a piece of text.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;                 
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

> [!NOTE]
> From DataMiner 9.5.3 onwards, this control can be used with a “WantsOnChange” property, which prevents updates being sent after a single character is changed in a text box. See [WantsOnChange](UIBlockDefinition_properties.md#wantsonchange).

#### Time

Allows you to define a newly created dialog box item as an item displaying a time value.

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.Time;                    
...                                                   
MyDialogBox.AppendBlock(blockItem);                   
```

> [!NOTE]
> From DataMiner 9.5.3 onwards, additional classes are available to define controls to select the date and/or time. See [AutomationConfigOptions class](AutomationConfigOptions_class.md).

#### TreeView

Allows you to define a newly created dialog box item as a tree view. Available from DataMiner 10.0.10 onwards.

To define a tree view control, create a *UIBlockDefinition* of type *TreeView* and add each item of the tree view as a *TreeViewItem* to the *TreeViewItems* property. It is not required to fill in the *InitialValue* or *Value* of the *UIBlockDefinition*, as that value is determined based on the *TreeViewItem* collection.

Optionally, you can enable the *WantsOnChange* option for the tree view control, in which case it will send an update each time the selected state of a *TreeViewItem* changes. See [WantsOnChange](UIBlockDefinition_properties.md#wantsonchange).

To retrieve the results:

- The *UIResult*, which can be returned using *engine.ShowUI()*, contains the *KeyValue* of the selected items.

- The *GetString(UIBlockDefinition destvar)* method to retrieve a semicolon-separated string of the *KeyValues*.

- The *GetChecked(UIBlockDefinition destvar, KeyValue value)* method can be used to check if a specific *KeyValue* was selected.

> [!NOTE]
> Automation scripts with tree view controls are currently only supported in the DataMiner web apps. These are not yet supported in DataMiner Cube.

Example:

```txt
do                                                                                                         
{                                                                                                          
   UIBuilder uib = new UIBuilder();                                                                        
   uib.Title = "Treeview - default";                                                                       
   uib.RequireResponse = true;                                                                             
   uib.RowDefs = "*,*";                                                                                  
   uib.ColumnDefs = "*";                                                                                  
                                                                                                           
   UIBlockDefinition tree = new UIBlockDefinition();                                                       
   tree.Type = UIBlockType.TreeView;                                                                       
   tree.Row = 0;                                                                                           
   tree.Column = 0;                                                                                        
   tree.DestVar = "treevar";                                                                               
   tree.TreeViewItems = new List<TreeViewItem>                                                            
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
   };                                                                                                      
                                                                                                           
   uib.AppendBlock(tree);                                                                                  
                                                                                                           
   UIBlockDefinition next = new UIBlockDefinition();                                                       
   next.Type = UIBlockType.Button;                                                                         
   next.Row = 1;                                                                                           
   next.Column = 0;                                                                                        
   next.Text = "Next";                                                                                     
   next.DestVar = "Next";                                                                                  
   uib.AppendBlock(next);                                                                                  
                                                                                                           
   _treeResults = _engine.ShowUI(uib);                                                                   
} while (!_treeResults.WasButtonPressed("Next"));                                                         
                                                                                                           
ShowResult();                                                                                              
```

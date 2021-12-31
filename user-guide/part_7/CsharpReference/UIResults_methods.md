## UIResults methods

- [GetChecked](#getchecked)

- [GetDateTime](#getdatetime)

- [GetExpanded](#getexpanded)

- [GetString](#getstring)

- [GetUploadedFilePath](#getuploadedfilepath)

- [WasBack](#wasback)

- [WasButtonPressed](#wasbuttonpressed)

- [WasForward](#wasforward)

- [WasOnChange](#wasonchange)

#### GetChecked

Gets a boolean value (i.e. true or false) from the *UIResults* object.

This method can be used to check whether a *CheckBox* item has been selected.

- For a checkbox block, specify the variable name.

- For a checkbox within a checkbox list, specify the variable name and value.

```txt
bool GetChecked(string varname)                                               
bool GetChecked(string varname, string value)
```

Examples:

```txt
UIResults uir = null;                                     
bool isChecked;                                           
UIBlockDefinition blockCheckBox = new UIBlockDefinition();
blockCheckBox.Type = UIBlockType.CheckBox;                
blockCheckBox.DestVar = "checkbox";                       
...                                                       
uib.AppendBlock(blockCheckBox);                           
...                                                       
uir = engine.ShowUI(uib);                                 
isChecked = uir.GetChecked("checkbox");                   
```

```txt
UIBuilder uiBuilder = new UIBuilder();                
...                                                   
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.CheckBoxList;            
blockItem.AddCheckBoxListOption("1","First option");  
blockItem.AddCheckBoxListOption("2","Second option"); 
blockItem.DestVar = "chekBoxList";                    
uiBuilder.AppendBlock(blockItem);                     
...                                                   
var uir = engine.ShowUI(uiBuilder);                   
                                                      
bool selection = uir.GetChecked("chekBoxList", "2");  
```

#### GetDateTime

Gets a date/time value from the *UIResults* object.

This method can be used to retrieve the date/time that was selected in a *Calendar* item.

```txt
DateTime GetDateTime(string varname)
```

> [!NOTE]
> Prior to DataMiner 10.0.12, this method only supports the parsing of datetimes in the format dd/MM/yyyy HH:mm:ss. From DataMiner 10.0.12 onwards, ISO format is supported.

Example:

```txt
UIResults uir = null;                                                  
DateTime selection = DateTime.Now;                                     
...                                                                    
UIBlockDefinition blockCalendar = new UIBlockDefinition();             
blockCalendar.Type = UIBlockType.Calendar;                             
blockCalendar.InitialValue = selection.ToString("dd/MM/yyyy HH:mm:ss");
blockCalendar.DestVar = "calendar";                                    
blockCalendar.WantsOnChange = true;                                    
...                                                                    
uib.AppendBlock(blockCalendar);                                        
...                                                                    
uir = engine.ShowUI(uib);                                              
selection = uir.GetDateTime("calendar");                               
```

#### GetExpanded

Gets the key values of the tree view items that are expanded for the specified key.

This method can be used to check whether a tree view node is collapsed or expanded.

Available from DataMiner 10.2.0/10.1.2 onwards.

```txt
string[] GetExpanded(string key)
```

Example:

```txt
if (_treeResults?.GetExpanded("treevar").Contains(treeViewItem.KeyValue) == true)
{                                                                                 
   treeViewItem.ChildItems = new List<TreeViewItem>                              
   {                                                                              
      // add child items                                                          
   };                                                                             
}                                                                                 
```

#### GetString

Gets a string value from the *UIResults* object.

This method can be used to retrieve e.g. the text that was entered in a *TextBox* item.

```txt
string GetString(string varname)
```

Example:

```txt
UIResults uir = null;                                 
...                                                   
UIBlockDefinition blockItem = new UIBlockDefinition();
blockItem.Type = UIBlockType.TextBox;                 
blockItem.DestVar = "myText";                         
...                                                   
uibDialogBox1.AppendBlock(blockItem);                 
...                                                   
uir = engine.ShowUI(uibDialogBox1);                   
enteredText = uir.GetString("myText");                
```

#### GetUploadedFilePath

Retrieves the selected upload file path. Available from DataMiner 10.0.0/10.0.2 onwards.

When a file has been selected, the actual upload will only start after a button is clicked to make the script continues (e.g. Close, Next, etc.). Once the upload has started, a *Cancel* option will appear, so the upload operation can be aborted.

```txt
string GetUploadedFilePath(string key)
```

Example:

```txt
UIBlockDefinition uiBlock = new UIBlockDefinition();                         
uiBlock.Type = UIBlockType.FileSelector;                                     
uiBlock.DestVar = "varUserUploadedFile";                                     
...                                                                          
UIResults results = engine.ShowUI(uiBuilder);                                
string uploadedFilePath = results.GetUploadedFilePath("varUserUploadedFile");
```

> [!NOTE]
> All files uploaded by users will by default be placed in the *C:\\Skyline DataMiner\\TempDocuments* folder, which is automatically cleared at every DataMiner startup.

> [!TIP]
> See also:
> [FileSelector](UIBlockType_enumeration.md#fileselector)

#### WasBack

Returns a value indicating whether the user clicked the *Back* button.

Only works for scripts that support this feature.

```txt
bool WasBack()
```

> [!NOTE]
> To enable the *Back* and *Forward* buttons, in the *General* section of the script in the Automation module, expand *Show Details* and select *Supports back/forward buttons in interactive mode*.

Example:

```txt
UIBuilder uib = new UIBuilder();   
...                                
UIResults uir = engine.ShowUI(uib);
                                   
if (uir.WasBack())                 
{                                  
    ...                            
}                                  
```

#### WasButtonPressed

Returns a value indicating whether a specific button was clicked.

```txt
bool WasButtonPressed(string varname)
```

Example:

```txt
UIResults uir = null;                                   
do                                                      
{                                                       
    UIBuilder uib = new UIBuilder();                        
    uib.RequireResponse = true;                             
    uib.Width = 800;                                        
    uib.Height = 600;                                       
    uib.RowDefs = "100;100;100";                            
    uib.ColumnDefs="100;100;100";                           
                                                            
    UIBlockDefinition blockButton = new UIBlockDefinition();
    blockButton.Type = UIBlockType.Button;                  
    blockButton.Text = "Go";                                
    blockButton.DestVar = "buttonGo";                       
    blockButton.Row = 0;                                    
    blockButton.Column = 0;                                 
    uib.AppendBlock(blockButton);                           
                                                            
    uir = engine.ShowUI(uib);                               
} while (!uir.WasButtonPressed("buttonGo"));            
```

#### WasForward

Returns a value indicating whether the user clicked the *Forward* button.

Only works for scripts that support this feature.

```txt
bool WasForward()
```

> [!NOTE]
> To enable the *Back* and *Forward* buttons, in the *General* section of the script in the Automation module, expand *Show Details* and select *Supports back/forward buttons in interactive mode*.

Example:

```txt
UIBuilder uib = new UIBuilder();   
...                                
UIResults uir = engine.ShowUI(uib);
                                   
if (uir.WasForward())              
{                                  
    ...                            
}                                  
```

#### WasOnChange

Use this method to check whether or not the user changed the value of a particular dialog box item:

- Did the user enter text in a text box?

- Did the user select a value in a selection box?

- Did the user specify a date/time in a calendar item?

- ...

Usually, this method will be used in combination with a “do ... while” loop.

```txt
bool WasOnChange(string varname)
```

> [!NOTE]
> For a .WasOnChange to work, you have to put .WantsOnChange to true. See the example below.

Example:

```txt
UIResults uir = null;                                     
do                                                        
{                                                         
    UIBuilder uib = new UIBuilder();                          
    uib.RequireResponse = true;                               
    uib.Width = 800;                                          
    uib.Height = 600;                                         
    uib.RowDefs = "100;100;100";                              
    uib.ColumnDefs="100;100;100";                             
                                                              
    UIBlockDefinition blockCheckBox = new UIBlockDefinition();
    blockCheckBox.Type = UIBlockType.CheckBox;                
    blockCheckBox.WantsOnChange = true;                       
    blockCheckBox.DestVar = "myCheckBox";                     
    blockCheckBox.Row = 0;                                    
    blockCheckBox.Column = 0;                                 
    uib.AppendBlock(blockCheckBox);                           
                                                              
    UIBlockDefinition blockButton = new UIBlockDefinition();  
    blockButton.Type = UIBlockType.Button;                    
    blockButton.Text = "Next";                                
    blockButton.DestVar = "buttonNext";                       
    blockButton.Row = 1;                                      
    blockButton.Column = 0;                                   
    uib.AppendBlock(blockButton);                             
                                                              
    uir = engine.ShowUI(uib);                                 
} while (!uir.WasOnChange("myCheckBox"));                 
```

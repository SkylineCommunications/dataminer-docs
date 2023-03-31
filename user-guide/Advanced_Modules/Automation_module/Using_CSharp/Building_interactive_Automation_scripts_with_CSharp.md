---
uid: Building_interactive_Automation_scripts_with_CSharp
---

# Building interactive Automation scripts with C#

In an Automation script, you can define custom-made dialog boxes in C# code blocks. When the script is run, those dialog boxes can then either ask the user to provide input or display some status information or error message.

In DataMiner Cube, it is also possible to add these dialog boxes using the script action *User interaction*. For more information, see [User interaction](xref:User_interaction).

> [!NOTE]
>
> - For detailed information on the classes, methods and properties that can be used in C# code blocks of Automation scripts, see [Skyline.DataMiner.Automation](xref:Skyline.DataMiner.Automation).
> - For more information on how to abort an interactive Automation script, see [How do I abort a running Automation script?](xref:How_do_I_abort_a_running_Automation_script)
> - For a high-level API to build interactive Automation scripts, see [Interactive Automation Script Toolkit](xref:Interactive_Automation_Script_Toolkit).

## Example of a dialog box displaying information

The following code first creates and then displays a simple dialog box that shows the text “Hello World!” and stays open until you click the *Close* button.

Notice that the programmer defined a number of columns and rows. This forms a grid onto which all dialog box items (i.e. controls) are positioned:

- The “static text” item displaying the text “Hello World!” is positioned on row 0, column 0.

- The button is positioned on row 2, column 0.

Also notice that a height and a width have been defined for every dialog box item, and that the row heights and column widths have been set to “a” (i.e. automatic) instead of to a specific number of pixels. That way, the rows and columns will automatically be resized according to the size of the dialog box items.

```cs
// Create the dialog box
UIBuilder uib = new UIBuilder();

// Configure the dialog box
uib.RequireResponse = true;
uib.RowDefs = "a;a;a";
uib.ColumnDefs="a;a;a";

// Add a 'StaticText' item to the dialog box
UIBlockDefinition blockStaticText = new UIBlockDefinition();
blockStaticText.Type = UIBlockType.StaticText;
blockStaticText.Text = "Hello World!";
blockStaticText.Height = 50;
blockStaticText.Width = 200;
blockStaticText.Row = 0;
blockStaticText.Column = 0;
uib.AppendBlock(blockStaticText);

// Add a button to the dialog box
UIBlockDefinition blockButton = new UIBlockDefinition();
blockButton.Type = UIBlockType.Button;
blockButton.Text = "Close";
blockButton.Height = 20;
blockButton.Width = 75;
blockButton.Row = 2;
blockButton.Column = 0;
uib.AppendBlock(blockButton);

// Display the dialog box
engine.ShowUI(uib);
```

## Example of a dialog box asking to enter information

The following code displays a simple dialog box that shows a checkbox list. When you select one of the options in the list and you click *Next*, another dialog box will appear, showing the text of the option you selected.

```cs
// ------------------------ SCREEN 1 -----------------------------

UIResults uir = null;
string selection = "";

UIBuilder uib = new UIBuilder();
uib.RequireResponse = true;
uib.RowDefs = "50;*;*";
uib.ColumnDefs="50;*;*";

UIBlockDefinition blockCheckBoxList = new UIBlockDefinition();
blockCheckBoxList.Type = UIBlockType.CheckBoxList;
blockCheckBoxList.AddCheckBoxListOption("Option 1");
blockCheckBoxList.AddCheckBoxListOption("Option 2");
blockCheckBoxList.DestVar = "selectionDest";
blockCheckBoxList.WantsOnChange = false;
blockCheckBoxList.Height = 100;
blockCheckBoxList.Width = 100;
blockCheckBoxList.Row = 1;
blockCheckBoxList.Column = 1;
uib.AppendBlock(blockCheckBoxList);

// Add a button to the dialog box
UIBlockDefinition blockButtonNext = new UIBlockDefinition();
blockButtonNext.Type = UIBlockType.Button;
blockButtonNext.Text = "Next";
blockButtonNext.Height = 50;
blockButtonNext.Width = 100;
blockButtonNext.Row = 2;
blockButtonNext.Column = 1;
uib.AppendBlock(blockButtonNext);

uir = engine.ShowUI(uib);
selection = uir.GetString("selectionDest");
// ------------------------ SCREEN 2 -------------------------------
// Create the dialog box
UIBuilder uib2 = new UIBuilder();

// Configure the dialog box
uib2.RequireResponse = true;
uib2.RowDefs = "50;*;*";
uib2.ColumnDefs="50;*;*";

// Add a 'StaticText' item to the dialog box
UIBlockDefinition blockStaticText = new UIBlockDefinition();
blockStaticText.Type = UIBlockType.StaticText;
blockStaticText.Text = "You chose " + selection;
blockStaticText.Row = 1;
blockStaticText.Column = 1;
blockStaticText.Height = 50;
blockStaticText.Width = 200;
uib2.AppendBlock(blockStaticText);

// Add a button to the dialog box
UIBlockDefinition blockButtonClose = new UIBlockDefinition();
blockButtonClose.Type = UIBlockType.Button;
blockButtonClose.Text = "Close";
blockButtonClose.Row = 2;
blockButtonClose.Column = 1;
blockButtonClose.Height = 50;
blockButtonClose.Width = 200;
uib2.AppendBlock(blockButtonClose);

// Display the dialog box
engine.ShowUI(uib2);
```

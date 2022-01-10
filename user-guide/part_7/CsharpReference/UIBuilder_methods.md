## UIBuilder methods

- [Append](#append)

- [AppendBlock](#appendblock)

- [AppendButton](#appendbutton)

- [AppendDropDown](#appenddropdown)

- [AppendLine](#appendline)

- [AppendParameter](#appendparameter)

- [AppendTextBox](#appendtextbox)

- [ToString](#tostring)

#### Append

Adds text to the dialog box (either a text string or a composite format string).

```txt
UIBuilder Append(string text)
UIBuilder Append(string format, params object[] args)
```

Examples:

```txt
UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.Append("Select a ticket:");
```

```txt
int selectedTicketId = 1;
UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.Append("The ID of the selected ticket is {0}", selectedTicketId);
```

#### AppendBlock

Adds the specified *UIBlockDefinition* instance to the dialog box.

```txt
UIBuilder AppendBlock(UIBlockDefinition block)
```

Example:

```txt
UIBuilder uibDialogBox1 = new UIBuilder();
// ...
UIBlockDefinition blockTextBox = new UIBlockDefinition();
// ...
uibDialogBox1.AppendBlock(blockTextBox);
```

#### AppendButton

Adds a button to the dialog box by providing two arguments:

- the name of the destination variable

- the button text

When the button is pressed, the variable is filled with its own name.

This is a convenience method that will create a new instance of *UIBlockDefinition* of type *Button* and set *RequireResponse* to true. (See [RequireResponse](UIBuilder_properties.md#requireresponse).)

```txt
UIBuilder AppendButton(string varname, string text)
```

Example:

```txt
UIBuilder uibDialogBox1 = new UIBuilder();
// ...
uiBuilder.AppendButton("applyButtonDestVar", "Apply");
// ...
var uir = engine.ShowUI(uiBuilder);
string value = uir.GetString("applyButtonDestVar"); // If the button was pressed, the value will be "applyButtonDestVar"; otherwise, null.
```

#### AppendDropDown

Adds a drop-down box to the dialog box by providing two arguments:

- the name of the destination variable (into which to store the result)

- the list of available options, using the format *value\|displayvalue*

This is a convenience method that will create a new instance of *UIBlockDefinition* of type *Dropdown* and set *RequireResponse* to true. (See [RequireResponse](UIBuilder_properties.md#requireresponse).)

```txt
UIBuilder AppendDropDown(string varname, string[] options)
```

Example:

```txt
UIBuilder uibDialogBox1 = new UIBuilder();

uiBuilder.AppendDropDown("selectionVar", "1|Automatic", "2|Semi-automatic", "3|Manual");

var uir = engine.ShowUI(uiBuilder);
string result = uir.GetString("selectionVar");
engine.GenerateInformation("selectionVar: " + result); // In case "Semi-automatic" was selected, selectionVar will contain "2".
```

#### AppendLine

Adds a line of text to the dialog box (a new empty line, a specified line of text, or a specified composite format string).

```txt
UIBuilder AppendLine()
UIBuilder AppendLine(string text)
UIBuilder AppendLine(string format, params object[] args)
```

Examples:

```txt
UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.AppendLine();
// ...
```

```txt
UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.AppendLine("Select a ticket:");
```

```txt
int selectedTicketId = 1;
UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.AppendLine("The ID of the selected ticket is {0}", selectedTicketId);
```

#### AppendParameter

Adds the display value of a parameter to the dialog box by providing the following arguments:

- the element

- the parameter to be displayed

- for a table parameter, the index

```txt
UIBuilder AppendParameter(Element element, int pid)
UIBuilder AppendParameter(Element element, int pid, string idx)
UIBuilder AppendParameter(int dmaid, int eid, int pid)
UIBuilder AppendParameter(int dmaid, int eid, int pid, string idx)
```

Examples:

```txt
Element element = engine.FindElement(200, 4000);

UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.AppendParameter(element, 1000);
```

```txt
Element element = engine.FindElement(200, 4000);

UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.AppendParameter(element, 1002, "Row 1");
```

```txt
UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.AppendParameter(200, 4000, 1000);
```

```txt
UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.AppendParameter(200, 4000, 1002, "Row 1");
```

#### AppendTextBox

Adds a text box to the dialog box by providing the following argument:

- the name of the destination variable (into which to store the result)

```txt
UIBuilder AppendTextBox(string varname)
```

Example:

```txt
UIBuilder uiBuilder = new UIBuilder();
// ...
uiBuilder.AppendTextBox("input");
```

#### ToString

Gets a string representation of this dialog box.

```txt
string ToString()
```

Example:

```txt
UIBuilder uiBuilder = new UIBuilder();
uiBuilder.MinHeight = 450;
uiBuilder.MinWidth = 400;
uiBuilder.RequireResponse = true;
uiBuilder.ColumnDefs = "a;";

uiBuilder.Append("Input: ");
uiBuilder.AppendTextBox("input");

string result = uiBuilder.ToString();
// result:
// [UI]
// type=global
// min-width=400
// min-height=450
// grid-column-defs=a;
// [/UI][UI]
// type=static
// range-low=NaN
// range-high=NaN
// range-step=NaN
// text = Input:
// [/UI][UI]
// type=textbox
// range-low=NaN
// range-high=NaN
// range-step=NaN
// destvar = input
// [/ UI]
```

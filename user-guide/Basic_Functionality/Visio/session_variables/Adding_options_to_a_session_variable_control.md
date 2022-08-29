---
uid: Adding_options_to_a_session_variable_control
---

# Adding options to a session variable control

If you turned a shape into a control that allows users to update a session variable, you can add a shape data field of type **SetVarOptions** to that same shape to apply options such as:

- Validation against a list of forbidden values.
- Ensuring the session variable can only be updated via the shape.
- Turning the shape into a datetime control, a list box control, a list of profile instances, a multiple checkbox control, a search box, or a tree control.

> [!TIP]
> See also:
>
> - [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)
> - [Initializing a session variable](xref:Initializing_a_session_variable)
> - [Making a shape display the current value of a variable](xref:Making_a_shape_display_the_current_value_of_a_variable)

> [!TIP]
> For examples, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > VARIABLE1 and VARIABLE2]* pages.

## Configuring the shape data field

Add a shape data field of type **SetVarOptions** to the shape, and set its value depending on which of the following options you want to configure:

- **Text box with input validation**:

  ```txt
  ExistingValuesValidation=DmaID/ElementID,PID
  ```

  The value you enter in the **SetVar** text box will be validated against the list of possible values stored in the specified parameter of the specified element. See [Creating a text box with input validation](#creating-a-text-box-with-input-validation).

  ```txt
  ValidationText=xxx
  ```

  The default validation error message will be replaced by the message you specified. See [Creating a text box with input validation](#creating-a-text-box-with-input-validation).

- **Combo box control**:

  ```txt
  Control=ComboBox
  ```

  The **SetVar** text box will be turned into a combo box control. See [Creating a combo box control](#creating-a-combo-box-control).

- **Filtered combo box control:**

  ```txt
  Control=FilterComboBox
  ```

  The **SetVar** text box will be turned into a combo box control with search box, to allow easy filtering. Available from DataMiner 10.0.3 onwards. See [Creating a filtered combo box control](#creating-a-filtered-combo-box-control).

- **DateTime control**:

  ```txt
  Control=DateTime|ShortTime
  ```

  The **SetVar** text box will be turned into a datetime control. See [Creating a DateTime control](#creating-a-datetime-control).

- **List box control**:

  ```txt
  Control=ListBox|DisplayColumn=COLPID|SetColumn=COLPID|FKColumn=FKCOLPID| Filter=[...]
  ```

  The **SetVar** text box will be turned into a list box control. See [Creating a list box control](#creating-a-list-box-control) or [Creating a list of profile instances](#creating-a-list-of-profile-instances).

- **Multiple checkbox control**:

  ```txt
  Control=MultiCheckBoxHorizontal
  Control=MultiCheckBoxVertical
  ```

  The **SetVar** text box will be turned into a multiple checkbox control. See [Creating a multiple checkbox control](#creating-a-multiple-checkbox-control).

- **Search box**:

  ```txt
  Control=SearchTextBox|TextBoxInfo=Enter a search string
  ```

  The **SetVar** text box will be turned into a search box containing the watermark text "Enter a search string".

- **Control displayed as a custom Visio shape**:

  From DataMiner 9.0.5 onwards, by default the SetVar shape is shown as a basic button shape, even if a custom shape is configured in Visio. To revert to the legacy behavior and show the custom shape, add the following option in the **SetVarOptions** shape data field:

  ```txt
  Control=Shape
  ```

- **Tree control**:

  ```txt
  VariableName:ElementID:TableID:TableID:...
  ```

  The **SetVar** text box will be turned into a tree control. See [Creating a tree control](#creating-a-tree-control).

- **Control that does not update the variable when the source is updated:**

  From DataMiner 9.5.6 onwards, by default all SetVar shapes are updated when their source is updated (e.g. the session variable is cleared when an item is selected in a list box and the corresponding row is deleted from the source table). However, you can prevent this by specifying the following **SetVarOptions** value:

  ```txt
  DisableSetOnSourceUpdate
  ```

- **Unique variable update control:**

  ```txt
  OneWayToVariable
  ```

  If this option is added to the shape, it will not be possible to update the session variable in any other way except via the shape. This option can be used when, for example, you want to prevent that a session variable is updated by a QAction.

- **Control to set a duration:**

  From DataMiner 10.3.0/10.2.4 onwards, a SetVar shape can be configured to set a duration in a session variable. See [Creating a control to set a duration in a session variable](#creating-a-control-to-set-a-duration-in-a-session-variable).

  ```txt
  Control=Duration
  ```

## Creating a text box with input validation

If, in a shape data field of type **SetVar**, you specify a session variable without a value, then the shape turns into a text box that allows the user to enter a value.

If you want to have the contents of such a text box validated against a list of forbidden values, add an additional shape data field of type **SetVarOptions**, and make sure its value matches the following syntax:

```txt
ExistingValuesValidation=DmaID/ElementID,PID
```

- If the Visio drawing is linked to a protocol, "DmaID/ElementID" can be replaced by "\*".
- "PID" has to refer to either a table or a table column.

  - In case of a table, the forbidden values will be the values in the table's displaykey column.
  - In case of a table column, the forbidden values will be the values in the specified column.

> [!NOTE]
> A **SetVar** textbox updates the associated session variable using a "textchanged" event. This means that values are validated on the fly while the user is typing.

### Error message

If users enter a forbidden value, by default, they get the error message `The value you entered, already exists.` If you want to customize that message, add a "ValidationText" statement to the **SetVarOptions** field:

```txt
ValidationText=My special error text
```

### Combining ExistingValuesValidation and ValidationText

An "ExistingValuesValidation" statement and a "ValidationText" statement can be combined by means of a pipe character ("\|").

If you enter the following value in a **SetVarOptions** field, the forbidden values will be those found in parameter 104 of element 111/10, and the error message will be `Incorrect value`:

```txt
ExistingValuesValidation=111/10,104|ValidationText=Incorrect value
```

## Creating a combo box control

To turn a **SetVar** box into a combo box control:

1. Add an additional shape data field of type **SetVarOptions**, and set its value to "Control=ComboBox".

1. In the shape data field of type **SetVar**, you can then

   - Specify a list of fixed values, or

   - Refer to a table parameter containing a number of values (optionally using dynamic placeholders).

     By default, the primary key of a row is used as set value and the display key is used to display that value in the combo box. From DataMiner 9.5.0/9.5.3 onwards, by default, the list of values is sorted by the display column. In previous versions of DataMiner, it is sorted by the primary key.

1. In the **SetVarOptions** shape data field, you can then use the following options to override the default behavior, using a pipe character ("\|") as separator:

   - *DisplayColumn=\[Column parameter ID\]*: Show the value of this column and set the session variable to this value when it is selected in the combo box.
   - *SetColumn=\[Column parameter ID\]*: Set the value of the session variable to the value of this column. This overrides the DisplayColumn option as far as the set value is concerned.
   - *SortColumn=\[Column parameter ID\]*: Sorts the items in the combo box by the values of this column

For example:

| Shape data field | Value                                      |
| ---------------- | ------------------------------------------ |
| SetVar           | RecursiveVar:\[param:\[Var:Element\],101\] |
| SetVarOptions    | Control=ComboBox                           |

## Creating a filtered combo box control

To turn a **SetVar** box into a combo box control with a search box, which allows faster filtering than a regular combo box control:

1. Add an additional shape data field of type **SetVarOptions**, and set its value to "Control=FilterComboBox".
1. In the shape data field of type **SetVar**, specify a list of fixed values or refer to a table parameter containing a number of values (optionally using dynamic placeholders). This is the same as for a regular combo box control.
1. In the **SetVarOptions** shape data field, you can use additional options to override the default behavior, using a pipe character ("\|") as separator, in the same way as for a regular combo box control. See [Creating a combo box control](#creating-a-combo-box-control).

For example:

| Shape data field | Value                                             |
| ---------------- | ------------------------------------------------- |
| SetVar           | \[Sep::;\]MySessionVariable;\[Param:25/1245,568\] |
| SetVarOptions    | Control=FilterComboBox                            |

## Creating a DateTime control

If, in a shape data field of type **SetVar**, you specify a session variable without a value, the shape becomes a text box that allows the user to enter a value. If you want to turn a **SetVar** box into a datetime control, add an additional shape data field of type **SetVarOptions**, and set its value to "Control=DateTime" or "Control=DateTime\|ShortTime".

| Value                       | DateTime format     |
| --------------------------- | ------------------- |
| Control=DateTime            | mm/dd/yyyy hh:mm:ss |
| Control=DateTime\|ShortTime | mm/dd/yyyy hh:mm    |

From DataMiner 10.2.0/10.1.8 onwards, you can also define the culture that should be used for the datetime, by adding "DateTimeCulture=", followed by "Current" or "Invariant". The latter is the default value. For example:

| Shape data field | Value                                     |
| ---------------- | ----------------------------------------- |
| SetVarOptions    | Control=DateTime\|DateTimeCulture=Current |

## Creating a list box control

If you want to turn a **SetVar** box into a list box control, add an additional shape data field of type **SetVarOptions**, and set its value to "Control=ListBox".

> [!NOTE]
> Session variable list boxes have a filter box that allows you to narrow down the values.

### Populating a list box control

A list box can be populated in two ways. In the shape data field of type **SetVar**, you can

- Specify a list of fixed values, or
- Refer to a table parameter containing a number of values.

  By default, the primary key of a row is used as set value and the display key is used to display that value in the list box. From DataMiner 9.5.0/9.5.3 onwards, by default, the list is sorted by the display column. In previous versions of DataMiner, it is sorted by the primary key.

  The following options are available to override the default behavior:

  - *DisplayColumn=\[Column parameter ID\]*: Show the value of this column and set the session variable to this value when it is selected in the list box.
  - *SetColumn=\[Column parameter ID\]*: Set the value of the session variable to the value of this column. This overrides the DisplayColumn option as far as the set value is concerned.
  - *SortColumn=\[Column parameter ID\]*: Sorts the items in the list box by the values of this column

### Linking two list box controls

It is possible to link two list boxes. That way, when you select an item in the first list box, you will filter the values displayed in the second list box.

In the second list box, use the SetVarOption "FKColumn" to define a foreign key relationship between the two datasets. In that option, specify the column in the second list box that contains the foreign keys that link to the first list box.

First listbox shape:

| Shape data field | Value                                         |
| ---------------- | --------------------------------------------- |
| SetVar           | FilterVariable;\[Param:dmaid/elementid,1000\] |
| SetVarOptions    | Control=ListBox\|displaycolumn=1002           |

Second listbox shape:

| Shape data field | Value                                                                             |
| ---------------- | --------------------------------------------------------------------------------- |
| SetVar           | MyVarName;\[Param:dmaid/elementid,2000\]                                          |
| SetVarOptions    | Control=ListBox\|displaycolumn=2003\|FKColumn=2004\|Filter=\[var:FilterVariable\] |

In the "FKColumn" option, specify the parameter ID of the column that contains the foreign keys. In the example above, column 2004 of the table with parameter ID 2000 will contain references to primary keys of table 1000.

In the "Filter" option, you can indicate that the list has to be filtered. In the example above, the list will be filtered by foreign key value, based on the value of the session variable that was set in the "FilterVariable" by the first listbox shape.

> [!NOTE]
> In the "Filter" option, you can also use parameter values, property values or a combination of both (\[Param:...\], \[property:...\], etc.).

## Creating a list of profile instances

If profile instances have been defined in Cube, the list box control can also be used to display a list of profile instances based on the same base instance, so that these can be linked to a session variable.

To create such a control, configure the **SetVar** and SetVarOptions shape data fields as follows:

| Shape data field | Value                                                                                            |
| ---------------- | ------------------------------------------------------------------------------------------------ |
| SetVar           | *xxx:\[profile:yyy\]*<br>- xxx = name of a session variable<br>- yyy = name of the base instance |
| SetVarOptions    | *Control=ListBox*                                                                                |

> [!TIP]
> See also: [The Profiles module](xref:The_Profiles_module)

## Creating a multiple checkbox control

If you want to turn a **SetVar** box into a multiple checkbox control, add an additional shape data field of type **SetVarOptions**, and set its value to "Control=MultiCheckBoxHorizontal" or "Control=MultiCheckBoxVertical".

In this case, the value of the shape data field of type **SetVar** has to refer to a table of which the display key column contains the checkbox labels to be shown:

```txt
VariableName:[Param:dmaid/elementId,pid]
```

The session variable will contain the names of the selected checkboxes, separated by pipe characters. When, for example, checkbox 1, 2 and 4 are selected, the session variable will contain the value "Checkbox1\|Checkbox2\|Checkbox4". If you want to use another separator, add a shape data field of type **SetVarOptions** to the shape and set its value to "MultipleValueSep=", followed by the character of your choice:

```txt
MultipleValueSep=;
```

> [!NOTE]
> Up to DataMiner 9.5.1, only a single character can be specified as a separator after "MultipleValueSep". From DataMiner 9.5.2 onwards, you can also specify separators that consist of multiple characters. E.g.: "MultipleValueSep=-AND-"

By default, when no checkboxes are selected, the value of the session variable will be empty. If, however, you want the session variable to have a fixed value in case none of the checkboxes are selected, then add a shape data field of type **SetVarOptions** to the shape and set its value to "EmptyValue=", followed by the value of your choice:

```txt
EmptyValue=0
```

Using a shape data field of type InitVar you can choose to have the session variable initialized when the Visio page is first opened. However, you can also use the SetVarOption "InitVarWithFirstSelection" to have the session variable set to the first checkbox value in the series the moment the checkbox data is retrieved:

```txt
InitVarWithFirstSelection
```

If you want the checkboxes to be selected by default, use the SetVarOption "InitNewCheckBoxChecked".

```txt
InitNewCheckBoxChecked
```

> [!NOTE]
> In DataMiner Cube, from version 9.5.1 onwards, right-clicking a multiple checkbox control displays a context menu that allows you to select or deselect all checkboxes, or invert the current selection.

From DataMiner 9.5.0/9.5.3 onwards, by default, the checkboxes are sorted by the display key. To override this default order, use the SetVarOption "SortColumn=\[Column parameter ID\]".

For example:

| Shape data field | Value                                          |
| ---------------- | ---------------------------------------------- |
| SetVarOptions    | control=MultiCheckBoxVertical\|SortColumn=1001 |

## Creating a tree control

You can update a session variable by means of a shape turned into a tree control with a search box above it and a status line below it.

To turn a shape into a tree control:

1. Add a shape data field of type **SetVar** to the shape. As the value of this shape data field, specify the name of the session variable, followed by the list of tables that will populate the tree control. If you specify multiple tables, make sure there are foreign key relationships between them.

   Syntax of the SetVar value:

   ```txt
   VariableName:ElementID:TableID:TableID:...
   ```

1. Add a shape data field of **SetVarOptions** to the shape. As the value of this shape data field, specify "Control=TreeView", optionally followed by a number of options, separated by pipe characters ("\|").

   The following options can be used:

   | SetVarOption | Description |
   | ------------ | ----------- |
   | DisplayColumn | The ID of the column to be used for the tree item. Default: Primary key. |
   | IconColumn | The ID of the column that contains the icon to be shown in front of the tree item.<br>Note: All icons must have a height of exactly 16 px. |
   | MultipleValueSep | The session variable will contain the names of the selected tree items, separated by pipe characters. When, for example, tree items 1, 2 and 4 are selected, the session variable will contain the value "X\|Y\|Z" (note: X, Y, Z depending on the above-mentioned *SetColumn* setting). If you want to use another separator, add a shape data field of type **SetVarOptions** to the shape and set its value to "MultipleValueSep=", followed by the character of your choice.<br>Note that from DataMiner 9.5.2 onwards, you can also specify a separator consisting of multiple characters, e.g. "MultipleValueSep=-AND-". |
   | SetColumn | The ID of the column of which the value will be assigned to the session variable. |
   | SingleSelectionMode | Specify this option if users are only allowed to select one single item in the tree control. By default, users are allowed to select multiple items. |
   | SortColumn | Specify this option to configure the way items are sorted in the tree control. If you set the value to "SortColumn=*ParameterId*,*ParameterId*,...", each tree level will sort its items based on the values of the specified column. If no sorting column is specified, the items are sorted based on the display value. String values are sorted using natural sorting. |
   | ViewColumn | One or more column IDs, separated by commas, referring to columns with view names in the table containing the tree items to be shown. For example: "ViewColumn=2011,3011"<br>If the indicated columns contain a view for a particular tree item, that tree item will only be visible for users with permission to access that view. Tree items of which the view columns are empty will be visible to all users. |
   | VisibilityColumn | The ID of the column that will determine whether the item is shown in the tree control. If this column contains "1", then the item will be shown.<br>Note: VisibilityColumn may refer to a parameter of type "discreet". |
   | VisibilityConditionColumn= | Available from DataMiner 9.0.5 onwards. Allows you to use the value of a column in a condition. If the condition is true, the tree item is shown, otherwise it is hidden. If a tree control is populated by multiple tables, you can configure a condition for each of those tables.<br>Supported operators: ==, !=, \>, \>=, \<, \<=<br>For columns of type String only the "==" and "!=" operators can be used.<br>For examples, see [Examples of SetVarOptions using conditions](#examples-of-setvaroptions-using-conditions). |

   > [!NOTE]
   > The border and background of the tree control can be configured by setting the border and background of the shape.

1. From DataMiner 10.0.5 onwards, if you want to use one or more subscription filters, add the **SubscriptionFilter** shape data field. Set this field to one or more filters, separated by pipe characters, to apply these to the table(s) specified in the **SetVar** shape data field. See [Example of tree control with subscription filters](#example-of-tree-control-with-subscription-filters).

1. If you want to customize the status line, then draw an extra shape and add a shape data field to it of type **SetVarOptions**.

   - If you want that shape to only display the number of selected tree items, then set the value to:

     ```txt
     SelectedCount
     ```

   - If you want that shape to display information depending on what has been selected in the tree, then set the value as shown in the following example:

     ```txt
     SelectedInfoFormatCountIsNull=Nothing selected| SelectedInfoFormatCountIsOne=One item selected| SelectedInfoFormatCountIsMultiple= Multiple ({0}) items selected| SelectedCount
     ```

### Examples

| Shape data field | Value                                                                                 |
| ---------------- | ------------------------------------------------------------------------------------- |
| SetVar           | Tree2:219/346:1000:3000:5000:7000                                                     |
| SetVarOptions    | Control=TreeView\|DisplayColumn=1002,5002,7002\|VisibilityColumn=5004\|SetColumn=7003 |

| Shape data field | Value                            |
| ---------------- | -------------------------------- |
| SetVar           | Tree2:219/125:101                |
| SetVarOptions    | Control=TreeView\|IconColumn=120 |

### Examples of SetVarOptions using conditions

| Shape data field | Value                                                                  |
| ---------------- | ---------------------------------------------------------------------- |
| SetVarOptions    | Control=TreeView\|VisibilityConditionColumn=3==my value                |
| SetVarOptions    | Control=TreeView\|VisibilityConditionColumn=402==\[thisusersfullname\] |
| SetVarOptions    | Control=TreeView\|VisibilityConditionColumn=510>=4                     |

### Example of tree control with subscription filters

In the following example, the first subscription filter ("value=101 == 1") will be used when subscribing to the first table (with ID 100) and the second subscription filter ("value=201 == A") will be used when subscribing to the second table (with ID 200).

| Shape data field   | Value                            |
| ------------------ | -------------------------------- |
| SetVar             | MyVar:\[this elementID\]:100:200 |
| SetVarOptions      | Control=TreeView                 |
| SubscriptionFilter | value=101 == 1\|value=201 == A   |

## Creating a control to set a duration in a session variable

From DataMiner 10.3.0/10.2.4 onwards, you can configure a SetVar shape to set a duration of type TimeSpan in a session variable.

To do so:

1. Add a shape data field of type **SetVar** to the shape. As the value of this shape data field, specify the name of the session variable.

1. Add a shape data field of type **SetVarOptions** to the shape. As the value of this shape data field, specify `Control=Duration`, optionally followed by a number of options, separated by pipe characters ("\|").

   The following options can be used:

   | SetVarOption | Description |
   | ------------ | ----------- |
   | ShowInfinity=true/false | When this option is set to true, next to the duration selector, a checkbox is displayed that can be used to set the duration to infinity, which will replace the value of the session variable with TimeSpan.MaxValue. Default: False. |
   | Minimum= | The minimum duration. Default: 1 minute. |
   | Maximum= | The maximum duration. Default: 1 week. |

   To specify the duration, you can use the following units:

   | Unit    | Description                                                                            | Example |
   | ------- | -------------------------------------------------------------------------------------- | ------- |
   | No unit | If no unit is specified, the specified number<br>is considered to be a number of days. | 1       |
   | s       | seconds                                                                                | 1s      |
   | m       | minutes                                                                                | 1m      |
   | h       | hours                                                                                  | 1h      |
   | d       | days                                                                                   | 1d      |
   | mo      | months (1 month = 30 days)                                                             | 1mo     |
   | y       | years (1 year = 365 days)                                                              | 1y      |

   For example:

   | Shape data field | Value                                                       |
   | ---------------- | ----------------------------------------------------------- |
   | SetVarOptions    | Control=Duration\|minimum=5\|maximum=25\|showInfinity=false |

> [!NOTE]
> A page-level **InitVar** shape data field can be used to set the initial value of the duration in the session variable. To set the maximum time span value, InitVar can be set to "Infinity". See [Initializing a session variable](xref:Initializing_a_session_variable).

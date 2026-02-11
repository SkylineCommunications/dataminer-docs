---
uid: Protocol.Params.Param.Measurement.Discreets.Discreet-options
---

# options attribute

Specifies the options to be used.

## Content Type

string

## Parent

[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)

## Remarks

The following options are available:

### confirm:abc

<!-- RN 7360 -->

Used with ContextMenu: Displays an OK/Cancel confirmation box showing the message "abc" (case insensitive) before triggering a ContextMenu item.

Use this option to prevent accidental impacting actions such as, for example, deletion of selected rows.

### disabled=

When this option is added to a column parameter of type button, the button will be disabled according to the value of a specific parameter.

In the following example, the button "Online" will be enabled on all values of parameter 25000 except for values "1", "2", "3" or "Not Initialized" (empty value):

```xml
<Discreet options=";disabled=25000,1,2,3,\empty">
    <Display>Online</Display>
    <Value>1</Value>
</Discreet>
```

> [!NOTE]
> The escape character "\\" is needed to be able to assess an empty value.

### enabled

When this option is added to a column parameter of type button, the button will be enabled according to the value of a specific parameter.

In the following example, the button "Online" will be disabled on all values of parameter 25000 except for values "1", "2", "3" or "Not Initialized" (empty value):

```xml
<Discreet options=";enabled=25000,1,2,3,\empty">
    <Display>Online</Display>
    <Value>1</Value>
</Discreet>
```

> [!NOTE]
> The escape character "\\" is needed to be able to assess an empty value.

### level=X

<!-- RN 7360 -->

Used with ContextMenu: Only show the menu item if the user has access level X or higher (access levels run from 5 to 1, 1 being the highest level).

Note that this always has to be the first option in the list:

```xml
<Discreet options="level=5;...">
```

### rowTextColor=#RRGGBB

Use this option to link a particular color to a value of a discreet parameter. If that parameter is associated with a table column that controls the row color, selecting a discreet value will mean selecting the color linked to that value.

See also: [rowTextColoring](xref:ColumnOptionOptionsOverview#rowtextcoloring)

### script:...

<!-- RN 7360 -->

Used with ContextMenu: This will execute an (interactive) Automation script instead of triggering a QAction. The script command syntax is identical to the syntax used in Visio shape data fields of type "Execute". For more information about the syntax, refer to [Linking a shape to an automation script](xref:Linking_a_shape_to_an_Automation_script).

This type of menu items do not require a row selection. In other words, they also work in case of an empty table.

Note that this always has to be the last option in the list as the option separator ";" is also used to separate parameters and dummies inside the script:... syntax.

You can use the following placeholders:

- [this element] to use the current element as dummy.
- [value:XXX] to specify parameter IDs of columns of the selected row to be used as values for script parameters.

```xml
<Discreet options="script:MyTableScript|d1=[this element]|p1=[value:1001];p2=[value:1002]|||NoConfirmation">
    <Display>Start script</Display>
    <Value>script1</Value>
</Discreet>
```

### separator

Used with ContextMenu: This displays a separator line between menu items.

```xml
<Discreet options="separator">
   <Display>Separator 1</Display>
   <Value>-1</Value>
</Discreet>
```

### severity=...

(Used in EPM interface.) Using this option, you can specify the color of the cell that displays the parameter when the parameter value equals this discrete entry.

The value to be specified is a number from the slenumvalues. (For more information, refer to [Structure of the offload database](xref:Structure_of_the_offload_database).)

Example:

```xml
<Discreet options="Severity=28"><!-- 28: Notice-->
    <Display>Join</Display>
    <Value>1</Value>
</Discreet>
```

### table:selection

<!-- RN 7360 -->

Used with ContextMenu: This action will only be available if the user has selected one or more rows in the table. The table index of each row will be passed to the QAction.

This option can be combined with the dependencyValues attribute. See the following example:

```xml
<Discreet options="table:selection" dependencyValues="1002:[value:1002];1003:[value:1003]">
   <Display>Delete selected row(s)...</Display>
   <Value>delete</Value>
</Discreet>
```

### table:singleselection

<!-- RN 7360 -->

Used with ContextMenu: This action will only be available if the user has selected one single row in the table.
The table index of the row will be passed to the QAction.

This option can be combined with the dependencyValues attribute.
